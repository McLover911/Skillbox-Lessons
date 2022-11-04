using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Collections.Generic;
using Telegram.Bot.Types.InputFiles;
using Newtonsoft.Json;
using File = System.IO.File;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace TelegramBotExperiments
{
    class Program
    {
        static string token = @"token.txt";
        static ITelegramBotClient bot = new TelegramBotClient(File.ReadAllText(token));

        static Dictionary<int, string> fileIDs = new Dictionary<int, string>();

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // переменные
            string savePath = @"Save\";
            string downloadPath = @"Download\";
            string usernameAndText = $"{update.Message.From.Username}\n{update.Message.Text}\n\n";
            string creationDate = Convert.ToString(DateTime.Now).Replace(':', '-').Replace(' ', '_');
            string[] messageSubstrings;

            Message message = update.Message;
            long chatId = update.Message.Chat.Id;

            if (update.Type == UpdateType.Message)
            {
                // обработка текстовых сообщений
                switch (update.Message.Text)
                {
                    case "/start":
                        await botClient.SendTextMessageAsync(message.Chat, "Начало работы");
                        break;

                    case "/getfiles":
                        await botClient.SendTextMessageAsync(message.Chat, "Список файлов:");

                        DirectoryInfo directory = new DirectoryInfo(savePath);
                        FileInfo[] files = directory.GetFiles();
                        int fileNum = 0;

                        foreach (FileInfo file in files)
                        {
                            FileStream fs = System.IO.File.OpenRead(file.FullName);
                            InputOnlineFile iof = new InputOnlineFile(fs);
                            iof.FileName = file.Name;

                            await botClient.SendTextMessageAsync(
                                chatId: chatId,
                                text: $"Номер файла: {fileNum}",
                                cancellationToken: cancellationToken);

                            var sendDoc = await botClient.SendDocumentAsync(update.Message.Chat.Id, iof, file.Name);

                            fileIDs.Add(fileNum, sendDoc.Document.FileId);

                            fileNum++;
                        }
                        await botClient.SendTextMessageAsync(message.Chat, "Чтобы скачать файл, введите команду /get_номерФайла");

                        break;
                }

                // обработка остальных типов сообщений (не текстовых)
                switch (update.Message.Type)
                {
                    case MessageType.Voice:
                        Download(update.Message.Voice.FileId, savePath + creationDate + update.Message.Voice.FileId + ".mp3");
                        break;

                    case MessageType.Photo:
                        string photoFileID = update.Message.Photo[update.Message.Photo.Length - 1].FileId;
                        Download(photoFileID, savePath + "Картинка_" + creationDate + ".png");
                        break;

                    case MessageType.Text:
                        messageSubstrings = update.Message.Text.Split(' ');

                        // обработка "/get_файл"
                        if (messageSubstrings[0] == "/get")
                        {
                            int fileIndex = Convert.ToInt32(messageSubstrings[1]);

                            if (fileIDs.ContainsKey(fileIndex))
                            {
                                DirectoryInfo directory = new DirectoryInfo(savePath);
                                FileInfo[] files = directory.GetFiles();
                                FileStream fs = System.IO.File.OpenRead(files[fileIndex].FullName);

                                Download(fileIDs[fileIndex], downloadPath + "Файл_" + creationDate);
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat, "Нет такого индекса");
                            }

                            await botClient.SendTextMessageAsync(message.Chat, "Файл скачен");
                        }
                        break;

                    default:
                        await botClient.SendTextMessageAsync(
                            chatId: chatId,
                            text: $"Unknown type",
                            cancellationToken: cancellationToken);
                        break;
                }
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        /// <summary>
        /// сохранение файлов на сервере
        /// </summary>
        /// <param name="fileId">id скачиваемого файла</param>
        /// <param name="path">путь для скачивания</param>
        static async void Download(string fileId, string path)
        {
            var file = await bot.GetFileAsync(fileId);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await bot.DownloadFileAsync(file.FilePath, fs);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}

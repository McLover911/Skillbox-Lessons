using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;


using var cts = new CancellationTokenSource();

Dictionary<int, string> fileIDs = new Dictionary<int, string>();

string token = System.IO.File.ReadAllText(@"E:\TelegramBots\1\TheFirstPrototypeBot.txt");
TelegramBotClient botClient = new TelegramBotClient(token);

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { }
};

botClient.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken: cts.Token);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    string[] messageSubstrings;

    long chatId = update.Message.Chat.Id;
    string messageText = update.Message.Text;
    string creationDate = Convert.ToString(DateTime.Now).Replace(':', '-').Replace(' ', '_');

    string savePath = @"E:\Skillbox\C#\Skillbox-Lessons\LESSON-9\TASK-1\bin\Debug\net6.0\Save\";
    string downloadPath = @"E:\Skillbox\C#\Skillbox-Lessons\LESSON-9\TASK-1\bin\Debug\net6.0\Download\";

    if (update.Type != UpdateType.Message)
    {
        return;
    }

    if (update.Message.Type == MessageType.Voice)
    {
        Download(update.Message.Voice.FileId, savePath + creationDate + update.Message.Voice.FileId);
    }

    if (update.Message.Type == MessageType.Photo)
    {
        string photoFileID = update.Message.Photo[update.Message.Photo.Length - 1].FileId;

        Download(photoFileID, savePath + "Картинка_" + creationDate + ".png");
    }

    if (update.Message.Text == "/start")
    {
        Message message = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Бот готов к работе",
            disableNotification: true,
            cancellationToken: cancellationToken);
    }

    if (update.Message.Text == "/getfiles")
    {
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

            Thread.Sleep(300);
        }

        await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Чтобы скачать файл, введите команду /get с номером файла через пробел",
                cancellationToken: cancellationToken);
    }

    if (update.Message.Type == MessageType.Text)
    {
        messageSubstrings = update.Message.Text.Split(' ');

        if (messageSubstrings[0] == "/get")
        {
            int fileIndex = Convert.ToInt32(messageSubstrings[1]);

            if (fileIDs.ContainsKey(fileIndex))
            {
                DirectoryInfo directory = new DirectoryInfo(savePath);
                FileInfo[] files = directory.GetFiles();
                FileStream fs = System.IO.File.OpenRead(files[fileIndex].FullName);

                Download(fileIDs[fileIndex], downloadPath + "Картинка_" + creationDate + ".png");
            }
            else
            {
                await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Нет такого номера",
                cancellationToken: cancellationToken);
            }
        }
    }
}

Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}

async void Download(string fileId, string path)
{
    var file = await botClient.GetFileAsync(fileId);

    using (FileStream fs = new FileStream(path, FileMode.Create))
    {
        await botClient.DownloadFileAsync(file.FilePath, fs);
    }
}
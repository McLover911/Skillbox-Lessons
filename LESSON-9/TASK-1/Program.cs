using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

string token = System.IO.File.ReadAllText(@"E:\TelegramBots\1\TheFirstPrototypeBot.txt");
TelegramBotClient botClient = new TelegramBotClient(token);

using var cts = new CancellationTokenSource();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { } // receive all update types
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
    var chatId = update.Message.Chat.Id;
    var messageText = update.Message.Text;
    string creationDate = Convert.ToString(DateTime.Now).Replace(':', '-');
    string path = @"E:\Skillbox\C#\Skillbox-Lessons\LESSON-9\TASK-1\bin\Debug\net6.0\Downloads\";


    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Type != UpdateType.Message)
    {
        return;
    }

    int update_id = 0;

    var msgs = botClient.GetUpdatesAsync(update_id).Result;

    if (update.Message.Type == MessageType.Voice)
    {
        Download(update.Message.Voice.FileId, path + creationDate + update.Message.Voice.FileId);
    }

    if (update.Message.Type == MessageType.Photo)
    {
        string photoFileID = update.Message.Photo[update.Message.Photo.Length - 1].FileId;

        Download(photoFileID, path + "Картинка " + creationDate + ".png");
    }

    if (update.Message.Text == "/getFiles")
    {
        DirectoryInfo directory = new DirectoryInfo(path);
        FileInfo[] files = directory.GetFiles();
        foreach (FileInfo file in files)
        {
            FileStream fs = System.IO.File.OpenRead(file.FullName);
            InputOnlineFile iof = new InputOnlineFile(fs);
            iof.FileName = file.Name;
            botClient.SendDocumentAsync(update.Message.Chat.Id, iof, file.Name);
            Thread.Sleep(300);
        }
    }

    Message sentMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Message type is " + update.Message.Type,
        cancellationToken: cancellationToken);

    //foreach (dynamic msg in msgs)
    //{
    //    update_id = Convert.ToInt32(msg.Id) + 1;
    //    string userMessage = msg.Message.Text;
    //    string userId = Convert.ToString(msg.Message.From.Id);
    //    string useFirstrName = msg.Message.From.FirstName;
    //    string text = $"{useFirstrName} {userId} {userMessage} {msg.Id} {msg.Message.Type} {update_id}";



    //    if (msg.Message.Text == "/start")
    //    {
    //        Message message = await botClient.SendTextMessageAsync(
    //            chatId: chatId,
    //            text: "Бот готов к работе",
    //            disableNotification: true,
    //            cancellationToken: cancellationToken);
    //    }

    //    Console.WriteLine(text);
    //}
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
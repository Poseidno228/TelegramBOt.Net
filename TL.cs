using System;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramTestBot
{
    class Program
    {
        static TelegramBotClient BotClient;
        static void Main(string[] args)
        {
            BotClient = new TelegramBotClient("1371351010:AAGimx5E5g07L7glY-m5KK0zETDKTHHXD44");
            var me = BotClient.GetMeAsync().Result;
            BotClient.StartReceiving();
            BotClient.OnMessage += BotClient_OnMessage;
            
            Console.ReadLine();
            BotClient.StopReceiving();
            Console.WriteLine(BotClient.MessageOffset.ToString());
        }

        private static async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                await BotClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                      text: "Max Pidor");
                
            }
            if (e.Message.Photo != null)
                await BotClient.SendPhotoAsync(e.Message.Chat, "https://st.depositphotos.com/2000885/1902/i/450/depositphotos_19021343-stock-photo-red-heart.jpg");
        }
    }
}

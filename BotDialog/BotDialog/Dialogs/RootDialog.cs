using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotDialog.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        static string username;
        int count = 0;
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hello, I am Microsoft Bot");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result as Activity;
            
            if(count >0)
                username = message.Text;

            if (string.IsNullOrEmpty(username))
            {
                await context.PostAsync("what is your good name");
                count++;
            }
            else
            {
                 await context.PostAsync($"Hello {username} , How may help You");
      
            }
            context.Wait(MessageReceivedAsync);

        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DevEnvExeBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            
            //test
            if (activity.Text.Contains("technology"))
            {
                await context.PostAsync("Refer C# corner website for tecnology help - http://www.c-sharpcorner.com/");
            }
            else if (activity.Text.Contains("morning"))
            {
                await context.PostAsync("Hello !! Good Morning , Have a nice Day");
            }
            //test
            else if (activity.Text.Contains("night"))
            {
                await context.PostAsync(" Good night and Sweetest Dreams with Bot Application ");
            }
            else if (activity.Text.Contains("date"))
            {
                await context.PostAsync(DateTime.Now.ToString());
            }
            else
            {
                await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}
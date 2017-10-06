using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Botstatedata.Dialogs
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
            // Try retrieving the name of the user from state.
            context.UserData.TryGetValue("userName", out string nameOfUser);
            
            // We don't want to process the first message that the user sent to the bot to initiate a conversation (the 'Hi' message). This flag will only be set when our bot requests the user to enter his name. Therefore, we will check the value of this flag and only then set the state with the name of the user.
            context.UserData.TryGetValue("nameRequired", out bool nameRequired);
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // Save the name and set the flag.
            context.UserData.SetValue("userName", nameOfUser);
            context.UserData.SetValue("nameRequired", false);

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }
    }
}
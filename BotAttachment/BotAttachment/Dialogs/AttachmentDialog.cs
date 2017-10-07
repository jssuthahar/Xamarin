using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace BotAttachment.Dialogs
{
    [Serializable]
    public class AttachmentDialog : IDialog<object>
    {    
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }
        private readonly IDictionary<string, string> options = new Dictionary<string, string>
        {
            { "1", "1. Attach Local-Image " },
            { "2", "2. Attach Internet Image" },
            {"3" , "3. File Attachment" },
            {"4" , "4. Get local PDF" },
            {"5" , "5. Video Attachment" },
            {"6" , "6. Youtube video Attachment" },
            {"7" , "7. MP3 Attachment" },

        };
        public async virtual Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var welcomeMessage = context.MakeMessage();
            welcomeMessage.Text = "Welcome to bot Attachment Demo";

            await context.PostAsync(welcomeMessage);

            await this.DisplayOptionsAsync(context);
        }

        public async Task DisplayOptionsAsync(IDialogContext context)
        {
            PromptDialog.Choice<string>(
                context,
                this.SelectedOptionAsync,
                this.options.Keys,
                "What Demo / Sample option would you like to see?",
                "Please select Valid option 1 to 6",
                6,
                PromptStyle.PerLine,
                this.options.Values);
        }

        public async Task SelectedOptionAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var message = await argument;

            var replyMessage = context.MakeMessage();
            
            Attachment attachment = null;

            switch (message)
            {
                case "1":
                    attachment = GetLocalAttachment();
                    replyMessage.Text = "Attach Image from Local Machine";
                    break;
                case "2":
                    attachment = GetInternetAttachment();
                    replyMessage.Text = "Attach Image from Internet";
                    break;
                case "3":
                    attachment = GetinternetFileAttachment();
                    replyMessage.Text = "Click Link for navigate PDF internet location";
                    break;
                case "4":
                    attachment = GetLocalFileAttachment();
                    replyMessage.Text = "Click Link for navigate PDF local location";
                    break;
                case "5":
                    attachment = GetinternetVideoAttachment();
                    replyMessage.Text = "Click on play button ";
                    break;
                case "6":
                    attachment = GetinternetYoutubeAttachment();
                    replyMessage.Text = "Showing video from Youtube ";
                    break;
                case "7":
                    attachment = GetinternetMP3Attachment();
                    replyMessage.Text = "Showing MP3 from internet ";
                    break;

            }
            replyMessage.Attachments = new List<Attachment> { attachment };

            await context.PostAsync(replyMessage);

            await this.DisplayOptionsAsync(context);
        }
        /// <summary>
        /// dispaly local image
        /// </summary>
        /// <returns></returns>
        private static Attachment GetLocalAttachment()
        {
            var imagePath = HttpContext.Current.Server.MapPath("~/images/demo.gif");

            var imageData = Convert.ToBase64String(File.ReadAllBytes(imagePath));

            return new Attachment
            {
                Name = "demo.gif",
                ContentType = "image/gif",
                ContentUrl = $"data:image/gif;base64,{imageData}"
            };
        }
        /// <summary>
        /// Dispaly image from internet
        /// </summary>
        /// <returns></returns>
        private static Attachment GetInternetAttachment()
        {
            return new Attachment
            {
                Name = "architecture-resize.png",
                ContentType = "image/png",
                ContentUrl = "https://docs.microsoft.com/en-us/bot-framework/media/how-it-works/architecture-resize.png"
            };
        }

        

            /// <summary>
        /// attach internet file
        /// </summary>
        /// <returns></returns>
        public static Attachment GetinternetMP3Attachment()
        {
            Attachment attachment = new Attachment();
            attachment.ContentType = "audio/mpeg3";
            attachment.ContentUrl = "http://video.ch9.ms/ch9/f979/40088849-aa88-45d4-93d5-6d1a6a17f979/TestingBotFramework.mp3";
            attachment.Name = "Testing the Bot Framework Mp3";
            return attachment;
        }
        /// <summary>
        /// attach internet file
        /// </summary>
        /// <returns></returns>
        public static Attachment GetinternetFileAttachment()
        {
            Attachment attachment = new Attachment();
            attachment.ContentType = "application/pdf";
            attachment.ContentUrl = "https://qconlondon.com/london-2017/system/files/presentation-slides/microsoft_bot_framework_best_practices.pdf";
            attachment.Name = "Microsoft Bot Framework Best Practices";
            return attachment;
        }
        /// <summary>
        /// Get local file 
        /// </summary>
        /// <returns></returns>
        public static Attachment GetLocalFileAttachment()
        {
            var pdfPath = HttpContext.Current.Server.MapPath("~/File/BotFramework.pdf");
            Attachment attachment = new Attachment();
            attachment.ContentType = "application/pdf";
            attachment.ContentUrl = pdfPath;
            attachment.Name = "Local Microsoft Bot Framework Best Practices";
            return attachment;
        }
        /// <summary>
        /// Display Youtube Video
        /// </summary>
        /// <returns></returns>
        public static Attachment GetinternetYoutubeAttachment()
        {
            Attachment attachment = new Attachment();
            attachment.ContentType = "video/mp4";
            attachment.ContentUrl = "https://youtu.be/RaNDktMQVWI";
            return attachment;
        }
        /// <summary>
        /// Dispaly video from internet
        /// </summary>
        /// <returns></returns>
        public static Attachment GetinternetVideoAttachment()
        {

            Attachment attachment = new Attachment();
            attachment = new VideoCard("Build a great conversationalist", "Bot Demo Video", "Build a great conversationalist", media: new[] { new MediaUrl(@"https://bot-framework.azureedge.net/videos/skype-hero-050517-sm.mp4") }).ToAttachment();
            return attachment;
        }

     
    
}
}
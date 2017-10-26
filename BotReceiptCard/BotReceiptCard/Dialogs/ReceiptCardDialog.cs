using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotReceiptCard.Dialogs
{
    [Serializable]
    public class ReceiptCardDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
            return Task.CompletedTask;
        }
        /// <summary>
        /// MessageReceivedAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public async virtual Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var welcomeMessage = context.MakeMessage();
            welcomeMessage.Text = "Your Invoice Details below , if you requred detail click on 'Request Email' Options ";

            await context.PostAsync(welcomeMessage);

            await this.DisplayThumbnailCard(context);
        }
        /// <summary>
        /// DisplayReceiptCard
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task DisplayReceiptCard(IDialogContext context)
        {

            var replyMessage = context.MakeMessage();
            Attachment attachment = getBotReceiptCard(); ;
            replyMessage.Attachments = new List<Attachment> { attachment };
            await context.PostAsync(replyMessage);
        }
        /// <summary>
        /// getBotReceiptCard
        /// </summary>
        /// <returns></returns>
        private static Attachment getBotReceiptCard()
        {
            var receiptCard = new ReceiptCard
            {
                Title = "Online Shopping",
                Facts = new List<Fact> { new Fact("Name:","Nikhil"),
                    new Fact("Address:","Bangalore"),
                    new Fact("------------------------",""),
                    new Fact("Phone :97420XXXX2",""),
                    new Fact("Email:jssXXXXX@gmail.com",""),
                    new Fact("Order Number:97421",""),
                    new Fact("Payment Method : Master 5555-****", ""),
                    new Fact("------------------------","")
                },
                Items = new List<ReceiptItem>
        {
            
            new ReceiptItem("Hit Refresh",subtitle:"by Satya Nadella (Author)",text:"Kindle Edition", price: "278.31", quantity: "1", image: new CardImage(url: "https://images-eu.ssl-images-amazon.com/images/I/41eAfVuUzeL.jpg"),tap: new CardAction("Read More")),
            new ReceiptItem("XamarinQA",subtitle:"by Suthahar J (Author)",text:"Kindle Edition", price: "116.82", quantity: "1", image: new CardImage(url: "https://images-eu.ssl-images-amazon.com/images/I/51z6GXy3FSL.jpg"),tap: new CardAction("Read More")),
            new ReceiptItem("Surface Pro 4",subtitle:"Core i5 - 6th Gen/4GB/128GB/Windows 10 Pro/Integrated Graphics/31.242 Centimeter Full HD Display", price: "66,500", quantity: "1", image: new CardImage(url: "https://images-na.ssl-images-amazon.com/images/I/41egJVu%2Bc0L.jpg"),tap: new CardAction("Read More")),
            new ReceiptItem("Windows 10 pro",subtitle:"by Microsoft", price: "13,846", quantity: "1", image: new CardImage(url: "https://images-na.ssl-images-amazon.com/images/I/7176wliQYsL._SL1500_.jpg"),tap: new CardAction("Read More"))
        },
                Tax = "2000",
                Total = "82,741.13",
                Tap =new CardAction(ActionTypes.OpenUrl,value: "https://www.microsoft.com/en-in/store/b/home?SilentAuth=1&wa=wsignin1.0"),
                Buttons = new List<CardAction>
        {
            new CardAction(
                ActionTypes.OpenUrl,
                "Request Email",
                "https://assets.onestore.ms/cdnfiles/external/uhf/long/9a49a7e9d8e881327e81b9eb43dabc01de70a9bb/images/microsoft-gray.png",
                "mailto:jssuthahar@gmail.com?subject=Order%20Number:97421&body=Hi%team,%20I%need%20Invoice")
        }
            };

            return receiptCard.ToAttachment();
        }
    }
}
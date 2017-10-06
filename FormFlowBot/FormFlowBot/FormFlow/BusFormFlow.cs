using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Dialogs;
using System;

namespace FormFlowBot.FormFlow
{
    [Serializable]
    public class BusFormFlow
    {
        /// <summary>
        /// From City Enum
        /// </summary>
        public enum FromCity
        {
            Bangalore,Chennai,Madurai,Trichy,Coimbatore,Tanjore,Pudukkottai
        }
        /// <summary>
        /// To City Enum
        /// </summary>
        public enum ToCity
        {
            Bangalore, Chennai, Madurai, Trichy, Coimbatore, Tanjore, Pudukkottai
        }


        public enum Food
        {
            [Describe("Yes, I want South indian meal")]
            SMeal = 1,

            [Describe("Yes, I want South North Indain meal")]
            NMeal = 2,

            [Describe("Yes , I want Fruits")]
            Fruts = 3 ,
            [Describe("Thanks , I dont want any Food")]
            No =4
        }

        

        /// <summary>
        /// Bus Type Enum
        /// </summary>
        public enum BusType
        {
            AC, NonAC,Slepper, Siting 
        }
        /// <summary>
        /// Gender
        /// </summary>
        public enum Gender
        {
            [Terms("M","boy")]
             Male,
            [Terms("F","girl")]
             Female

        }

        /// <summary>
        /// List of Form Flow
        /// </summary>
        [Prompt("You can Select {&}  {||}")]
        public FromCity? FromAddress;
        [Prompt("You can Select {&}  {||}")]
        public ToCity? ToAddress;
        [Prompt("When you are satrting from")]
        public DateTime? StartDate;
        public BusType? BusTypes;
        [Numeric(1,5)]
        public int? NumberofSeat;
        [Optional]
        public string Address;
        [Pattern(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email;
        [Template(TemplateUsage.NotUnderstood, "Sorry , \"{0}\" Not avilable .", "Try again, I don't get \"{0}\".")]
        [Template(TemplateUsage.EnumSelectOne, "What kind of {&} would you like ? {||}", ChoiceStyle = ChoiceStyleOptions.PerLine)]
        public Food LunchFood;
        public Gender? SelectGender;
        [Prompt("What is Your Name")]
        public string Name;
        public int Age;
        //[Template(TemplateUsage.EnumSelectMany, "Which temperature {&} would you like?{||}", ChoiceStyle = ChoiceStyleOptions.PerLine)]
        /// <summary>
        /// Build Form
        /// </summary>
        /// <returns></returns>
        public static IForm<BusFormFlow> BuildForm()
        {
            return new FormBuilder<BusFormFlow>()
                    .Message("Welcome to the BotChat Bus Booking !")
                    .Field(nameof(ToAddress))
                    .Field(nameof(FromAddress))
                    .Field(nameof(StartDate))
                    .Field(nameof(BusTypes))
                    .Field(nameof(NumberofSeat))
                    .Field(nameof(LunchFood))
                    .Message("Passenger Details")
                    .AddRemainingFields()
                    .Message("You will get confirmation email and SMS .Thanks for using Chat Bot Bus Booking")
                    .OnCompletion(async (context, profileForm) =>
                    {
                        string message = "Your Bus booking Successfully Completed  , Welcome Again !!! :)";
                        await context.PostAsync(message);
                    })
                    .Build();
        }


    }
}
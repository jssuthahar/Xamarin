using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevEnvExeFace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void emotion_Clicked(object sender, EventArgs e)
        {
            var emotionClient = new EmotionServiceClient("ccd94bca7ccc4e0d9b45b200088990e9");
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                // Supply media options for saving our photo after it's taken.
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Receipts",
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                // Take a photo of the business receipt.
                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                 using (var photoStream = file.GetStream())
                {
                    Emotion[] emotionResult = await emotionClient.RecognizeAsync(photoStream);
                    if (emotionResult.Any())
                    {
                        // Emotions detected are happiness, sadness, surprise, anger, fear, contempt, disgust, or neutral.
                        lblrating.Text = emotionResult.FirstOrDefault().Scores.ToRankedList().FirstOrDefault().Key;
                    }
                    file.Dispose();
                }
            }

            //var visionclient = new VisionServiceClient(visionKey);
            //var result = await visionclient.DescribeAsync(file.GetStream());
            //LblResult.Text = result.Description.Captions.First().Text;
        }
    }
}

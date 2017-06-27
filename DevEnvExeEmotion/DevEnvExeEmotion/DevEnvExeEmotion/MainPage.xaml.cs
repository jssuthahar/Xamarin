using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevEnvExeEmotion
{
    public partial class MainPage : ContentPage
    {
        EmotionServiceClient emotionClient;
        MediaFile photo;

        public MainPage()
        {
            InitializeComponent();
            emotion.IsVisible = false;
            emotionClient = new EmotionServiceClient("7f495be5faf643adbeead444d5b79a13");
        }
        async void OnFeedBackClicked(object sender, EventArgs e)
        {
            //capture image
            await CaptureImage();
            ((Button)sender).IsEnabled = false;
            // Recognize emotion
            await Recognizeemotion();
            ((Button)sender).IsEnabled = true;
        }
        public async Task CaptureImage()
        {
            await CrossMedia.Current.Initialize();
            emotion.IsVisible = false;
            // Take photo
            if (CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported)
            {
                photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = false
                    
                });

            }
            else
            {
                await DisplayAlert("No Camera", "Camera unavailable.", "OK");
            }
        }

        public async Task Recognizeemotion()
        {
            try
            {
                if (photo != null)
                {
                    using (var photoStream = photo.GetStream())
                    {

                        Emotion[] emotionResult = await emotionClient.RecognizeAsync(photoStream);
                        if (emotionResult.Any())
                        {
                            // Emotions detected are happiness, sadness, surprise, anger, fear, contempt, disgust, or neutral.
                            emotionResultLabel.Text = emotionResult.FirstOrDefault().Scores.ToRankedList().FirstOrDefault().Key;
                            emotion.IsVisible = true;
                        }
                        photo.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

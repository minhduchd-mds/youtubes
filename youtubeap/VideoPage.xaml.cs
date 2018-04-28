using Google.Apis.YouTube.v3.Data;
using MyToolkit.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XemYouTubeThoi.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace youtubeap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoPage : Page
    {
        XemYouTubeThoi.Model.Video video;
        public VideoPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try {
                video = e.Parameter as XemYouTubeThoi.Model.Video;
                var Url = await YouTube.GetVideoUriAsync(video.Id, YouTubeQuality.Quality360P);

                Player.Source = Url.Uri;
            } catch (Exception){

            }
          
        }
        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new object());
        }
    }
}

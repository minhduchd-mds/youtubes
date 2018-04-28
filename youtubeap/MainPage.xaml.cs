using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using XemYouTubeThoi.Model;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace youtubeap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private YouTubeService youtubeService =
            new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyCPTflOQted7ACmI01muIG0fqn78xw3PD4",
                ApplicationName = "youtube"
            });
        List<Video> ListVideo = new List<Video>();
        private string TokenNextPage = null, TokenPrivPage = null;


        public MainPage()
        {
            this.InitializeComponent();
            GetVideo();
        }

        private async void GetVideo(string PageToken = null)
        {
            var Request = youtubeService.Search.List("snippet");
            Request.ChannelId = "UCssRwa6rXARIVQ6vl96mctQ";
            Request.MaxResults = 25;
            Request.Type = "video";
            Request.Order = SearchResource.ListRequest.OrderEnum.Date;
            Request.PageToken = PageToken;
            var Result = await Request.ExecuteAsync();
            if (Result.NextPageToken != null)
                TokenNextPage = Result.NextPageToken;
            if (Result.PrevPageToken != null)
                TokenPrivPage = Result.PrevPageToken;

            foreach (var item in Result.Items)
            {
                ListVideo.Add(new Video
                {
                    Title = item.Snippet.Title,
                    Id = item.Id.VideoId,
                    Img = item.Snippet.Thumbnails.Default__.Url
                });
            }
            lv.ItemsSource = null;
            lv.ItemsSource = ListVideo;
        }

      

        private void NextPage_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GetVideo();
        }

        private void lv_ItemClick(object sender, ItemClickEventArgs e)
        {
            Video video = e.ClickedItem as Video;
            Frame.Navigate(typeof(VideoPage), video);

        }


    }
}

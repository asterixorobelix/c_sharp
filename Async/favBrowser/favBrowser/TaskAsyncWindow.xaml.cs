using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace favBrowser
{
    //Downloads the favicons with task based asynchronous programming (TAP)
    public partial class TaskAsyncWindow : Window
    {
        private HttpClient client;//supports concurrent operations

        public TaskAsyncWindow()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void GetButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (string domain in WebsiteAddresses.Websites)
            {
               await AddAFaviconAsync(domain);

               //Note: you cannot do this: await AddAFaviconAsync(domain).ConfigureAwait(false);
               //Because the ui thread needs to be notified that the byte download has finished.
            }
        }

        private async Task AddAFaviconAsync(string domain)
        {
            var uri = WebsiteAddresses.CreateUri(domain);

            var bytes = await client.GetByteArrayAsync(uri);

            Image imageControl =ImageMaker.MakeImageControl(bytes);
            m_WrapPanel.Children.Add(imageControl);
        }
    }
}

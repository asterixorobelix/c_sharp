using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace favBrowser
{
    //Downloads the favicons with task based asynchronous programming (TAP)
    public partial class TaskAsyncWindow2 : Window
    {
        private HttpClient client;//supports concurrent operations

        public TaskAsyncWindow2()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private void GetButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (string domain in WebsiteAddresses.Websites)
            {
                //note how this is not awaited like it is in the TaskAsyncWindow.xaml.cs
                //Behaves more like the event based async class
                AddAFaviconAsync(domain);
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

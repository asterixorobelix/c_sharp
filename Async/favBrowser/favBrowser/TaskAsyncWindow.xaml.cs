using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace favBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TaskAsyncWindow : Window
    {
        //Uses task based asynchronous programming (TAP)
        public TaskAsyncWindow()
        {
            InitializeComponent();
        }

        private async void GetButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (string domain in WebsiteAddresses.Websites)
            {
               await AddAFaviconAsync(domain);
            }
        }

        private async Task AddAFaviconAsync(string domain)
        {
            var webClient = new HttpClient();
            var uri = new Uri("http://" + domain + "/favicon.ico");

            var bytes = await webClient.GetByteArrayAsync(uri);

            Image imageControl =ImageMaker.MakeImageControl(bytes);
            m_WrapPanel.Children.Add(imageControl);
        }
    }
}

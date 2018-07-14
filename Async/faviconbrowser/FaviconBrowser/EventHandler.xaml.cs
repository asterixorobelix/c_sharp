using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FaviconBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EventHandlerWindow : Window
    {


        public EventHandlerWindow()
        {
            InitializeComponent();
        }

        private void GetButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (string domain in WebsiteAddresses.Websites)
            {
                AddAFaviconAsync(domain);
            }
        }

        private void AddAFaviconAsync(string domain)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadDataCompleted += DownloadDataCompletedHandler;
            var uri = new Uri("http://" + domain + "/favicon.ico");
            webClient.DownloadDataAsync(uri);
        }

        private void DownloadDataCompletedHandler(object sender, DownloadDataCompletedEventArgs e)
        {
            var bytes = e.Result;
            Image imageControl = ImageMaker.MakeImageControl(bytes);
            m_WrapPanel.Children.Add(imageControl);
        }
    }
}

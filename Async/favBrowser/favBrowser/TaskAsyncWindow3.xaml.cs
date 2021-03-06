﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace favBrowser
{
    //Downloads the favicons with task based asynchronous programming (TAP)
    public partial class TaskAsyncWindow3 : Window
    {
        private HttpClient client;//supports concurrent operations

        public TaskAsyncWindow3()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void GetButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (string domain in WebsiteAddresses.Websites)
            {
                //var bytes = GetFaviconByteArray(domain).Result; //blocking
                var bytes =await GetFaviconByteArray(domain);
                AddFaviconBytesToUi(bytes);
            }
        }

        private async Task<byte[]> GetFaviconByteArray(string domain)
        {
            var uri = WebsiteAddresses.CreateUri(domain);

            var bytes = await client.GetByteArrayAsync(uri);
            return bytes;
        }

        private void AddFaviconBytesToUi(byte[] bytes)
        {
            Image imageControl = ImageMaker.MakeImageControl(bytes);
            m_WrapPanel.Children.Add(imageControl);
        }
    }
}

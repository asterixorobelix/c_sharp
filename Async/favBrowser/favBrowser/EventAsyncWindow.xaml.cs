﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace favBrowser
{
    public partial class EventAsyncWindow : Window
    {
        //uses event based async (EAP), rather than task based async

        public EventAsyncWindow()
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
            WebClient webClient = new WebClient();//cant reuse web client and have concurrent operations on it.
            webClient.DownloadDataCompleted += DownloadDataCompletedHandler;
            var uri = WebsiteAddresses.CreateUri(domain);
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

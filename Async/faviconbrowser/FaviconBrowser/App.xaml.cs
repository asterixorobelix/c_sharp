using System.Windows;

namespace FaviconBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {

            var eventHandlerWindow = new EventHandlerWindow
            {
                Top = 100,

                Left = 400
            };

            eventHandlerWindow.Show();

        }
    }
}

using System.Windows;

namespace favBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var eventHandlerWindow = new EventAsyncWindow
            {
                Top = 100,
                Left = 400
            };

            eventHandlerWindow.Show();

            var synchronousWindow = new SynchronousWindow
            {
                Top = 200,
                Left = 800
            };
            synchronousWindow.Show();
        }
    }
}

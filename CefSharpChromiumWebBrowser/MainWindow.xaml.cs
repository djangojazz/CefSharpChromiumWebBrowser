using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CefSharpChromiumWebBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BrowserContextMenuHandler _contextMenuHandler = new BrowserContextMenuHandler();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            //ChromiumBrowser.ContextMenu = BrowserContextMenu;
            //ChromiumBrowser.MenuHandler = _contextMenuHandler;
            this.Loaded += RunwayAnalysisChromiumControl_Loaded;
        }

        private void RunwayAnalysisChromiumControl_Loaded(object sender, RoutedEventArgs e)
        {
            //RunwayAnalysisWebViewModel vm = DataContext as RunwayAnalysisWebViewModel;
            //if (vm != null)
            //{
            //    vm.InitializeBrowser(ChromiumBrowser);
            //}
        }
    }

    public class BrowserContextMenuHandler : IContextMenuHandler
    {
        private bool _devToolsVisible = false;
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.AddItem((CefMenuCommand)103, "Reload");
            model.AddItem((CefMenuCommand)26501, "DevTools");
            model.AddItem((CefMenuCommand)220, "Javascript test");
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            // React to the first ID (show dev tools method)
            if (commandId == (CefMenuCommand)26501)
            {
                if (!_devToolsVisible)
                {
                    browser.GetHost().ShowDevTools();
                    _devToolsVisible = true;
                }
                else
                {
                    browser.GetHost().CloseDevTools();
                    _devToolsVisible = false;
                }
                return true;
            }


            // React to the third ID (Display alert message)
            if (commandId == (CefMenuCommand)103)
            {
                browser.Reload(true);
                return true;
            }

            if (commandId == (CefMenuCommand)220)
            {
                List<long> frameIds = browser.GetFrameIdentifiers();
                if (frameIds.Count > 0)
                {
                    browser.GetFrame(frameIds[0]).ExecuteJavaScriptAsync("alert('javascript test');");
                }
                return true;
            }


            // Ignore anything we did not explicitly handle.
            return true;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}

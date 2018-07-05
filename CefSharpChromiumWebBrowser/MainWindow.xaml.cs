using CefSharp;
using CefSharp.Wpf;
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
        //private BrowserContextMenuHandler _contextMenuHandler = new BrowserContextMenuHandler();
        private MainWindowViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainWindowViewModel();
            DataContext = _vm;
            browser.MenuHandler = new BrowserContextMenuHandler(menu =>
                {
                    menu.Clear();
                    menu.AddItem((CefMenuCommand)26501, "Run Test for De");
                    menu.AddSeparator();
                    menu.AddItem((CefMenuCommand)26502, "Hello");
                },
                commandId =>
                {
                    if (commandId == (CefMenuCommand)26501)
                        _vm.CommandRun.Execute(null);

                    if (commandId == (CefMenuCommand)26502)
                        MessageBox.Show("Hello there");

                    return true;
                });
        }
    }
    
    public class BrowserContextMenuHandler : IContextMenuHandler
    {
        private Action<IMenuModel> _menu;
        private Func<CefMenuCommand, bool> _menuCommands;

        public BrowserContextMenuHandler(Action<IMenuModel> menu, Func<CefMenuCommand, bool> menuCommands)
        {
            _menu = menu;
            _menuCommands = menuCommands;
        }
        
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model) =>
            _menu(model);

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags) => _menuCommands(commandId);

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

            chromiumWebBrowser.Dispatcher.Invoke(() =>
            {
                chromiumWebBrowser.ContextMenu = null;
            });
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback) => false;
    }
}

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
        private ChromiumWebBrowser _browser;
        private BrowserContextMenuHandler _contextMenuHandler;// = new BrowserContextMenuHandler();
        //private MainWindowViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel();
            DataContext = vm;
            //vm.ChromiumWebBrowser = browser;
        }

        private void browser_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _browser = (sender as ChromiumWebBrowser);
            var vm = (_browser.DataContext as MainWindowViewModel);

            _browser.MenuHandler = new BrowserContextMenuHandler(menu =>
            {
                menu.Clear();
                menu.AddItem((CefMenuCommand)26501, "Run Test for VM");
                menu.AddSeparator();
                menu.AddItem((CefMenuCommand)26502, "Hello");
            },
            commandId =>
            {
                if (commandId == (CefMenuCommand)26501)
                    vm.CommandRun.Execute(null);

                if (commandId == (CefMenuCommand)26502)
                    MessageBox.Show("Hello there");
            }
            );
        }
    }

    public class BrowserContextMenuHandler : IContextMenuHandler
    {
        private Action<IMenuModel> _menu;
        //private Func<CefMenuCommand, bool> _menuCommands;
        private Action<CefMenuCommand> _menuSetup;

        public BrowserContextMenuHandler(Action<IMenuModel> menu, Action<CefMenuCommand> menuSetup)
        {
            _menu = menu;
            _menuSetup = menuSetup;
        }

        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model) => _menu(model);

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags) => false;

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame) => ((ChromiumWebBrowser)browserControl).Dispatcher.Invoke(() => ((ChromiumWebBrowser)browserControl).ContextMenu = null);

        bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

            //IMenuModel is only valid in the context of this method, so need to read the values before invoking on the UI thread
            var menuItems = GetMenuItems(model).ToList();

            chromiumWebBrowser.Dispatcher.Invoke(() =>
            {
                var menu = new ContextMenu
                {
                    IsOpen = true
                };

                RoutedEventHandler handler = null;

                handler = (s, e) =>
                {
                    menu.Closed -= handler;

                    //If the callback has been disposed then it's already been executed
                    //so don't call Cancel
                    if (!callback.IsDisposed)
                    {
                        callback.Cancel();
                    }
                };

                menu.Closed += handler;

                foreach (var item in menuItems)
                {
                    if (item.Item2 == CefMenuCommand.NotFound && string.IsNullOrWhiteSpace(item.Item1))
                    {
                        menu.Items.Add(new Separator());
                        continue;
                    }

                    menu.Items.Add(new MenuItem
                    {
                        Header = item.Item1.Replace("&", "_"),
                        IsEnabled = item.Item3,
                        Command = new RelayCommand(x => _menuSetup(item.Item2))
                    });
                }
                chromiumWebBrowser.ContextMenu = menu;
            });

            return true;
        }

        private static IEnumerable<Tuple<string, CefMenuCommand, bool>> GetMenuItems(IMenuModel model)
        {
            for (var i = 0; i < model.Count; i++)
            {
                var header = model.GetLabelAt(i);
                var commandId = model.GetCommandIdAt(i);
                var isEnabled = model.IsEnabledAt(i);
                yield return new Tuple<string, CefMenuCommand, bool>(header, commandId, isEnabled);
            }
        }
        //public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback) => false;
    }
}

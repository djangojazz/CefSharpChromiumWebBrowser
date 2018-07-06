using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CefSharp;
using CefSharp.Wpf;

namespace CefSharpChromiumWebBrowser
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _text;
        private string _result;
        
        public ICommand CommandRun { get; } 

        public MainWindowViewModel()
        {
            Text = "Test";
            CommandRun = new RelayCommand(x =>
            {
                Result = DateTime.Now.ToString();
            });
        }


        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        //This really ONLY exists to perform invocation of the Context Menu Builder implementation
        public ChromiumWebBrowser ChromiumWebBrowser
        {
            set
            {
                //_chromiumWebBrowser = value;
                if (value != null)
                {
                    value.MenuHandler = new BrowserContextMenuHandler(menu =>
                    {
                        menu.Clear();
                        menu.AddItem((CefMenuCommand)26501, "Run Test for VM");
                        menu.AddSeparator();
                        menu.AddItem((CefMenuCommand)26502, "Hello");
                    },
                    commandId =>
                    {
                        if (commandId == (CefMenuCommand)26501)
                            CommandRun.Execute(null);

                        if (commandId == (CefMenuCommand)26502)
                            MessageBox.Show("Hello there");

                        return true;
                    });
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String info) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}

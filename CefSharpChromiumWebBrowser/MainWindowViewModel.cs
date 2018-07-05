using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CefSharpChromiumWebBrowser
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private string _result;

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }


        public ICommand CommandRun { get; } 

        public MainWindowViewModel()
        {
            Text = "Test";
            CommandRun = new RelayCommand(x =>
            {
                Result = DateTime.Now.ToString();
            });
    }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String info) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}

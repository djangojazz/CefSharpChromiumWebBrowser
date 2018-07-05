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

        public ICommand CommandRun { get; } 

        public MainWindowViewModel()
        {
            Text = "Test";
            CommandRun = new RelayCommand(x =>
            {
                MessageBox.Show("hello");
            });
    }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String info) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}

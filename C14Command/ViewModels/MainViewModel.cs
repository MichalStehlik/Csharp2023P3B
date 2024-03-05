using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C14Command.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private int _position = 0;

        public MainViewModel()
        {
            NextCommand = new Command(() =>
            {
                Position = Position + 1;
            }, () => { return Position < 3; });
            PreviousCommand = new Command(() =>
            {
                Position = Position - 1;
            }, () => { return Position > 0; });
            ShiftCommand = new Command<string>((x) =>
            {
                Position = Convert.ToInt16(x);
            });
        }

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public Command<string> ShiftCommand { get; set; }
    
        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                RaisePropertyChanged();
                (NextCommand as Command).ChangeCanExecute();
                (PreviousCommand as Command).ChangeCanExecute();
            }
        }

        public ICommand AlertCommand =>
            new Command(() =>
            {
                App.Current.MainPage.DisplayAlert("Pozor", "Něco se děje", "OK");
            }, () => (true));

        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
                );
        }
        #endregion
    }
}

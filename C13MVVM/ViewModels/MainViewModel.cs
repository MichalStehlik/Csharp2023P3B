using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C13MVVM.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private int _value;
        private int _width;
        private string _text;

        public MainViewModel()
        {
            Text = "Ahoj";
            Width = 48;
        }

        public int Value 
        {
            get 
            { 
                return _value;
            } 
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                //RaisePropertyChanged("Width");
                RaisePropertyChanged();
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(TextLength));
                RaisePropertyChanged(nameof(PasswordStrength));
            }
        }

        public int TextLength
        {
            get 
            { 
                return _text.Length; 
            }
        }

        public string PasswordStrength
        {
            get
            {
                if (_text.Length < 10)
                    return "Weak";
                else
                    return "Strrrong";
            }
        }

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

using MP.Support;
using System;
using System.Windows.Input;

namespace MP.ActiveDirectoryInfo.Models
{
    public class MenuItem : BindableBase
    {
        private object _name;
        private object _icon;
        private string _text;
        private RelayCommand _command;
        private Uri _navigationDestination;

        public object Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }

        public object Icon
        {
            get => _icon;
            set { SetProperty(ref _icon, value); }
        }

        public string Text
        {
            get => _text;
            set { SetProperty(ref _text, value); }
        }

        public ICommand Command
        {
            get => _command;
            set { SetProperty(ref _command, (RelayCommand)value); }
        }

        public Uri NavigationDestination
        {
            get => _navigationDestination;
            set { SetProperty(ref _navigationDestination, value); }
        }

        public bool IsNavigation => _navigationDestination != null;
    }
}
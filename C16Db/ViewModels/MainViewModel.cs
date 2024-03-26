using C16Db.Data;
using C16Db.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C16Db.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ShoppingItem> _items = new ObservableCollection<ShoppingItem>();
        private ShoppingItem? _selectedItem;
        private ShoppingDatabase _database;
        private string _newName;

        public Command AddCommand { get; set; }
        public Command ReloadCommand { get; set; }

        public MainViewModel()
        {
            _database = new ShoppingDatabase();
            AddCommand = new Command(
                async () =>
                {
                    await StoreItemAsync(new ShoppingItem { Name = NewName });
                    //Items.Add(new ShoppingItem { Name = NewName});
                    await LoadItems();
                },
                () => NewName is not null
            );
            ReloadCommand = new Command(
                async () =>
                {
                    await LoadItems();
                }
             );

            Items = new ObservableCollection<ShoppingItem>();
            //Items.Add(new ShoppingItem { Id = 0, Name = "Jahoda", Done = true });
            //Items.Add(new ShoppingItem { Id = 1, Name = "Hruška" });
            //Items.Add(new ShoppingItem { Id = 2, Name = "Jablko" });
            Task.Run(() => LoadItems());
        }

        public ObservableCollection<ShoppingItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ShoppingItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public string? NewName
        {
            get => _newName;
            set
            {
                _newName = value;
                OnPropertyChanged();
                AddCommand.ChangeCanExecute();
            }
        }

        private async Task LoadItems()
        {
            var items = await _database.GetItemsAsync();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public async Task<int> StoreItemAsync(ShoppingItem item)
        {
            return await _database.StoreItemAsync(item);
        }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

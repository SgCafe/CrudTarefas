using CrudTarefas.Models;
using CrudTarefas.Services;
using CrudTarefas.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudTarefas.Viewmodel
{
    public class ListItemsViewmodel : BaseViewmodel
    {
        #region properties
        public INavigation Navigation;

        private readonly IItemsService _itemsService;

        private ObservableCollection<Item> _itemsList;
        public ObservableCollection<Item> ItemsList
        {
            get => _itemsList;
            set => SetProperty(ref _itemsList, value);
        }


        #endregion

        #region constructor
        public ListItemsViewmodel(INavigation navigation)
        {
            Navigation = navigation;
            _itemsService = new ItemsService();
            LoadItems();
            GoAddItemPageCommand = new Command(ExecuteGoAddItemPageCommand);
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);
        }
        #endregion

        #region commands 
        public ICommand GoAddItemPageCommand { get; set; }
        public ICommand LoadItemsCommand { get; set; }
        #endregion

        #region methods
        private void LoadItems()
        {
            var items = _itemsService.GetAllItems();
            ItemsList = new ObservableCollection<Item>(items);
            

        }

        public void ExecuteLoadItemsCommand()
        {
            var items = _itemsService.GetAllItems();
            ItemsList.Clear();

            foreach (var item in items)
            {
                ItemsList.Add(item);
            }
        }

        private async void ExecuteGoAddItemPageCommand()
        {
            await Navigation.PushAsync(new AddItemPage());
        }

        #endregion
    }
}

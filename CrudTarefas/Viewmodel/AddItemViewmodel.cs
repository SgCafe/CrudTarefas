using CrudTarefas.Models;
using CrudTarefas.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudTarefas.Viewmodel
{
    public class AddItemViewmodel : BaseViewmodel
    {
        #region properties
        public INavigation Navigation { get;}
        private readonly IItemsService _itemsService;

        private string _nameSave;
        public string NameSave
        {
            get => _nameSave;
            set => SetProperty(ref _nameSave, value);
        }

        private string _descriptionSave;
        public string DescriptionSave
        {
            get => _descriptionSave;
            set => SetProperty(ref _descriptionSave, value);
        }

        private string _prioritySave;

        public string PrioritySave
        {
            get => _prioritySave;
            set => SetProperty(ref _prioritySave, value);
        }


        #endregion

        #region constructor
        public AddItemViewmodel(INavigation navigation)
        {
            Navigation = navigation;
            _itemsService = new ItemsService();
            BackProductPageCommand = new Command(ExecuteBackProductPageCommand);
            SaveItemsCommand = new Command(ExecuteSaveItemsCommand);
        }

        #endregion

        #region commands
        public ICommand BackProductPageCommand { get; set; }
        public ICommand SaveItemsCommand { get; set; }
        #endregion

        #region methods

        //Function SaveItems
        private async void ExecuteSaveItemsCommand()
        {
            try
            {

                Item itemSaved = new Item()
                {
                    Name = NameSave,
                    Description = DescriptionSave,
                    ItemPriority = new Priority
                    {
                        PriorityName = PrioritySave,
                        PriorityColor = "#ccc"
                    }
                };

                _itemsService.InsertItem(itemSaved);
                ExecuteBackProductPageCommand();

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void ExecuteBackProductPageCommand()
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}
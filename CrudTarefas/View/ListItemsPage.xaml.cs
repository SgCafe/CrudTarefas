using CrudTarefas.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudTarefas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListItemsPage : ContentPage
    {
        public ListItemsPage()
        {
            InitializeComponent();
            BindingContext = new ListItemsViewmodel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ListItemsViewmodel viewmodel)
            {
                viewmodel.ExecuteLoadItemsCommand();
            }
        }
    }
}
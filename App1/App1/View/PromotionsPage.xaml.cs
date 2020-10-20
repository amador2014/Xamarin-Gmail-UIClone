using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PromotionsPage : ContentPage
    {
        const int duracaoRefresh = 2;

        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

        public bool IsRefreshing{get; set;}
        

        public PromotionsPage()
        {
            InitializeComponent();
        }

        private void OnArchivedSwipeItem(object sender, EventArgs e)
        {
            DisplayAlert("1 Arquivado", "Arquivado comsucesso", "Ok");
        }

         async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(duracaoRefresh));
            IsRefreshing = false;
        }



    


    }
}
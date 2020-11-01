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
    public partial class PromotionsPage : INotifyPropertyChanged
    {
        const int duracaoRefresh = 1;
        public bool IsRefreshing{get; set;}
        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

        

        public PromotionsPage()
        {
            InitializeComponent();
            
        }

        private void OnArchivedSwipeItem(object sender, EventArgs e)
        {
            DisplayAlert("1 Arquivado", "Arquivado com sucesso", "Ok");
        }

         async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(duracaoRefresh));
            IsRefreshing = false;
        }

    }
}
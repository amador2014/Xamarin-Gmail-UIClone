using App1.MenuItems;
using App1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{

    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MainPage : MasterDetailPage
    {
        private List<MasterPageItem> menuList;

        public MainPage()
        {

            InitializeComponent();
            menuList = new List<MasterPageItem>();
            
            var page1 = new MasterPageItem() { Title = "Promotions", Icon = "promotion_icon.png", TargetType = typeof(PromotionsPage) };
            var page2 = new MasterPageItem() { Title = "Social", Icon = "ssocial_icon.png", TargetType = typeof(SocialPage) };
            var page3 = new MasterPageItem() { Title = "Fórums", Icon = "forum_icon.png", TargetType = typeof(ForumPage) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);

            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomeTabbedPage)));

        }

        void Handle_Social(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomeTabbedPage());
        }


        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}

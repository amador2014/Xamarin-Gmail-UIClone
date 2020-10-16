using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        const string texto = "Texto do Dysplay";
        public string DisplayText {get;set;}

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        //Quando o APP é aberto
        protected override void OnStart()
        {
            Console.WriteLine("App Iniciado");

            if (Properties.ContainsKey(texto))
            {
                DisplayText = (string)Properties[texto];
            }
        }

        //Quando o APP vai para segundo plano
        protected override void OnSleep()
        {
            Console.WriteLine("App em segundo plano");
            Properties[texto] = DisplayText;
        }

        //Quando o App volta do segundo plano
        protected override void OnResume()
        {
            Console.WriteLine("App de volta ao primeiro plano");
        }
    }
}

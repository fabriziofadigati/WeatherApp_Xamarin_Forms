using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace WeatherAppForms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.FindByName<Entry>("entry");
            this.FindByName<Button>("button");       

            button.Clicked += Button_Clicked;         

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.entry.Text))
            {
                Navigation.PushAsync(new ResultPage(this.entry.Text));
            }
            else
            {
                DisplayAlert("Errore", "Il campo Città è vuoto", "OK");
            }
            
        }


    }
}

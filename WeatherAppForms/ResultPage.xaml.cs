using System;
using WeatherApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherAppForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {

        public ResultPage(String city)
        {

            InitializeComponent();

            this.FindByName<Label>("temperatura");
            this.FindByName<Label>("vento");
            this.FindByName<Label>("umidità");
            this.FindByName<Label>("visibilità");

            WeatherData w = GetWeatherData.Chiamata(city);

            Double temp = Double.Parse(w.main["temp"]) - 273.15;

            temperatura.Text = Convert.ToString(temp) + " °C";
            vento.Text = w.wind["speed"] + " nodi";
            umidità.Text = w.main["humidity"] + "%";
            visibilità.Text = w.visibility + " metri";


        }

        
    }
}
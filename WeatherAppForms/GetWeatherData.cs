using System;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using Xamarin.Forms;
using WeatherAppForms;

namespace WeatherApp
{
    class GetWeatherData 
    {

        public static WeatherData Chiamata(String city)
        {
            

            try
            {
                var request = HttpWebRequest.Create(Constants.OpenWeatherMapEndpoint + "?q=" + city + "&APPID=" + Constants.OpenWeatherMapAPIKey);
                request.ContentType = "application/json";
                request.Method = "GET";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    
                    App.Current.MainPage.DisplayAlert("Errore", "Città inserita non esistente o errore di connessione", "OK");
                    return null;
                }
                

                StreamReader reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();
                
                if (string.IsNullOrWhiteSpace(content))
                {
                    App.Current.MainPage.DisplayAlert("Errore", "Dati meteo non presenti, riprova più tardi", "OK");
                    return null;
                }
                

                WeatherData w = JsonConvert.DeserializeObject<WeatherData>(content);
                return w;
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Errore", "Errore imprevisto, riprova più tardi", "OK");
                return null;
            }

            

        }
    }
}
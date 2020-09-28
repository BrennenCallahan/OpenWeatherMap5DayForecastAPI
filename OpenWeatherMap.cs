using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace demo.MVC.Models
{
	public class OpenWeatherMap
	{
		public string apiResponse{get;set;}
		public Dictionary<string, string> cities{get;set;} /*dictionary of city keys and values, names HTML buttons, HTML buttons scale with # of values in dictionary */
		
	}
}

namespace demo.MVC.Class
{
	public class OpenWeatherMapApi{}	
	
	
	/* BELOW HERE:
	obtained using the results of 
	api.openweathermap.org/data/2.5/forecast?q=Marlboro&appid=e66de5d17da4399a40f4d71687a52301&cnt=1
	cnt=changeable for # of days, default is 40 so set it to 1
	cnt is actually not straightforward: need to do math on how cnt translates - it is 3 hour periods
	*/
	
    public class Main    {
        public double temp { get; set; } 
        public double feels_like { get; set; } 
        public double temp_min { get; set; } 
        public double temp_max { get; set; } 
        public int pressure { get; set; } 
        public int sea_level { get; set; } 
        public int grnd_level { get; set; } 
        public int humidity { get; set; } 
        public double temp_kf { get; set; } 
    }

    public class Weather    {
        public int id { get; set; } 
        public string main { get; set; } 
        public string description { get; set; } 
        public string icon { get; set; } 
    }

    public class Clouds    {
        public int all { get; set; } 
    }

    public class Wind    {
        public double speed { get; set; } 
        public int deg { get; set; } 
    }

    public class Sys    {
        public string pod { get; set; } 
    }



    public class List    {
        public int dt { get; set; } 
        public Main main { get; set; } 
        public List<Weather> weather { get; set; } 
        public Clouds clouds { get; set; } 
        public Wind wind { get; set; } 
        public int visibility { get; set; } 
        public double pop { get; set; } 
        public Sys sys { get; set; } 
        public string dt_txt { get; set; } 
	
        
    }

    public class Coord    {
        public double lat { get; set; } 
        public double lon { get; set; } 
    }

    public class City    {
        public int id { get; set; } 
        public string name { get; set; } 
        public Coord coord { get; set; } 
        public string country { get; set; } 
        public int population { get; set; } 
        public int timezone { get; set; } 
        public int sunrise { get; set; } 
        public int sunset { get; set; } 
    }

    public class ResponseWeather    {
        public string cod { get; set; } 
        public int message { get; set; } 
        public int cnt { get; set; } 
        public List<List> list { get; set; } 
        public City city { get; set; } 
    }


}

	
	
	
	
	

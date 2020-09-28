using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using demo.MVC.Class;
using demo.MVC.Models;
using System.Linq;
using System.Web;
namespace demo.MVC.Controllers
{

    public class OpenWeatherMapMvcController : Controller
    {
     

        public ActionResult Index()
        {
		
            OpenWeatherMap openWeatherMap = FillCity(); 
            return View(openWeatherMap);
        }

        [HttpPost]
        public ActionResult Index(string cities)
        {

            OpenWeatherMap openWeatherMap = FillCity();

            if (cities != null)
            {
                /*Calling API http://openweathermap.org/api (it is the 5 day forecast API)*/
                string apiKey = "e66de5d17da4399a40f4d71687a52301";
                HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?q="+cities+"&appid="+ apiKey +"&cnt=40"+"&units=imperial") as HttpWebRequest;
                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
                /*End Calling API*/	
				
				/*START OF PRINTING TABLE*/
				/*start of the text into the weather forecast table
				 if-else block determines if * is going to be printed for rain chance. If-elses based on if the weather for the day is rain 
				(rootObject.list[0].weather[0].main)*/
				/* Retrieves temperature from list[x].main.temp */
				/*date time text + day x + temperature F format */
				
				/*so, the API sends 40 cnt for a 5 day forecast, each cnt being 3 hours, so, what were doing here is getting the average temperature for EACH 24 HOUR PERIOD, starting from the first data point, and then adding 8 - 3 hour blocks for a total of 24 hours.*/
				/*the below average variables calculate the average for each 24 hour period, and then we assign them into days 1-5 */
				ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
				double average1=(rootObject.list[0].main.temp+rootObject.list[1].main.temp+rootObject.list[2].main.temp+rootObject.list[3].main.temp+rootObject.list[4].main.temp+rootObject.list[5].main.temp+rootObject.list[6].main.temp+rootObject.list[7].main.temp)/8;
				double average2=(rootObject.list[8].main.temp+rootObject.list[9].main.temp+rootObject.list[10].main.temp+rootObject.list[11].main.temp+rootObject.list[12].main.temp+rootObject.list[13].main.temp+rootObject.list[14].main.temp+rootObject.list[15].main.temp)/8;
				double average3=(rootObject.list[16].main.temp+rootObject.list[17].main.temp+rootObject.list[18].main.temp+rootObject.list[19].main.temp+rootObject.list[20].main.temp+rootObject.list[21].main.temp+rootObject.list[22].main.temp+rootObject.list[23].main.temp)/8;
				double average4=(rootObject.list[24].main.temp+rootObject.list[25].main.temp+rootObject.list[26].main.temp+rootObject.list[27].main.temp+rootObject.list[28].main.temp+rootObject.list[29].main.temp+rootObject.list[30].main.temp+rootObject.list[31].main.temp)/8;
				double average5=(rootObject.list[32].main.temp+rootObject.list[33].main.temp+rootObject.list[34].main.temp+rootObject.list[35].main.temp+rootObject.list[36].main.temp+rootObject.list[37].main.temp+rootObject.list[28].main.temp+rootObject.list[39].main.temp)/8;
                double average=(average1+average2+average3+average4+average5)/5; /*TOTAL 5 DAY AVERAGE*/
			   
				
				StringBuilder sb = new StringBuilder();
                sb.Append("<table><tr><th> Date</th></tr>");
                /* checks IF weather every 3 hours contains rain, if it does, print the statement with the * next to day */
				if(rootObject.list[0].weather[0].main == "Rain" || rootObject.list[1].weather[0].main == "Rain" || rootObject.list[2].weather[0].main == "Rain" || rootObject.list[3].weather[0].main == "Rain" || rootObject.list[4].weather[0].main == "Rain" || rootObject.list[5].weather[0].main == "Rain" || rootObject.list[6].weather[0].main == "Rain" || rootObject.list[7].weather[0].main == "Rain" ){
				sb.Append("<tr><td>"+ rootObject.list[0].dt_txt+"  Day 1*:</td><td>" + String.Format("{0:0.00}", average1)+ "°F</td></tr>");
				}else{
				sb.Append("<tr><td>"+rootObject.list[0].dt_txt+"  Day 1:</td><td>" + String.Format("{0:0.00}", average1)+ "°F</td></tr>");
				}
                if(rootObject.list[8].weather[0].main == "Rain" || rootObject.list[9].weather[0].main == "Rain" || rootObject.list[10].weather[0].main == "Rain" || rootObject.list[11].weather[0].main == "Rain" || rootObject.list[12].weather[0].main == "Rain" || rootObject.list[13].weather[0].main == "Rain" || rootObject.list[14].weather[0].main == "Rain" || rootObject.list[15].weather[0].main == "Rain"){
				sb.Append("<tr><td>"+rootObject.list[8].dt_txt+"  Day 2*:</td><td>" + String.Format("{0:0.00}", average2)+ "°F</td></tr>");
				}else{
				sb.Append("<tr><td>"+rootObject.list[8].dt_txt+"  Day 2:</td><td>" + String.Format("{0:0.00}", average2)+ "°F</td></tr>");
				}
				if(rootObject.list[16].weather[0].main == "Rain" || rootObject.list[17].weather[0].main == "Rain" || rootObject.list[18].weather[0].main == "Rain" || rootObject.list[19].weather[0].main == "Rain" || rootObject.list[20].weather[0].main == "Rain" || rootObject.list[21].weather[0].main == "Rain" || rootObject.list[22].weather[0].main == "Rain" || rootObject.list[23].weather[0].main == "Rain"){
				sb.Append("<tr><td>"+rootObject.list[16].dt_txt+"  Day 3*:</td><td>" + String.Format("{0:0.00}", average3)+ "°F</td></tr>");
				}else{
				sb.Append("<tr><td>"+rootObject.list[16].dt_txt+"  Day 3:</td><td>" + String.Format("{0:0.00}", average3)+ "°F</td></tr>");
				}
				if(rootObject.list[24].weather[0].main == "Rain" || rootObject.list[25].weather[0].main == "Rain" || rootObject.list[26].weather[0].main == "Rain" || rootObject.list[27].weather[0].main == "Rain" || rootObject.list[28].weather[0].main == "Rain" || rootObject.list[29].weather[0].main == "Rain" || rootObject.list[30].weather[0].main == "Rain" || rootObject.list[31].weather[0].main == "Rain"){
				sb.Append("<tr><td>"+rootObject.list[24].dt_txt+"  Day 4*:</td><td>" + String.Format("{0:0.00}", average4)+ "°F</td></tr>");
				}else{
				sb.Append("<tr><td>"+rootObject.list[24].dt_txt+"  Day 4:</td><td>" + String.Format("{0:0.00}", average4)+ "°F</td></tr>");
				}
				if(rootObject.list[32].weather[0].main == "Rain" || rootObject.list[33].weather[0].main == "Rain" || rootObject.list[34].weather[0].main == "Rain" || rootObject.list[35].weather[0].main == "Rain" || rootObject.list[36].weather[0].main == "Rain" || rootObject.list[37].weather[0].main == "Rain" || rootObject.list[38].weather[0].main == "Rain" || rootObject.list[39].weather[0].main == "Rain"){
				sb.Append("<tr><td>"+rootObject.list[32].dt_txt+"  Day 5*:</td><td>" + String.Format("{0:0.00}", average5)+ "°F</td></tr>");
				}else{
				sb.Append("<tr><td>"+rootObject.list[32].dt_txt+"  Day 5:</td><td>" + String.Format("{0:0.00}", average5)+ "°F</td></tr>");
				}
				sb.Append("<tr><td>Averaged Temperature of all 5 days:</td><td>" + String.Format("{0:0.00}", average) + "°F</td></tr>");
					
				/*END OF PRINTING TABLE*/		
                sb.Append("</table>");
                openWeatherMap.apiResponse = sb.ToString();
            }
            else
            {
                if (Request.Form["submit"] != null)
                {
                    openWeatherMap.apiResponse = "Please Select a City";
                }
            }
            return View(openWeatherMap);
        }

        
		
		/*city data for each of the corresponding radio buttons
		first value is going to display as the name
		second value going to be what goes into the API, dont touch unless going to change API*/
		public OpenWeatherMap FillCity()
        {
            OpenWeatherMap openWeatherMap = new OpenWeatherMap();
      openWeatherMap.cities = new Dictionary<string,string>();
      openWeatherMap.cities.Add("Marlboro, MA", "Marlboro");
			openWeatherMap.cities.Add("San Diego, CA", "San Diego");
			openWeatherMap.cities.Add("Cheyenne, WY", "Cheyenne");
			openWeatherMap.cities.Add("Anchorage, AK", "Anchorage");
			openWeatherMap.cities.Add("Austin, TX", "Austin");
			openWeatherMap.cities.Add("Orlando, FL", "Orlando");
			openWeatherMap.cities.Add("Seattle, WA", "Seattle");
			openWeatherMap.cities.Add("Cleveland, OH", "Cleveland");
			openWeatherMap.cities.Add("Portland, ME", "Portland");
			openWeatherMap.cities.Add("Honolulu, HI", "Honolulu");

            return openWeatherMap;
        }
		
		
		
		
		
    }

}

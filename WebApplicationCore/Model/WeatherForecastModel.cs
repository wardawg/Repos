using System;
using WebApplicationCore;

namespace WebApplicationCoreModel
{
    public interface IModelView { }

    public interface ImodelView<T> 
   : IModelView{ }
    public class WeatherForecastModel : ImodelView<WeatherForecast>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }
                
        public string Summary { get; set; }
    }
}

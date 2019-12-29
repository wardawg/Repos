using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Handlers.Handlers.Common;
using ReposServices.SubCategoriesServices;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private ISubCategoriesService _SubCategoriesService;
        private IServiceHandlerFactory _ServiceHandlerFactory;
        public WeatherForecastController(IServiceHandlerFactory ServiceHandlerFactory
                                        , ISubCategoriesService SubCategoriesService
                                        ,ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _SubCategoriesService = SubCategoriesService;
            _ServiceHandlerFactory = ServiceHandlerFactory;
        }

     //   [HttpGet]
        public HttpResponseMessage Get()
        {



            var SubCategory = _SubCategoriesService.GetById(24);


            _SubCategoriesService.Add(SubCategory);
            ////   var ModelState = new ModelStateDictionary();

            var client = _ServiceHandlerFactory
                                      .Using<IClientRefInfoHandler>()
                                      .Get().Where(w => w.Id == 1).FirstOrDefault();



            if (_SubCategoriesService.Verify(ModelState, client).IsSuccess)

            {
                //
            }

            var resp = new HttpResponseMessage()
            {
                Content = new StringContent(string.Join("", "dd"))
              ,StatusCode = HttpStatusCode.BadRequest
            };


            return  resp;

            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}

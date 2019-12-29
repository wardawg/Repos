using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.Interfaces.Filter;
using ReposServiceConfigurations.ServiceTypes.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;
//using WebApi.Base;
//using WebApi.Validation;
using Newtonsoft.Json.Linq;
//using WebApi.Models;
using RepoUnitTest.Utilities;
using Repos.DomainModel.Interface.DomainViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RepoUnitTest.Controllers
{
    class TestWebController : Controller


    {

        public TestWebController(
                                       IServiceHandlerFactory ServiceHandlerFactory
                                     , IRule RuleFactory
                                     , IFilterFactory FilterFactory
                                     , ICommonInfo CommonInfo
                                    ) 
                                  //: base(ServiceHandlerFactory
                                  //      , RuleFactory
                                  //      , FilterFactory
                                  //      , CommonInfo
                                  //      , null)
        {




        }



        //public bool TestJsonParsing<TViewModel>(JObject jsonbody)
        //    where TViewModel : class,IDomainViewModel
        //{
                       
        //    TViewModel ViewModel =  ParsePostBody<TViewModel>(jsonbody);

        //    List<ValidationResults> results = new List<ValidationResults>();

        //    results = isModelValid(ViewModel, Streamer.GenerateStreamFromString(jsonbody.ToString()));
            
        //    return results.Any();
          
        //}

     }
}

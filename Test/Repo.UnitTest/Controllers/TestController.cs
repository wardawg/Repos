using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.Interfaces.Filter;
//using ReposAdmin.Controllers;
using ReposServiceConfigurations.ServiceTypes.Rules;
using System.Web.Http;
using System.Web.Mvc;

namespace RepoUnitTest.Controllers
{
    class TestController : Controller
    {
        public TestController(IServiceHandlerFactory ServiceHandlerFactory  
                            , IFilterFactory FilterFactory
                            , IRule RulesFactor
                            , ICommonInfo CommonInfo) 
          ///  : base(ServiceHandlerFactory, FilterFactory, RulesFactor, CommonInfo)
        {
        }

        public ActionResult Create()
        {

            //SubCategoryModel model = _SubCategoriesService.CreateServiceEntity().ToModel();
            //model.SubCategoryTypeModel = _SubCategoryTypeService.CreateServiceEntity().ToModel();

            //GetCategoriesForModel(model, "Category Type");
            //model.AvailableCategoryTypes = AvailableCategoryFilter(model, "Sub Category Type");

            //ApplyViewModelRules(model);

            //    return View(model);
            return View();
        }

        public ActionResult Validate(IBaseViewModelRule model)
        {
            TryValidateModel(model);
            return View();
        }
    }
}

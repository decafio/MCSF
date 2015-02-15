using System.Web.Mvc;

namespace MCSF.Areas.MainPage
{
    public class MainPageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MainPage";
            }
        }

        // Routes the root to the MainPage Area
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MainPage_default",
                "{action}/{id}",
                new { area = "MainPAGE", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

namespace Goodstub.Web.Attributes
{
    public class ErrorAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                filterContext.ExceptionHandled = true;

            }
            base.OnException(filterContext);
        }
    }
}

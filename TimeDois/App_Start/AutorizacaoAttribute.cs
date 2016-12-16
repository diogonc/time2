using System.Web.Mvc;

namespace TimeDois
{
    public sealed class AutorizacaoAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["Login"] == null && (string)filterContext.RouteData.Values["controller"] != "Login") // TODO: Tentativa de correção do erro de objeto nulo em produção 
                filterContext.Result = new RedirectResult("~/");
        }
    }
}
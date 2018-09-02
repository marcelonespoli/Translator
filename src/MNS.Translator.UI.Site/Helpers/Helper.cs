using System.Linq;
using System.Web.Mvc;

namespace MNS.Translator.UI.Site.Helpers
{
    public class Helper
    {
        public static string GetModelErrors(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(x => x.Errors).ToArray();

            string message = "";
            foreach (ModelError error in errors)
                message += error.ErrorMessage + "<br />";

            return message;
        }
    }
}
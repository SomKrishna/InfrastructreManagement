using System.Web.UI;

namespace InfrastructureManagement.Common
{
    public static class Alert
    {
        public static void ShowAlert(Page p, string Class, string Message)
        {
            ScriptManager.RegisterStartupScript(p, p.GetType(), "Key", "customAlert('" + Class.ToUpper() + "','" + Message + "');", true);
        }
    }
}
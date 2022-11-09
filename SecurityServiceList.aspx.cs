using System;
using WebServices;

namespace InfrastructureManagement
{
    public partial class SecurityServiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = ODataServices.GetSecurityServiceList();
            SecurityServiceListView.DataSource = result;
            SecurityServiceListView.DataBind();
        }
    }
}
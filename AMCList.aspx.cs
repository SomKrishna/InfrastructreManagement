using System;
using WebServices;

namespace InfrastructureManagement
{
    public partial class AMCList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = ODataServices.GetAMCList();
            SecurityServiceListView.DataSource = result;
            SecurityServiceListView.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LittleThingsWebsite
{
    public partial class _Default : Page
    {
        Models.LittleThingsRepository Repository = new Models.LittleThingsRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}
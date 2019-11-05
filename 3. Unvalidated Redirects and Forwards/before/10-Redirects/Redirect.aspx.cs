using System;
using System.Web.UI;

namespace _10_Redirects
{
  public partial class Redirect : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var url = Request.QueryString["url"];
      
      // ToDo: Log exit here.

      Response.Redirect(url);
    }
  }
}
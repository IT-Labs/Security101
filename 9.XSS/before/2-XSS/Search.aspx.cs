using System;
using System.Linq;

namespace _2_XSS
{
  public partial class Search : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var searchTerm = Request.QueryString["q"];
      SearchTerm.Text = searchTerm;
      var products = new Product().GetSampleProductList();

      SearchGrid.DataSource = products.Where(p => p.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
      SearchGrid.DataBind();
    }
  }
}
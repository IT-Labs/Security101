﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _9_tls
{
  public partial class TestSSL : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Request.IsSecureConnection)
      {
        var secureUrl = Request.Url.ToString().Replace("http://", "https://");
        Response.RedirectPermanent(secureUrl);
      }
    }
  }
}
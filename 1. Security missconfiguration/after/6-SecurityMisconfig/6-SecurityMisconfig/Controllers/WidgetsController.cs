using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_SecurityMisconfig.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: Widgets
        public ActionResult Index()
        {
            var model = new List<WidgetDto>();

            var categoryId = Request.QueryString["CategoryId"];
            var categoryIdInt = Int64.Parse(categoryId);

            var typeId = Request.QueryString["TypeId"];
            var typeIdInt = string.IsNullOrEmpty(typeId) ? 1 : Int64.Parse(typeId);

            const string connString = "Data Source=ITLabs-SQL2017;Initial Catalog=6-SecurityMisconfig;User Id=6-SecurityMisconfig-User;Password=qc9yFUrYyWiLx80ZFlgj";
            const string sqlString = "SELECT * FROM Widget WHERE CategoryId = @CategoryId AND TypeId = @TypeId";
            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(sqlString, conn))
                {
                    command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryIdInt;
                    command.Parameters.Add("@TypeId", SqlDbType.Int).Value = typeIdInt;
                    command.Connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new WidgetDto
                            {
                                Id = Convert.ToInt32(reader[0]),
                                Name = reader[1]?.ToString(),
                                CategoryId = Convert.ToInt32(reader[2] ?? ""),
                                TypeId = Convert.ToInt32(reader[3])
                            });
                        }
                    }
                }
            }

            Trace.TraceWarning("All data successfully loaded using conn string " + connString);
            return View(model);
        }
    }
}
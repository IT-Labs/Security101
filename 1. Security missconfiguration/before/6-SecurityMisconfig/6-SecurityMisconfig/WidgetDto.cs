using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6_SecurityMisconfig
{
    public class WidgetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int TypeId { get; set; }
    }
}
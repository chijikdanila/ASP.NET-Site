using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB_953502_CHIZHIK.Controllers
{
    public class HomeController : Controller
    {
        private List<ListDemo> _listDemo;
        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Item 3"},
                new ListDemo{ ListItemValue=4, ListItemText="Item 4"},
                new ListDemo{ ListItemValue=5, ListItemText="Item 5"}
            };
        }

        public class ListDemo
        {
            public int ListItemValue { get; set; }
            public string ListItemText { get; set; }
        }

        public IActionResult Index()
        {
            ViewData["Lst"] =  new SelectList(_listDemo, "ListItemValue", "ListItemText");
            ViewData["Message"] = "Лабораторная работа №2";
            return View();
        }
    }
}

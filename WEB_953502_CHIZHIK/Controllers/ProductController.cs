using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHIZHIK.Entities;
using WEB_953502_CHIZHIK.Extensions;
using WEB_953502_CHIZHIK.Models;
using WEB_953502_CHIZHIK.Data;
using Microsoft.Extensions.Logging;

namespace WEB_953502_CHIZHIK.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;

        int _pageSize;
        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{page}")]
        public IActionResult Index(int? group, int page = 1)
        {
            var booksFiltered = _context.Books.Where(d => !group.HasValue || d.BookGroupId == group.Value);

            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.BookGroups;

            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Book>.GetModel(booksFiltered, page, _pageSize);

            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}

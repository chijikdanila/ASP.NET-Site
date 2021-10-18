using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953502_CHIZHIK.Data;
using WEB_953502_CHIZHIK.Entities;

namespace WEB_953502_CHIZHIK.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WEB_953502_CHIZHIK.Data.ApplicationDbContext _context;

        public IndexModel(WEB_953502_CHIZHIK.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Group).ToListAsync();
        }
    }
}

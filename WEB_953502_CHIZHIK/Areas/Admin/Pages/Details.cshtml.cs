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
    public class DetailsModel : PageModel
    {
        private readonly WEB_953502_CHIZHIK.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_953502_CHIZHIK.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Group).FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

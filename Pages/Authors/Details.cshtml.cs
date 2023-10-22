using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stoica_Alexandru_Lab2.Data;
using Stoica_Alexandru_Lab2.Models;

namespace Stoica_Alexandru_Lab2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Stoica_Alexandru_Lab2.Data.Stoica_Alexandru_Lab2Context _context;

        public DetailsModel(Stoica_Alexandru_Lab2.Data.Stoica_Alexandru_Lab2Context context)
        {
            _context = context;
        }

      public Author Author { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }
    }
}

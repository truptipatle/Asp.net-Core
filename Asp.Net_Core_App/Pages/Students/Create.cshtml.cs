using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asp.Net_Core_App.Data;
using Asp.Net_Core_App.Model;

namespace Asp.Net_Core_App.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly Asp.Net_Core_App.Data.AspNet_Core_AppContext _context;

        public CreateModel(Asp.Net_Core_App.Data.AspNet_Core_AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentReg StudentReg { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentReg.Add(StudentReg);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

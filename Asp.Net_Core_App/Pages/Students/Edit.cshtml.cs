using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.Net_Core_App.Data;
using Asp.Net_Core_App.Model;

namespace Asp.Net_Core_App.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly Asp.Net_Core_App.Data.AspNet_Core_AppContext _context;

        public EditModel(Asp.Net_Core_App.Data.AspNet_Core_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentReg StudentReg { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentreg =  await _context.StudentReg.FirstOrDefaultAsync(m => m.Id == id);
            if (studentreg == null)
            {
                return NotFound();
            }
            StudentReg = studentreg;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentRegExists(StudentReg.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentRegExists(int id)
        {
            return _context.StudentReg.Any(e => e.Id == id);
        }
    }
}

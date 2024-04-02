﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asp.Net_Core_App.Data;
using Asp.Net_Core_App.Model;

namespace Asp.Net_Core_App.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly Asp.Net_Core_App.Data.AspNet_Core_AppContext _context;

        public DeleteModel(Asp.Net_Core_App.Data.AspNet_Core_AppContext context)
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

            var studentreg = await _context.StudentReg.FirstOrDefaultAsync(m => m.Id == id);

            if (studentreg == null)
            {
                return NotFound();
            }
            else
            {
                StudentReg = studentreg;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentreg = await _context.StudentReg.FindAsync(id);
            if (studentreg != null)
            {
                StudentReg = studentreg;
                _context.StudentReg.Remove(StudentReg);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

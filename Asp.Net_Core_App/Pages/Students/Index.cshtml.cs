using System;
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
    public class IndexModel : PageModel
    {
        private readonly Asp.Net_Core_App.Data.AspNet_Core_AppContext _context;

        public IndexModel(Asp.Net_Core_App.Data.AspNet_Core_AppContext context)
        {
            _context = context;
        }

        public IList<StudentReg> StudentReg { get;set; } = default!;

        public async Task OnGetAsync()
        {
            StudentReg = await _context.StudentReg.ToListAsync();
        }
    }
}

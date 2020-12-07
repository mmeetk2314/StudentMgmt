using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentMgmt.Data;
using StudentMgmt.Models;

namespace StudentMgmt.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly StudentMgmt.Data.StudentMgmtContext _context;

        public IndexModel(StudentMgmt.Data.StudentMgmtContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Course.ToListAsync();
        }
    }
}

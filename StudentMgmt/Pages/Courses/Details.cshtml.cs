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
    public class DetailsModel : PageModel
    {
        private readonly StudentMgmt.Data.StudentMgmtContext _context;

        public DetailsModel(StudentMgmt.Data.StudentMgmtContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Course.FirstOrDefaultAsync(m => m.course_ID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

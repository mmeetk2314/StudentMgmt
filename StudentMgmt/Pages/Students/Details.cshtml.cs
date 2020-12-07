using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentMgmt.Data;
using StudentMgmt.Models;

namespace StudentMgmt.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly StudentMgmt.Data.StudentMgmtContext _context;

        public DetailsModel(StudentMgmt.Data.StudentMgmtContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.FirstOrDefaultAsync(m => m.student_ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

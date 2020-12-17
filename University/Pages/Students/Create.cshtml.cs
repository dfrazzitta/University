﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using University.Data;
using University.Models;
using University.ViewModels;

namespace University.Pages.Students
{
    public class CreateVMModel : PageModel
    {
        private readonly University.Data.UniversityContext _context;

        public CreateVMModel(University.Data.UniversityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        //[BindProperty]
        //public Student Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Students.Add(Student);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var emptyStudent = new Student();

        //    if (await TryUpdateModelAsync<Student>(
        //        emptyStudent,
        //        "student",   // Prefix for form value.
        //        s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
        //    {
        //        _context.Students.Add(emptyStudent);
        //        await _context.SaveChangesAsync();
        //        return RedirectToPage("./Index");
        //    }

        //    return Page();
        //}

        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

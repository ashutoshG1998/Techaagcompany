using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.Repository.Implementation
{
   
    public class StudentRepo : IstudentRepo
    {
        private ApplicationDbContext _Context;

        public StudentRepo(ApplicationDbContext context)
        {
            _Context = context;
        }

        public  async Task Edit(Student student)
        {
           _Context.Students.Update(student);
           await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
          return await _Context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            var student= await _Context.Students.FindAsync(id);
            return student;
        }
        public async Task RemoveData(Student student)
        {
           _Context.Students.Remove(student);
            await _Context.SaveChangesAsync();
        }

        public async Task save(Student student)
        {
            await _Context.AddAsync(student);
            await _Context.SaveChangesAsync();
        }
    }
}

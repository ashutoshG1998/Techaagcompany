using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;
using TechAgCompany.UI.ViewModel.SkillViewModel;
using TechAgCompany.UI.ViewModel.StudentViewModel;

namespace TechAgCompany.UI.Controllers
{
    public class StudentController : Controller
    {

        private readonly IstudentRepo _Student;

        public StudentController(IstudentRepo student)
        {
            _Student = student;
        }

        public async Task<IActionResult> Index()
        {

            List<StudentViewModel> cvm = new List<StudentViewModel>();
            var students = await _Student.GetAll();

            foreach (var student in students)
            {
                cvm.Add(new StudentViewModel { Id = student.Id, Name = student.Name });
            }
            return View(cvm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
            var student = new Student
            {
                Id = vm.Id,
                Name = vm.Name,
            };
            await _Student.save(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _Student.GetById(id);
            
                StudentViewModel cvm = new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                };
            
            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel vm)
        {
            Student country = new Student()
            {
                Id = vm.Id,
                Name = vm.Name
            };
            await _Student.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> Delete(Country country)
        {
            var skill = await _Student.GetById(country.Id);
            await _Student.RemoveData(skill);
            return RedirectToAction("Index");
        }
    }
}

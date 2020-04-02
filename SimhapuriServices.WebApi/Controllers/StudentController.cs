using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimhapuriServices.WebApi.IServices;
using SimhapuriServices.WebApi.Models;

namespace SimhapuriServices.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("{searchString}")]
        public ActionResult<Student> GetStudent(string searchString)
        {
            var students = _studentService.SearchStudents(searchString);
            return Ok(students);
        }
    }
}
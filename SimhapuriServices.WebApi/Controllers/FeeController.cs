using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimhapuriServices.WebApi.IServices;
using SimhapuriServices.WebApi.Models;

namespace SimhapuriServices.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeeController : ControllerBase
    {
        private readonly ILogger<FeeController> _logger;
        private IFeeService _feeService;
        private IStudentService _studentService;

        public FeeController(ILogger<FeeController> logger, IFeeService feeService, IStudentService studentService)
        {
            _logger = logger;
            _feeService = feeService;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("{admissionNumber}")]
        public ActionResult<Fee> GetFee(string admissionNumber)
        {
            var student = _studentService.GetStudent(admissionNumber);
            var feeDetail = _feeService.GetFeeByStudent(admissionNumber);
            feeDetail.Student = student;
            return Ok(feeDetail);
        }

        [HttpGet]
        [Route("FeesForAllStudentsByClass")]
        public ActionResult<Fee> GetFeesForAllStudentsByClass()
        {
            var feesForAllStudentsByClass = _feeService.GetFeesForAllStudentsByClass();
            return Ok(feesForAllStudentsByClass);
        }
    }
}
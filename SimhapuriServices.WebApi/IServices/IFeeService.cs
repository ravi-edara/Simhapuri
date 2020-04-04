using System.Collections.Generic;
using SimhapuriServices.WebApi.Models;

namespace SimhapuriServices.WebApi.IServices
{
    public interface IFeeService
    {
        Fee GetFeeByStudent(string admissionNumber);

        IEnumerable<FeesForAllStudentsByClass> GetFeesForAllStudentsByClass();
    }
}
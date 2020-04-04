using System.Collections.Generic;
using SimhapuriServices.WebApi.Models;

namespace SimhapuriServices.WebApi.IServices
{
    public interface ISharedService
    {
        IEnumerable<Student> GetAllStudents();

        IEnumerable<FeeDto> GetAllFees();

        IEnumerable<ClassDto> GetAllClass();

        IEnumerable<StudentClassDto> GetAllStudentClass();

        IEnumerable<FeeTerm> GetAllFeeTerms();
    }
}
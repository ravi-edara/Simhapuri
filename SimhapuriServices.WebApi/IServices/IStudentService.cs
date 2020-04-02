using System.Collections.Generic;
using SimhapuriServices.WebApi.Models;

namespace SimhapuriServices.WebApi.IServices
{
    public interface IStudentService
    {
        Student GetStudent(string admissionNumber);

        IEnumerable<Student> SearchStudents(string searchString);
    }
}
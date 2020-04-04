using CsvHelper;
using SimhapuriServices.WebApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using SimhapuriServices.WebApi.IServices;
using Microsoft.AspNetCore.Hosting;

namespace SimhapuriServices.WebApi.Services
{
    public class SharedService : ISharedService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public SharedService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/Student.csv"))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                students = csv.GetRecords<Student>().ToList();
            }

            return students;
        }

        public IEnumerable<ClassDto> GetAllClass()
        {
            List<ClassDto> classes = new List<ClassDto>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/Class.csv"))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                classes = csv.GetRecords<ClassDto>().ToList();
            }

            return classes;
        }

        public IEnumerable<StudentClassDto> GetAllStudentClass()
        {
            List<StudentClassDto> studentClasses = new List<StudentClassDto>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/StudentClass.csv"))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                studentClasses = csv.GetRecords<StudentClassDto>().ToList();
            }

            return studentClasses;
        }

        public IEnumerable<FeeTerm> GetAllFeeTerms()
        {
            List<FeeTerm> feeTerms = new List<FeeTerm>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/FeeTerm.csv"))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                feeTerms = csv.GetRecords<FeeTerm>().ToList();
            }

            return feeTerms;
        }

        public IEnumerable<FeeDto> GetAllFees()
        {
            List<FeeDto> fees = new List<FeeDto>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/Fee.csv"))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                fees = csv.GetRecords<FeeDto>().ToList();
            }

            return fees;
        }
    }
}
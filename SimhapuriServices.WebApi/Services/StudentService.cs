﻿using CsvHelper;
using SimhapuriServices.WebApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using SimhapuriServices.WebApi.IServices;
using Microsoft.AspNetCore.Hosting;

namespace SimhapuriServices.WebApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public StudentService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public Student GetStudent(string admissionNumber)
        {
            List<Student> students = new List<Student>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/Student.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                students = csv.GetRecords<Student>().ToList();
            }

            if (students != null && students.Any())
            {
                var student = students.FirstOrDefault(x => x.AdmissionNumber == admissionNumber);
                return student;
            }

            return null;
        }

        public IEnumerable<Student> SearchStudents(string searchString)
        {
            List<Student> students = new List<Student>();
            IEnumerable<Student> returnStudents = new List<Student>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/Student.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                students = csv.GetRecords<Student>().ToList();
            }

            if (students != null && students.Any())
            {
                returnStudents = students.Where(x => x.AdmissionNumber.Contains(searchString)
                                                                     || x.FirstName.ToLower().Contains(searchString.ToLower())
                                                                     || x.LastName.Contains(searchString));
            }

            return returnStudents;
        }
    }
}
using CsvHelper;
using SimhapuriServices.WebApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SimhapuriServices.WebApi.IServices;

namespace SimhapuriServices.WebApi.Services
{
    public class FeeService : IFeeService
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        private ISharedService _sharedService;

        public FeeService(IMapper mapper, IHostingEnvironment hostingEnvironment, ISharedService sharedService)
        {
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _sharedService = sharedService;
        }

        public Fee GetFeeByStudent(string admissionNumber)
        {
            Fee feeDetail = new Fee();
            //List<FeeDto> fees = new List<FeeDto>();

            //using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/fee.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    fees = csv.GetRecords<FeeDto>().ToList();
            //}

            //if (fees != null && fees.Any() && fees.Any(x => x.AdmissionNumber == admissionNumber))
            //{
            //    feeDetail = _mapper.Map<FeeDto, Fee>(fees.FirstOrDefault(x => x.AdmissionNumber == admissionNumber));
            //    var feesByAdmissionNumber = fees.Where(x => x.AdmissionNumber == admissionNumber);

            //    if (feesByAdmissionNumber != null && feesByAdmissionNumber.Any())
            //    {
            //        feeDetail.FeePaid = feesByAdmissionNumber.Select(x => x.FeePaid).Sum();
            //    }

            //    feeDetail.LastFeePaidDate = fees.Where(x => x.AdmissionNumber == admissionNumber)
            //        .OrderByDescending(x => x.FeePaidDate).Select(x => x.FeePaidDate).FirstOrDefault();
            //}
            return feeDetail;
        }

        public IEnumerable<FeesForAllStudentsByClass> GetFeesForAllStudentsByClass()
        {
            List<FeesForAllStudentsByClass> feesForAllStudentsByClass = new List<FeesForAllStudentsByClass>();

            var allStudents = _sharedService.GetAllStudents();
            var allClasses = _sharedService.GetAllClass();
            var allStudentClasses = _sharedService.GetAllStudentClass();
            var allFeeTerms = _sharedService.GetAllFeeTerms();
            var allFees = _sharedService.GetAllFees();

            // Need ClassName, NoOfStudents, TotalFee, TotalFeePaid, TotalFeeBalance

            // Per class hw many students.
            var studentsPerClass = allStudentClasses.Where(x => x.IsActive).GroupBy(x => x.ClassId)
                .OrderBy(x => x.Key);

            if (studentsPerClass != null && studentsPerClass.Any())
            {
                foreach (var item in studentsPerClass)
                {
                    FeesForAllStudentsByClass itemToAdd = new FeesForAllStudentsByClass();
                    var currentClass = allClasses.First(x => x.Id == item.Key);
                    itemToAdd.ClassName = currentClass.Name;
                    itemToAdd.NoOfStudents = item.Count();
                    itemToAdd.TotalFee = item.Sum(x => x.FeeAgreed);
                    var studentClassIdSet = item.Select(x => x.Id);
                    itemToAdd.TotalFeePaid = allFees.Where(x => studentClassIdSet.Contains(x.StudentClassId)).Sum(x => x.FeePaid);
                    itemToAdd.TotalFeeBalance = itemToAdd.TotalFee - itemToAdd.TotalFeePaid;
                    feesForAllStudentsByClass.Add(itemToAdd);
                }
            }
            return feesForAllStudentsByClass;
        }
    }
}
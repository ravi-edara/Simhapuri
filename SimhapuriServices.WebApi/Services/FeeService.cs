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

        public FeeService(IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public Fee GetFeeByStudent(string admissionNumber)
        {
            Fee feeDetail = new Fee();
            List<FeeDto> fees = new List<FeeDto>();

            using (var reader = new StreamReader(_hostingEnvironment.WebRootPath + "/fee.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                fees = csv.GetRecords<FeeDto>().ToList();
            }

            if (fees != null && fees.Any() && fees.Any(x => x.AdmissionNumber == admissionNumber))
            {
                feeDetail = _mapper.Map<FeeDto, Fee>(fees.FirstOrDefault(x => x.AdmissionNumber == admissionNumber));
                var feesByAdmissionNumber = fees.Where(x => x.AdmissionNumber == admissionNumber);

                if (feesByAdmissionNumber != null && feesByAdmissionNumber.Any())
                {
                    feeDetail.FeePaid = feesByAdmissionNumber.Select(x => x.FeePaid).Sum();
                }

                feeDetail.LastFeePaidDate = fees.Where(x => x.AdmissionNumber == admissionNumber)
                    .OrderByDescending(x => x.FeePaidDate).Select(x => x.FeePaidDate).FirstOrDefault();
            }
            return feeDetail;
        }
    }
}
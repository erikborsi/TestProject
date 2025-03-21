using ExerciseApp.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseApp.Services
{
    public class QuoteService
    {
        public QuoteDetail GetQuoteDetail()
        {
            var quoteDetail = new QuoteDetail();

            quoteDetail.Makes.Add("Ford");
            quoteDetail.Makes.Add("Audi");
            quoteDetail.Makes.Add("BMW");

            var modelSpec = new ModelSpec { Make = "Ford" };
            modelSpec.Models.AddRange(new []{ "Fiesta", "Focus", "Puma", "S Max" });
            quoteDetail.Models.Add(modelSpec);

            modelSpec = new ModelSpec { Make = "Audi" };
            modelSpec.Models.AddRange(new[] { "A3", "A4", "A5" });
            quoteDetail.Models.Add(modelSpec);

            /* misspelled BMW */
            modelSpec = new ModelSpec { Make = "BMW" };
            modelSpec.Models.AddRange(new[] { "X5", "3 Series", "5 Series" });
            quoteDetail.Models.Add(modelSpec);

            return quoteDetail;
        }

        public decimal PerformQuote(QuoteRequest request)
        {   
            /* calculates the age from the input date and today's date */
            DateTime dateOfBirth = (DateTime)request.DateOfBirth;
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
                        
            if (age >= 17 && age <= 80)
            {
                if (request.InsuranceType == InsuranceType.itFullyComprehensive)
                {
                    if (request.Make == "Ford")
                        return 200;
                    if (request.Make == "BMW")
                    {
                        if (request.Model == "X5")
                            return 500;
                        else
                            return 400;
                    }
                    return 300;
                }
                if (request.InsuranceType == InsuranceType.itThirdPartyFireAndTheft) {
                    if (request.Make == "Ford")
                        return 180;
                    if (request.Make == "BMW")
                    {
                        if (request.Model == "X5")
                            return 510;
                        else
                            return 400;
                    }
                    return 300;
                }
                if (request.InsuranceType == InsuranceType.itThirdPartyOnly)
                {
                    if (request.Make == "Ford")
                        return 180;
                    if (request.Make == "Audi")
                    {
                        return 250;
                    }
                    return 300;
                }
                return 0;
            }
            return 0;

        }
    }
}

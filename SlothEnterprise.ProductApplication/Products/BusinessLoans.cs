using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Factories;

namespace SlothEnterprise.ProductApplication.Products
{
    public class BusinessLoans : IProduct
    {
        public int Id { get; set; }
        /// <summary>
        /// Per annum interest rate
        /// </summary>
        public decimal InterestRatePerAnnum { get; set; }

        /// <summary>
        /// Total available amount to withdraw
        /// </summary>
        public decimal LoanAmount { get; set; }


        private readonly IBusinessLoansService _businessLoansService;
        public BusinessLoans(IBusinessLoansService businessLoansService)
        {
            _businessLoansService = businessLoansService;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var result = _businessLoansService.SubmitApplicationFor(
                CompanyDataRequestFactory.BuildCompanyData(application),
                LoanRequestFactory.BuildLoanRequest(this));

            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}
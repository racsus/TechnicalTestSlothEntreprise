using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication.Factories
{
    public static class LoanRequestFactory
    {
        public static LoansRequest BuildLoanRequest(BusinessLoans loans)
        {
            var res = new LoansRequest
            {
                InterestRatePerAnnum = loans.InterestRatePerAnnum,
                LoanAmount = loans.LoanAmount
            };

            return res;
        }
    }
}

using System;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Factories;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService
    {
        public int SubmitApplicationFor(ISellerApplication application)
        {
            if ((application == null) || (application.Product == null))
            {
                throw new ArgumentNullException();
            }

            return application.Product.SubmitApplicationFor(application);
        }

        //public int SubmitApplicationFor(ISellerApplication application)
        //{

        //    if (application.Product is SelectiveInvoiceDiscount sid)
        //    {
        //        return _selectInvoiceService.SubmitApplicationFor(application.CompanyData.Number.ToString(), sid.InvoiceAmount, sid.AdvancePercentage);
        //    }

        //    if (application.Product is ConfidentialInvoiceDiscount cid)
        //    {
        //        var result = _confidentialInvoiceWebService.SubmitApplicationFor(
        //            new CompanyDataRequest
        //            {
        //                CompanyFounded = application.CompanyData.Founded,
        //                CompanyNumber = application.CompanyData.Number,
        //                CompanyName = application.CompanyData.Name,
        //                DirectorName = application.CompanyData.DirectorName
        //            }, cid.TotalLedgerNetworth, cid.AdvancePercentage, cid.VatRate);

        //        return (result.Success) ? result.ApplicationId ?? -1 : -1;
        //    }

        //    if (application.Product is BusinessLoans loans)
        //    {
        //        var result = _businessLoansService.SubmitApplicationFor(new CompanyDataRequest
        //        {
        //            CompanyFounded = application.CompanyData.Founded,
        //            CompanyNumber = application.CompanyData.Number,
        //            CompanyName = application.CompanyData.Name,
        //            DirectorName = application.CompanyData.DirectorName
        //        }, new LoansRequest
        //        {
        //            InterestRatePerAnnum = loans.InterestRatePerAnnum,
        //            LoanAmount = loans.LoanAmount
        //        });
        //        return (result.Success) ? result.ApplicationId ?? -1 : -1;
        //    }

        //    throw new InvalidOperationException();
        //}
    }
}

using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SlothEnterprise.ProductApplication.Factories
{
    public static class CompanyDataRequestFactory
    {
        public static CompanyDataRequest BuildCompanyData(ISellerApplication application)
        {
            var res = new CompanyDataRequest
            {
                CompanyFounded = application.CompanyData.Founded,
                CompanyNumber = application.CompanyData.Number,
                CompanyName = application.CompanyData.Name,
                DirectorName = application.CompanyData.DirectorName
            };

            return res;
        }
    }
}

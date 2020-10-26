using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Factories;

namespace SlothEnterprise.ProductApplication.Products
{
    public class ConfidentialInvoiceDiscount : IProduct
    {
        public int Id { get; set; }
        public decimal TotalLedgerNetworth { get; set; }
        public decimal AdvancePercentage { get; set; }
        public decimal VatRate { get; set; } = VatRates.UkVatRate;

        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        public ConfidentialInvoiceDiscount(IConfidentialInvoiceService confidentialInvoiceWebService)
        {
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(CompanyDataRequestFactory.BuildCompanyData(application),
                this.TotalLedgerNetworth, this.AdvancePercentage, this.VatRate);

            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }

    }
}
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Products
{
    public class SelectiveInvoiceDiscount : IProduct
    {
        public int Id { get; set; }
        /// <summary>
        /// Proposed networth of the Invoice
        /// </summary>
        public decimal InvoiceAmount { get; set; }
        /// <summary>
        /// Percentage of the networth agreed and advanced to seller
        /// </summary>
        public decimal AdvancePercentage { get; set; } = 0.80M;

        private readonly ISelectInvoiceService _selectInvoiceService;
        public SelectiveInvoiceDiscount(ISelectInvoiceService selectInvoiceService)
        {
            _selectInvoiceService = selectInvoiceService;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            return _selectInvoiceService.SubmitApplicationFor(application.CompanyData.Number.ToString(), this.InvoiceAmount, this.AdvancePercentage);
        }
    }
}
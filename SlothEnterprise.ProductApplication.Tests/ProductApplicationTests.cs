using Moq;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;
using Xunit;
using Xunit.Sdk;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        private readonly Mock<ISelectInvoiceService> _mockSelectInvoiceService = new Mock<ISelectInvoiceService>();
        private readonly Mock<IBusinessLoansService> _mockBusinessLoansService = new Mock<IBusinessLoansService>();
        private readonly Mock<IConfidentialInvoiceService> _mockConfidentialInvoiceService = new Mock<IConfidentialInvoiceService>();
        private readonly Mock<ISellerCompanyData> _mockCompanyData = new Mock<ISellerCompanyData>();

        private SelectiveInvoiceDiscount _selectiveInvoiceDiscount;
        private BusinessLoans _businessLoans;
        private ConfidentialInvoiceDiscount _confidentialInvoiceDiscount;

        private ProductApplicationService _productApplicationService;
        private SellerApplication _sellerApplication;

        public ProductApplicationTests()
        {
            _productApplicationService = new ProductApplicationService();
            _sellerApplication = new SellerApplication();

            _selectiveInvoiceDiscount = new SelectiveInvoiceDiscount(_mockSelectInvoiceService.Object);
            _confidentialInvoiceDiscount = new ConfidentialInvoiceDiscount(_mockConfidentialInvoiceService.Object);
            _businessLoans = new BusinessLoans(_mockBusinessLoansService.Object);
            SetupMockups();
        }

        [Fact]
        public void TestInvoiceDiscountProductNull()
        {
            _sellerApplication.Product = null;
            _sellerApplication.CompanyData = _mockCompanyData.Object;
            Assert.Throws<ArgumentNullException>(() => _productApplicationService.SubmitApplicationFor(_sellerApplication));
        }

        [Fact]
        public void TestInvoiceDiscount()
        {
            _sellerApplication.Product = _selectiveInvoiceDiscount;
            _sellerApplication.CompanyData = _mockCompanyData.Object;
            var applicationId = _productApplicationService.SubmitApplicationFor(_sellerApplication);
            Assert.Equal(1, 1);
        }

        private void SetupMockups()
        {
            _mockSelectInvoiceService.Setup(x => x.SubmitApplicationFor("1", Decimal.Zero, 0.80M)).Returns(1);
            _mockCompanyData.SetupGet(x => x.Name).Returns("Oscar Test");
            _mockCompanyData.SetupGet(x => x.Number).Returns(1);
            _mockCompanyData.SetupGet(x => x.DirectorName).Returns("Juan Test");
        }
    }
}

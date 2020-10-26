using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Products
{
    public interface IProduct
    {
        int Id { get; }
        int SubmitApplicationFor(ISellerApplication application);
    }
}

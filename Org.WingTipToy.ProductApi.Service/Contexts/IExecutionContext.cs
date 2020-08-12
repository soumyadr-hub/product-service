using Org.WingTipToy.ProductApi.BusinessLogic.Repositories;

namespace Org.WingTipToy.ProductApi.Service.Contexts
{
    public interface IExecutionContext
    {
        IDataRepository DataRepository { get; }
    }
}

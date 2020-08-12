using Org.WingTipToy.ProductApi.BusinessLogic.Repositories;

namespace Org.WingTipToy.ProductApi.Service.Contexts
{
    public class ExecutionContext : IExecutionContext
    {
        public IDataRepository DataRepository { get; }

        public ExecutionContext(IDataRepository dataRepository)
        {
            DataRepository = dataRepository;
        }
    }
}

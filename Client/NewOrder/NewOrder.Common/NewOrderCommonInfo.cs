using Repos.DomainModel.Interface.Interfaces;
using ReposServiceConfigurations.Common;

namespace NewOrder.Common
{

    public interface INewOrderCommonInfo
            : ICommonInfo
    { }

    public class NewOrderCommonInfo 
        : CommonInfo, ICommonInfo
    {
   
        public override void setDefaults()
        {
            ClientInfo = new ClientInfo();
        }
        
    }
}

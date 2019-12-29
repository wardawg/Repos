using Repos.DomainModel.Interface.Interfaces;
using System;

namespace NewOrder.Common
{
    public class ClientInfo :
           IClientInfo<ClientInfo>
    {
        private string _AssmPrefix = "NewOrder";
        private string _ExtClientId = "NO4THh8vB0";
        public Enum FilterEnum { get; set; }

        public ClientInfo()
        {
            SetInfo();
        }

        public ClientInfo(int inId
                            , string AssmPrefix
                            , string ExtClientId)
{
             Id = inId;
            _AssmPrefix = AssmPrefix;
            _ExtClientId = ExtClientId;
        }

        protected virtual void SetInfo()
        {
            Id = 0;
        }

        public dynamic GetEnum(string enumName)
        {
            return FilterEnum;
        }
        
        public string DefaultPrefix { get => "ReposDomain"; }

        public int Id { get; private set; }

        public string ExtClientId => _ExtClientId;

        string IClientInfo.AssmPrefix => _AssmPrefix;
    }
}

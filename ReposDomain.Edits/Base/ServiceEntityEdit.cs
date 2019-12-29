using Repos.DomainModel.Interface.Interfaces;
using ReposServiceConfigurations.ServiceTypes.Edits;

namespace ReposDomain.Edits.Base
{

    public class ServiceEntityEdits<T>
            : IServiceEntityEdit<T>
            , IReposDomain<T>
        where T : BaseEntity<T>

    {
        
        public virtual void RunEdits(){
        }

        public virtual void SetEntityDefaults(T source){
        }

        public virtual void SetEntityValues(T Entity){
        }

    }
}


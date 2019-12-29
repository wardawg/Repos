using Repos.DomainModel.Interface.DomainViewModels;
using Repos.DomainModel.Interface.Interfaces;

namespace Repos.Models
{

    public abstract class BaseViewModel{
    }
    public abstract class BaseViewModel<T>
        : DomainViewModel<T>
        where T : BaseEntity<T>

    {

        public virtual bool CanAdd { get; set; }
        public virtual bool CanEdit { get; set; }
        public virtual bool CanDelete { get; set; }
        public virtual int Id { get; set; }
        public virtual void UpdateModel(IDomainViewModel viewModel){
        }
    }
}

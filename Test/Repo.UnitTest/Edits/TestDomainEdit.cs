using Repos.DomainModel.Interface.Interfaces;
using ReposServiceConfigurations.ServiceTypes.Edits;

namespace RepoUnitTest.Edits
{
    public class TestDomainEdit
          : IDomainEdit
    {
        
        public virtual IServiceEntityEdit<T> CreateEdit<T>() where T : BaseEntity<T>
        {
            return (IServiceEntityEdit<T>)new TestEntityEdits();
        }
    }
}
 
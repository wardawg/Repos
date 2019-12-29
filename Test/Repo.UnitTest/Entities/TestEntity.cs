using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Interfaces;

namespace RepoUnitTest.Entities
{
    public class TestEntity 
        : BaseEntity<TestEntity>, IBaseEntity 
    {
        public new int Id { get; set; }
        public DomainEntityTypeString Name { set; get; } = new DomainEntityTypeString();
        public int someInt { set; get; }
        public DomainEntityTypeInt ComplexInt = new DomainEntityTypeInt();
        public double someDouble { set; get; }
        public long   someLong   { set; get; }


    }
}
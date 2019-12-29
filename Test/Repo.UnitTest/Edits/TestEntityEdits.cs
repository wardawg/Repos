using ReposServiceConfigurations.ServiceTypes.Edits;
using RepoUnitTest.Entities;
using System;

namespace RepoUnitTest.Edits
{
    public class TestEntityEdits
        : ReposDomainEdit<TestEntity>
        , IServiceEntityEdit<TestEntity>

    {
       
        public TestEntityEdits()
            : base(null,null,null,null)
        {

        }
        public void RunEdits()
        {
            throw new NotImplementedException();
        }

        public void SetEntityDefaults(TestEntity Entity)
        {
            Entity.Name.Value = "Test Entity Name";
        }

        public void SetEntityValues(TestEntity Entity)
        {
            throw new NotImplementedException();
        }
    }
}

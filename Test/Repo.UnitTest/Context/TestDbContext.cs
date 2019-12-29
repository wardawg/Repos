using ReposData.Repository;
using RepoUnitTest.Entities;
using System.Data.Entity;

namespace RepoUnitTest.Context
{
    public class TestDbContext
        : ReposContext
    {
        public TestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder){
        }

        public IDbSet<TestReposAttribute> TestAttribute { set; get; }

    }
}
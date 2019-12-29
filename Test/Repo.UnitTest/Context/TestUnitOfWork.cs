using ReposCore.Extensions;
//using ReposFramework.Repository;
using System;
using ReposData.Repository;

namespace RepoUnitTest.Context
{
    public class TestUnitOfWork
        : ReposData.Repository.IUnitOfWork
    {
        public IDbContext Context => throw new NotImplementedException();

        public Result Commit()
        { 
            return Result.Success();
        }

        public void Dispose()
        {
            
        } 

        //public IUnitOfWork NewUnitOfWork()
        //{
        //    //   return new TestNewUnitOfWork();
        //    return null;
        //}
    

    //public class TestNewUnitOfWork : IUnitOfWork
    //{
    //    public Result Commit()
    //    {
    //        return Result.Success();
    //    }

        //public void Dispose()
        //{
            
        //}
    }
}

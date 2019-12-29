using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitTest.Utilities
{
    public class DelegatedMoqFactory<T> where T : class
    {
        private Action<Mock<T>> setupMock;
        private Mock<T> mock;

        public Mock<T> CurrentMock { get { return mock; } }

        public T CreateInstance()
        {
            mock = new Mock<T>();
            return mock.Object;
        }

        public Mock<T> OnResolve()
        {
            return mock;
        }
    }
}

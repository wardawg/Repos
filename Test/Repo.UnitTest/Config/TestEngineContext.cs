using ReposCore.Configuration;
using ReposCore.Infrastructure;
using ReposDomain.Infrastructure;
using System.Configuration;

namespace RepoUnitTest.Config
{
    public  class TestEngineContext
    { 
        public static TestEngineHandler Initialize()
        {
            return Initialize(new TestEngineHandler());
        }

        public static TestEngineHandler Initialize(TestEngineHandler Engine, TestClassConfigOptions opts)
        {
            Singleton<TestEngineHandler>.Instance = Engine;
            var config = ConfigurationManager.GetSection("ReposConfig") as ReposConfig;
            Singleton<TestEngineHandler>.Instance.Initialize(config,opts);

            return Singleton<TestEngineHandler>.Instance;
        }
        public static TestEngineHandler Initialize(TestEngineHandler Engine)
        {
            Singleton<TestEngineHandler>.Instance = Engine;
            var config = ConfigurationManager.GetSection("ReposConfig") as ReposConfig;
            Singleton<TestEngineHandler>.Instance.Initialize(config);

            return Singleton<TestEngineHandler>.Instance;
        }

        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(TestEngineHandler engine)
        {
            Singleton<TestEngineHandler>.Instance = engine;
        }

        #region Properties

        public static void Clear()
        {
            Singleton<TestEngineHandler>.Instance = null;
        }
        /// <summary>
        /// Gets the singleton Nop engine used to access Nop services.
        /// </summary>
        public static TestEngineHandler Current
        {
            get
            {
                if (Singleton<TestEngineHandler>.Instance == null)
                {
                    Initialize();
                }
                return Singleton<TestEngineHandler>.Instance;
            }
        }

        #endregion
    }
}

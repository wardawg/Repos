using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions;

namespace WebCoreApi.autofac
{
    public class register
    {
       // [Obsolete]
        public void Reg()
        {
            var builder = new ContainerBuilder();
            var Con = builder.Build();

            builder.RegisterType<register>().As<ICloneable>().IfNotRegistered(typeof(ICloneable));


            // var configuration = builder.RegisterInstance


            builder.Update(Con);


        }

    }
}

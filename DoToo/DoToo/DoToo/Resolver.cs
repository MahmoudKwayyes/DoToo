using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoToo
{
    public static class Resolver
    {
        private static IContainer Container;
        public static void Initialize(IContainer container)
        {
            Resolver.Container = container;
        }
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}

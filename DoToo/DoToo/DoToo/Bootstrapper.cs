using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using DoToo.ViewModels;
using DoToo.Repositories;

namespace DoToo
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder containerBuilder { get; private set; }
        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }
        protected virtual void Initialize()
        {
            var currntAssembly = Assembly.GetExecutingAssembly();
            containerBuilder = new ContainerBuilder();

            foreach (var type in currntAssembly.DefinedTypes.Where(e=>e.IsSubclassOf(typeof(Page))||
                                                                      e.IsSubclassOf(typeof(ViewModel))))
            {
                containerBuilder.RegisterType(type.AsType());
            }

            containerBuilder.RegisterType<TodoItemRepository>().SingleInstance();
        }

        private void FinishInitialization()
        {
            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}

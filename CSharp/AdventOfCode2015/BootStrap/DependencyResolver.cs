using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AdventOfCode2015.BootStrap
{
    class DependencyResolver
    {
        /*
		Jon Skeet version 4:
		http://csharpindepth.com/Articles/General/Singleton.aspx
		*/

        // ReSharper disable once InconsistentNaming
        private static readonly DependencyResolver instance = new DependencyResolver();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DependencyResolver()
        {
        } //Do not use

        private DependencyResolver()
        {
            InitContainer();
        }

        private void InitContainer()
        {
            var builder = new ContainerBuilder();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IPuzzle))))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<PuzzleRunner>().As<IPuzzleRunner>().SingleInstance();

            Container = builder.Build();
        }

        public static DependencyResolver Instance => instance;

        public IContainer Container { get; private set; }
    }
}

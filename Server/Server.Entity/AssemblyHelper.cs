using System.Reflection;
using System.Runtime.Loader;

namespace Server.Entity
{
    public static class AssemblyHelper
    {
        private const string HotfixDll = "Server.Hotfix";
        private static AssemblyLoadContext? _assemblyLoadContext = null;

        public static Assembly[] Assemblies
        {
            get
            {
                var assemblies = new Assembly[2];
                assemblies[0] = LoadEntityAssembly();
                assemblies[1] = LoadHotfixAssembly();
                return assemblies;
            }
        }
        
        private static Assembly LoadEntityAssembly()
        {
            return typeof(AssemblyHelper).Assembly;
        }
        
        private static Assembly LoadHotfixAssembly()
        {
            if (_assemblyLoadContext != null)
            {
                _assemblyLoadContext.Unload();
                GC.Collect();
            }

            _assemblyLoadContext = new AssemblyLoadContext(HotfixDll, true);
            var dllBytes = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, $"{HotfixDll}.dll"));
            var pdbBytes = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, $"{HotfixDll}.pdb"));
            return _assemblyLoadContext.LoadFromStream(new MemoryStream(dllBytes), new MemoryStream(pdbBytes));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KEYAKI_Suite.ViewModel
{
    public static class ViewTypeToViewModelTypeResolver
    {
        private static readonly Assembly LocalAssembly = typeof(ViewTypeToViewModelTypeResolver).GetTypeInfo().Assembly;
        public static Type Resolve(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));

            var vmTypeName = $"{viewType.Namespace.Replace("Views", "ViewModels")}.{viewType.Name}ViewModel";
            return LocalAssembly.GetType(vmTypeName);
        }
    }
}

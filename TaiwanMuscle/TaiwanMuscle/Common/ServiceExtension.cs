using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TaiwanMuscle.Common
{
    /// <summary>
    /// IServiceCollection扩展
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// DI 实作注入物件，没抽换需求，则不使用介面
        /// </summary>
        /// <param name="service"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterInstanceAssembly(this IServiceCollection service, string assemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException(nameof(assemblyName));

            var assembly = RuntimeHelper.GetAssembly(assemblyName);
            if (assembly == null)
            {
                throw new DllNotFoundException($"the dll \"{assemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = assembly.GetTypes().Where(t => !t.GetTypeInfo().IsGenericType && t.Namespace != null && t.Namespace.Contains(".Services") && t.IsVisible);

            foreach (var type in types)
            {
                service.AddTransient(type);
            }

            return service;
        }

        /// <summary>
        /// 扩展Service接口
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName"></param>
        public static void RegisterServices(this IServiceCollection service, string interfaceAssemblyName)
        {
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));

            var assembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (assembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = assembly.GetTypes().Where(t => !t.GetTypeInfo().IsGenericType && t.GetTypeInfo().IsInterface);

            foreach (var type in types)
            {
                var implementTypeName = type.Name.Substring(1);
                var implementType = RuntimeHelper.GetImplementType(implementTypeName, type);
                if (implementType != null)
                    service.AddTransient(type, implementType);
            }
        }



        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <param name="implementAssemblyName">实现程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection RegisterAssembly(this IServiceCollection service, string interfaceAssemblyName, string implementAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));
            if (string.IsNullOrEmpty(implementAssemblyName))
                throw new ArgumentNullException(nameof(implementAssemblyName));

            var interfaceAssembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (interfaceAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            var implementAssembly = RuntimeHelper.GetAssembly(implementAssemblyName);
            if (implementAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{implementAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = interfaceAssembly.GetTypes().Where(t => t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsGenericType);

            foreach (var type in types)
            {
                //过滤掉抽象类、泛型类以及非class
                var implementType = implementAssembly.DefinedTypes
                    .FirstOrDefault(t => t.IsClass && !t.IsAbstract && !t.IsGenericType &&
                                         t.GetInterfaces().Any(b => b.Name == type.Name));
                if (implementType != null)
                {
                    service.AddTransient(type, implementType.AsType());
                }
            }

            return service;
        }
    }
}

using Autofac;
using JCF.Infrastructure.Sqlsugar;
using System.Reflection;

public static class AutofacExt
{
    public static void RegisterAutofacModules(this ContainerBuilder builder)
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var domainDllFile = Path.Combine(basePath, "JCF.Domain.dll");
        var infrastructureDllFile = Path.Combine(basePath, "JCF.Infrastructure.dll");
        var applicationDllFile = Path.Combine(basePath, "JCF.Application.dll");

        if (!(File.Exists(domainDllFile) && File.Exists(infrastructureDllFile)))
        {
            throw new Exception("Required DLLs not found.");
        }

        builder.RegisterGeneric(typeof(BaseDB<>)).As(typeof(IBaseDB<>)).InstancePerDependency();

        // 注册 DLL 中的类型
        RegisterAssemblyTypes(builder, domainDllFile);
        RegisterAssemblyTypes(builder, infrastructureDllFile);

        //注册类
        var assembly = Assembly.LoadFrom(applicationDllFile);
        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.IsClass && !t.IsAbstract)//过滤出类类型
            .AsSelf()//注册自己
            .InstancePerDependency();//每次依赖都创建新的实例
    }

    private static void RegisterAssemblyTypes(ContainerBuilder builder, string dllFile)
    {
        var assembly = Assembly.LoadFrom(dllFile);
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .InstancePerDependency();
    }
}

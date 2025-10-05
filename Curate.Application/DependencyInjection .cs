using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace Curate.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        return service;
    }
}
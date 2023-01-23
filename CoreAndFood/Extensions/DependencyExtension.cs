using CoreAndFood.Repositories;
using CoreAndFood.Repositories.Abstract;
using MediatR;

namespace CoreAndFood.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencyResolvers(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddMediatR(typeof(Program));
        }
    }
}

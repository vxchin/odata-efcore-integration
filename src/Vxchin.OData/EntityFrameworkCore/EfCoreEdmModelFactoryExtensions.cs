using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vxchin.OData.EntityFrameworkCore.Internal;

namespace Vxchin.OData.EntityFrameworkCore
{
    public static class EfCoreEdmModelFactoryExtensions
    {
        /// <summary>
        /// 使用指定配置创建一个 <see cref="TContext"/> 实例，并使用 <see cref="DbContext.Model"/>
        /// 属性返回的实体模型对 <see cref="IConventionEdmModelFactory" /> 进行配置。
        /// </summary>
        /// <typeparam name="TContext">用于配置 <see cref="IConventionEdmModelFactory" /> 的 <see cref="DbContext" /> 类型。</typeparam>
        /// <param name="factory">要配置的 <see cref="IConventionEdmModelFactory" /> 对象。</param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IConventionEdmModelFactory ConfigureWithDbContext<TContext>(
            this IConventionEdmModelFactory factory, Action<DbContextOptionsBuilder<TContext>> optionsAction)
            where TContext : DbContext
        {
            var model = CreateDbContext(optionsAction).Model;
            return factory.ConfigureWithEntityFrameworkModel(model);
        }

        /// <summary>
        /// 基于 <see cref="IModel" /> 对象对 <see cref="IConventionEdmModelFactory" /> 进行配置。
        /// </summary>
        /// <param name="factory">要配置的 <see cref="IConventionEdmModelFactory" /> 对象。</param>
        /// <param name="model">用于配置 <see cref="IConventionEdmModelFactory"/> 的 Entity Framework Core 模型对象。</param>
        /// <returns>用于链式调用的 <see cref="IConventionEdmModelFactory" /> 对象。</returns>
        public static IConventionEdmModelFactory ConfigureWithEntityFrameworkModel(
            this IConventionEdmModelFactory factory, IModel model)
        {
            return factory.Configure(new EfCoreEdmModelConfigurator(model));
        }

        private static TContext CreateDbContext<TContext>(Action<DbContextOptionsBuilder<TContext>> optionsAction)
            where TContext : DbContext
        {
            try
            {
                var builder = new DbContextOptionsBuilder<TContext>();
                optionsAction.Invoke(builder);
                var options = builder.Options;
                var context = (TContext)Activator.CreateInstance(typeof(TContext), options);
                return context;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"使用指定的 optionsAction 创建 {typeof(TContext)} 的实例时发生错误。", ex);
            }
        }
    }
}
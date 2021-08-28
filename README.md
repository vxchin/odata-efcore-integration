# odata-efcore-integration

Use DbContext.Model to configure the edm model.

使用 DbContext 上配置的模型（`Microsoft.EntityFrameworkCore.Metadata.IModel` 的示例）自动配置 OData 模型中的复杂类型和实体类型。

## Usage

* Step 1: Configure your Entity Framework Core Model with `OnModelCreating`.

```csharp
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // ...
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ...
    }
}
```

* Step 2: Register your `DbContext` and then use `EdmModel.CreateConventionFactory()` static method to create a `IEdmModel` factory.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    void UseSqlServer(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ApplicationDb"));
        
    services.AddDbContext<ApplicationDbContext>(UseSqlServer);
    
    services.AddController().AddOData(options => options
        .AddRouteComponents("odata", CreateEdmModel(UseSqlServer)));
}    

private static IEdmModel CreateEdmModel(Action<DbContextOptionsBuilder> optionsAction)
{
    return EdmModel.CreateConventionFactory()
        .ConfigureWithDbContext<ApplicationDbContext>(optionsAction)
        .Configure(builder =>
        {
            // Additional configuration for the edm model.
        }).CreateEdmModel();
}
```

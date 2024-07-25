var builder = WebApplication.CreateBuilder(args);

ConfigurationServices(builder.Services);

var app = builder.Build();

Configure(app, app.Environment);

app.Run();

void ConfigurationServices(IServiceCollection services)
{
    services.AddRazorPages();
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (!env.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();
    app.UseEndpoints(x =>
    {
        x.MapRazorPages();
    });
}
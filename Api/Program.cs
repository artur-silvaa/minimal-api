using MinimalApi;

IHostBuilder CreateHostBuilder(string[] args)
{
    // A correção está aqui: ConfigureWebHostDefaults
    return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
}

CreateHostBuilder(args).Build().Run();
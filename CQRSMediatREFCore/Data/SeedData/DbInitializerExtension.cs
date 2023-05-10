namespace CQRSMediatREFCore.Data.SeedData
{
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedSqliteDb(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            using var appContext = services.GetRequiredService<TrailDbContext>();
            try
            {
                TrailDbInitializer.Initialize(appContext);
            }
            catch (Exception ex) { }

            return app;
        }
    }
}

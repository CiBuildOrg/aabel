using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CInfinity.Identity.Webapi
{
    public class Startup
    {
        #region Fields
        /// <summary>
        /// Gets the configuration for the host.
        /// </summary>
        private IConfigurationRoot Configuration { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class
        /// using the host environment veriables.
        /// </summary>
        /// <param name="env">
        /// The host environement variables.
        /// </param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Add the services to be used to our server.
        /// </summary>
        /// <param name="services">
        /// The collection of services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services
                .AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryIdentityResources(InMemoryManager.GetIdentityResources())
                .AddInMemoryApiResources(InMemoryManager.GetApiResources())
                .AddInMemoryClients(InMemoryManager.GetClients())
                .AddInMemoryUsers(InMemoryManager.GetUsers());
        }

        /// <summary>
        /// Configures the application by starting using the services.
        /// </summary>
        /// <param name="app">
        /// The application builder.
        /// </param>
        /// <param name="env">
        /// The hosting environment variables.
        /// </param>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            if (env.IsDevelopment())app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
        #endregion
    }
}

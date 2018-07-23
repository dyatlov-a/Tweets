using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Tweets.Commands.CommandContexts;
using Tweets.Commands.CommandHandlers;
using Tweets.Commands.Contracts;
using Tweets.Commands.Implementations;
using Tweets.DataAccess.Contexts;
using Tweets.DataAccess.Implementations;
using Tweets.Queries;
using Tweets.Queries.Contracts;
using Tweets.Queries.Criterions;
using Tweets.Queries.Dtos;
using Tweets.TwitterClient.Common;
using Tweets.TwitterClient.Contracts;
using Tweets.TwitterClient.Implementations;
using Tweets.Web.Infrastructure;
using Tweets.Web.Infrastructure.CQRS.Contracts;
using Tweets.Web.Infrastructure.CQRS.Implementations;
using Tweets.Web.Infrastructure.Middlewares;

namespace Tweets.Web
{
    public class Startup
    {
        private const string DefaultCorsPolicy = "AllowAll";

        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private void AddSettings(IServiceCollection services)
        {
            var twitterClientSettings = Configuration.GetSection(nameof(TwitterClientSettings)).Get<TwitterClientSettings>();
            services.AddSingleton(twitterClientSettings);

            var tweetsSettings = Configuration.GetSection(nameof(TweetsSettings)).Get<TweetsSettings>();
            services.AddSingleton(tweetsSettings);
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddDbContext<TweetsContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ITweetsCollectionRepository, TweetsCollectionRepository>();
            services.AddTransient<ITweetsProvider, TweetsProvider>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPictureWorker, DefaultPictureWorker>();

            services.AddTransient<ICommandsDispatcher, CommandsDispatcher>();
            services.AddTransient<IAsyncCommand<TweetsRefreshCommandContext>, TweetsRefreshCommand>();

            services.AddTransient<IQueriesDispatcher, QueriesDispatcher>();
            services.AddSingleton<IProjectionService, ProjectionService>();
            services.AddTransient<IQuery<TweetsQueryCriterion, TweetsCollectionDto>, TweetsQuery>();

            services.AddSingleton<ITwitterClient, DefaultTwitterClient>();
            services.AddSingleton<ITokenProvider, DefaultTokenProvider>();
            services.AddSingleton<IRequestSender, DefaultRequestSender>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy(DefaultCorsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });
            services.AddMvc().AddJsonOptions(x =>
            {
                x.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });
            AddSettings(services);
            AddServices(services);
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Tweets.Web", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<UnhandledExceptionsLoggingMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwagger()
                   .UseSwaggerUI(c =>
                   {
                       c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tweets.Web API V1");
                       c.RoutePrefix = String.Empty;
                   });
            }

            app.UseCors(DefaultCorsPolicy);
            app.UseMvc();
        }
    }
}

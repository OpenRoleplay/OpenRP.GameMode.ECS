using Microsoft.Extensions.DependencyInjection;
using OpenRP.GameMode.Features.Chat.Handlers;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;

namespace OpenRP.GameMode
{
    public class Startup : IStartup
    {
        public void Configure(IServiceCollection services)
        {
            // TODO: Add services and systems to the services collection
            services.AddSystemsInAssembly();
            services.AddSingleton<IPlayerCommandService, PlayerCommandServiceHandler>();
        }

        public void Configure(IEcsBuilder builder)
        {
            // TODO: Enable desired ECS system features
            builder.EnableSampEvents()
                .EnablePlayerCommands()
                .EnableRconCommands();
        }
    }
}
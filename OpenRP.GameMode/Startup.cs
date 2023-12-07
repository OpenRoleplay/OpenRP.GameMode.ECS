using Microsoft.Extensions.DependencyInjection;
using OpenRP.GameMode.Features.Chat.Handlers;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;
using SampSharp.Streamer.Entities;

namespace OpenRP.GameMode
{
    public class Startup : IStartup
    {
        public void Configure(IServiceCollection services)
        {
            // TODO: Add services and systems to the services collection
            services
                .AddTransient<IStreamerService, StreamerService>()
                .AddSingleton<IPlayerCommandService, PlayerCommandServiceHandler>()
                .AddSystemsInAssembly();
        }

        public void Configure(IEcsBuilder builder)
        {
            // TODO: Enable desired ECS system features
            builder.EnableSampEvents()
                .EnablePlayerCommands()
                .EnableRconCommands()
                .EnableStreamerEvents(); ;
        }
    }
}
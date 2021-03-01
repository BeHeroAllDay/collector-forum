using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(collector_forum.Areas.Identity.IdentityHostingStartup))]
namespace collector_forum.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });

        }
    }
}
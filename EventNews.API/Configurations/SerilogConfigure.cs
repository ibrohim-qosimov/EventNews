using Serilog;
using Serilog.Events;

namespace EventNews.API.Configurations
{
    public static class SerilogConfigure
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.Telegram(
                    botToken: "7841694833:AAGt7EaVcrGOcUaWsViiP1TM9PNaa-FIl50",
                    chatId: "-5210971106",
                    restrictedToMinimumLevel: LogEventLevel.Warning)
                .CreateLogger();
        }
    }
}

using Microsoft.Extensions.Logging;
using Coursework_BudgetMate.Service.Interface;
using Coursework_BudgetMate.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Http;

namespace Coursework_BudgetMate;

public static partial class Program
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddMauiBlazorWebView();
        #if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
        #endif

        builder.Services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();
        builder.Services.AddScoped<HttpClient>();

        return builder.Build();
    }
} 
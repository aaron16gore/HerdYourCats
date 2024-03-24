using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSpaStaticFiles(options => options.RootPath = "./svelte-kit/output/prerendered/pages");

builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:5000", "http://localhost:5174")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions { RequestPath = "" });

bool IsSiteRequest(HttpContext context) => !context.Request.Path.StartsWithSegments("/api");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CollaborationHub>("/collaborationHub", options =>
    {
        options.Transports = HttpTransportType.WebSockets;
    });
    endpoints.MapFallbackToFile("index.html");
});

if (1 == 1) //env.IsDevelopment())
{
    // Search for `port: 6000` in the Vite config
    var spaPort = new Regex("\"?port\"?:[ \t\r\n]*([0-9]+)")
        .Match(File.ReadAllText("./vite.config.ts"))
        .Groups.Values.ElementAtOrDefault(1)?.Value ?? "6000";
    app.UseWhen(IsSiteRequest, builder => builder.UseSpa(spa => spa.UseProxyToSpaDevelopmentServer($"http://localhost:{spaPort}")));


}
else
{
    app.UseWhen(IsSiteRequest, builder => builder.UseFileServer());
}

app.Run();

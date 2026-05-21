using Examensarbete.Blazor.Components;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("ApiGateway", client =>
{
    client.BaseAddress = new Uri("http://apigateway:8080/");
});

var app = builder.Build();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".br"] = "application/octet-stream";
provider.Mappings[".data"] = "application/octet-stream";
provider.Mappings[".wasm"] = "application/wasm";
provider.Mappings[".js"] = "application/javascript";
provider.Mappings[".symbols.json"] = "application/octet-stream";

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider,
    OnPrepareResponse = ctx =>
    {
        if (ctx.File.Name.EndsWith(".br"))
        {
            ctx.Context.Response.Headers["Content-Encoding"] = "br";

            if (ctx.File.Name.Contains(".js.br"))
                ctx.Context.Response.Headers["Content-Type"] = "application/javascript";
            else if (ctx.File.Name.Contains(".wasm.br"))
                ctx.Context.Response.Headers["Content-Type"] = "application/wasm";
            else if (ctx.File.Name.Contains(".data.br"))
                ctx.Context.Response.Headers["Content-Type"] = "application/octet-stream";
        }
    }
});
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

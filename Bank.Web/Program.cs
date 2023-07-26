
using Microsoft.AspNetCore.Server.Kestrel.Core;
/*
 * To add a user
var context = new Bank.SwcbankContext();
var user = new Bank.User()
{
    FirstName = "Sam",
    LastName = "Winkles",
    AcctOpenDate = DateTime.Today.ToLongDateString(),
};
context.Add(user);
context.SaveChanges();
*/

/*
 * To remove a user
var context = new Bank.SwcbankContext();
context.Remove(context.Users.Single(a => a.Id == 1));
context.SaveChanges();
*/


// configure services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddRequestDecompression();
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        listenOptions.UseHttps(); // HTTP3 requires secure connection
    });
});
var app = builder.Build();

// configure the HTTP pipeline

if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

    if(rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }
    if(context.Request.Path == "/bonjour")
    {
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }
    await next();
});
app.UseHttpsRedirection();
app.UseRequestDecompression();
app.UseDefaultFiles(); // index.html, etc.
app.UseStaticFiles();
app.MapRazorPages();

// start the web server
app.Run();

WriteLine("Web server has stopped.");
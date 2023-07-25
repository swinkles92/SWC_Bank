
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

var context = new Bank.SwcbankContext();
context.Remove(context.Users.Single(a => a.Id == 1));
context.SaveChanges();
/*var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

// The following enables HSTS and HTTPS redirection for security purposes
if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();
app.MapGet("/hello", () => "Hello World!");

app.Run();

WriteLine("Web server has stopped.");*/
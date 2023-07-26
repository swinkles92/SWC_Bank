﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bank.Mvc.Data;
using Bank;

/*
 * Section 1: Configure host web server & services
 */
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection") ?? throw new
    InvalidOperationException("Connection string 'DefaultConnection' " +
    "not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSwcbankContext();

var app = builder.Build();

/*
 * Section 2: Configure HTTP request pipeline
 */
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

/*
 * Section 3: Start host web server listening for HTTP requests
 */
app.Run();


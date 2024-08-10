using AdminManager.OfficeDB;
using ProjectFS2.Entity;
using Infrastructure.DependencyInjection;
using EmployeeManager.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructureServices(builder.Configuration);

var app = builder.Build();

// Cấu hình pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapPost("/users/", async (UserDTOs e, ApplicationDbContext db) =>
{
    User u = new User()
    {
        UserId = e.UserId,
        UserName = e.UserName,
        Password = e.Password,
        RoleId = e.RoleId,
        DepartmentId = e.DepartmentId,
    };
    db.Users.Add(u);
    await db.SaveChangesAsync();
    return Results.Created($"/employee/{u.UserId}", e);
});
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

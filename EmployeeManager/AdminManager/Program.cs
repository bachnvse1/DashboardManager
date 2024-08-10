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
app.MapPost("/employee/", async (EmployeeDTO e, ApplicationDbContext db) =>
{
    Employee e1 = new Employee()
    {
        EmployeeId = e.EmployeeId,
        EmployeeName = e.EmployeeName,
        DepartmentId = e.DepartmentId,
        UserId = e.UserId,
    };
    db.Employees.Add(e1);
    await db.SaveChangesAsync();
    return Results.Created($"/employee/{e.EmployeeId}", e);
});
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

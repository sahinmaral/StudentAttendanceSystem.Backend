using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Business.Concrete;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.DataAccess.Concrete.EntityFramework;

using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ILectureDal, EfLectureDal>();
builder.Services.AddSingleton<ILectureHourDal, EfLectureHourDal>();
builder.Services.AddSingleton<IDepartmentDal, EfDepartmentDal>();
builder.Services.AddSingleton<IInstructorDal, EfInstructorDal>();
builder.Services.AddSingleton<IStudentAttendanceDal, EfStudentAttendanceDal>();
builder.Services.AddSingleton<IStudentSchoolCardDal, EfStudentSchoolCardDal>();
builder.Services.AddSingleton<IStudentDal, EfStudentDal>();


builder.Services.AddSingleton<ILectureService, LectureManager>();
builder.Services.AddSingleton<IStudentAttendanceService, StudentAttendanceManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

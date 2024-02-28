using MCC.DAL.DB.Context;
using MCC.DAL.Repository.Implements;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MCC.DAL.Dto.MappingAutoMapper;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interfacep;

var builder = WebApplication.CreateBuilder(args);
// Add cros policy
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ignore loop when include
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

#region Register service

// register DBContext
builder.Services.AddDbContext<ManageCourseCenterContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
    options.UseSqlServer(connectionString);
});

// register Repository
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
//builder.Services.AddScoped<IAcademicTranscriptRepository, AcademicTranscriptRepository>();
//builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
//builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IChildRepository, ChildRepository>();
//builder.Services.AddScoped<IChildrendClassRepository, ChildrenClassRepository>();
builder.Services.AddScoped<IClassReposotory, ClassRepositoy>();
//builder.Services.AddScoped<IClassTimeRepository, ClassTimeRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
//builder.Services.AddScoped<IEquipmentActivityRepository, EquipmentActivityRepository>();
//builder.Services.AddScoped<IEquipmentReportRepository, EquipmentReportRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
//builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
//builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
//builder.Services.AddScoped<IRoomRepository, RoomRepository>();
//builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

// register Service
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IChildService, ChildService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
// Add automapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion
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

app.Run();

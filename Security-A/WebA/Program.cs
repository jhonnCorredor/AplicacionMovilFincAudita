using Business.Implements.Operational;
using Business.Implements.Parameter;
using Business.Implements.Security;
using Business.Interfaces.Operational;
using Business.Interfaces.Parameter;
using Business.Interfaces.Security;
using Data.Implements.Operational;
using Data.Implements.Parameter;
using Data.Implements.Security;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Data.Interfaces.Security;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace WebA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configuracion Cords
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        //policy.WithOrigins("http://localhost:4200")
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Configura DbContext con SQL Server
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbfaultConnection")));

            //Configuiracion de Data I,S
            builder.Services.AddScoped<IModuloData, ModuloData>();
            builder.Services.AddScoped<IPersonData, PersonData>();
            builder.Services.AddScoped<IRoleData, RoleData>();
            builder.Services.AddScoped<IRoleViewData, RoleViewData>();
            builder.Services.AddScoped<IUserData, UserData>();
            builder.Services.AddScoped<IUserRoleData, UserRoleData>();
            builder.Services.AddScoped<IViewData, ViewData>();
            builder.Services.AddScoped<ICountryData, CountryData>();
            builder.Services.AddScoped<ICityData, CityData>();
            builder.Services.AddScoped<IDepartamentData, DepartamentData>();
            builder.Services.AddScoped<IFarmData, FarmData>();
            builder.Services.AddScoped<IAssesmentCriteriaData, AssesmentCriteriaData>();
            builder.Services.AddScoped<IChecklistData, ChecklistData>();
            builder.Services.AddScoped<ICropData, CropData>();
            builder.Services.AddScoped<IEvidenceData, EvidenceData>();
            builder.Services.AddScoped<ILotData, LotData>();
            builder.Services.AddScoped<IQualificationData, QualificationData>();
            builder.Services.AddScoped<IReviewTechnicalData, ReviewTechnicalData>();
            builder.Services.AddScoped<ISuppliesData, SuppliesData>();
            builder.Services.AddScoped<ITreatmentData, TreatmentData>();
            builder.Services.AddScoped<ITreatmentSuppliesData, TreatmentSuppliesData>();
            builder.Services.AddScoped<ILotTreatmentData, LotTreatmentData>();
            builder.Services.AddScoped<IAlertData, AlertData>();

            //Configuracion de Business I,S
            builder.Services.AddScoped<IModuloBusiness, ModuloBusiness>();
            builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
            builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
            builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();
            builder.Services.AddScoped<IUserBusiness, UserBusiness>();
            builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
            builder.Services.AddScoped<IViewBusiness, ViewBusiness>();
            builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
            builder.Services.AddScoped<ICityBusiness, CityBusiness>();
            builder.Services.AddScoped<IDepartamentBusiness, DepartamentBusiness>();
            builder.Services.AddScoped<IFarmBusiness, FarmBusiness>();
            builder.Services.AddScoped<ILotBusiness, LotBusiness>();
            builder.Services.AddScoped<IChecklistBusiness, ChecklistBusiness>();
            builder.Services.AddScoped<IEvidenceBusiness, EvidenceBusiness>();
            builder.Services.AddScoped<ICropBusiness, CropBusiness>();
            builder.Services.AddScoped<IAssesmentCriteriaBusiness, AssesmentCriteriaBusiness>();
            builder.Services.AddScoped<IQualificationBusiness, QualificationBusiness>();
            builder.Services.AddScoped<IReviewTechnicalBusiness, ReviewTechnicalBusiness>();
            builder.Services.AddScoped<ISuppliesBusiness, SuppliesBusiness>();
            builder.Services.AddScoped<ITreatmentBusiness, TreatmentBusiness>();
            builder.Services.AddScoped<ITreatmentSuppliesBusiness, TreatmentSuppliesBusiness>();
            builder.Services.AddScoped<ILotTreatmentBusiness, LotTreatmentBusiness>();
            builder.Services.AddScoped<IAlertBusiness, AlertBusiness>();



            // Add services to the container.
            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");


            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
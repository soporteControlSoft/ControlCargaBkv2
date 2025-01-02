using AccsoDtos.PortalClientes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Srvcio.Extensions;
using Microsoft.OpenApi.Models;
using AccesoDatos.Extensions;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MdloDtos.CcVenturaContext>(options =>
{
    if (builder.Environment.IsProduction())
    {
        options.UseSqlServer(MdloDtos.Utilidades.Conexiones.CadenaConexion);
    }
    else if (builder.Environment.IsDevelopment())
    {
        options.UseSqlServer(MdloDtos.Utilidades.Conexiones.CadenaConexion);
    }
});

// Add services to the container.
//ocultar campos nullos dentro del Json.
builder.Services.AddControllers()
.AddJsonOptions(opciones => opciones.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => {
    config.RegisterApiMappings();
    config.RegisterAccessMappings();
});

//aca va la configuracion de los contraladores.
builder.Services.AddScoped<MdloDtos.IModelos.IGrupoModelo, AccsoDtos.Parametrizacion.GrupoTercero>();
builder.Services.AddScoped<MdloDtos.IModelos.ITercero, AccsoDtos.Parametrizacion.Tercero>();
builder.Services.AddScoped<MdloDtos.IModelos.IUsuario, AccsoDtos.Parametrizacion.Usuario>();
builder.Services.AddScoped<MdloDtos.IModelos.IPerfil, AccsoDtos.Parametrizacion.Perfil>();
builder.Services.AddScoped<MdloDtos.IModelos.ITipoIdentificacion, AccsoDtos.Parametrizacion.TipoIdentificacion>();
builder.Services.AddScoped<MdloDtos.IModelos.ITerminalMaritimo, AccsoDtos.Parametrizacion.TerminalMaritimo>();
builder.Services.AddScoped<MdloDtos.IModelos.IPuertoOrigen, AccsoDtos.Parametrizacion.PuertoOrigen>();
builder.Services.AddScoped<MdloDtos.IModelos.IAuditoriaModulo, AccsoDtos.Parametrizacion.AuditoriaModulo>();
builder.Services.AddScoped<MdloDtos.IModelos.IAuditoriaMotivo, AccsoDtos.Parametrizacion.AuditoriaMotivo>();
builder.Services.AddScoped<MdloDtos.IModelos.IPais, AccsoDtos.Parametrizacion.Pais>();
builder.Services.AddScoped<MdloDtos.IModelos.ICausalCancelacion, AccsoDtos.Parametrizacion.CausalCancelacion>();
builder.Services.AddScoped<MdloDtos.IModelos.ICiudad, AccsoDtos.Parametrizacion.Ciudad>();
builder.Services.AddScoped<MdloDtos.IModelos.ICompania, AccsoDtos.Parametrizacion.Compania>();
builder.Services.AddScoped<MdloDtos.IModelos.IConfiguracionVehicular, AccsoDtos.Parametrizacion.ConfiguracionVehicular>();
builder.Services.AddScoped<MdloDtos.IModelos.IDepartamento, AccsoDtos.Parametrizacion.Departamento>();
builder.Services.AddScoped<MdloDtos.IModelos.ISede, AccsoDtos.Parametrizacion.Sede>();
builder.Services.AddScoped<MdloDtos.IModelos.IZonaCd, AccsoDtos.Parametrizacion.ZonaCd>();

//Wilber Fecha.29/12/2023
builder.Services.AddScoped<MdloDtos.IModelos.ICondicionFacturacion, AccsoDtos.Parametrizacion.CondicionFacturacion>();
builder.Services.AddScoped<MdloDtos.IModelos.IMotonave, AccsoDtos.Parametrizacion.Motonave>();
builder.Services.AddScoped<MdloDtos.IModelos.IProducto, AccsoDtos.Parametrizacion.Producto>();
builder.Services.AddScoped<MdloDtos.IModelos.IPeriodoFacturacion, AccsoDtos.Parametrizacion.PeriodoFacturacion>();
builder.Services.AddScoped<MdloDtos.IModelos.IVehiculo, AccsoDtos.Parametrizacion.Vehiculo>();
builder.Services.AddScoped<MdloDtos.IModelos.IEmpaque, AccsoDtos.Parametrizacion.Empaque>();
builder.Services.AddScoped<MdloDtos.IModelos.IUsuario, AccsoDtos.Parametrizacion.Usuario>();

//Daniel Fecha 03/12/2024
builder.Services.AddScoped<MdloDtos.IModelos.IPerfilUsuario, AccsoDtos.Parametrizacion.PerfilUsuario>();
builder.Services.AddScoped<MdloDtos.IModelos.IPerfilPermisos, AccsoDtos.AccesoSistema.PerfilPermiso>();
builder.Services.AddScoped<MdloDtos.IModelos.ILoginSistema, AccsoDtos.AccesoSistema.LoginSistema>();
builder.Services.AddScoped<MdloDtos.IModelos.IGeneradoClave, AccsoDtos.AccesoSistema.GeneradorClave>();
builder.Services.AddScoped<MdloDtos.IModelos.IEnvioCorreo, AccsoDtos.AccesoSistema.EnvioCorreoElectronico>();

//Wilber Fecha 15/02/2024
builder.Services.AddScoped<MdloDtos.IModelos.IUnidadMedida, AccsoDtos.Parametrizacion.UnidadMedida>();
builder.Services.AddScoped<MdloDtos.IModelos.ISituacionPortuariaDetalle, AccsoDtos.SituacionPortuaria.SituacionPortuariaDetalle>();

//Daniel Fecha 17/02/2024
builder.Services.AddScoped<MdloDtos.IModelos.ISituacionPortuaria, AccsoDtos.SituacionPortuaria.SituacionPortuaria>();
builder.Services.AddScoped<MdloDtos.IModelos.IEstadosMotonave, AccsoDtos.SituacionPortuaria.EstadosMotonave>();

//Daniel Fecha 20/03/2024
builder.Services.AddScoped<MdloDtos.IModelos.IVisitaMotonave, AccsoDtos.VisitaMotonave.VisitaMotonave>();

//Daniel Fecha 21/03/2024
builder.Services.AddScoped<MdloDtos.IModelos.IVisitaMotonaveDetalle, AccsoDtos.VisitaMotonave.VisitaMotonaveDetalle>();


//Daniel Fecha 01/04/2024
//builder.Services.AddScoped<MdloDtos.IModelos.INovedad, AccsoDtos.VisitaMotonave.Novedad>();
builder.Services.AddScoped<MdloDtos.IModelos.IDocumentacionVisita, AccsoDtos.VisitaMotonave.DocumentacionVisita>();
builder.Services.AddScoped<MdloDtos.IModelos.INovedad, AccsoDtos.VisitaMotonave.Novedad>();
builder.Services.AddScoped<MdloDtos.IModelos.IParametros, AccsoDtos.Parametrizacion.Parametros>();
builder.Services.AddScoped<MdloDtos.IModelos.ITipoDocumento, AccsoDtos.Parametrizacion.TipoDocumento>();

//Wilber Fecha 3/05/2024
builder.Services.AddScoped<MdloDtos.IModelos.IVisitaMotonaveBI, AccsoDtos.VisitaMotonave.VisitaMotonaveBl>();

//Daniel Alejandro Lopez Fecha 22/07/2024
builder.Services.AddScoped<MdloDtos.IModelos.IListadoClientesDetalle, AccsoDtos.ListadoClientes.ListadoClientesDetalle>();
builder.Services.AddScoped<MdloDtos.IModelos.IListadoClientesEncabezado, AccsoDtos.ListadoClientes.ListadoClientesEncabezado>();


//Daniel Alejandro Lopez Fecha 26/08/2024
builder.Services.AddScoped<MdloDtos.IModelos.ISubdepositos, Subdepositos>();
builder.Services.AddScoped<MdloDtos.IModelos.ICertificado, Certificado>();

//Wilber Fecha 19/08/2024
builder.Services.AddScoped<MdloDtos.IModelos.IDeposito, AccsoDtos.PortalClientes.Deposito>();


//Daniel Alejandro Lopez Fecha 26/08/2024
builder.Services.AddScoped<MdloDtos.IModelos.ISubdepositos, AccsoDtos.PortalClientes.Subdepositos>();
builder.Services.AddScoped<MdloDtos.IModelos.ICertificado, AccsoDtos.PortalClientes.Certificado>();


//estado de hechos
//Jesus Fecha 02/09/2024
builder.Services.AddScoped<MdloDtos.IModelos.IClasificacion, AccsoDtos.EstadoHechos.Clasificacion>();

//Jesus Fecha 02/09/2024
builder.Services.AddScoped<MdloDtos.IModelos.IResponsable, AccsoDtos.EstadoHechos.Responsable>();

//Jesus Fecha 06/09/2024
builder.Services.AddScoped<MdloDtos.IModelos.IEquipo, AccsoDtos.EstadoHechos.Equipo>();

//Jesus Fecha 06/09/2024
builder.Services.AddScoped<MdloDtos.IModelos.IEstadoHechosListas, AccsoDtos.EstadoHechos.vwEstadoHechosListas>();

//Jesus Fecha 11/09/2024
builder.Services.AddScoped<MdloDtos.IModelos.IEventos, AccsoDtos.EstadoHechos.Evento>();

//Jesus Fecha 18/09/2024
builder.Services.AddScoped<MdloDtos.IModelos.ISector, AccsoDtos.EstadoHechos.Sector>();
//Jesus Fecha 18/09/2024
builder.Services.AddScoped<MdloDtos.IModelos.IEstadoHechos, AccsoDtos.EstadoHechos.EstadoHecho>();

builder.Services.AddScoped<MdloDtos.IModelos.ISolicitudRetiros, AccsoDtos.PortalClientes.SolicitudRetiro>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Daniel Lopez 30/12/2024
builder.Services.AddScoped<MdloDtos.IModelos.IRNDC, AccsoDtos.RNDC.RNDC>();
builder.Services.AddScoped<MdloDtos.IModelos.IConsecutivo, AccsoDtos.ControlPesajes.Consecutivo>();


//Wilbert Rivas 30/12/2024
builder.Services.AddScoped<MdloDtos.IModelos.IReserva, AccsoDtos.Reserva.Reserva>();

//configuracion de la seguridad por medio de JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//para afectos de pruebas lo documentados , pero en produccion se debe configurar lo CORS y el HTTPS.
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseSwagger();
app.UseSwaggerUI(c=>c.SwaggerEndpoint("swagger/v1/swagger.json","APi OPP"));
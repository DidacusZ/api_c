using api4.Models;
using Microsoft.EntityFrameworkCore;

namespace api4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //conexion
            builder.Services.AddDbContext<Contexto>(o =>
            o.UseNpgsql(builder.Configuration.GetConnectionString("MiConexion")));

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

            app.UseHttpsRedirection();
            


            //accesos GET

            //ver un acceso
            app.MapGet("/acceso/{id:int}", async (int id, Contexto contexto) =>
            {
                /*
                return await contexto.Accesos.FindAsync(id)//busca asincronamente el id

                    //es como un if
                    is Acceso acceso
                    ? Results.Ok(acceso)//si existe
                    : Results.NotFound();//si no existe
                */

                //si no lo hago de esta forma se me añade un campo como nulll que no esta en la bd:
                //[{"id_acceso":1,"codigo_acceso":"4312","descripcion_acceso":"admin","usuarioAcceso":null}]//este ultimo esta en la tabla usuarios

                var resultado = await contexto.Accesos
                    .Where(acceso => acceso.id_acceso == id)
                    .Select(acceso => new
                    {
                        id_acceso = acceso.id_acceso,
                        codigo_acceso = acceso.codigo_acceso,
                        descripcion_acceso = acceso.descripcion_acceso
                        // Otros campos necesarios, excluyendo la relación con los usuarios
                    })
                    .FirstOrDefaultAsync();

                return resultado != null
                    ? Results.Ok(resultado)  // si existe
                    : Results.NotFound();    // si no existe

            });

            //ver todos los accesos
            app.MapGet("/accesos/", async (Contexto contexto) =>
            {
                //return await contexto.Accesos.ToListAsync();//devuelve todos los campos incluyendo inecesarios
                
                var resultados = await contexto.Accesos
                    .Select(acceso => new
                    {
                        id_acceso = acceso.id_acceso,
                        codigo_acceso = acceso.codigo_acceso,
                        descripcion_acceso = acceso.descripcion_acceso
                        // Otros campos necesarios, excluyendo la relación con los usuarios
                    })
                    .ToListAsync();

                return resultados;
                
            });

            //usuarios GET

            app.MapGet("/usuarios/", async (Contexto contexto) =>
            {
                var resultados = await contexto.Usuarios
                    .Select(usuario => new
                    {
                        id_usuario = usuario.id_usuario,
                        dni_usuario = usuario.dni_usuario,
                        nombre_usuario = usuario.nombre_usuario,
                        apellidos_usuario = usuario.apellidos_usuario,
                        tlf_usuario = usuario.tlf_usuario,
                        email_usuario = usuario.email_usuario,
                        clave_usuario = usuario.clave_usuario,
                        estaBloqueado_usuario = usuario.estaBloqueado_usuario,
                        fch_fin_bloqueo_usuario = usuario.fch_fin_bloqueo_usuario,
                        fch_alta_usuario = usuario.fch_alta_usuario,
                        fch_baja_usuario = usuario.fch_baja_usuario,
                        id_acceso = usuario.id_acceso,  // Incluye el id_acceso si es necesario
                        // Otros campos necesarios, excluyendo la relación con los accesos
                    })
                    .ToListAsync();

                return resultados;
            });

            app.MapGet("/usuario/{id:int}", async (int id, Contexto contexto) =>
            {
               var resultado = await contexto.Usuarios
                    .Where(usuario => usuario.id_usuario == id)
                    .Select(usuario => new
                    {
                        id_usuario = usuario.id_usuario,
                        dni_usuario = usuario.dni_usuario,
                        nombre_usuario = usuario.nombre_usuario,
                        apellidos_usuario = usuario.apellidos_usuario,
                        tlf_usuario = usuario.tlf_usuario,
                        email_usuario = usuario.email_usuario,
                        clave_usuario = usuario.clave_usuario,
                        estaBloqueado_usuario = usuario.estaBloqueado_usuario,
                        fch_fin_bloqueo_usuario = usuario.fch_fin_bloqueo_usuario,
                        fch_alta_usuario = usuario.fch_alta_usuario,
                        fch_baja_usuario = usuario.fch_baja_usuario,
                        id_acceso = usuario.id_acceso,  // Incluye el id_acceso si es necesario
                        // Otros campos necesarios, excluyendo la relación con los accesos
                    })
                    .FirstOrDefaultAsync();

                return resultado != null
                    ? Results.Ok(resultado)  // si existe
                    : Results.NotFound();    // si no existe

            });







            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
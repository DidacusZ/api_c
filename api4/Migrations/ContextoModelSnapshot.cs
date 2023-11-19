﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api4.Models;

#nullable disable

namespace api4.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api4.Models.Acceso", b =>
                {
                    b.Property<int>("id_acceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_acceso"));

                    b.Property<string>("codigo_acceso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("descripcion_acceso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_acceso");

                    b.ToTable("Accesos");
                });

            modelBuilder.Entity("api4.Models.Usuario", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_usuario"));

                    b.Property<string>("apellidos_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("clave_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dni_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("estaBloqueado_usuario")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("fch_alta_usuario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fch_baja_usuario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fch_fin_bloqueo_usuario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("id_acceso")
                        .HasColumnType("integer");

                    b.Property<string>("nombre_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tlf_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_usuario");

                    b.HasIndex("id_acceso");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("api4.Models.Usuario", b =>
                {
                    b.HasOne("api4.Models.Acceso", "acceso")
                        .WithMany("UsuarioAcceso")
                        .HasForeignKey("id_acceso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("acceso");
                });

            modelBuilder.Entity("api4.Models.Acceso", b =>
                {
                    b.Navigation("UsuarioAcceso");
                });
#pragma warning restore 612, 618
        }
    }
}

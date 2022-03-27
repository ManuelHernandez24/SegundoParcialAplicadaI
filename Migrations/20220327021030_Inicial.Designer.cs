﻿// <auto-generated />
using System;
using ExamenBlazor.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamenBlazor.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220327021030_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("ExamenBlazor.Entidades.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<float>("Existencia")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("TEXT");

                    b.Property<float>("Ganancia")
                        .HasColumnType("REAL");

                    b.Property<float>("Peso")
                        .HasColumnType("REAL");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.Property<float>("ValorInventario")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ExamenBlazor.Entidades.ProductoDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductoDetalle");
                });

            modelBuilder.Entity("ExamenBlazor.Entidades.ProductoEmpacado", b =>
                {
                    b.Property<int>("ProductoEmpacadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("TEXT");

                    b.Property<float>("PesoTotal")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductoProducido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoEmpacadoId");

                    b.ToTable("ProductoEmpacado");
                });

            modelBuilder.Entity("ExamenBlazor.Entidades.ProductoEmpacadoDetalle", b =>
                {
                    b.Property<int>("ProductoEmpacadoDetallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoEmpacadoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoEmpacadoDetallesId");

                    b.HasIndex("ProductoEmpacadoId");

                    b.ToTable("ProductoEmpacadoDetalle");
                });

            modelBuilder.Entity("ExamenBlazor.Entidades.ProductoDetalle", b =>
                {
                    b.HasOne("ExamenBlazor.Entidades.Producto", null)
                        .WithMany("ProductoDetalle")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamenBlazor.Entidades.ProductoEmpacadoDetalle", b =>
                {
                    b.HasOne("ExamenBlazor.Entidades.ProductoEmpacado", null)
                        .WithMany("ProductoEmpacadoDetalle")
                        .HasForeignKey("ProductoEmpacadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamenBlazor.Entidades.Producto", b =>
                {
                    b.Navigation("ProductoDetalle");
                });

            modelBuilder.Entity("ExamenBlazor.Entidades.ProductoEmpacado", b =>
                {
                    b.Navigation("ProductoEmpacadoDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
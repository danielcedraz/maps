﻿// <auto-generated />
using Maps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Maps.Migrations
{
    [DbContext(typeof(DBContextModel))]
    partial class DBContextModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Maps.DBO.Parada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPonto")
                        .HasColumnName("Ponto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdRota")
                        .HasColumnName("Rota")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ordem")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdPonto");

                    b.HasIndex("IdRota");

                    b.ToTable("Paradas");
                });

            modelBuilder.Entity("Maps.DBO.Ponto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pontos");
                });

            modelBuilder.Entity("Maps.DBO.Rota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdDestino")
                        .HasColumnName("Destino")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdOrigem")
                        .HasColumnName("Origem")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdDestino");

                    b.HasIndex("IdOrigem");

                    b.ToTable("Rotas");
                });

            modelBuilder.Entity("Maps.DBO.Parada", b =>
                {
                    b.HasOne("Maps.DBO.Ponto", "Ponto")
                        .WithMany()
                        .HasForeignKey("IdPonto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Maps.DBO.Rota", "Rota")
                        .WithMany()
                        .HasForeignKey("IdRota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Maps.DBO.Rota", b =>
                {
                    b.HasOne("Maps.DBO.Ponto", "Destino")
                        .WithMany()
                        .HasForeignKey("IdDestino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Maps.DBO.Ponto", "Origem")
                        .WithMany()
                        .HasForeignKey("IdOrigem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
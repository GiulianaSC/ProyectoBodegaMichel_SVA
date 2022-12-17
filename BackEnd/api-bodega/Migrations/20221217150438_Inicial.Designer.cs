﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_bodega;

namespace api_bodega.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221217150438_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api_bodega.Entitys.Categoria", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("comCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estadoCategoria")
                        .HasColumnType("bit");

                    b.Property<string>("nomCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("api_bodega.Entitys.Cliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EstadoCliente")
                        .HasColumnType("bit");

                    b.Property<string>("NDocumento")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("distritoidDistrito")
                        .HasColumnType("int");

                    b.Property<int>("idDistrito")
                        .HasColumnType("int");

                    b.HasKey("idCliente");

                    b.HasIndex("distritoidDistrito");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("api_bodega.Entitys.Comprobante", b =>
                {
                    b.Property<int>("idComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstadoComprobante")
                        .HasColumnType("bit");

                    b.Property<string>("FechaComprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Igv")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("TipoComprobante")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("clienteidCliente")
                        .HasColumnType("int");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioidUsuario")
                        .HasColumnType("int");

                    b.HasKey("idComprobante");

                    b.HasIndex("clienteidCliente");

                    b.HasIndex("usuarioidUsuario");

                    b.ToTable("Comprobante");
                });

            modelBuilder.Entity("api_bodega.Entitys.DetalleComprobante", b =>
                {
                    b.Property<int>("idDetalleComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantProducto")
                        .HasColumnType("int");

                    b.Property<decimal>("ImporteProducto")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("comprobanteidComprobante")
                        .HasColumnType("int");

                    b.Property<int>("idComprobante")
                        .HasColumnType("int");

                    b.Property<int>("idProducto")
                        .HasColumnType("int");

                    b.Property<int?>("productoidProducto")
                        .HasColumnType("int");

                    b.HasKey("idDetalleComprobante");

                    b.HasIndex("comprobanteidComprobante");

                    b.HasIndex("productoidProducto");

                    b.ToTable("DetalleComprobante");
                });

            modelBuilder.Entity("api_bodega.Entitys.Distrito", b =>
                {
                    b.Property<int>("idDistrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("comDistrito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estadoDistrito")
                        .HasColumnType("bit");

                    b.Property<string>("nomDistrito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idDistrito");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("api_bodega.Entitys.Producto", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EstadoProducto")
                        .HasColumnType("bit");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("categoriaidCategoria")
                        .HasColumnType("int");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.HasKey("idProducto");

                    b.HasIndex("categoriaidCategoria");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("api_bodega.Entitys.Proveedor", b =>
                {
                    b.Property<int>("idProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("categoriaidCategoria")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estadoProveedor")
                        .HasColumnType("bit");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ruc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idProveedor");

                    b.HasIndex("categoriaidCategoria");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("api_bodega.Entitys.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContraseñaUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EstadoUsuario")
                        .HasColumnType("bit");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("api_bodega.Entitys.Cliente", b =>
                {
                    b.HasOne("api_bodega.Entitys.Distrito", "distrito")
                        .WithMany("cliente")
                        .HasForeignKey("distritoidDistrito");

                    b.Navigation("distrito");
                });

            modelBuilder.Entity("api_bodega.Entitys.Comprobante", b =>
                {
                    b.HasOne("api_bodega.Entitys.Cliente", "cliente")
                        .WithMany("comprobante")
                        .HasForeignKey("clienteidCliente");

                    b.HasOne("api_bodega.Entitys.Usuario", "usuario")
                        .WithMany("comprobante")
                        .HasForeignKey("usuarioidUsuario");

                    b.Navigation("cliente");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("api_bodega.Entitys.DetalleComprobante", b =>
                {
                    b.HasOne("api_bodega.Entitys.Comprobante", "comprobante")
                        .WithMany()
                        .HasForeignKey("comprobanteidComprobante");

                    b.HasOne("api_bodega.Entitys.Producto", "producto")
                        .WithMany("detallecomprobante")
                        .HasForeignKey("productoidProducto");

                    b.Navigation("comprobante");

                    b.Navigation("producto");
                });

            modelBuilder.Entity("api_bodega.Entitys.Producto", b =>
                {
                    b.HasOne("api_bodega.Entitys.Categoria", "categoria")
                        .WithMany("producto")
                        .HasForeignKey("categoriaidCategoria");

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("api_bodega.Entitys.Proveedor", b =>
                {
                    b.HasOne("api_bodega.Entitys.Categoria", "categoria")
                        .WithMany("proveedor")
                        .HasForeignKey("categoriaidCategoria");

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("api_bodega.Entitys.Categoria", b =>
                {
                    b.Navigation("producto");

                    b.Navigation("proveedor");
                });

            modelBuilder.Entity("api_bodega.Entitys.Cliente", b =>
                {
                    b.Navigation("comprobante");
                });

            modelBuilder.Entity("api_bodega.Entitys.Distrito", b =>
                {
                    b.Navigation("cliente");
                });

            modelBuilder.Entity("api_bodega.Entitys.Producto", b =>
                {
                    b.Navigation("detallecomprobante");
                });

            modelBuilder.Entity("api_bodega.Entitys.Usuario", b =>
                {
                    b.Navigation("comprobante");
                });
#pragma warning restore 612, 618
        }
    }
}

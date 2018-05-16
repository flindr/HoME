﻿// <auto-generated />
using HoMeAPI.Entities;
using HoMeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HoMeAPI.Migrations
{
    [DbContext(typeof(MeasurementsContext))]
    [Migration("20180516200714_added body measurements")]
    partial class addedbodymeasurements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoMeAPI.Entities.BodyMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Bmi");

                    b.Property<int>("Bmr");

                    b.Property<float>("BodyFat");

                    b.Property<float>("BodyWater");

                    b.Property<float>("Muscle");

                    b.Property<DateTime>("Time");

                    b.Property<float>("Weight");

                    b.HasKey("Id");

                    b.ToTable("BodyMeasurements");
                });

            modelBuilder.Entity("HoMeAPI.Entities.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Humidity");

                    b.Property<int>("Location");

                    b.Property<float>("Temperature");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("Measurements");
                });
#pragma warning restore 612, 618
        }
    }
}

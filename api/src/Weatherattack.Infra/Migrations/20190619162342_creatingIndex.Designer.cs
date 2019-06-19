﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherAttack.Infra;

namespace WeatherAttack.Infra.Migrations
{
    [DbContext(typeof(WeatherAttackContext))]
    [Migration("20190619162342_creatingIndex")]
    partial class creatingIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherAttack.Domain.Entities.Character", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Battles")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0L);

                    b.Property<long>("HealthPoints");

                    b.Property<long>("Losses")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0L);

                    b.Property<long>("ManaPoints");

                    b.Property<long>("Medals")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0L);

                    b.Property<long>("UserId");

                    b.Property<long>("Wins")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0L);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("WeatherAttack.Domain.Entities.Spell", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseDamage");

                    b.Property<int>("BaseManaCost");

                    b.Property<byte>("Element");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("WeatherAttack.Domain.Entities.SpellRule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Operator");

                    b.Property<long?>("SpellId")
                        .IsRequired();

                    b.Property<int>("Value");

                    b.Property<byte>("WeatherCondition");

                    b.HasKey("Id");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellRules");
                });

            modelBuilder.Entity("WeatherAttack.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<byte>("PermissionLevel");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Email", "Username")
                        .IsUnique()
                        .HasName("IX_USER");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeatherAttack.Domain.Entities.Character", b =>
                {
                    b.HasOne("WeatherAttack.Domain.Entities.User")
                        .WithOne("Character")
                        .HasForeignKey("WeatherAttack.Domain.Entities.Character", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherAttack.Domain.Entities.SpellRule", b =>
                {
                    b.HasOne("WeatherAttack.Domain.Entities.Spell", "Spell")
                        .WithMany("Rules")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

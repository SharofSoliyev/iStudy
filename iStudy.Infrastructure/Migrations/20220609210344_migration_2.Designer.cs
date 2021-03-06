// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iStudy.Infrastructure.Data;

namespace iStudy.Infrastructure.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20220609210344_migration_2")]
    partial class migration_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("iStudy.Core.Entities.CITIES", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("iStudy.Core.Entities.DEPARTMENTS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("iStudy.Core.Entities.STUDENTS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CITIESId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentGradeLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DEPARTMENTSId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CITIESId");

                    b.HasIndex("DEPARTMENTSId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("iStudy.Core.Entities.STUDENTS_SUBJECTS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Mark")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("STUDENTSId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SUBJECTSId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("STUDENTSId");

                    b.HasIndex("SUBJECTSId");

                    b.ToTable("Student_Subjects");
                });

            modelBuilder.Entity("iStudy.Core.Entities.SUBJECTS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("iStudy.Core.Entities.TEACHERS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CITIESId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CITIESId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("iStudy.Core.Entities.TEACHERS_SUBJECTS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SUBJECTSId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TEACHERSId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SUBJECTSId");

                    b.HasIndex("TEACHERSId");

                    b.ToTable("Teachers_Subjects");
                });

            modelBuilder.Entity("iStudy.Core.Entities.STUDENTS", b =>
                {
                    b.HasOne("iStudy.Core.Entities.CITIES", "CITIES")
                        .WithMany()
                        .HasForeignKey("CITIESId");

                    b.HasOne("iStudy.Core.Entities.DEPARTMENTS", "DEPARTMENTS")
                        .WithMany()
                        .HasForeignKey("DEPARTMENTSId");

                    b.Navigation("CITIES");

                    b.Navigation("DEPARTMENTS");
                });

            modelBuilder.Entity("iStudy.Core.Entities.STUDENTS_SUBJECTS", b =>
                {
                    b.HasOne("iStudy.Core.Entities.STUDENTS", "STUDENTS")
                        .WithMany()
                        .HasForeignKey("STUDENTSId");

                    b.HasOne("iStudy.Core.Entities.SUBJECTS", "SUBJECTS")
                        .WithMany()
                        .HasForeignKey("SUBJECTSId");

                    b.Navigation("STUDENTS");

                    b.Navigation("SUBJECTS");
                });

            modelBuilder.Entity("iStudy.Core.Entities.TEACHERS", b =>
                {
                    b.HasOne("iStudy.Core.Entities.CITIES", "CITIES")
                        .WithMany()
                        .HasForeignKey("CITIESId");

                    b.Navigation("CITIES");
                });

            modelBuilder.Entity("iStudy.Core.Entities.TEACHERS_SUBJECTS", b =>
                {
                    b.HasOne("iStudy.Core.Entities.SUBJECTS", "SUBJECTS")
                        .WithMany()
                        .HasForeignKey("SUBJECTSId");

                    b.HasOne("iStudy.Core.Entities.TEACHERS", "TEACHERS")
                        .WithMany()
                        .HasForeignKey("TEACHERSId");

                    b.Navigation("SUBJECTS");

                    b.Navigation("TEACHERS");
                });
#pragma warning restore 612, 618
        }
    }
}

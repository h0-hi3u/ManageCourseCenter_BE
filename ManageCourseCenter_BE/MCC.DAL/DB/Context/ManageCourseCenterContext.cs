using System;
using System.Collections.Generic;
using MCC.DAL.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MCC.DAL.EntityModels.Context
{
    public partial class ManageCourseCenterContext : DbContext
    {
        public ManageCourseCenterContext()
        {
        }

        public ManageCourseCenterContext(DbContextOptions<ManageCourseCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassTime> ClassTimes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<EquipmenntActivity> EquipmenntActivities { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentReport> EquipmentReports { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = ManageCourseCenter;uid=sa;pwd=1234567890;Trustservercertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicTranscript>(entity =>
            {
                entity.ToTable("AcademicTranscript");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Average).HasColumnName("average");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Midtern).HasColumnName("midtern");

                entity.Property(e => e.Quiz1).HasColumnName("quiz_1");

                entity.Property(e => e.Quiz2).HasColumnName("quiz_2");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcademicTranscript_Children");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcademicTranscript_Course");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcademicTranscript_Teacher");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Cart");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Children");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Class");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItem_Course");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Children_Parent");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.TimeId).HasColumnName("time_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Course");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Teacher");
            });

            modelBuilder.Entity<ClassTime>(entity =>
            {
                entity.ToTable("ClassTime");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.DayInWeek)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("day_in_week");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.StarTime).HasColumnName("star_time");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassTimes)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassTime_Class");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CloseFormTime)
                    .HasColumnType("datetime")
                    .HasColumnName("close_form_time");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OpenFormTime)
                    .HasColumnType("datetime")
                    .HasColumnName("open_form_time");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalSlot).HasColumnName("total_slot");
            });

            modelBuilder.Entity<EquipmenntActivity>(entity =>
            {
                entity.ToTable("EquipmenntActivity");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.OperateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("operate_time");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmenntActivities)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmenntActivity_Equipment");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.EquipmenntActivities)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmenntActivity_Manager");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.EquipmenntActivities)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmenntActivity_Room");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<EquipmentReport>(entity =>
            {
                entity.ToTable("EquipmentReport");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentReports)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReport_Equipment");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CourseRating).HasColumnName("course_rating");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EquipmentRating).HasColumnName("equipment_rating");

                entity.Property(e => e.TeacherRating).HasColumnName("teacher_rating");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Children");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Course1");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Cart");

                entity.HasOne(d => d.CartNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Parent");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.RoomNo).HasColumnName("room_no");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Children");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Room");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

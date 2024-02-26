using System;
using System.Collections.Generic;
using MCC.DAL.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MCC.DAL.DB.Context
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Average)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("average");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Final)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("final");

                entity.Property(e => e.Midtern)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("midtern");

                entity.Property(e => e.Quiz1)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("quiz_1");

                entity.Property(e => e.Quiz2)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("quiz_2");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__child__2E1BDC42");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__cours__2D27B809");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AcademicT__teach__2C3393D0");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__parent_id__38996AB5");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__cart_i__3B75D760");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__childr__3E52440B");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__class___3D5E1FD2");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__course__3C69FB99");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__course_id__34C8D9D1");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__teacher_i__35BCFE0A");
            });

            modelBuilder.Entity<ClassTime>(entity =>
            {
                entity.ToTable("ClassTime");

                entity.Property(e => e.Id).HasColumnName("id");

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
                    .HasConstraintName("FK__ClassTime__class__412EB0B6");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CloseFormTime)
                    .HasColumnType("datetime")
                    .HasColumnName("close_form_time");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Description).HasColumnName("description");

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
                    .HasConstraintName("FK__Equipmenn__equip__4AB81AF0");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.EquipmenntActivities)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipmenn__manag__49C3F6B7");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.EquipmenntActivities)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipmenn__room___4BAC3F29");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<EquipmentReport>(entity =>
            {
                entity.ToTable("EquipmentReport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentReports)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__equip__4F7CD00D");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.EquipmentReports)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__room___4E88ABD4");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CourseRating).HasColumnName("course_rating");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EquipmentRating).HasColumnName("equipment_rating");

                entity.Property(e => e.TeacherRating).HasColumnName("teacher_rating");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__childr__52593CB8");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__course__534D60F1");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__cart_id__59063A47");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.RoomNo).HasColumnName("room_no");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.ChildrenId).HasColumnName("children_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ChildrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__childr__5CD6CB2B");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__course__5DCAEF64");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__room_i__5EBF139D");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__teache__5BE2A6F2");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasColumnName("birth_day");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RemoteTrainingApi;

namespace RemoteTrainingApi.Migrations
{
    [DbContext(typeof(RTADbContext))]
    [Migration("20201120181355_Roles")]
    partial class Roles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RemoteTrainingApi.Groups.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<int?>("MembershipId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("MembershipId");

                    b.HasIndex("UserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.Discussion", b =>
                {
                    b.Property<int>("DiscussionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("DiscussionId");

                    b.HasIndex("GroupId");

                    b.ToTable("Discussion");
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Membership");
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportId");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.SportOnGroup", b =>
                {
                    b.Property<int>("SportOnGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.HasKey("SportOnGroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SportId");

                    b.ToTable("SportOnGroup");
                });

            modelBuilder.Entity("RemoteTrainingApi.Users.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.ExerciseOnWorkout", b =>
                {
                    b.Property<int>("ExerciseOnWorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseOnWorkoutId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseOnWorkout");
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.ExerciseSet", b =>
                {
                    b.Property<int>("ExerciseSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseOnWorkoutId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("PauseSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("UserOnWorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ExerciseSetId");

                    b.HasIndex("ExerciseOnWorkoutId");

                    b.HasIndex("UserOnWorkoutId");

                    b.ToTable("ExerciseSet");
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.UserOnWorkout", b =>
                {
                    b.Property<int>("UserOnWorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("WillAttend")
                        .HasColumnType("bit");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("UserOnWorkoutId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("UserOnWorkout");
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTemplate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WorkoutId");

                    b.HasIndex("GroupId");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Message", b =>
                {
                    b.HasOne("RemoteTrainingApi.Groups.Models.Discussion", "Discussion")
                        .WithMany("Messages")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RemoteTrainingApi.Groups.Models.Membership", null)
                        .WithMany("Message")
                        .HasForeignKey("MembershipId");

                    b.HasOne("RemoteTrainingApi.Users.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.Discussion", b =>
                {
                    b.HasOne("RemoteTrainingApi.Groups.Models.Group", "Group")
                        .WithMany("Discussions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.Membership", b =>
                {
                    b.HasOne("RemoteTrainingApi.Groups.Models.Group", "Group")
                        .WithMany("Membership")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RemoteTrainingApi.Users.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Groups.Models.SportOnGroup", b =>
                {
                    b.HasOne("RemoteTrainingApi.Groups.Models.Group", "Group")
                        .WithMany("SportsOnGroup")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RemoteTrainingApi.Groups.Models.Sport", "Sport")
                        .WithMany("SportsOnGroup")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.Exercise", b =>
                {
                    b.HasOne("RemoteTrainingApi.Users.Models.User", "User")
                        .WithMany("Exercises")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.ExerciseOnWorkout", b =>
                {
                    b.HasOne("RemoteTrainingApi.Workouts.Models.Exercise", "Exercise")
                        .WithMany("ExerciseOnWorkouts")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RemoteTrainingApi.Workouts.Models.Workout", "Workout")
                        .WithMany("ExerciseOnWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.ExerciseSet", b =>
                {
                    b.HasOne("RemoteTrainingApi.Workouts.Models.ExerciseOnWorkout", "ExerciseOnWorkout")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("ExerciseOnWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RemoteTrainingApi.Workouts.Models.UserOnWorkout", "UserOnWorkout")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("UserOnWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.UserOnWorkout", b =>
                {
                    b.HasOne("RemoteTrainingApi.Users.Models.User", "User")
                        .WithMany("UsersOnWorkout")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RemoteTrainingApi.Workouts.Models.Workout", "Workout")
                        .WithMany("UsersOnWorkout")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteTrainingApi.Workouts.Models.Workout", b =>
                {
                    b.HasOne("RemoteTrainingApi.Groups.Models.Group", null)
                        .WithMany("Workouts")
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}

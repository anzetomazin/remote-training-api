using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteTrainingApi.Migrations
{
    public partial class Asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseOnWorkout_Exercise_ExerciseId",
                table: "ExerciseOnWorkout");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_User_UserId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Workout_UserId",
                table: "Workout");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Workout",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserOnWorkoutId",
                table: "ExerciseSet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "UserOnWorkout",
                columns: table => new
                {
                    UserOnWorkoutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WillAttend = table.Column<bool>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOnWorkout", x => x.UserOnWorkoutId);
                    table.ForeignKey(
                        name: "FK_UserOnWorkout_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOnWorkout_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discussion",
                columns: table => new
                {
                    DiscussionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussion", x => x.DiscussionId);
                    table.ForeignKey(
                        name: "FK_Discussion_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    MembershipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_Membership_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipId = table.Column<int>(nullable: true),
                    DiscussionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Discussion_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussion",
                        principalColumn: "DiscussionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workout_GroupId",
                table: "Workout",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSet_UserOnWorkoutId",
                table: "ExerciseSet",
                column: "UserOnWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_GroupId",
                table: "Discussion",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_GroupId",
                table: "Membership",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_UserId",
                table: "Membership",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_DiscussionId",
                table: "Message",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_MembershipId",
                table: "Message",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOnWorkout_UserId",
                table: "UserOnWorkout",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOnWorkout_WorkoutId",
                table: "UserOnWorkout",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseOnWorkout_Exercise_ExerciseId",
                table: "ExerciseOnWorkout",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSet_UserOnWorkout_UserOnWorkoutId",
                table: "ExerciseSet",
                column: "UserOnWorkoutId",
                principalTable: "UserOnWorkout",
                principalColumn: "UserOnWorkoutId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Group_GroupId",
                table: "Workout",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseOnWorkout_Exercise_ExerciseId",
                table: "ExerciseOnWorkout");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSet_UserOnWorkout_UserOnWorkoutId",
                table: "ExerciseSet");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Group_GroupId",
                table: "Workout");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "UserOnWorkout");

            migrationBuilder.DropTable(
                name: "Discussion");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Workout_GroupId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSet_UserOnWorkoutId",
                table: "ExerciseSet");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "UserOnWorkoutId",
                table: "ExerciseSet");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_UserId",
                table: "Workout",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseOnWorkout_Exercise_ExerciseId",
                table: "ExerciseOnWorkout",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_User_UserId",
                table: "Workout",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

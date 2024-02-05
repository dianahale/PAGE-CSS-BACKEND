using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PageCss.DataAccess.Migrations
{
    public partial class AddtableSubscriptionPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubscriptionPlans_subscriptionPlansId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "subscriptionPlansId",
                table: "AspNetUsers",
                newName: "SubscriptionPlansId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_subscriptionPlansId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SubscriptionPlansId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubscriptionPlans_SubscriptionPlansId",
                table: "AspNetUsers",
                column: "SubscriptionPlansId",
                principalTable: "SubscriptionPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubscriptionPlans_SubscriptionPlansId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SubscriptionPlansId",
                table: "AspNetUsers",
                newName: "subscriptionPlansId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SubscriptionPlansId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_subscriptionPlansId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubscriptionPlans_subscriptionPlansId",
                table: "AspNetUsers",
                column: "subscriptionPlansId",
                principalTable: "SubscriptionPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

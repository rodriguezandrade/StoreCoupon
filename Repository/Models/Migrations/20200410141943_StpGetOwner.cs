using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class StpGetOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Stored Procedures

            //Get Owners from Users
            var sp_GetOwners = @"CREATE PROCEDURE stpGetOwners
                               AS
                               BEGIN
                                    SET NOCOUNT ON;
                                    SELECT UserDetails.Id, UserDetails.FirstName, UserDetails.LastName, UserDetails.Address, UserDetails.Telephone, UserDetails.RFC, UserDetails.IdUser FROM UserDetails, UserRoles WHERE UserDetails.id = UserRoles.Id AND UserRoles.Id=1
                               END";
            migrationBuilder.Sql(sp_GetOwners);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

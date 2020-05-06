using Microsoft.EntityFrameworkCore.Migrations;

namespace GihanSoft.EfCore.Test.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "e4ux+rg+mjrBH5lpmAjO3kbC7ZQoZy+2nGQctmRFPfA=",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    x60CtDoxdsIVW2h5hgD6WyIoSDE6I3EMCMsWj1F21c = table.Column<string>(name: "/x60CtDoxdsIVW2h5hgD6WyIoSDE6I3EMCMsWj1F21c=", nullable: true),
                    lpzL089jAOzVyIBFnYGukCffdRdWMYShuLFSgtsjBiE = table.Column<string>(name: "lpzL089jAOzVyIBFnYGukCffdRdWMYShuLFSgtsjBiE=", nullable: true),
                    _1yD2HIxeKB4mchfy6OCQ6DIIdypR2GNDwrvxvQQPef4 = table.Column<string>(name: "1yD2HIxeKB4mchfy6OCQ6DIIdypR2GNDwrvxvQQPef4=", nullable: true),
                    y6rTz0plBXWYFXiVcqWRYjIww7PGY5yY7ZdBP1k = table.Column<string>(name: "y6rTz0plB+XW+YFX+iVcqWRYjIww7PGY+5yY7ZdBP1k=", nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_e4ux+rg+mjrBH5lpmAjO3kbC7ZQoZy+2nGQctmRFPfA=", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "e4ux+rg+mjrBH5lpmAjO3kbC7ZQoZy+2nGQctmRFPfA=");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProcedureCRUD.Migrations
{
    /// <inheritdoc />
    public partial class EmptyAddProductStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create stored procedures
            migrationBuilder.Sql(@"
                CREATE PROCEDURE CreateProduct
                    @Name NVARCHAR(100),
                    @Price DECIMAL(18, 2)
                AS
                BEGIN
                    INSERT INTO Products (Name, Price)
                    VALUES (@Name, @Price);
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetProductById
                    @Id INT
                AS
                BEGIN
                    SELECT * FROM Products WHERE Id = @Id;
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE UpdateProduct
                    @Id INT,
                    @Name NVARCHAR(100),
                    @Price DECIMAL(18, 2)
                AS
                BEGIN
                    UPDATE Products
                    SET Name = @Name, Price = @Price
                    WHERE Id = @Id;
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE DeleteProduct
                    @Id INT
                AS
                BEGIN
                    DELETE FROM Products WHERE Id = @Id;
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetProducts
                AS
                BEGIN
                    SELECT * FROM Products;
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop stored procedures
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS CreateProduct");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetProductById");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS UpdateProduct");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS DeleteProduct");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetProducts");
        }
    }
}

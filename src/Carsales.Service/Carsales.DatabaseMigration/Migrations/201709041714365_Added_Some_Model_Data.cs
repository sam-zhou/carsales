namespace Carsales.DatabaseMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Some_Model_Data : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Makes (Name, CreatedDateTime, CreatedBy)
                SELECT 'Acura' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Audi' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Bentley' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'BMW' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Buick' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Cadillac' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Chevrolet' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Chrysler' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Dodge' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Fiat' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Ford' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'GMC' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Honda' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Hyundai' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Infiniti' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Jaguar' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Jeep' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Kia' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Lamborghini' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Lexus' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Lincoln' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Maserati' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Mazda' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'McLaren' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Mercedes-Benz' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Mini' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Mitsubishi' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Nissan' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Porsche' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Rolls-Royce' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Scion' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Smart' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Subaru' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Toyota' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Volkswagen' , GETUTCDATE(), 1
                UNION ALL
                SELECT 'Volvo' , GETUTCDATE(), 1
                GO");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM MAKES");
        }
    }
}

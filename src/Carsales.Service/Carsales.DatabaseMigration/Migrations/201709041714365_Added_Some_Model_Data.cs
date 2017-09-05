namespace Carsales.DatabaseMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Some_Model_Data : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT Makes ON
                INSERT INTO Makes (Id, Name, CreatedDateTime, CreatedBy)
                SELECT 2,'Acura' , GETUTCDATE(), 1
                UNION ALL
                SELECT 3,'Audi' , GETUTCDATE(), 1
                UNION ALL
                SELECT 4,'Bentley' , GETUTCDATE(), 1
                UNION ALL
                SELECT 5,'BMW' , GETUTCDATE(), 1
                UNION ALL
                SELECT 6,'Buick' , GETUTCDATE(), 1
                UNION ALL
                SELECT 7,'Cadillac' , GETUTCDATE(), 1
                UNION ALL
                SELECT 8,'Chevrolet' , GETUTCDATE(), 1
                UNION ALL
                SELECT 9,'Chrysler' , GETUTCDATE(), 1
                UNION ALL
                SELECT 10,'Dodge' , GETUTCDATE(), 1
                UNION ALL
                SELECT 11,'Fiat' , GETUTCDATE(), 1
                UNION ALL
                SELECT 12,'Ford' , GETUTCDATE(), 1
                UNION ALL
                SELECT 13,'GMC' , GETUTCDATE(), 1
                UNION ALL
                SELECT 14,'Honda' , GETUTCDATE(), 1
                UNION ALL
                SELECT 15,'Hyundai' , GETUTCDATE(), 1
                UNION ALL
                SELECT 16,'Infiniti' , GETUTCDATE(), 1
                UNION ALL
                SELECT 17,'Jaguar' , GETUTCDATE(), 1
                UNION ALL
                SELECT 18,'Jeep' , GETUTCDATE(), 1
                UNION ALL
                SELECT 19,'Kia' , GETUTCDATE(), 1
                UNION ALL
                SELECT 20,'Lamborghini' , GETUTCDATE(), 1
                UNION ALL
                SELECT 21,'Lexus' , GETUTCDATE(), 1
                UNION ALL
                SELECT 22,'Lincoln' , GETUTCDATE(), 1
                UNION ALL
                SELECT 23,'Maserati' , GETUTCDATE(), 1
                UNION ALL
                SELECT 24,'Mazda' , GETUTCDATE(), 1
                UNION ALL
                SELECT 25,'McLaren' , GETUTCDATE(), 1
                UNION ALL
                SELECT 26,'Mercedes-Benz' , GETUTCDATE(), 1
                UNION ALL
                SELECT 27,'Mini' , GETUTCDATE(), 1
                UNION ALL
                SELECT 28,'Mitsubishi' , GETUTCDATE(), 1
                UNION ALL
                SELECT 29,'Nissan' , GETUTCDATE(), 1
                UNION ALL
                SELECT 30,'Porsche' , GETUTCDATE(), 1
                UNION ALL
                SELECT 31,'Rolls-Royce' , GETUTCDATE(), 1
                UNION ALL
                SELECT 32,'Scion' , GETUTCDATE(), 1
                UNION ALL
                SELECT 33,'Smart' , GETUTCDATE(), 1
                UNION ALL
                SELECT 34,'Subaru' , GETUTCDATE(), 1
                UNION ALL
                SELECT 35,'Toyota' , GETUTCDATE(), 1
                UNION ALL
                SELECT 36,'Volkswagen' , GETUTCDATE(), 1
                UNION ALL
                SELECT 37,'Volvo' , GETUTCDATE(), 1
                GO
                SET IDENTITY_INSERT Makes OFF");
            Sql(@"
                SET IDENTITY_INSERT Models ON
                INSERT INTO Models (Id, Name, MakeId, CREATEDDATETIME, CREATEDBY, VehicleType)
                 SELECT 1,'1 Series',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 2,'2 Series',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 3,'3 Series',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 4,'4 Series',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 5,'5 Series',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 6,'7 Series',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 7,'X1',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 8,'X3',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 9,'X4',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 10,'X5',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 11,'X6',5 , GETUTCDATE(), 1, 1
                 UNION ALL
                 SELECT 12,'M Series',5 , GETUTCDATE(), 1, 1
                GO
                SET IDENTITY_INSERT Models OFF");

            Sql(@" SET IDENTITY_INSERT Badges ON
                  INSERT INTO Badges (Id, Name, BadgeType, ModelId, CreatedDateTime, CreatedBy, Engine, Doors, Wheels)
                  SELECT 1, 'F15 xDrive20i', 103, 10, GETUTCDATE(), 1, 2000, 5, 4
                  UNION ALL
                  SELECT 2, 'F15 xDrive20d', 103, 10, GETUTCDATE(), 1, 2000, 5, 4
                  UNION ALL
                  SELECT 3, 'F15 xDrive30i', 103, 10, GETUTCDATE(), 1, 3000, 5, 4
                  UNION ALL
                  SELECT 4, 'F15 xDrive30d', 103, 10, GETUTCDATE(), 1, 3000, 5, 4
                  UNION ALL
                  SELECT 5, 'E70 xDrive30d', 103, 10, GETUTCDATE(), 1, 3000, 5, 4
                  GO
  
                  SET IDENTITY_INSERT Badges OFF");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM Badges");
            Sql(@"DELETE FROM Models");
            Sql(@"DELETE FROM MAKES");
        }
    }
}

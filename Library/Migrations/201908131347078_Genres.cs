namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action and adventure')");

            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Alternate history')");

            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Anthology')");

            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Chick lit')");

            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Children s')");
        }
        
        public override void Down()
        {
        }
    }
}

namespace WeApiNg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentMasters",
                c => new
                    {
                        StdID = c.Int(nullable: false, identity: true),
                        StdName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StdID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentMasters");
        }
    }
}

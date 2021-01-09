namespace mvc_najehacademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        birth = c.DateTime(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        Confirm = c.String(nullable: false, maxLength: 20),
                        MajorID = c.Int(),
                        RoleRoleID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Majors", t => t.MajorID)
                .ForeignKey("dbo.Roles", t => t.RoleRoleID, cascadeDelete: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.MajorID)
                .Index(t => t.RoleRoleID);
            
            CreateTable(
                "dbo.Junctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Hours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Guid(nullable: false),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "ID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleRoleID", "dbo.Roles");
            DropForeignKey("dbo.Users", "MajorID", "dbo.Majors");
            DropForeignKey("dbo.Junctions", "UserID", "dbo.Users");
            DropForeignKey("dbo.Junctions", "CourseID", "dbo.Courses");
            DropIndex("dbo.Junctions", new[] { "CourseID" });
            DropIndex("dbo.Junctions", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "RoleRoleID" });
            DropIndex("dbo.Users", new[] { "MajorID" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Accounts", new[] { "ID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Majors");
            DropTable("dbo.Courses");
            DropTable("dbo.Junctions");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}

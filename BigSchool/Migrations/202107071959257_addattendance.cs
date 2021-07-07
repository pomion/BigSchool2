namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Attendee_Id = c.String(maxLength: 128),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.Attendee_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Attendee_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "Attendee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "Course_Id" });
            DropIndex("dbo.Attendances", new[] { "Attendee_Id" });
            DropTable("dbo.Attendances");
        }
    }
}

namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSkillsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Skills(Name) VALUES('Applications')");
            Sql("INSERT INTO Skills(Name) VALUES('Certifications')");
            Sql("INSERT INTO Skills(Name) VALUES('Coding')");
            Sql("INSERT INTO Skills(Name) VALUES('Computing')");
            Sql("INSERT INTO Skills(Name) VALUES('Configuration')");
            Sql("INSERT INTO Skills(Name) VALUES('Customer Support')");
            Sql("INSERT INTO Skills(Name) VALUES('Debugging')");
            Sql("INSERT INTO Skills(Name) VALUES('Design')");
            Sql("INSERT INTO Skills(Name) VALUES('Development')");
            Sql("INSERT INTO Skills(Name) VALUES('Hardware')");
            Sql("INSERT INTO Skills(Name) VALUES('Implementation')");
            Sql("INSERT INTO Skills(Name) VALUES('Information Technology')");
            Sql("INSERT INTO Skills(Name) VALUES('Infrastructure')");
            Sql("INSERT INTO Skills(Name) VALUES('Languages')");
            Sql("INSERT INTO Skills(Name) VALUES('Maintenance')");
            Sql("INSERT INTO Skills(Name) VALUES('Network Architecture')");
            Sql("INSERT INTO Skills(Name) VALUES('Network Security')");
            Sql("INSERT INTO Skills(Name) VALUES('Networking')");
            Sql("INSERT INTO Skills(Name) VALUES('New Technologies')");
            Sql("INSERT INTO Skills(Name) VALUES('Operating Systems')");
            Sql("INSERT INTO Skills(Name) VALUES('Programming')");
            Sql("INSERT INTO Skills(Name) VALUES('Restoration')");
            Sql("INSERT INTO Skills(Name) VALUES('Security')");
            Sql("INSERT INTO Skills(Name) VALUES('Servers')");
            Sql("INSERT INTO Skills(Name) VALUES('Software')");
            Sql("INSERT INTO Skills(Name) VALUES('Solution Delivery')");
            Sql("INSERT INTO Skills(Name) VALUES('Storage')");
            Sql("INSERT INTO Skills(Name) VALUES('Structures')");
            Sql("INSERT INTO Skills(Name) VALUES('Systems Analysis')");
            Sql("INSERT INTO Skills(Name) VALUES('Technical Support')");
            Sql("INSERT INTO Skills(Name) VALUES('Technology')");
            Sql("INSERT INTO Skills(Name) VALUES('Testing')");
            Sql("INSERT INTO Skills(Name) VALUES('Tools')");
            Sql("INSERT INTO Skills(Name) VALUES('Training')");
            Sql("INSERT INTO Skills(Name) VALUES('Troubleshooting')");
            Sql("INSERT INTO Skills(Name) VALUES('.NET')");
            Sql("INSERT INTO Skills(Name) VALUES('SQL')");
            Sql("INSERT INTO Skills(Name) VALUES('SQL Server')");
            Sql("INSERT INTO Skills(Name) VALUES('C#')");
            Sql("INSERT INTO Skills(Name) VALUES('JavaScript')");
            Sql("INSERT INTO Skills(Name) VALUES('ASP.NET')");
            Sql("INSERT INTO Skills(Name) VALUES('CSS')");
            Sql("INSERT INTO Skills(Name) VALUES('HTML')");
            Sql("INSERT INTO Skills(Name) VALUES('Python')");
            Sql("INSERT INTO Skills(Name) VALUES('JQuery')");
            Sql("INSERT INTO Skills(Name) VALUES('MVC')");
            Sql("INSERT INTO Skills(Name) VALUES('AngularJS')");
            Sql("INSERT INTO Skills(Name) VALUES('Ruby')");
            Sql("INSERT INTO Skills(Name) VALUES('Data Analysis')");
            Sql("INSERT INTO Skills(Name) VALUES('Bootstrap')");
            Sql("INSERT INTO Skills(Name) VALUES('Experience')");
            Sql("INSERT INTO Skills(Name) VALUES('Team')");
            Sql("INSERT INTO Skills(Name) VALUES('Design')");
            Sql("INSERT INTO Skills(Name) VALUES('Testing')");
            Sql("INSERT INTO Skills(Name) VALUES('Management')");
            Sql("INSERT INTO Skills(Name) VALUES('Knowledge')");
            Sql("INSERT INTO Skills(Name) VALUES('Strong')");
            Sql("INSERT INTO Skills(Name) VALUES('Agile')");
            Sql("INSERT INTO Skills(Name) VALUES('Understanding')");
            Sql("INSERT INTO Skills(Name) VALUES('Flexible')");
        }
        
        public override void Down()
        {
        }
    }
}

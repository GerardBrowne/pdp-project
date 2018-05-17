namespace StormPDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateManagersTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Managers(StormId, Name, Email) VALUES('101', 'Louis Martinez', 'lm@storm.ie')");
            Sql("INSERT INTO Managers(StormId, Name, Email) VALUES('102', 'Robert Smith', 'rs@storm.ie')");
            Sql("INSERT INTO Managers(StormId, Name, Email) VALUES('103', 'Larry Miller', 'lm2@storm.ie')");
            Sql("INSERT INTO Managers(StormId, Name, Email) VALUES('104', 'John Johnson', 'jj@storm.ie')");
            Sql("INSERT INTO Managers(StormId, Name, Email) VALUES('105', 'Gregory Rodriguez', 'gr@storm.ie')");
        }
        
        public override void Down()
        {
        }
    }
}

namespace MNS.Translator.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TranslationRequest",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(nullable: false, maxLength: 4000),
                        Translation = c.String(maxLength: 4000),
                        ErrorMessage = c.String(maxLength: 500, unicode: false),
                        Success = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Ip = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TranslationRequest");
        }
    }
}

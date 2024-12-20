namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_restaurantsocial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantSocials",
                c => new
                    {
                        RestaurantSocialId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Icon = c.String(),
                        SocialMediaName = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantSocialId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantSocials");
        }
    }
}

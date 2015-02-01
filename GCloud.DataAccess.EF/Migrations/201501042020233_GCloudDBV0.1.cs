namespace GCloud.DataAccess.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GCloudDBV01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Tenant.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Address1 = c.String(maxLength: 250),
                        Address2 = c.String(maxLength: 250),
                        City = c.String(maxLength: 80),
                        Suburb = c.String(maxLength: 80),
                        PostalCode = c.String(maxLength: 10),
                        AddressType = c.Int(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        CountryId = c.Guid(),
                        StateProvinceId = c.Guid(),
                        ContactId = c.Guid(),
                        GymId = c.Guid(),
                        CustomerId = c.Guid(),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Tenant.Contact", t => t.ContactId)
                .ForeignKey("Tenant.Customer", t => t.CustomerId)
                .ForeignKey("Tenant.Gym", t => t.GymId)
                .ForeignKey("System.Country", t => t.CountryId)
                .ForeignKey("System.Province", t => t.StateProvinceId)
                .Index(t => t.CountryId)
                .Index(t => t.StateProvinceId)
                .Index(t => t.ContactId)
                .Index(t => t.GymId)
                .Index(t => t.CustomerId)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "Tenant.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(maxLength: 80),
                        Email = c.String(maxLength: 100),
                        WebSite = c.String(maxLength: 200),
                        Twitter = c.String(maxLength: 200),
                        Facebook = c.String(maxLength: 200),
                        Primary = c.Boolean(nullable: false),
                        Identification = c.String(maxLength: 50),
                        CustomField1 = c.String(maxLength: 100),
                        CustomField2 = c.String(maxLength: 100),
                        CustomField3 = c.String(maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                        Gym_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Tenant.Gym", t => t.Gym_Id)
                .Index(t => t.TenantId, name: "Tenant")
                .Index(t => t.Gym_Id);
            
            CreateTable(
                "Tenant.PhoneNumber",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AreaCode = c.String(nullable: false, maxLength: 3),
                        Number = c.String(nullable: false, maxLength: 8),
                        Primary = c.Boolean(nullable: false),
                        PhoneType = c.Int(nullable: false),
                        ContactId = c.Guid(),
                        GymId = c.Guid(),
                        CustomerId = c.Guid(),
                        UserId = c.Guid(),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Tenant.Contact", t => t.ContactId)
                .ForeignKey("Tenant.Gym", t => t.GymId)
                .ForeignKey("Tenant.Customer", t => t.CustomerId)
                .ForeignKey("Security.User", t => t.UserId)
                .Index(t => t.ContactId)
                .Index(t => t.GymId)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "Tenant.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 80),
                        Identification = c.String(maxLength: 50),
                        Card = c.Int(nullable: false),
                        IdentificationType = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 250),
                        Gender = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Email = c.String(maxLength: 100),
                        AllowNotifications = c.Boolean(nullable: false),
                        CustomField1 = c.String(maxLength: 100),
                        CustomField2 = c.String(maxLength: 100),
                        CustomField3 = c.String(maxLength: 100),
                        CustomField4 = c.String(maxLength: 100),
                        CustomField5 = c.String(maxLength: 100),
                        NacionalityId = c.Guid(),
                        GroupId = c.Guid(),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Tenant.Group", t => t.GroupId)
                .ForeignKey("System.Country", t => t.NacionalityId)
                .Index(t => t.NacionalityId)
                .Index(t => t.GroupId)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "Tenant.Group",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Code = c.String(maxLength: 10),
                        CustomField1 = c.String(maxLength: 100),
                        CustomField2 = c.String(maxLength: 100),
                        CustomField3 = c.String(maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "System.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 2),
                        CurrencyCode = c.String(maxLength: 3),
                        CurrencyName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "System.Province",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false, maxLength: 2),
                        CountryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("System.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "System.Tenant",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CurrencyId = c.Guid(nullable: false),
                        CountryId = c.Guid(nullable: false),
                        TenantState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("System.Country", t => t.CountryId)
                .ForeignKey("System.Currency", t => t.CurrencyId)
                .Index(t => t.CurrencyId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "System.Currency",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Tenant.Gym",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Code = c.String(maxLength: 20),
                        CurrencyId = c.Guid(),
                        CountryId = c.Guid(),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("System.Country", t => t.CountryId)
                .ForeignKey("System.Currency", t => t.CurrencyId)
                .Index(t => t.CurrencyId)
                .Index(t => t.CountryId)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "Security.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Email = c.String(maxLength: 50),
                        CustomField1 = c.String(maxLength: 100),
                        CustomField2 = c.String(maxLength: 100),
                        CustomField3 = c.String(maxLength: 100),
                        CustomField4 = c.String(maxLength: 100),
                        CustomField5 = c.String(maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "Security.Rol",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Tenant.Audit",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Resource = c.String(),
                        UserName = c.String(),
                        OldData = c.String(),
                        NewData = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "System.FrequencyPeriod",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Code = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "System.PaymentType",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        PaymentCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Tenant.Plan",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Code = c.String(nullable: false, maxLength: 3),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "Tenant.Rate",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FrequencyPeriodId = c.Guid(),
                        PlanId = c.Guid(),
                        Price = c.Long(nullable: false),
                        Active = c.Boolean(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("System.FrequencyPeriod", t => t.FrequencyPeriodId)
                .ForeignKey("Tenant.Plan", t => t.PlanId)
                .Index(t => t.FrequencyPeriodId)
                .Index(t => t.PlanId)
                .Index(t => t.TenantId, name: "Tenant");
            
            CreateTable(
                "Security.UserRole",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("Security.Rol", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Security.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Tenant.Rate", "PlanId", "Tenant.Plan");
            DropForeignKey("Tenant.Rate", "FrequencyPeriodId", "System.FrequencyPeriod");
            DropForeignKey("Tenant.Address", "StateProvinceId", "System.Province");
            DropForeignKey("Tenant.Address", "CountryId", "System.Country");
            DropForeignKey("Security.UserRole", "UserId", "Security.User");
            DropForeignKey("Security.UserRole", "RoleId", "Security.Rol");
            DropForeignKey("Tenant.PhoneNumber", "UserId", "Security.User");
            DropForeignKey("Tenant.PhoneNumber", "CustomerId", "Tenant.Customer");
            DropForeignKey("System.Tenant", "CurrencyId", "System.Currency");
            DropForeignKey("Tenant.PhoneNumber", "GymId", "Tenant.Gym");
            DropForeignKey("Tenant.Gym", "CurrencyId", "System.Currency");
            DropForeignKey("Tenant.Gym", "CountryId", "System.Country");
            DropForeignKey("Tenant.Contact", "Gym_Id", "Tenant.Gym");
            DropForeignKey("Tenant.Address", "GymId", "Tenant.Gym");
            DropForeignKey("System.Tenant", "CountryId", "System.Country");
            DropForeignKey("System.Province", "CountryId", "System.Country");
            DropForeignKey("Tenant.Customer", "NacionalityId", "System.Country");
            DropForeignKey("Tenant.Customer", "GroupId", "Tenant.Group");
            DropForeignKey("Tenant.Address", "CustomerId", "Tenant.Customer");
            DropForeignKey("Tenant.PhoneNumber", "ContactId", "Tenant.Contact");
            DropForeignKey("Tenant.Address", "ContactId", "Tenant.Contact");
            DropIndex("Security.UserRole", new[] { "UserId" });
            DropIndex("Security.UserRole", new[] { "RoleId" });
            DropIndex("Tenant.Rate", "Tenant");
            DropIndex("Tenant.Rate", new[] { "PlanId" });
            DropIndex("Tenant.Rate", new[] { "FrequencyPeriodId" });
            DropIndex("Tenant.Plan", "Tenant");
            DropIndex("Security.User", "Tenant");
            DropIndex("Security.User", new[] { "Email" });
            DropIndex("Security.User", new[] { "UserName" });
            DropIndex("Tenant.Gym", "Tenant");
            DropIndex("Tenant.Gym", new[] { "CountryId" });
            DropIndex("Tenant.Gym", new[] { "CurrencyId" });
            DropIndex("System.Tenant", new[] { "CountryId" });
            DropIndex("System.Tenant", new[] { "CurrencyId" });
            DropIndex("System.Province", new[] { "CountryId" });
            DropIndex("Tenant.Group", "Tenant");
            DropIndex("Tenant.Customer", "Tenant");
            DropIndex("Tenant.Customer", new[] { "GroupId" });
            DropIndex("Tenant.Customer", new[] { "NacionalityId" });
            DropIndex("Tenant.PhoneNumber", "Tenant");
            DropIndex("Tenant.PhoneNumber", new[] { "UserId" });
            DropIndex("Tenant.PhoneNumber", new[] { "CustomerId" });
            DropIndex("Tenant.PhoneNumber", new[] { "GymId" });
            DropIndex("Tenant.PhoneNumber", new[] { "ContactId" });
            DropIndex("Tenant.Contact", new[] { "Gym_Id" });
            DropIndex("Tenant.Contact", "Tenant");
            DropIndex("Tenant.Address", "Tenant");
            DropIndex("Tenant.Address", new[] { "CustomerId" });
            DropIndex("Tenant.Address", new[] { "GymId" });
            DropIndex("Tenant.Address", new[] { "ContactId" });
            DropIndex("Tenant.Address", new[] { "StateProvinceId" });
            DropIndex("Tenant.Address", new[] { "CountryId" });
            DropTable("Security.UserRole");
            DropTable("Tenant.Rate");
            DropTable("Tenant.Plan");
            DropTable("System.PaymentType");
            DropTable("System.FrequencyPeriod");
            DropTable("Tenant.Audit");
            DropTable("Security.Rol");
            DropTable("Security.User");
            DropTable("Tenant.Gym");
            DropTable("System.Currency");
            DropTable("System.Tenant");
            DropTable("System.Province");
            DropTable("System.Country");
            DropTable("Tenant.Group");
            DropTable("Tenant.Customer");
            DropTable("Tenant.PhoneNumber");
            DropTable("Tenant.Contact");
            DropTable("Tenant.Address");
        }
    }
}

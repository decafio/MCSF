namespace MCSF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calc1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalChildrens",
                c => new
                    {
                        ChildCount = c.Int(nullable: false, identity: true),
                        Multiplier = c.Decimal(nullable: false, precision: 5, scale: 4),
                    })
                .PrimaryKey(t => t.ChildCount);
            
            CreateTable(
                "dbo.GeneralCareSupports",
                c => new
                    {
                        SupportBracketId = c.Int(nullable: false, identity: true),
                        ChildCount = c.Short(nullable: false),
                        BasePercent = c.Decimal(nullable: false, precision: 8, scale: 2),
                        BaseSupport = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarginalPercent = c.Decimal(nullable: false, precision: 5, scale: 4),
                        IncomeBracket_IncomeBracketId = c.Int(),
                    })
                .PrimaryKey(t => t.SupportBracketId)
                .ForeignKey("dbo.IncomeBrackets", t => t.IncomeBracket_IncomeBracketId)
                .Index(t => t.IncomeBracket_IncomeBracketId);
            
            CreateTable(
                "dbo.IncomeBrackets",
                c => new
                    {
                        IncomeBracketId = c.Int(nullable: false, identity: true),
                        IncomeMin = c.Int(nullable: false),
                        IncomeMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeBracketId);
            
            CreateTable(
                "dbo.LowIncomeThresholds",
                c => new
                    {
                        LowIncomeThresholdId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LowIncomeThresholdId);
            
            CreateTable(
                "dbo.OrdinaryMedExps",
                c => new
                    {
                        ChildCount = c.Int(nullable: false, identity: true),
                        AnnualAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyAmount = c.Decimal(nullable: false, precision: 8, scale: 2),
                    })
                .PrimaryKey(t => t.ChildCount);
            
            CreateTable(
                "dbo.TransitionAdjustments",
                c => new
                    {
                        TransitionAdjustmentId = c.Int(nullable: false, identity: true),
                        ChildCount = c.Short(nullable: false),
                        Multiplier = c.Decimal(nullable: false, precision: 3, scale: 2),
                    })
                .PrimaryKey(t => t.TransitionAdjustmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralCareSupports", "IncomeBracket_IncomeBracketId", "dbo.IncomeBrackets");
            DropIndex("dbo.GeneralCareSupports", new[] { "IncomeBracket_IncomeBracketId" });
            DropTable("dbo.TransitionAdjustments");
            DropTable("dbo.OrdinaryMedExps");
            DropTable("dbo.LowIncomeThresholds");
            DropTable("dbo.IncomeBrackets");
            DropTable("dbo.GeneralCareSupports");
            DropTable("dbo.AdditionalChildrens");
        }
    }
}

namespace control_de_gastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IngresoGastosJFs", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IngresoGastosJFs", "Fecha");
        }
    }
}

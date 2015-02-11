namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class OrdinaryMedExp
    {
        [Key]
        public int ChildCount { get; set; }
        public decimal AnnualAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
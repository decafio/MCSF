namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// MCSF-S 2.02 Ordinary Medical Expense Amounts: On average, families spend $345.00 per child annually on 
    /// ordinary medical expenses. Ordinary Medical Expense Averages table states the amounts families are presumed 
    /// to spend on ordinary medical expenses. Courts may add amounts to cover higher expenses. (2008 MCSF 3.04(B)). 
    /// </summary>
    public class OrdinaryMedicalExpense
    {
        [Key]
        public int ChildCount { get; set; }
        public decimal AnnualAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
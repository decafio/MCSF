namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// MCSF-S 2.01 Low Income Threshold: 2.01(A) The Low Income Threshold is $851.00 (2007 United States HHS Poverty Guideline). 
    /// </summary>
    public class LowIncomeThreshold
    {
        [Key]
        public int LowIncomeThresholdId { get; set; }
        public int Amount { get; set; }
    }
}
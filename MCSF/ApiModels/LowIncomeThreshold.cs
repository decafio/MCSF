namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;

    public class LowIncomeThreshold
    {
        [Key]
        public int LowIncomeThresholdId { get; set; }
        public int Amount { get; set; }
    }
}
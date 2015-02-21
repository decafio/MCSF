namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// MCSF 3.02(D) Low Income Transition Equation: Percentage Multiplier for the appropriate number of children 
    /// from the Transition Adjustment table
    /// </summary>
    public class TransitionAdjustment
    {
        [Key]
        public int TransitionAdjustmentId { get; set; }
        public short ChildCount { get; set; }
        public decimal Multiplier { get; set; }
    }
}
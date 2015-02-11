namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;

    public class TransitionAdjustment
    {
        [Key]
        public int TransitionAdjustmentId { get; set; }
        public short ChildCount { get; set; }
        public decimal Multiplier { get; set; }
    }
}
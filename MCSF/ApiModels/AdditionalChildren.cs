namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class AdditionalChildren
    {
        [Key]
        public int ChildCount { get; set; }
        public decimal Multiplier { get; set; }
    }
}
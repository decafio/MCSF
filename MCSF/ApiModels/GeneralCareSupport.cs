namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class GeneralCareSupport
    {
        [Key]
        public int SupportBracketId { get; set; }
        public short ChildCount { get; set; }
        public decimal BasePercent { get; set; }
        public decimal BaseSupport { get; set; }
        public decimal MarginalPercent { get; set; }
    
        public virtual IncomeBracket IncomeBracket { get; set; }
    }
}
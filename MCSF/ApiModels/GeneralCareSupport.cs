namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// MCSF-S 2.03 General Care Support Tables: 2.03(A) Based on the estimated costs of raising children, the General Care Equation 
    /// (2008 MCSF 3.02(B)) uses variable percentages of family income to determine a child support obligation. The General Care 
    /// Support Tables contain those figures and its percentages exclude medical or child care expenses. This supplement contains 
    /// net family income levels adjusted using the August 2007 Consumer Price Index (CPI-U Detroit) from its 1985 original base.
    /// </summary>
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
namespace MCSF.ApiModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class IncomeBracket
    {
        public IncomeBracket()
        {
            this.SupportBrackets = new HashSet<GeneralCareSupport>();
        }
    
        [Key]
        public int IncomeBracketId { get; set; }
        public int IncomeMin { get; set; }
        public int IncomeMax { get; set; }
    
        public virtual ICollection<GeneralCareSupport> SupportBrackets { get; set; }
    }
}





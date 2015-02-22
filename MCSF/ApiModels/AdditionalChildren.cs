namespace MCSF.ApiModels
{
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// 2.08(B) When a parent has additional minor children (whether living in that parent’s household or for whom the parent 
    /// pays child support), net income for calculating support in the present case does not include the portion of that 
    /// parent’s income reserved for supporting those additional children calculated according to both of the following steps:
    /// (1) Deduct from a parent’s income dollar-for-dollar the portion of that parent’s health insurance premiums used to cover 
    /// qualifying additional children. (2) After subtracting qualifying additional children’s health care coverage costs, multiply 
    /// that parent’s remaining net income by the Additional Children table’s Adjustment Multiplier to determine net income to 
    /// use for the present case.
    /// </summary>
    public class AdditionalChildren
    {
        [Key]
        public int ChildCount { get; set; }
        public decimal Multiplier { get; set; }
    }
}
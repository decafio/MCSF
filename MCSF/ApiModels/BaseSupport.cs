using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization; // DataContract, Datamember
using System.Web;

// Adding the DataContract (Class) and DataMember (Methods) causes the variable name to be part of the JSON/XML return

namespace MCSF.ApiModels
{
    [Serializable]
    [DataContract]
    public class BaseSupports
    {
        [DataMember]
        public BaseSupport ParentA { get; set; }

        [DataMember]
        public BaseSupport ParentB { get; set; }
    }


    [Serializable]
    [DataContract]
    public class BaseSupport
    {
        [DataMember]
        public int BaseObligation { get; set; }

        [DataMember]
        public string FormulaUsed { get; set; }
    }
}
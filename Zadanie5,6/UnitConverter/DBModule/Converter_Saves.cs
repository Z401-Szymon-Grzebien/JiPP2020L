//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBModule
{
    using System;
    using System.Collections.Generic;
    
    public partial class Converter_Saves
    {
        public int Id { get; set; }
        public string Converter { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public string ValueToConvert { get; set; }
        public string ConvertedValue { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    }
}

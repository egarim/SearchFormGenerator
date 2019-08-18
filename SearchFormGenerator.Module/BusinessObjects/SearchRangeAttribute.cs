using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFormGenerator.Module.BusinessObjects
{

    public class SearchableClass:Attribute
    {
        
        public SearchableClass()
        {
            
        }
    }
    public class SearchAttribute : Attribute
    {

        public string Caption { get; set; }
        public bool IsRange { get; set; }
        public SearchAttribute(bool IsRange, string caption)
        {
            this.IsRange = IsRange;
            Caption = caption;
        }
    }
}

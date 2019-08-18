using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFormGenerator.Module.BusinessObjects
{
  
    public class SearchableClass:Attribute
    {
        public Type SearchFormType { get; set; }
        public SearchableClass(Type searchFormType)
        {
            SearchFormType = searchFormType;
        }
    }
    public class SearchAttribute : Attribute
    {

   
        public bool IsRange { get; set; }
        public SearchAttribute(bool IsRange)
        {
            this.IsRange = IsRange;
         
        }
    }
}

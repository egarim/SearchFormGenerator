using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFormGenerator.Module.BusinessObjects
{
    public interface ISearch
    {
        
    }
    public class SearchableClass:Attribute
    {
        
        public SearchableClass()
        {
            
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

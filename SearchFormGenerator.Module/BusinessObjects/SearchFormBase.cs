using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace SearchFormGenerator.Module.BusinessObjects
{
    [NonPersistent()]
    public class SearchFormBase : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SearchFormBase(Session session)
            : base(session)
        {
          
        }

        string name;
        bool saveParameters;

        public bool SaveParameters
        {
            get => saveParameters;
            set => SetPropertyValue(nameof(SaveParameters), ref saveParameters, value);
        }
        [Appearance("Name Disable", AppearanceItemType = "ViewItem", TargetItems = "Name",
        Criteria = "SaveParameters = false", Context = "DetailView",Enabled =false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
    }

}
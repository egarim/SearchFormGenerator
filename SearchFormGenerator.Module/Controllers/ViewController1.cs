using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo.Metadata;
using SearchFormGenerator.Module.BusinessObjects;

namespace SearchFormGenerator.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ViewController1 : ViewController
    {
        public ViewController1()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ShowSearchForm_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            XPDictionary xpDictionary = DevExpress.ExpressApp.Xpo.XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary;
            var MyClassInfo=   xpDictionary.Classes.Cast<XPClassInfo>().FirstOrDefault(ci => ci.FullName == "MyClass");
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            var MyClass=  objectSpace.CreateObject(typeof(SearchFormBase));
           
            e.View = Application.CreateDetailView(objectSpace, MyClass);
        }
    }
}

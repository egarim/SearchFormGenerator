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

        SearchableClass searchAttribute;
        object SearchFormObject;
        private void ShowSearchForm_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            searchAttribute = this.View.ObjectTypeInfo.FindAttribute<SearchableClass>();
            if (searchAttribute != null)
            {
                IObjectSpace objectSpace = Application.CreateObjectSpace();
                SearchFormObject = objectSpace.CreateObject(searchAttribute.SearchFormType);
                e.View = Application.CreateDetailView(objectSpace, SearchFormObject);
            }



        }

        private void ShowSearchForm_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            List<CriteriaOperator> Criterias = new List<CriteriaOperator>();

            var item = this.View.ObjectTypeInfo;
            var SearchTypeInfo = XafTypesInfo.Instance.FindTypeInfo(searchAttribute.SearchFormType);
            var members = item.Members.Where(m => m.FindAttribute<SearchAttribute>() != null);
            foreach (var member in members)
            {
                var SearchParameters = member.FindAttribute<SearchAttribute>();
                if (SearchParameters.IsRange)
                {

                    var FromValue = SearchTypeInfo.FindMember($"From{member.Name}").GetValue(SearchFormObject);
                    var ToValue = SearchTypeInfo.FindMember($"To{member.Name}").GetValue(SearchFormObject);
                    BetweenOperator betweenOperator = new BetweenOperator(member.Name, FromValue, ToValue);
                    Criterias.Add(betweenOperator);
                }
                else
                {
                    var SingleValue = SearchTypeInfo.FindMember($"{member.Name}").GetValue(SearchFormObject);
                    BinaryOperator binaryOperator = new BinaryOperator(member.Name, SingleValue);
                    Criterias.Add(binaryOperator);
                }

            }
            var SearchCriteria=  CriteriaOperator.Or(Criterias);

        }
    }
}

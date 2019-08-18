using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo.Metadata;
using SearchFormGenerator.Module.BusinessObjects;

namespace SearchFormGenerator.Module {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class SearchFormGeneratorModule : ModuleBase {
        public SearchFormGeneratorModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);




            //typesInfo.FindTypeInfo(typeof(SearchFormBase)).AddAttribute(new DevExpress.Persistent.Base.DefaultClassOptionsAttribute());

            ////Dennis: simple creation of a new member.
            ///

            var SearchableClass= typesInfo.PersistentTypes.Cast<TypeInfo>().Where(pt => pt.FindAttribute<SearchableClass>()!=null);
            foreach (var item in SearchableClass)
            {
                var members= item.Members.Where(m => m.FindAttribute<SearchAttribute>() != null);
                foreach (var member in members)
                {
                    var SearchParameters=member.FindAttribute<SearchAttribute>();
                    if(SearchParameters.IsRange)
                    {
                        typesInfo.FindTypeInfo(typeof(SearchFormBase)).CreateMember($"From{member.Name}", member.MemberType);
                        typesInfo.FindTypeInfo(typeof(SearchFormBase)).CreateMember($"To{member.Name}", member.MemberType);
                    }
                    else
                    {
                        typesInfo.FindTypeInfo(typeof(SearchFormBase)).CreateMember($"{member.Name}", member.MemberType);
                    }
                 
                }
            }
       

            ////Dennis: establishing a One-To-Many relationship between two classes.



            //XPDictionary xpDictionary = DevExpress.ExpressApp.Xpo.XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary;

            //XPClassInfo classInfo = xpDictionary.CreateClass(xpDictionary.GetClassInfo(typeof(SearchFormBase)), "MyClass");
            //XPMemberInfo memberInfo = classInfo.CreateMember("MyProperty", typeof(string),false,false);
            

            //XafTypesInfo.Instance.RefreshInfo(classInfo.ClassType);
            
            
            //if (xpDictionary.GetClassInfo(typeof(PersistentObject1)).FindMember("PersistentObject2s") == null)
            //{
            //    xpDictionary.GetClassInfo(typeof(PersistentObject1)).CreateMember("PersistentObject2s", typeof(XPCollection<PersistentObject2>), true,
            //        new AggregatedAttribute(), new AssociationAttribute("PersistentObject1-PersistentObject2s", typeof(PersistentObject2)));
            //}
            //if (xpDictionary.GetClassInfo(typeof(PersistentObject2)).FindMember("PersistentObject1") == null)
            //{
            //    xpDictionary.GetClassInfo(typeof(PersistentObject2)).CreateMember("PersistentObject1", typeof(PersistentObject1), new AssociationAttribute("PersistentObject1-PersistentObject2s"));
            //}
            ////Dennis: take special note of the fact that you have to refresh information about type, only if you made the changes in the XPDictionary. If you made the changes directly in the TypeInfo, refreshing is not necessary.
            XafTypesInfo.Instance.RefreshInfo(typeof(SearchFormBase));
            //XafTypesInfo.Instance.RefreshInfo(typeof(PersistentObject2));
        }
       
    }
}

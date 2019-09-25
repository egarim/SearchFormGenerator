namespace SearchFormGenerator.Module.Controllers
{
    partial class ViewController1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.showSearchForm = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.saClearCriteria = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // showSearchForm
            // 
            this.showSearchForm.AcceptButtonCaption = null;
            this.showSearchForm.CancelButtonCaption = null;
            this.showSearchForm.Caption = "Show Search Form";
            this.showSearchForm.ConfirmationMessage = null;
            this.showSearchForm.Id = "e7553118-6264-4ecf-9f5c-2b7c960513a7";
            this.showSearchForm.ToolTip = null;
            this.showSearchForm.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ShowSearchForm_CustomizePopupWindowParams);
            this.showSearchForm.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ShowSearchForm_Execute);
            // 
            // saClearCriteria
            // 
            this.saClearCriteria.Caption = "Clear Filter";
            this.saClearCriteria.ConfirmationMessage = null;
            this.saClearCriteria.Id = "7fb66f43-8a7d-49d9-be3a-06e37cbb4ae9";
            this.saClearCriteria.ToolTip = null;
            this.saClearCriteria.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.SaClearCriteria_Execute);
            // 
            // ViewController1
            // 
            this.Actions.Add(this.showSearchForm);
            this.Actions.Add(this.saClearCriteria);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction showSearchForm;
        private DevExpress.ExpressApp.Actions.SimpleAction saClearCriteria;
    }
}


namespace VSTO_DBV_Creator
{
    partial class OCC_UI_EugeneTest : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public OCC_UI_EugeneTest()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grp_DBV_Constructor = this.Factory.CreateRibbonGroup();
            this.btn_Run = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grp_DBV_Constructor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grp_DBV_Constructor);
            this.tab1.Label = "EugeneTest";
            this.tab1.Name = "tab1";
            // 
            // grp_DBV_Constructor
            // 
            this.grp_DBV_Constructor.Items.Add(this.btn_Run);
            this.grp_DBV_Constructor.Label = "DBV_Constructor";
            this.grp_DBV_Constructor.Name = "grp_DBV_Constructor";
            // 
            // btn_Run
            // 
            this.btn_Run.Label = "Run";
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_Run_Click);
            // 
            // OCC_UI_EugeneTest
            // 
            this.Name = "OCC_UI_EugeneTest";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grp_DBV_Constructor.ResumeLayout(false);
            this.grp_DBV_Constructor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grp_DBV_Constructor;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_Run;
    }

    partial class ThisRibbonCollection
    {
        internal OCC_UI_EugeneTest Ribbon1
        {
            get { return this.GetRibbon<OCC_UI_EugeneTest>(); }
        }
    }
}

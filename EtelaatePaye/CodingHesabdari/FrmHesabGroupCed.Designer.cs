namespace EtelaatePaye.CodingHesabdari
{
    partial class FrmHesabGroupCed
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHesabGroupCed));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSharhHesab = new DevExpress.XtraEditors.MemoEdit();
            this.btnCreateClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCreateNext = new DevExpress.XtraEditors.SimpleButton();
            this.chkEditCode = new DevExpress.XtraEditors.CheckEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnNewCode = new DevExpress.XtraEditors.SimpleButton();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblNoeHesab = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbNoeHesab = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbStandardGroups = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSharhHesab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNoeHesab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStandardGroups.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            this.btnClose.ToolTip = "Escape";
            this.btnClose.ToolTipTitle = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSharhHesab);
            this.groupBox2.Location = new System.Drawing.Point(8, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 117);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "توضیح یا تشریح حساب (اختیاری)";
            // 
            // txtSharhHesab
            // 
            this.txtSharhHesab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSharhHesab.Location = new System.Drawing.Point(3, 29);
            this.txtSharhHesab.Name = "txtSharhHesab";
            this.txtSharhHesab.Properties.MaxLength = 50;
            this.txtSharhHesab.Size = new System.Drawing.Size(579, 85);
            this.txtSharhHesab.TabIndex = 0;
            this.txtSharhHesab.TabStop = false;
            // 
            // btnCreateClose
            // 
            this.btnCreateClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateClose.ImageOptions.Image")));
            this.btnCreateClose.Location = new System.Drawing.Point(151, 5);
            this.btnCreateClose.Name = "btnCreateClose";
            this.btnCreateClose.Size = new System.Drawing.Size(147, 38);
            this.btnCreateClose.TabIndex = 1;
            this.btnCreateClose.Text = "ایجاد و بستن";
            this.btnCreateClose.ToolTip = "F2";
            this.btnCreateClose.ToolTipTitle = "ایجاد و بستن";
            this.btnCreateClose.Click += new System.EventHandler(this.btnCreateClose_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCreateClose);
            this.panelControl2.Controls.Add(this.btnCreateNext);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 294);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(601, 49);
            this.panelControl2.TabIndex = 17;
            // 
            // btnCreateNext
            // 
            this.btnCreateNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNext.ImageOptions.Image")));
            this.btnCreateNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCreateNext.ImageOptions.SvgImage")));
            this.btnCreateNext.Location = new System.Drawing.Point(450, 5);
            this.btnCreateNext.Name = "btnCreateNext";
            this.btnCreateNext.Size = new System.Drawing.Size(141, 38);
            this.btnCreateNext.TabIndex = 0;
            this.btnCreateNext.Text = "ایجاد و بعدی";
            this.btnCreateNext.ToolTip = "F3";
            this.btnCreateNext.ToolTipTitle = "ایجاد و بعدی";
            this.btnCreateNext.Click += new System.EventHandler(this.btnCreateNext_Click);
            // 
            // chkEditCode
            // 
            this.chkEditCode.Location = new System.Drawing.Point(394, 9);
            this.chkEditCode.Name = "chkEditCode";
            this.chkEditCode.Properties.Caption = "checkEdit1";
            this.chkEditCode.Size = new System.Drawing.Size(20, 29);
            this.chkEditCode.TabIndex = 5;
            this.chkEditCode.TabStop = false;
            this.chkEditCode.ToolTip = "ویرایش یا تغییر کد بصورت دستی";
            this.chkEditCode.CheckedChanged += new System.EventHandler(this.chkEditCode_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(6, 86);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(473, 32);
            this.txtName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(485, 85);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 32);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "نام حساب گروه";
            // 
            // btnNewCode
            // 
            this.btnNewCode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewCode.ImageOptions.SvgImage")));
            this.btnNewCode.Location = new System.Drawing.Point(288, 7);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(100, 33);
            this.btnNewCode.TabIndex = 6;
            this.btnNewCode.TabStop = false;
            this.btnNewCode.Text = "کد جدید";
            this.btnNewCode.ToolTip = "F11";
            this.btnNewCode.ToolTipTitle = "کد جدید";
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "";
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(420, 8);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "0";
            this.txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCode.Properties.MaxLength = 1;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(59, 32);
            this.txtCode.TabIndex = 4;
            this.txtCode.TabStop = false;
            this.txtCode.Click += new System.EventHandler(this.txtCode_Leave);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.EnterMoveNextControl = true;
            this.chkIsActive.Location = new System.Drawing.Point(9, 123);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(52, 33);
            this.chkIsActive.TabIndex = 3;
            this.chkIsActive.TabStop = false;
            this.chkIsActive.Visible = false;
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی ";
            this.txtId.Location = new System.Drawing.Point(6, 8);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(107, 32);
            this.txtId.TabIndex = 7;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(485, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد حساب ";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblNoeHesab);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.cmbNoeHesab);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.cmbStandardGroups);
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.chkEditCode);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnNewCode);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(601, 289);
            this.panelControl1.TabIndex = 16;
            // 
            // lblNoeHesab
            // 
            this.lblNoeHesab.AutoEllipsis = true;
            this.lblNoeHesab.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNoeHesab.Location = new System.Drawing.Point(241, 124);
            this.lblNoeHesab.Name = "lblNoeHesab";
            this.lblNoeHesab.Size = new System.Drawing.Size(80, 31);
            this.lblNoeHesab.TabIndex = 8;
            this.lblNoeHesab.Text = ".";
            // 
            // labelControl5
            // 
            this.labelControl5.AutoEllipsis = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(485, 123);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 32);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "نوع حساب";
            // 
            // cmbNoeHesab
            // 
            this.cmbNoeHesab.EnterMoveNextControl = true;
            this.cmbNoeHesab.Location = new System.Drawing.Point(327, 124);
            this.cmbNoeHesab.Name = "cmbNoeHesab";
            this.cmbNoeHesab.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNoeHesab.Properties.Items.AddRange(new object[] {
            "ترازنامه ای ",
            "سود و زیانی",
            "کنترلی و آماری"});
            this.cmbNoeHesab.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbNoeHesab.Size = new System.Drawing.Size(152, 32);
            this.cmbNoeHesab.TabIndex = 2;
            this.cmbNoeHesab.SelectedIndexChanged += new System.EventHandler(this.cmbNoeHesab_SelectedIndexChanged);
            this.cmbNoeHesab.Enter += new System.EventHandler(this.cmbNoeHesab_Enter);
            // 
            // labelControl4
            // 
            this.labelControl4.AutoEllipsis = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(482, 51);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(111, 32);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "انتخاب نوع گروه";
            // 
            // cmbStandardGroups
            // 
            this.cmbStandardGroups.EnterMoveNextControl = true;
            this.cmbStandardGroups.Location = new System.Drawing.Point(6, 51);
            this.cmbStandardGroups.Name = "cmbStandardGroups";
            this.cmbStandardGroups.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStandardGroups.Properties.Items.AddRange(new object[] {
            "داراییهای جاری",
            "داراییهای غیر جاری",
            "بدهیهای جاری",
            "بدهیهای غیرجاری",
            "حقوق صاحبان سهام",
            "فروش و درآمدها",
            "بهای تمام شده کالای فروش رفته",
            "هزینه ها",
            "حسابهای انتظامی"});
            this.cmbStandardGroups.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbStandardGroups.Size = new System.Drawing.Size(473, 32);
            this.cmbStandardGroups.TabIndex = 0;
            this.cmbStandardGroups.SelectedIndexChanged += new System.EventHandler(this.cmbStandardGroups_SelectedIndexChanged);
            this.cmbStandardGroups.Enter += new System.EventHandler(this.cmbStandardGroups_Enter);
            // 
            // labelControl3
            // 
            this.labelControl3.AutoEllipsis = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(67, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 32);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "وضعیت حساب";
            // 
            // FrmHesabGroupCed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 343);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHesabGroupCed";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ایجاد حساب گروه ";
            this.Load += new System.EventHandler(this.FrmHesabGroupCed_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmHesabGroupCed_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSharhHesab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNoeHesab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStandardGroups.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.MemoEdit txtSharhHesab;
        public DevExpress.XtraEditors.SimpleButton btnCreateClose;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton btnCreateNext;
        private DevExpress.XtraEditors.CheckEdit chkEditCode;
        public DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnNewCode;
        public DevExpress.XtraEditors.TextEdit txtCode;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStandardGroups;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbNoeHesab;
        private DevExpress.XtraEditors.LabelControl lblNoeHesab;
    }
}
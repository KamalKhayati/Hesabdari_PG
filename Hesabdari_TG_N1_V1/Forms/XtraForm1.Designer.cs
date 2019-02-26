namespace Hesabdari_TG_N1_V1.Forms
{
    partial class XtraForm1
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
            this.cmbNoeShakhs = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMahiatHesab = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNoeShakhs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMahiatHesab.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbNoeShakhs
            // 
            this.cmbNoeShakhs.EnterMoveNextControl = true;
            this.cmbNoeShakhs.Location = new System.Drawing.Point(341, 333);
            this.cmbNoeShakhs.Name = "cmbNoeShakhs";
            this.cmbNoeShakhs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNoeShakhs.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "آیدی", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "    کد ", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "                          نام حساب     ", 350, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NoeHesab", "  نوع حساب", 120, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbNoeShakhs.Properties.DisplayMember = "Name";
            this.cmbNoeShakhs.Properties.DropDownRows = 10;
            this.cmbNoeShakhs.Properties.ImmediatePopup = true;
            this.cmbNoeShakhs.Properties.NullText = "";
            this.cmbNoeShakhs.Properties.ValueMember = "Id";
            this.cmbNoeShakhs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbNoeShakhs.Size = new System.Drawing.Size(134, 32);
            this.cmbNoeShakhs.TabIndex = 15;
            // 
            // labelControl3
            // 
            this.labelControl3.AutoEllipsis = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(481, 332);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 32);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "نوع شخص";
            // 
            // labelControl4
            // 
            this.labelControl4.AutoEllipsis = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(454, 135);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(98, 32);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "ماهیت حساب";
            // 
            // cmbMahiatHesab
            // 
            this.cmbMahiatHesab.EnterMoveNextControl = true;
            this.cmbMahiatHesab.Location = new System.Drawing.Point(341, 136);
            this.cmbMahiatHesab.Name = "cmbMahiatHesab";
            this.cmbMahiatHesab.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMahiatHesab.Properties.Items.AddRange(new object[] {
            "بدهکار",
            "بستانکار",
            "بد / بس"});
            this.cmbMahiatHesab.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMahiatHesab.Size = new System.Drawing.Size(107, 32);
            this.cmbMahiatHesab.TabIndex = 16;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 501);
            this.Controls.Add(this.cmbNoeShakhs);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cmbMahiatHesab);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.cmbNoeShakhs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMahiatHesab.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cmbNoeShakhs;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMahiatHesab;
    }
}
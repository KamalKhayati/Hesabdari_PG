namespace Hesabdari_TG_N1_V1.Forms.Base.AnbarKala
{
    partial class FrmSaveAnbars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaveAnbars));
            this.txtcodeAnbar = new DevExpress.XtraEditors.TextEdit();
            this.txtNameAnbar = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodeAnbar
            // 
            this.txtcodeAnbar.Location = new System.Drawing.Point(279, 12);
            this.txtcodeAnbar.Name = "txtcodeAnbar";
            this.txtcodeAnbar.Properties.Mask.EditMask = "f0";
            this.txtcodeAnbar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtcodeAnbar.Properties.MaxLength = 3;
            this.txtcodeAnbar.Size = new System.Drawing.Size(150, 32);
            this.txtcodeAnbar.TabIndex = 0;
            // 
            // txtNameAnbar
            // 
            this.txtNameAnbar.Location = new System.Drawing.Point(12, 59);
            this.txtNameAnbar.Name = "txtNameAnbar";
            this.txtNameAnbar.Properties.MaxLength = 100;
            this.txtNameAnbar.Size = new System.Drawing.Size(417, 32);
            this.txtNameAnbar.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(279, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(439, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد انبار";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(440, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 25);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "نام انبار";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(12, 8);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "انبار فعال باشد؟  ";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIsActive.Size = new System.Drawing.Size(129, 33);
            this.chkIsActive.TabIndex = 2;
            // 
            // FrmSaveAnbars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 158);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNameAnbar);
            this.Controls.Add(this.txtcodeAnbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaveAnbars";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSaveAnbars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcodeAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtcodeAnbar;
        public DevExpress.XtraEditors.TextEdit txtNameAnbar;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}
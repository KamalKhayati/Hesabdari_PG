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
            this.codeAnbar = new DevExpress.XtraEditors.TextEdit();
            this.NameAnbar = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.codeAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameAnbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // codeAnbar
            // 
            this.codeAnbar.Location = new System.Drawing.Point(279, 12);
            this.codeAnbar.Name = "codeAnbar";
            this.codeAnbar.Properties.Mask.EditMask = "f0";
            this.codeAnbar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codeAnbar.Properties.MaxLength = 3;
            this.codeAnbar.Size = new System.Drawing.Size(150, 32);
            this.codeAnbar.TabIndex = 0;
            // 
            // NameAnbar
            // 
            this.NameAnbar.Location = new System.Drawing.Point(12, 59);
            this.NameAnbar.Name = "NameAnbar";
            this.NameAnbar.Properties.MaxLength = 100;
            this.NameAnbar.Size = new System.Drawing.Size(417, 32);
            this.NameAnbar.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(279, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره";
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(12, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "بستن ";
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
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(12, 8);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.checkEdit1.Properties.Caption = "انبار فعال باشد؟  ";
            this.checkEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkEdit1.Size = new System.Drawing.Size(129, 33);
            this.checkEdit1.TabIndex = 2;
            // 
            // FrmSaveAnbars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 158);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.NameAnbar);
            this.Controls.Add(this.codeAnbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaveAnbars";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.codeAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameAnbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit codeAnbar;
        private DevExpress.XtraEditors.TextEdit NameAnbar;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}
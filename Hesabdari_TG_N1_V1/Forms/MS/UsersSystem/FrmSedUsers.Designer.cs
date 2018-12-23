namespace Hesabdari_TG_N1_V1.Forms.MS.UsersSystem
{
    partial class FrmSedUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSedUsers));
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnNewCode = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveNext = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 146);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.MaxLength = 50;
            this.txtPassword.Size = new System.Drawing.Size(208, 32);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(113, 108);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.MaxLength = 50;
            this.txtUserName.Size = new System.Drawing.Size(208, 32);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(5, 46);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(316, 32);
            this.txtName.TabIndex = 0;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(327, 149);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 25);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "رمز عبور";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(327, 49);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(149, 25);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "نام و نام خانوادگی کاربر";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(327, 111);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 25);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "نام کاربری";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(327, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(213, 8);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "f0";
            this.txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCode.Properties.MaxLength = 3;
            this.txtCode.Size = new System.Drawing.Size(108, 32);
            this.txtCode.TabIndex = 4;
            this.txtCode.TabStop = false;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnSaveClose.Location = new System.Drawing.Point(154, 3);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(150, 40);
            this.btnSaveClose.TabIndex = 1;
            this.btnSaveClose.Text = "ثبت و بستن";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(5, 145);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(58, 33);
            this.chkIsActive.TabIndex = 3;
            this.chkIsActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // txtId
            // 
            this.txtId.EditValue = "آیدی ";
            this.txtId.Location = new System.Drawing.Point(5, 8);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtId.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtId.Properties.NullText = "آیدی انبار";
            this.txtId.Properties.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(96, 32);
            this.txtId.TabIndex = 6;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnNewCode);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.txtPassword);
            this.panelControl1.Controls.Add(this.txtUserName);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(481, 184);
            this.panelControl1.TabIndex = 22;
            // 
            // btnNewCode
            // 
            this.btnNewCode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.btnNewCode.Location = new System.Drawing.Point(107, 6);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(100, 35);
            this.btnNewCode.TabIndex = 5;
            this.btnNewCode.TabStop = false;
            this.btnNewCode.Text = "کد جدید";
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.btnSaveNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.btnSaveNext.Location = new System.Drawing.Point(341, 5);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.Size = new System.Drawing.Size(135, 38);
            this.btnSaveNext.TabIndex = 0;
            this.btnSaveNext.Text = "ثبت و بعدی";
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnSaveNext);
            this.panelControl2.Controls.Add(this.btnSaveClose);
            this.panelControl2.Location = new System.Drawing.Point(12, 202);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(481, 48);
            this.panelControl2.TabIndex = 23;
            // 
            // FrmSedUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 260);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSedUsers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت کاربر جدید";
            this.Load += new System.EventHandler(this.FrmSedAnbarha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtPassword;
        public DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtCode;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnSaveClose;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtId;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnNewCode;
        public DevExpress.XtraEditors.SimpleButton btnSaveNext;
        public DevExpress.XtraEditors.PanelControl panelControl2;
    }
}
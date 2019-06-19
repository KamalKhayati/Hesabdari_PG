﻿namespace Hesabdari_PG.Forms.Ap.AnbarKala
{
    partial class FrmAnbarhaCed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnbarhaCed));
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnCreateClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnNewCode = new DevExpress.XtraEditors.SimpleButton();
            this.chkAllowSupplyNegative = new DevExpress.XtraEditors.CheckEdit();
            this.btnCreateNext = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowSupplyNegative.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(273, 8);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "f0";
            this.txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCode.Properties.MaxLength = 3;
            this.txtCode.Size = new System.Drawing.Size(102, 32);
            this.txtCode.TabIndex = 4;
            this.txtCode.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(5, 46);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(370, 32);
            this.txtName.TabIndex = 0;
            // 
            // btnCreateClose
            // 
            this.btnCreateClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateClose.ImageOptions.Image")));
            this.btnCreateClose.Location = new System.Drawing.Point(154, 3);
            this.btnCreateClose.Name = "btnCreateClose";
            this.btnCreateClose.Size = new System.Drawing.Size(150, 40);
            this.btnCreateClose.TabIndex = 1;
            this.btnCreateClose.Text = "ایجاد و بستن";
            this.btnCreateClose.Click += new System.EventHandler(this.btnCreateClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(5, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "بستن ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(381, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(381, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 25);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "نام انبار";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.EnterMoveNextControl = true;
            this.chkIsActive.Location = new System.Drawing.Point(313, 84);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "فعال";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(58, 33);
            this.chkIsActive.TabIndex = 2;
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
            this.txtId.Size = new System.Drawing.Size(108, 32);
            this.txtId.TabIndex = 6;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnNewCode);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Controls.Add(this.chkAllowSupplyNegative);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(451, 125);
            this.panelControl1.TabIndex = 7;
            // 
            // btnNewCode
            // 
            this.btnNewCode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewCode.ImageOptions.SvgImage")));
            this.btnNewCode.Location = new System.Drawing.Point(167, 5);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(100, 35);
            this.btnNewCode.TabIndex = 5;
            this.btnNewCode.TabStop = false;
            this.btnNewCode.Text = "کد جدید";
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // chkAllowSupplyNegative
            // 
            this.chkAllowSupplyNegative.EnterMoveNextControl = true;
            this.chkAllowSupplyNegative.Location = new System.Drawing.Point(113, 84);
            this.chkAllowSupplyNegative.Name = "chkAllowSupplyNegative";
            this.chkAllowSupplyNegative.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkAllowSupplyNegative.Properties.Caption = "اجازه دادن موجودی منفی";
            this.chkAllowSupplyNegative.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAllowSupplyNegative.Size = new System.Drawing.Size(191, 33);
            this.chkAllowSupplyNegative.TabIndex = 3;
            // 
            // btnCreateNext
            // 
            this.btnCreateNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNext.ImageOptions.Image")));
            this.btnCreateNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCreateNext.ImageOptions.SvgImage")));
            this.btnCreateNext.Location = new System.Drawing.Point(310, 4);
            this.btnCreateNext.Name = "btnCreateNext";
            this.btnCreateNext.Size = new System.Drawing.Size(135, 38);
            this.btnCreateNext.TabIndex = 0;
            this.btnCreateNext.Text = "ایجاد و بعدی";
            this.btnCreateNext.Click += new System.EventHandler(this.btnCreateNext_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnCreateNext);
            this.panelControl2.Controls.Add(this.btnCreateClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 129);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(451, 48);
            this.panelControl2.TabIndex = 8;
            // 
            // FrmAnbarhaCed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 177);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAnbarhaCed";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایجاد انبارها";
            this.Load += new System.EventHandler(this.FrmAnbarhaCed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowSupplyNegative.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.SimpleButton btnCreateClose;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtCode;
        public DevExpress.XtraEditors.TextEdit txtName;
        public DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.TextEdit txtId;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnNewCode;
        public DevExpress.XtraEditors.SimpleButton btnCreateNext;
        public DevExpress.XtraEditors.CheckEdit chkAllowSupplyNegative;
        public DevExpress.XtraEditors.PanelControl panelControl2;
    }
}
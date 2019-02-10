﻿namespace EtelaatePaye.CodingHesabdari
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbEntezami = new System.Windows.Forms.RadioButton();
            this.rdbSodZiani = new System.Windows.Forms.RadioButton();
            this.rdbTaraznamei = new System.Windows.Forms.RadioButton();
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSharhHesab.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(6, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 93);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "توضیح یا تشریح حساب (اختیاری)";
            // 
            // txtSharhHesab
            // 
            this.txtSharhHesab.Location = new System.Drawing.Point(6, 27);
            this.txtSharhHesab.Name = "txtSharhHesab";
            this.txtSharhHesab.Properties.MaxLength = 50;
            this.txtSharhHesab.Size = new System.Drawing.Size(573, 59);
            this.txtSharhHesab.TabIndex = 0;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbEntezami);
            this.groupBox1.Controls.Add(this.rdbSodZiani);
            this.groupBox1.Controls.Add(this.rdbTaraznamei);
            this.groupBox1.Location = new System.Drawing.Point(281, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 62);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نوع حساب";
            // 
            // rdbEntezami
            // 
            this.rdbEntezami.AutoSize = true;
            this.rdbEntezami.Location = new System.Drawing.Point(6, 27);
            this.rdbEntezami.Name = "rdbEntezami";
            this.rdbEntezami.Size = new System.Drawing.Size(80, 29);
            this.rdbEntezami.TabIndex = 2;
            this.rdbEntezami.TabStop = true;
            this.rdbEntezami.Text = "انتظامی";
            this.rdbEntezami.UseVisualStyleBackColor = true;
            // 
            // rdbSodZiani
            // 
            this.rdbSodZiani.AutoSize = true;
            this.rdbSodZiani.Location = new System.Drawing.Point(92, 27);
            this.rdbSodZiani.Name = "rdbSodZiani";
            this.rdbSodZiani.Size = new System.Drawing.Size(108, 29);
            this.rdbSodZiani.TabIndex = 1;
            this.rdbSodZiani.TabStop = true;
            this.rdbSodZiani.Text = "سود و زیانی";
            this.rdbSodZiani.UseVisualStyleBackColor = true;
            // 
            // rdbTaraznamei
            // 
            this.rdbTaraznamei.AutoSize = true;
            this.rdbTaraznamei.Location = new System.Drawing.Point(206, 27);
            this.rdbTaraznamei.Name = "rdbTaraznamei";
            this.rdbTaraznamei.Size = new System.Drawing.Size(97, 29);
            this.rdbTaraznamei.TabIndex = 0;
            this.rdbTaraznamei.TabStop = true;
            this.rdbTaraznamei.Text = "ترازنامه ای";
            this.rdbTaraznamei.UseVisualStyleBackColor = true;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCreateClose);
            this.panelControl2.Controls.Add(this.btnCreateNext);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 278);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(598, 49);
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
            this.chkEditCode.Location = new System.Drawing.Point(347, 9);
            this.chkEditCode.Name = "chkEditCode";
            this.chkEditCode.Properties.Caption = "checkEdit1";
            this.chkEditCode.Size = new System.Drawing.Size(20, 29);
            this.chkEditCode.TabIndex = 10;
            this.chkEditCode.TabStop = false;
            this.chkEditCode.ToolTip = "ویرایش یا تغییر کد بصورت دستی";
            this.chkEditCode.Click += new System.EventHandler(this.chkEditCode_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(6, 47);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(474, 32);
            this.txtName.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(485, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 32);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "نام حساب گروه";
            // 
            // btnNewCode
            // 
            this.btnNewCode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewCode.ImageOptions.SvgImage")));
            this.btnNewCode.Location = new System.Drawing.Point(241, 7);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(100, 33);
            this.btnNewCode.TabIndex = 7;
            this.btnNewCode.TabStop = false;
            this.btnNewCode.Text = "کد جدید";
            this.btnNewCode.ToolTip = "F7";
            this.btnNewCode.ToolTipTitle = "کد جدید";
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "";
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(373, 8);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.Mask.EditMask = "00";
            this.txtCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCode.Properties.MaxLength = 2;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(106, 32);
            this.txtCode.TabIndex = 0;
            this.txtCode.TabStop = false;
            this.txtCode.Click += new System.EventHandler(this.txtCode_Leave);
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.EnterMoveNextControl = true;
            this.chkIsActive.Location = new System.Drawing.Point(5, 120);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.chkIsActive.Properties.Caption = "وضعیت حساب (فعال / غیرفعال)";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(236, 33);
            this.chkIsActive.TabIndex = 1;
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
            this.txtId.TabIndex = 6;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(485, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 25);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "کد حساب گروه";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox2);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.chkEditCode);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btnNewCode);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Controls.Add(this.chkIsActive);
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(598, 274);
            this.panelControl1.TabIndex = 16;
            // 
            // FrmHesabGroupCed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 327);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHesabGroupCed";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ایجاد حساب گروه ";
            this.Load += new System.EventHandler(this.FrmHesabGroupCed_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmHesabGroupCed_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSharhHesab.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.MemoEdit txtSharhHesab;
        public DevExpress.XtraEditors.SimpleButton btnCreateClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbEntezami;
        private System.Windows.Forms.RadioButton rdbSodZiani;
        private System.Windows.Forms.RadioButton rdbTaraznamei;
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
    }
}
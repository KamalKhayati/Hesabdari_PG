/****************************** Ghost.github.io ******************************\
*	Module Name:	FrmAnbarsName.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 17   04:17 ب.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hesabdari_TG_N1_V1.Models;
using Hesabdari_TG_N1_V1.Models.Base;
using Hesabdari_TG_N1_V1.Models.Base.AnbarKala;

namespace Hesabdari_TG_N1_V1.Forms.Base.AnbarKala
{
    public partial class FrmSaveAnbars : DevExpress.XtraEditors.XtraForm
    {
        FrmListAnbars Fm;
        public FrmSaveAnbars()
        {
            InitializeComponent();
        }
        public FrmSaveAnbars(FrmListAnbars fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        private void FrmSaveAnbars_Load(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {

                    if (db.BSAnbars.Any())
                    {
                        var q = db.BSAnbars.Max(p => p.Code);
                        txtcodeAnbar.Text = (q + 1).ToString();
                    }
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "ذخیره")
            {
                if (txtcodeAnbar.Text == string.Empty || txtNameAnbar.Text == string.Empty || txtcodeAnbar.Text == "0")
                {
                    XtraMessageBox.Show("اطلاعات را بصورت کامل وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                else
                {
                    using (var db = new MyContext())                    {
                        try
                        {
                            if (db.BSAnbars.Any())
                            {
                                int _code = Convert.ToInt32(txtcodeAnbar.Text);
                                var q1 = db.BSAnbars.Where(p => p.Code == _code ||p.Name.Contains(txtNameAnbar.Text));
                                if (q1.Any())
                                {
                                    XtraMessageBox.Show("انباری با این کد قبلاً تعریف شده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            {
                                BSAnbar ba = new BSAnbar()
                                {
                                    Code = Convert.ToInt32(txtcodeAnbar.Text),
                                    Name = txtNameAnbar.Text,
                                    IsActive = chkIsActive.Checked
                                };
                                db.BSAnbars.Add(ba);
                                db.SaveChanges();
                                Fm.FillGridViewWhitInstantFeedbackSource();
                                XtraMessageBox.Show("عملیات باموفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                                this.Close();
                            }
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("عملیات با خطا مواجه شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
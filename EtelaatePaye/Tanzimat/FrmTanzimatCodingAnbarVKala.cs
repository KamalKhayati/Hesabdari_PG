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
using DBHesabdari_PG;

namespace EtelaatePaye.Tanzimat
{
    public partial class FrmTanzimatCodingAnbarVKala : DevExpress.XtraEditors.XtraForm
    {
        public FrmTanzimatCodingAnbarVKala()
        {
            InitializeComponent();
        }

        public void FillTanzimatCodingAnbarVKala()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    var q1 = db.EpTanzimatAnbarVKalas.FirstOrDefault(s => s.SalId == _SalId);
                    if (q1 != null)
                    {
                        if (lblUserId.Text == "1")
                        {
                            txtAnbarCarakter.Text = q1.CodeAnbarCarakter.ToString();
                            txtTabagehKalaCarakter.Text = q1.CodeTabagehKalaCarakter.ToString();
                            txtGroupAsliCarakter.Text = q1.CodeGroupAsliKalaCarakter.ToString();
                            txtGroupFareeCarakter.Text = q1.CodeGroupFareeKalaCarakter.ToString();
                            txtNameKalaCarakter.Text = q1.CodeNameKalaCarakter.ToString();
                            txtVahedKalaCarakter.Text = q1.CodeVahedKalaCarakter.ToString();

                        }

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void IsAnyData()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _SalId = Convert.ToInt32(lblSalId.Text);
                    txtTabagehKalaCarakter.ReadOnly = db.EpTabaghehKalas.Any(s => s.SalId == _SalId) ? true : false;
                    txtGroupAsliCarakter.ReadOnly = db.EpGroupAsliKalas.Any(s => s.SalId == _SalId) ? true : false;
                    txtGroupFareeCarakter.ReadOnly = db.EpGroupFareeKalas.Any(s => s.SalId == _SalId) ? true : false;
                    txtNameKalaCarakter.ReadOnly = db.EpNameKalas.Any(s => s.SalId == _SalId) ? true : false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void FrmTanzimatCodingAnbarVKala_Load(object sender, EventArgs e)

        {
            FillTanzimatCodingAnbarVKala();
            IsAnyData();
        }

        private bool TextEditValidation()
        {
            ///////////////// اعتبار سنجی کد ////////////////////////////////////
            if (string.IsNullOrEmpty(txtAnbarCarakter.Text) || string.IsNullOrEmpty(txtTabagehKalaCarakter.Text)
                || string.IsNullOrEmpty(txtGroupAsliCarakter.Text) || string.IsNullOrEmpty(txtGroupFareeCarakter.Text)
                || string.IsNullOrEmpty(txtNameKalaCarakter.Text) || string.IsNullOrEmpty(txtVahedKalaCarakter.Text))
            {
                XtraMessageBox.Show("هیچکدام از فیلدها نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextEditValidation())
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _SalId = Convert.ToInt32(lblSalId.Text);
                        var q = db.EpTanzimatAnbarVKalas.FirstOrDefault(s => s.SalId == _SalId);
                        if (q != null)
                        {
                            q.CodeAnbarCarakter = Convert.ToInt32(txtAnbarCarakter.Text);
                            q.CodeTabagehKalaCarakter = Convert.ToInt32(txtTabagehKalaCarakter.Text);
                            q.CodeGroupAsliKalaCarakter = Convert.ToInt32(txtGroupAsliCarakter.Text);
                            q.CodeGroupFareeKalaCarakter = Convert.ToInt32(txtGroupFareeCarakter.Text);
                            q.CodeNameKalaCarakter = Convert.ToInt32(txtNameKalaCarakter.Text);
                            q.CodeVahedKalaCarakter = Convert.ToInt32(txtVahedKalaCarakter.Text);
                            ///////////
                            q.CodeAnbarMinCode = "1";
                            q.CodeAnbarMaxCode = "999";
                            //////////////
                            //switch (txtTabagehKalaCarakter.Text)
                            //{
                            //    case "1":
                            //        {
                            //            q.CodeTabagehKalaMinCode = "1";
                            //            q.CodeTabagehKalaMaxCode = "9";
                            //            break;
                            //        }
                            //    case "2":
                            //        {
                            //            q.CodeTabagehKalaMinCode = "10";
                            //            q.CodeTabagehKalaMaxCode = "99";
                            //            break;
                            //        }
                            //    case "3":
                            //        {
                            //            q.CodeTabagehKalaMinCode = "100";
                            //            q.CodeTabagehKalaMaxCode = "999";
                            //            break;
                            //        }
                            //    case "4":
                            //        {
                            //            q.CodeTabagehKalaMinCode = "1000";
                            //            q.CodeTabagehKalaMaxCode = "9999";
                            //            break;
                            //        }
                            //    default:
                            //        break;
                            //}
                            //////////////
                            switch (txtGroupAsliCarakter.Text)
                            {
                                //case "1":
                                //    {
                                //        q.CodeGroupAsliKalaMinCode = "1";
                                //        q.CodeGroupAsliKalaMaxCode = "9";
                                //        break;
                                //    }
                                //case "2":
                                //    {
                                //        q.CodeGroupAsliKalaMinCode = "01";
                                //        q.CodeGroupAsliKalaMaxCode = "99";
                                //        break;
                                //    }
                                case "3":
                                    {
                                        q.CodeGroupAsliKalaMinCode = "001";
                                        q.CodeGroupAsliKalaMaxCode = "999";
                                        break;
                                    }
                                case "4":
                                    {
                                        q.CodeGroupAsliKalaMinCode = "0001";
                                        q.CodeGroupAsliKalaMaxCode = "9999";
                                        break;
                                    }
                                default:
                                    break;
                            }
                            //////////////
                            switch (txtGroupFareeCarakter.Text)
                            {
                                //case "1":
                                //    {
                                //        q.CodeGroupFareeKalaMinCode = "1";
                                //        q.CodeGroupFareeKalaMaxCode = "9";
                                //        break;
                                //    }
                                //case "2":
                                //    {
                                //        q.CodeGroupFareeKalaMinCode = "01";
                                //        q.CodeGroupFareeKalaMaxCode = "99";
                                //        break;
                                //    }
                                case "3":
                                    {
                                        q.CodeGroupFareeKalaMinCode = "001";
                                        q.CodeGroupFareeKalaMaxCode = "999";
                                        break;
                                    }
                                case "4":
                                    {
                                        q.CodeGroupFareeKalaMinCode = "0001";
                                        q.CodeGroupFareeKalaMaxCode = "9999";
                                        break;
                                    }
                                default:
                                    break;
                            }
                            //////////////
                            switch (txtNameKalaCarakter.Text)
                            {
                                //case "1":
                                //    {
                                //        q.CodeNameKalaMinCode = "1";
                                //        q.CodeNameKalaMaxCode = "9";
                                //        break;
                                //    }
                                //case "2":
                                //    {
                                //        q.CodeNameKalaMinCode = "01";
                                //        q.CodeNameKalaMaxCode = "99";
                                //        break;
                                //    }
                                case "3":
                                    {
                                        q.CodeNameKalaMinCode = "001";
                                        q.CodeNameKalaMaxCode = "999";
                                        break;
                                    }
                                case "4":
                                    {
                                        q.CodeNameKalaMinCode = "0001";
                                        q.CodeNameKalaMaxCode = "9999";
                                        break;
                                    }
                                default:
                                    break;
                            }
                            //////////////
                            q.CodeVahedKalaMinCode = "1";
                            q.CodeVahedKalaMaxCode = "999";


                            db.SaveChanges();
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmTanzimatCodingAnbarVKala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSave_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClose_Click(sender, null);
            }
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("تعدادکاراکتر 2 = تعریف اتوماتیک کد کالا در سطح 1 حسابهای تفصیلی\n"+
                "تعدادکاراکتر 3 = تعریف اتوماتیک کد کالا در سطح 2 حسابهای تفصیلی\n" +
                "تعدادکاراکتر 4 = تعریف اتوماتیک کد کالا در سطح 3 حسابهای تفصیلی"
                        , "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
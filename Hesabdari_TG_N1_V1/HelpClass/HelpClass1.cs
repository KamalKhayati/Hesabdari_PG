/****************************** Ghost.github.io ******************************\
*	Module Name:	HelpClass.cs
*	Project:		Hesabdari_TG_N1_V1
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 17   03:51 ب.ظ
*	
***********************************************************************************/
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Hesabdari_TG_N1_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraGrid;
using System.Drawing;
using Hesabdari_TG_N1_V1.Models.AP.AnbarKala;
using Microsoft.Win32;

namespace Hesabdari_TG_N1_V1.HelpClass
{
    public class HelpClass1
    {
        /// <summary>
        /// جلوگیری از باز شدن فرمها بیش از یک بار
        /// </summary>
        /// <param name="form"></param>
        public static void ActiveForm(XtraForm form)
        {
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show();
            }
            else
            {
                Application.OpenForms[form.Name].Activate();
            }

        }
        public static void FormNewRecordCreate(XtraForm ChildForm, string btnCreateClose = "btnCreateClose", string txtName = "txtName", string panelControl2 = "panelControl2")
        {
            ChildForm.Text = "ایجاد رکورد جدید";
            ChildForm.Controls[panelControl2].Controls[btnCreateClose].Text = "ایجاد و بستن";
            ChildForm.ShowDialog();
        }

        public static int EditRowIndex = 0;
        public static void FormCurrentRecordEdit(GridView gridView1, XtraForm ChildForm, string btnCreateClose = "btnCreateClose", string btnCreateNext = "btnCreateNext", string panelControl2 = "panelControl2")
        {
            EditRowIndex = gridView1.FocusedRowHandle;
            ChildForm.Text = "ویرایش رکورد جاری";
            ChildForm.Controls[panelControl2].Controls[btnCreateClose].Text = "ویرایش و بستن";
            ChildForm.Controls[panelControl2].Controls[btnCreateNext].Visible = false;
            ChildForm.ShowDialog();
        }

        public static void FormCurrentRecordDelete(GridView gridView1, XtraForm ChildForm, string btnCreateClose = "btnCreateClose", string btnCreateNext = "btnCreateNext", string panelControl1 = "panelControl1", string panelControl2 = "panelControl2")
        {
            EditRowIndex = gridView1.FocusedRowHandle;
            ChildForm.Text = "حذف رکورد جاری";
            ChildForm.Controls[panelControl2].Controls[btnCreateClose].Text = "حذف و بستن";
            ChildForm.Controls[panelControl2].Controls[btnCreateNext].Visible = false;
            ChildForm.Controls[panelControl1].Enabled = false;
            ChildForm.ShowDialog();
        }

        /// <summary>
        /// تنظیم شماره بندی ردیفهای گرید ویو در ستون آنباند
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SetNumberRowsColumnUnboundGirdView(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = (GridView)sender;
            if (view == null) return;
            int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
            //int visibleIndex = view.GetVisibleIndex(rowHandle);
            //if (e.IsSetData) return;
            if (e.Column.FieldName == "Line")
                e.Value = rowHandle + 1;
            //if (e.Column.FieldName == "gridColumnVisibleIndex")
            //    e.Value = visibleIndex;
            //if (e.Column.FieldName == "gridColumnListSourceIndex")
            //    e.Value = e.ListSourceRowIndex;

        }

        public void AddPermissiveUsersNameToColumnUnboundGirdView()
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{

            //    using (var db = new MyContext())
            //    {
            //        try
            //        {
            //            int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsVahedId").ToString());
            //            var q = db.RmsVahedhaBmsUserhas.Where(s => s.MsVahedId == Id).Select(s => s.UserName).ToList();
            //            if (q.Count > 0)
            //            {
            //                string a = "";
            //                foreach (var item in q)
            //                {
            //                    a += item + ",";

            //                }
            //                gridView1.SetRowCellValue(i, "PermissiveUsersName", a);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
            //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        #region // متد ایجاد کد جدید به فرم بصورت اتومات
        //using (var db = new MyContext())
        //{
        //    try
        //    {
        //        var q = db.MyEntitys.Max(p => p.Code);
        //        txtName.Text = q != 0 ? (q + 1).ToString() : "";
        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        // متاسفانه درست اجرا نشد    
        #endregion

        #region //اضافه کردن رکورد جدید به دیتاگرید ویو
        //private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        //{
        //    gridView1.SetRowCellValue(e.RowHandle, "Code", "105");
        //    gridView1.SetRowCellValue(e.RowHandle, "Name", "ارومیه");
        //    gridView1.SetRowCellValue(e.RowHandle, IsActive, true);
        //}

        //
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    gridView1.AddNewRow();
        //}
        #endregion

        #region // حذف کردن رکورد در دیتاگرید ویو
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    gridView1.DeleteRow(gridView1.FocusedRowHandle);
        //}
        #endregion

        /// <summary>
        /// پیش نمایش چاپ گرید ویو
        /// </summary>
        /// <param name="gridControl1"></param>
        /// <param name="gridView1"></param>
        public static void PrintPreview(GridControl gridControl1, GridView gridView1)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                // Check whether the GridControl can be previewed.
                if (!gridControl1.IsPrintingAvailable)
                {
                    MessageBox.Show("کتابخانه XtraPrinting پیدا نشد", "خطا");
                    return;
                }
                // Open the Preview window.
                gridView1.ShowPrintPreview();
            }
        }

        /// <summary>
        /// چاپ گرید ویو
        /// </summary>
        /// <param name="gridControl1"></param>
        /// <param name="gridView1"></param>
        public static void ListPrint(GridControl gridControl1, GridView gridView1)
        {
            if (gridView1.SelectedRowsCount > 0)
            {

                //// Check whether the GridControl can be printed.
                //if (!gridControl1.IsPrintingAvailable)
                //{
                //    MessageBox.Show("کتابخانه XtraPrinting پیدا نشد", "خطا");
                //    return;
                //}
                //// Print.
                //gridView1.Print();
            }
        }

        /// <summary>
        /// شماره بندی ردیف های اندیکاتور گرید ویو
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="gridView1"></param>
        public static void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e, GridView gridView1)
        {
            gridView1.IndicatorWidth = 60;
            // Handle this event to paint RowIndicator manually
            GridView view = sender as GridView;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        public static void EnterReplaceTab(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public static void SwitchToPersianLanguage()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR"));
        }

        public static void SetRegionAndLanguage()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);

            ///Set Values
            regkey.SetValue("iCalendarType", "1");
            regkey.SetValue("iCountry", "981");
            regkey.SetValue("iCurrDigits", "0");
            regkey.SetValue("iCurrency", "0");
            regkey.SetValue("iDate", "2");
            regkey.SetValue("iDigits", "0");
            regkey.SetValue("iFirstDayOfWeek", "5");
            regkey.SetValue("iFirstWeekOfYear", "0");
            regkey.SetValue("iLocale", "00000429");
            regkey.SetValue("iLocaleName", "fa-IR");
            regkey.SetValue("iLZero", "1");
            regkey.SetValue("iMeasure", "0");
            regkey.SetValue("iNegCurr", "3");
            regkey.SetValue("iNegNumber", "3");
            regkey.SetValue("iPaperSize", "9");
            regkey.SetValue("iTime", "0");
            regkey.SetValue("iTimePrefix", "0");
            regkey.SetValue("iTLZero", "1");
            regkey.SetValue("Locale", "00000429");
            regkey.SetValue("LocaleName", "fa-IR");
            regkey.SetValue("iNumShape", "0");
            regkey.SetValue("s1159", "ق.ظ");
            regkey.SetValue("s2359", "ب.ظ");
            regkey.SetValue("sCountry", "Iran");
            regkey.SetValue("sCurrency", " ");
            regkey.SetValue("sDate", "/");
            regkey.SetValue("sDecimal", "/");
            regkey.SetValue("sGrouping", "3;0");
            regkey.SetValue("sLanguage", "FAR");
            regkey.SetValue("sList", ";");
            regkey.SetValue("sLongDate", "yyyy/MM/dd");
            regkey.SetValue("sMonDecimalSep", "/");
            regkey.SetValue("sMonGrouping", "3;0");
            regkey.SetValue("sMonThousandSep", ",");
            regkey.SetValue("sNativeDigits", "۰۱۲۳۴۵۶۷۸۹");
            regkey.SetValue("sNegativeSign", "-");
            regkey.SetValue("sPositiveSign", "");
            regkey.SetValue("sShortDate", "yyyy/MM/dd");
            regkey.SetValue("sShortTime", "hh:mm tt");
            regkey.SetValue("sTime", ":");
            regkey.SetValue("sTimeFormat", "hh:mm:ss tt");
            regkey.SetValue("sYearMonth", "hh:mm:ss tt");

            //Close the Registry
            regkey.Close();

            /////////////////////////////////////////////////////////////////
            //Get Data From Text Boxes

            //string DateFormat = txtDateFormat.Text.Trim();

            //string TimeFormat = txtTimeFormat.Text.Trim();

            //string Currency = txtCurrency.Text.Trim();



            //Registry Logic

            //Open Sub key

            //RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);



            ///Set Values

            //rkey.SetValue("sTimeFormat", TimeFormat);

            //rkey.SetValue("sShortDate", DateFormat);

            //rkey.SetValue("sCurrency", Currency);



            //Close the Registry

            //rkey.Close();
            /////////////////////////////////////////////////////////////
        }

        public static void StartCalculater()
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }
        public static void StartWordPad()
        {
            System.Diagnostics.Process.Start("WordPad.exe");
        }
        public static void StartNotePad()
        {
            System.Diagnostics.Process.Start("NotePad.exe");
        }
        public static void TextBoxFormatDesign_000(TextEdit TextEdit)
        {
            TextEdit.Text = Convert.ToInt32(TextEdit.Text).ToString("00#");
        }

    }
}

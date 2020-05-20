/****************************** Ghost.github.io ******************************\
*	Module Name:	HelpClass1.cs
*	Project:		HelpClassLibrary
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   02:42 ب.ظ
*	
***********************************************************************************/
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Globalization;
using DBHesabdari_PG;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data.Entity;
using static DevExpress.DataAccess.UI.XPObjectSource.PropertyCollectionEditor;
using DevExpress.XtraEditors.Popup;

namespace HelpClassLibrary
{
    public class HelpClass1
    {

        /// <summary>
        /// وایریش ردیف دیتاگرید با استفاده از اینتر
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void gridView_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        btnEdit_Click(null, null);
        //    }
        //}



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
        public static void SetNumberRowsColumnUnboundGirdView(object sender, CustomColumnDataEventArgs e)
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

        //public void AddPermissiveUsersNameToColumnUnboundGirdView()
        //{
        //    //for (int i = 0; i < gridView1.RowCount; i++)
        //    //{

        //    //    using (var db = new MyContext())
        //    //    {
        //    //        try
        //    //        {
        //    //            int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MsVahedId").ToString());
        //    //            var q = db.RmsUserhaBmsVahedhas.Where(s => s.MsVahedId == Id).Select(s => s.UserName).ToList();
        //    //            if (q.Count > 0)
        //    //            {
        //    //                string a = "";
        //    //                foreach (var item in q)
        //    //                {
        //    //                    a += item + ",";

        //    //                }
        //    //                gridView1.SetRowCellValue(i, "PermissiveUsersName", a);
        //    //            }
        //    //        }
        //    //        catch (Exception ex)
        //    //        {
        //    //            XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
        //    //                "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //        }
        //    //    }
        //    //}
        //}


            /// <summary>
            /// حذف ردیف فوکوس شده در دیتا گردید ویو با استفاده از کلید Delete
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
        }
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
                    XtraMessageBox.Show("کتابخانه XtraPrinting پیدا نشد", "خطا");
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

        //public static void EnterReplaceTab(KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        SendKeys.Send("{tab}");
        //        e.Handled = true;
        //        e.SuppressKeyPress = true;
        //    }
        //}


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
        //public static void TextBoxFormatDesign_00(TextEdit TextEdit)
        //{
        //    TextEdit.Text = Convert.ToInt32(TextEdit.Text).ToString("0#");
        //}
        //public static void TextBoxFormatDesign_000(TextEdit TextEdit)
        //{
        //    TextEdit.Text = Convert.ToInt32(TextEdit.Text).ToString("00#");
        //}
        public static void InActiveButtons(Control panel)
        {
            foreach (Control item in panel.Controls)
            {
                if (item is SimpleButton)
                {
                    if (item.Name == "btnSave" || item.Name == "btnSaveNext" || item.Name == "btnCancel")
                    {
                        item.Enabled = true;
                    }
                    else
                        item.Enabled = false;
                }
            }
        }

        public static void ActiveButtons(Control panel)
        {
            foreach (Control item in panel.Controls)
            {
                if (item is SimpleButton)
                {
                    if (item.Enabled == true)
                        item.Enabled = false;
                    else if (item.Name != "btnDelete" && item.Name != "btnEdit")
                        item.Enabled = true;
                }

            }
        }

        public static void ClearControls(Control panel)
        {
            foreach (Control item in panel.Controls)
            {
                var _Type = item.GetType();
                if (_Type.Name == "TextEdit")
                    item.Text = "";
                else if (_Type.Name == "LookUpEdit")
                {
                    LookUpEdit item1 = (LookUpEdit)item;
                    item1.EditValue = 0;
                }
                else if (_Type.Name == "ComboBoxEdit")
                {
                    ComboBoxEdit item1 = (ComboBoxEdit)item;
                    item1.SelectedIndex = -1;
                }
                else if (_Type.Name == "CheckEdit")
                {
                    CheckEdit item1 = (CheckEdit)item;
                    // if (item1.Name != "chkIsActive")
                    item1.Checked = false;
                }
                else if (_Type.Name == "GroupBox")
                {
                    GroupBox item1 = (GroupBox)item;
                    item1.Controls[0].Text = "";
                }
                else if (_Type.Name == "PictureEdit")
                {
                    PictureEdit item1 = (PictureEdit)item;
                    item1.Image = null;
                }
                else if (_Type.Name == "CheckedComboBoxEdit")
                {
                    CheckedComboBoxEdit item1 = (CheckedComboBoxEdit)item;
                    item1.SetEditValue(0);
                }
                
            }
        }

        public static void ActiveControls(Control panel)
        {
            panel.Enabled = true;

            //foreach (Control item in panel.Controls)
            //{
            //    //if (item is TextEdit)
            //    //{
            //    //    TextEdit item2 = (TextEdit)item;
            //    //    item2.ReadOnly = false;
            //    //}
            //    //else
            //    //var _Type = item.GetType();
            //    //if (_Type.Name == "TextEdit" || _Type.Name == "LookUpEdit")
            //        item.Enabled = true;
            //}
        }

        public static void InActiveControls(Control panel)
        {
            panel.Enabled = false;
            //foreach (Control item in panel.Controls)
            //{
            //    //if (item is TextEdit)
            //    //{
            //    //    TextEdit item2 = (TextEdit)item;
            //    //    item2.ReadOnly = false;
            //    //}
            //    //else
            //    //var _Type = item.GetType();
            //    //if (_Type.Name == "TextEdit" || _Type.Name == "LookUpEdit")
            //    //    //item.Enabled = true;
            //        item.Enabled = false;
            //}
        }

        /// <summary>
        /// رنگ بندی ردیفهای دیتاگریدویو
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void gridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            bool IsActive = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IsActive"));

            if (IsActive)
            {
                Color foreColor = Color.Black;
                e.Appearance.ForeColor = foreColor;
            }
            else
            {
                Color foreColor = Color.Red;
                e.Appearance.ForeColor = foreColor;
            }

        }

        /// <summary>
        /// رنگ بندی سلول کمبوباکس
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void LookupEdit_CustomDrawCell(object sender, LookUpCustomDrawCellArgs e)
        {
            //if (e.IsRowSelected) return;
            //if ((e.RowIndex % 2) == 0) return;
            //if (e.DisplayText != "False")
            //    return;
            //e.Appearance.BackColor = Color.Red;
            if (e.DisplayText == "False")
            {
                e.Appearance.BackColor = Color.Pink;
                e.DisplayText = "خیر";
            }
            else if (e.DisplayText == "True")
            {
                e.DisplayText = "بله";
            }
        }

        public static void DateTimeMask(TextEdit TextBox)
        {
            /// <summary>
            /// فرمول قالب بندی تاریخ برای ماه اسفند 29 روزه
            /// </summary>
            //([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[0-1])/([012][1-9]|[123]0))|((1[2])/([012][1-9]|[12]0)))

            /// <summary>
            /// فرمول قالب بندی تاریخ برای ماه اسفند 30 روزه
            /// </summary>
            //([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[0-1])/([012][1-9]|[123]0))|((1[2])/([012][1-9]|[123]0)))

            TextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            TextBox.Properties.Mask.EditMask = "([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[0-1])/([012][1-9]|[123]0))|((1[2])/([012][1-9]|[12]0)))";
            TextBox.RightToLeft = RightToLeft.No;
        }

        //public void SetDateTimeNow(MaskedTextBox objMTB)
        //{
        //    PersianCalendar objPC = new PersianCalendar();
        //    objMTB.Text = objPC.GetYear(DateTime.Now).ToString("0000") + objPC.GetMonth(DateTime.Now).ToString("00") + objPC.GetDayOfMonth(DateTime.Now).ToString("00");
        //}
        public static void SetCurrentYear(TextEdit TextEdit)
        {
            PersianCalendar objPC = new PersianCalendar();
            TextEdit.Text = objPC.GetYear(DateTime.Now).ToString("0000");
        }
        public static void CloseAllOpenForms()
        {
            List<XtraForm> openForms = new List<XtraForm>();

            foreach (XtraForm f in Application.OpenForms)
                openForms.Add(f);

            foreach (XtraForm f in openForms)
            {
                if (f.Name != "FrmMain")
                    f.Close();
            }

            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //{
            //    if (Application.OpenForms[i].Name != "FrmMain")
            //        Application.OpenForms[i].Close();
            //}
        }

        ////////////////////////Alt.Control.Shift.F12///////////////////////////////////////////
        //private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //if (e.KeyChar=='b')
        //    //{
        //    //    btnTest.Visible = true;
        //    //}
        //}

        //private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
        //    //{
        //    //    btnTest.Visible = true;
        //    //}

        //}


        ///////////////////////////////**************************************************//////////////////////////////////////////


        //تنظیم EditMask تکس باکس تاریخ
        //RightToLeft=No
        //RegEx
        //([1-9][3-9][0-9][0-9])/(((0[1-6])/([012][1-9]|[123]0|31))|((0[7-9]|1[01])/([012][1-9]|[123]0))|((1[2])/([012][1-9])))
        //Show Placeholdes=true

        public static void AddZerooToTextBox(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                TextEdit TextEdit1 = (TextEdit)sender;
                if (TextEdit1 == null) return;
                TextEdit1.Text = TextEdit1.Text + "000";
            }
            //else if (e.KeyChar == '-')
            //{
            //    TextEdit TextEdit1 = (TextEdit)sender;
            //    if (TextEdit1 == null) return;
            //    string Text1 = TextEdit1.Text.Replace("-", "+");
            //    string Text2 = Text1 + "00";
            //    TextEdit1.Text = Text2.Replace("-", "+");
            //}
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
            regkey.SetValue("iCurrency", "2");
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
            regkey.SetValue("iNumShape", "0");
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
            regkey.SetValue("sDecimal", ".");
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
            regkey.SetValue("sThousand", ",");
            regkey.SetValue("sTime", ":");
            regkey.SetValue("sTimeFormat", "hh:mm:ss tt");
            regkey.SetValue("sYearMonth", "MMMM,yyyy");

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
        public static void MoveLast(GridView gridView)
        {
            gridView.MoveLast();
        }
        public static void MoveNext(GridView gridView)
        {
            gridView.MoveNext();
        }
        public static void MovePrev(GridView gridView)
        {
            gridView.MovePrev();
        }
        public static void MoveFirst(GridView gridView)
        {
            gridView.MoveFirst();
        }

        #region عملیات مربوط به PictuerBox
        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
        //        return;
        //    pictureBox1.ImageLocation = openFileDialog1.FileName;
        //}

        //string copyPictuer(string sourcefile, string key)
        //{
        //    if (sourcefile == "")
        //        return null;
        //    string curentPath;
        //    string newPath;
        //    curentPath = Application.StartupPath + @"\image\";
        //    if (Directory.Exists(curentPath) == false)
        //    {
        //        Directory.CreateDirectory(curentPath);
        //    }

        //    newPath = curentPath + key + sourcefile.Substring(sourcefile.LastIndexOf("."));
        //    if (File.Exists(newPath))
        //    {
        //        File.Delete(newPath);
        //    }
        //    File.Copy(sourcefile, newPath);
        //    return newPath;
        //}

        //private Region r = new Region();
        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
        //    {
        //        r = pictureBox1.Region;
        //        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        //    }
        //    else
        //    {
        //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //        pictureBox1.Region = r;
        //    }
        //}

        //private void pictureBox1_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //    pictureBox1.Region = r;

        //}

        //private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    r = pictureBox1.Region;
        //    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

        //}
        #endregion


        public static void gridView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e, GridView gridView1, string Bed = "Bed", string Bes = "Bes", string Mande = "Mande")
        {
            if (gridView1.RowCount == 0)
                return;

            decimal SumBed = Convert.ToDecimal(gridView1.Columns[Bed].SummaryItem.SummaryValue);
            decimal SumBes = Convert.ToDecimal(gridView1.Columns[Bes].SummaryItem.SummaryValue);
            decimal _Mande = SumBed - SumBes;

            var item = e.Item as GridColumnSummaryItem;

            if (item == null || item.FieldName != Mande)
                return;

            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                e.TotalValue = _Mande;
        }

        public static List<decimal> Result2;
        public static int IndexAkharinDaruaft = -1;
        public static void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e, GridView gridView1, string Bed = "Bed", string Bes = "Bes", string Mande = "Mande")
        {
            if (gridView1.RowCount == 0)
                return;

            SetNumberRowsColumnUnboundGirdView(sender, e);
            int rowIndex = e.ListSourceRowIndex;
            decimal bed = Convert.ToDecimal(gridView1.GetListSourceRowCellValue(rowIndex, Bed));
            decimal bes = Convert.ToDecimal(gridView1.GetListSourceRowCellValue(rowIndex, Bes));
            if (e.Column.FieldName != Mande) return;
            if (e.IsGetData)
            {
                if (rowIndex == 0)
                {
                    Result2.Add(bed - bes);
                    e.Value = Result2[rowIndex];
                    if (Convert.ToDecimal(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
                else
                {
                    Result2.Add(Result2[rowIndex - 1] + bed - bes);
                    e.Value = Result2[rowIndex];
                    if (Convert.ToDecimal(e.Value) == 0)
                    {
                        IndexAkharinDaruaft = rowIndex;
                    }
                }
            }

        }

        public static void ControlAltShift_KeyDown(object sender, KeyEventArgs e, params Control[] btn)
        {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Visible = btn[i].Visible == true ? false : true;
                }
            }
        }

        //public static void LoadReportDesigner(string FilePath, string FileName)
        //{
        //    if (System.IO.File.Exists(FilePath + FileName))
        //    {
        //        //ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
        //        FrmReportDesigner frd = new FrmReportDesigner();
        //        frd.reportDesigner1.OpenReport(FilePath + FileName);
        //        frd.Show();

        //    }
        //    else
        //    {
        //        NewReportDesigner(FilePath, FileName);
        //    }
        //}

        //public static void NewReportDesigner(string FilePath, string FileName)
        //{
        //    XtraMessageBox.Show("چاپ فوق قبلاً طراحی نشده است لذا در صورت طراحی چاپ ، فایل مربوطه را با نام " + FileName + " در مسیر \n" + FilePath + " ذخیره فرمایید.", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        //    //ساخت فرم طراحی گزارش و ارسال فرم طراحی شده قبلی به فرم طراحی جهت ویرایش
        //    XtraReport XtraReport1 = new XtraReport();
        //    XtraReport1.DisplayName = FileName;
        //    XtraReport1.PaperName = FileName;
        //    XtraReport1.PaperKind = System.Drawing.Printing.PaperKind.Letter;
        //    XtraReport1.Name = FileName;
        //    //XtraReport1.PrinterName = FileName;
        //    XtraReport1.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
        //    FrmReportDesigner frd = new FrmReportDesigner();
        //    frd.reportDesigner1.OpenReport(XtraReport1);
        //    frd.Show();


        //}

        public static DataSet ConvettDatagridviewToDataSet(GridView gridView)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            for (int ColumnCounter = 0; ColumnCounter < gridView.Columns.Count; ColumnCounter++)
                dt.Columns.Add(gridView.Columns[ColumnCounter].FieldName);

            for (int RowCounter = 0; RowCounter < gridView.RowCount; RowCounter++)
            {
                DataRow DataRow1 = dt.NewRow();
                for (int j = 0; j < gridView.Columns.Count; j++)
                {
                    //DataRow1[j] = gridView.Rows[RowCounter].Cells[j].Value.ToString();
                    DataRow1[j] = gridView.GetRowCellDisplayText(RowCounter, gridView.Columns[j]);
                }
                dt.Rows.Add(DataRow1);
            }
            ds.Tables.Add(dt);
            return ds;
        }

        /////Encryption یا رمزنگاری
        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        /////Decryption یا رمزگشایی
        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;


            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        /////خب حالا باید دو تا void درست کنیم تا Encrypt و Decrypt را ساده تر برامون انجام دهند.
        ///ابتدا void مربوط به Encrypt
        public static string EncryptText(string input, string password = "km113012")
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        ///////سپس void دوم یا Decrypt همانند زیر می شود.
        ///نحوه استفاده از آن هم بسیار ساده است متد ها هرکدام دو مقدار ورودی دارد که اولی استرینگ است که می خواهید کد شود و دومی کلید شما است.
        public static string DecryptText(string input, string password = "km113012")
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        ////////////////////////////جلوگیری از خارج شدن برنامه //////////////////////////////////////
        public static void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("آیا میخواهید از برنامه خارج شود ؟", "پیغام ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
                return;
                // Application.OpenForms["FrmMain"].Activate();
            }
            else
            {
                SqlConnection.ClearAllPools();
                Application.ExitThread();
                Application.Exit();
            }
        }


    }
}


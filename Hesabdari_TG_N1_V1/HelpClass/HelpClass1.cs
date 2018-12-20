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

namespace Hesabdari_TG_N1_V1.HelpClass
{
    public class HelpClass1
    {
        /// <summary>
        /// جلوگیری از باز شدن فرمها بیش از یک بار
        /// </summary>
        /// <param name="form"></param>
        public static void FormActive(XtraForm form)
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
        /// <summary>
        /// تنظیم شماره بندی ردیفهای گرید ویو در ستون آنباند
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SetNumberRowsColumnUnboundGirdView(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
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
        public static void ShowGridPreview(GridControl gridControl1, GridView gridView1)
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

        /// <summary>
        /// چاپ گرید ویو
        /// </summary>
        /// <param name="gridControl1"></param>
        /// <param name="gridView1"></param>
        public static void PrintGrid(GridControl gridControl1, GridView gridView1)
        {
            // Check whether the GridControl can be printed.
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("کتابخانه XtraPrinting پیدا نشد", "خطا");
                return;
            }
            // Print.
            gridView1.Print();
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
    }
}

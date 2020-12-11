/****************************** Ghost.github.io ******************************\
*	Module Name:	HelpClass2.cs
*	Project:		HelpClassLibrary
*	Copyright (C) 2018 Kamal Khayati, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Kamal Khayati <Kamal1355@gmail.com>,  2018 / 12 / 31   02:43 ب.ظ
*	
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpClassLibrary
{
    class HelpClass2
    {
        //How to: Delete a Row When the CTRL+DEL Shortcut is Pressed => حذف یک ردیف خاص از دیتاگرید توسط کلیدهای ترکیبی CTRL+DEL
        //private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
        //    {
        //        if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
        //          DialogResult.Yes)
        //            return;
        //        GridView view = sender as GridView;
        //        view.DeleteRow(view.FocusedRowHandle);
        //    }
        //}

        //public void FillDataGridView(DataGridView objDGW)
        //{
        //    objDGW.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        //    foreach (DataGridViewRow Row in objDGW.Rows)
        //    {
        //        Row.Height = 40;
        //    }
        //}


        //public void JustInputTheNumbers(KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
        public void JustInputTheLetters(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void SeparateThreeDigits(TextBox objTB)
        {
            if (objTB.Text == "")
            {
                objTB.Text = "0";
            }
            objTB.Text = Convert.ToInt64(objTB.Text.Replace(",", "")).ToString("n0");
            objTB.SelectionStart = objTB.TextLength;
        }

        public void SetDateTimeNow(MaskedTextBox objMTB)
        {
            PersianCalendar objPC = new PersianCalendar();
            objMTB.Text = objPC.GetYear(DateTime.Now).ToString("0000") + objPC.GetMonth(DateTime.Now).ToString("00") + objPC.GetDayOfMonth(DateTime.Now).ToString("00");
        }


        //public void SortRadifeDataGridView(DataGridView objDGW)
        //{
        //    int a = 0;
        //    if (objDGW.RowCount == 0)
        //    {
        //        a = 0;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < objDGW.RowCount; i++)
        //        {
        //            a = i + 1;
        //            objDGW[0, i].Value = a;
        //        }
        //    }

        //}
        //public void DataGridView_CellFormating(DataGridView objDGW, int ColumnsIndex, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.ColumnIndex == ColumnsIndex && e.RowIndex != objDGW.NewRowIndex)
        //    {
        //        double d = double.Parse(e.Value.ToString());
        //        e.Value = d.ToString("#,##0.##");
        //    }

        //}

        ///////////// دستور چاپ به استیمول سافت///////////
        //StiReport Report = new StiReport();
        //Report.Load("Report/ChapFactor.mrt");
        //Report.Compile();
        //Report["NoeFactor"] = 1;
        //Report["ShomareFaktor"] = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        //Report.Show();

        //////////// انتخاب چند فیلد از جدول بانک اطلاعاتی بهمراه اعمال شرط و اعمال ترتیب ////////////
        //var x = from n in db.GroupFareeKalas
        //        where n.CodeKala=Convert.Toint32(txtCodeKala.Text)
        //        orderby n.TedadeKala Ascending
        //        Select n;
        //        OR
        //        select new 
        //        {
        //            n.CodeGroupAsliKala,
        //            n.NameGroupAsliKala,
        //            n.CodeGroupFareeKala,
        //            n.NameGroupFareeKala,

        //        };
        //        dataGridView1.DataSource = x.ToList();
        //        FillDataGrid();


        /////////////////////////////////////// چند ستونه کردن checkcombobox در صورت اطلاعات زیاد /////////////////////
        //private void chkcmbListMajmoeha_Popup(object sender, EventArgs e)
        //{
        //    CheckedPopupContainerForm form = chkcmbListMajmoeha.GetPopupEditForm();
        //    foreach (Control control in form.Controls)
        //    {
        //        if (control is PopupContainerControl)
        //        {
        //            foreach (Control child in control.Controls)
        //            {
        //                if (child is CheckedListBoxControl)
        //                {
        //                    (child as CheckedListBoxControl).MultiColumn = true;
        //                    break;
        //                }
        //            }
        //            break;
        //        }
        //    }
        //}

    }
}

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
using System.Data.Entity;
using DBHesabdari_PG;
using DBHesabdari_PG.Models.AK;

namespace AnbarVaKala.Reports
{
    public partial class FrmMojodiAnbarVKala : DevExpress.XtraEditors.XtraForm
    {
        public FrmMojodiAnbarVKala()
        {
            InitializeComponent();
        }

        int _SalId = 0;
        public void FillcmbAnbarName()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var q = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                    epListAnbarhasBindingSource.DataSource = q;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void FillbandedGridView()
        {
            //int TafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
            // var StartData = Convert.ToDateTime(txtAzTarikh.Text);
            // var EndData = Convert.ToDateTime(txtTaTarikh.Text);
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    //gridControl_MeghdariVRiali.DataSource = null;
                    //gridControl_Meghdari.DataSource = null;
                    //gridControl_Riali.DataSource = null;
                    //DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    for (int ColumnCounter = 0; ColumnCounter < bandedGridView_MeghdariVRiali.Columns.Count; ColumnCounter++)
                        dt.Columns.Add(bandedGridView_MeghdariVRiali.Columns[ColumnCounter].FieldName);
                    dt.Columns[0].DataType = typeof(decimal);
                    //dt.Columns[1].DataType = typeof(decimal);
                    //dt.Columns[2].DataType = typeof(decimal);
                    dt.Columns[5].DataType = typeof(decimal);
                    dt.Columns[6].DataType = typeof(decimal);
                    dt.Columns[7].DataType = typeof(decimal);
                    dt.Columns[8].DataType = typeof(decimal);
                    dt.Columns[9].DataType = typeof(decimal);
                    dt.Columns[10].DataType = typeof(decimal);
                    dt.Columns[11].DataType = typeof(decimal);
                    dt.Columns[12].DataType = typeof(decimal);
                    dt.Columns[13].DataType = typeof(decimal);
                    dt.Columns[14].DataType = typeof(decimal);
                    dt.Columns[15].DataType = typeof(decimal);
                    dt.Columns[16].DataType = typeof(decimal);

                    var q2 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId && s.LevelNamber == 4).ToList();
                    var q3 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId).ToList();
                    var q1 = q3.Select(s => s.KalaId).Distinct().ToList();

                    if (q3.Count > 0)
                    {
                        for (int RowCounter = 0; RowCounter < q1.Count; RowCounter++)
                        {
                            DataRow DataRow1 = dt.NewRow();
                            DataRow1.Table.Columns[0].DataType = typeof(decimal);
                            //DataRow1.Table.Columns[1].DataType = typeof(decimal);
                            //DataRow1.Table.Columns[2].DataType = typeof(decimal);
                            DataRow1.Table.Columns[5].DataType = typeof(decimal);
                            DataRow1.Table.Columns[6].DataType = typeof(decimal);
                            DataRow1.Table.Columns[7].DataType = typeof(decimal);
                            DataRow1.Table.Columns[8].DataType = typeof(decimal);
                            DataRow1.Table.Columns[9].DataType = typeof(decimal);
                            DataRow1.Table.Columns[10].DataType = typeof(decimal);
                            DataRow1.Table.Columns[11].DataType = typeof(decimal);
                            DataRow1.Table.Columns[12].DataType = typeof(decimal);
                            DataRow1.Table.Columns[13].DataType = typeof(decimal);
                            DataRow1.Table.Columns[14].DataType = typeof(decimal);
                            DataRow1.Table.Columns[15].DataType = typeof(decimal);
                            DataRow1.Table.Columns[16].DataType = typeof(decimal);

                            DataRow1[0] = 0;
                            //DataRow1[1] = 0;
                            //DataRow1[2] = 0;
                            DataRow1[5] = 0;
                            DataRow1[6] = 0;
                            DataRow1[7] = 0;
                            DataRow1[8] = 0;
                            DataRow1[9] = 0;
                            DataRow1[10] = 0;
                            DataRow1[11] = 0;
                            DataRow1[12] = 0;
                            DataRow1[13] = 0;



                            if (string.IsNullOrEmpty(cmbAnbarName.Text))
                            {
                                DataRow1[0] = q1[RowCounter];
                                DataRow1[1] = dt.Rows.Count + 1;
                                DataRow1[2] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).KeyCode;
                                DataRow1[3] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).LevelName;
                                DataRow1[4] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).EpNameKala1.VahedKala1Name;

                                DataRow1[5] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 1).Sum(s => s.Meghdar);
                                DataRow1[7] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 1).Sum(s => s.Mablag);
                                DataRow1[6] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 1).Sum(s => s.Mablag) != 0 ? q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 1).Sum(s => s.Mablag) / q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 1).Sum(s => s.Meghdar) : 0;

                                DataRow1[8] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 2).Sum(s => s.Meghdar);
                                DataRow1[10] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 2).Sum(s => s.Mablag);
                                DataRow1[9] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 2).Sum(s => s.Mablag) != 0 ? q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 2).Sum(s => s.Mablag) / q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 2).Sum(s => s.Meghdar) : 0;

                                DataRow1[11] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 3).Sum(s => s.Meghdar);
                                DataRow1[13] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 3).Sum(s => s.Mablag);
                                DataRow1[12] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 3).Sum(s => s.Mablag) != 0 ? q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 3).Sum(s => s.Mablag) / q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 3).Sum(s => s.Meghdar) : 0;

                                //DataRow1[14] = Convert.ToDecimal(DataRow1[5].ToString()) + Convert.ToDecimal(DataRow1[8].ToString()) - Convert.ToDecimal(DataRow1[11].ToString());
                                //DataRow1[16] = Convert.ToDecimal(DataRow1[7].ToString()) + Convert.ToDecimal(DataRow1[10].ToString()) - Convert.ToDecimal(DataRow1[13].ToString());
                                //DataRow1[15] = Convert.ToDecimal(DataRow1[16].ToString()) != 0 ? Convert.ToDecimal(DataRow1[16].ToString()) / Convert.ToDecimal(DataRow1[14].ToString()) : 0;
                                //dt.Rows.Add(DataRow1);

                            }
                            else
                            {
                                var CheckedList = cmbAnbarName.Properties.GetItems().GetCheckedValues();
                                if (CheckedList.Count > 0)
                                {
                                    foreach (var item in CheckedList)
                                    {
                                        //CheckedItems += item.ToString() + ",";
                                        int _AnbarId = Convert.ToInt32(item);
                                        if (q3.Any(s => s.AzAnbarId == _AnbarId && s.KalaId == q1[RowCounter]))
                                        {
                                            DataRow1[0] = q1[RowCounter];
                                            DataRow1[1] = dt.Rows.Count + 1;
                                            DataRow1[2] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).KeyCode;
                                            DataRow1[3] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).LevelName;
                                            DataRow1[4] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).EpNameKala1.VahedKala1Name;

                                            //decimal a = Convert.ToDecimal(DataRow1[5].ToString());
                                            DataRow1[5] = Convert.ToDecimal(DataRow1[5].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 1 && s.AzAnbarId == _AnbarId).Sum(s => s.Meghdar);
                                            DataRow1[7] = Convert.ToDecimal(DataRow1[7].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 1 && s.AzAnbarId == _AnbarId).Sum(s => s.Mablag);
                                            DataRow1[6] = Convert.ToDecimal(DataRow1[7].ToString()) != 0 ? Convert.ToDecimal(DataRow1[7].ToString()) / Convert.ToDecimal(DataRow1[5].ToString()) : 0;

                                            DataRow1[8] = Convert.ToDecimal(DataRow1[8].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 2 && s.AzAnbarId == _AnbarId).Sum(s => s.Meghdar);
                                            DataRow1[10] = Convert.ToDecimal(DataRow1[10].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 2 && s.AzAnbarId == _AnbarId).Sum(s => s.Mablag);
                                            DataRow1[9] = Convert.ToDecimal(DataRow1[10].ToString()) != 0 ? Convert.ToDecimal(DataRow1[10].ToString()) / Convert.ToDecimal(DataRow1[8].ToString()) : 0;

                                            DataRow1[11] = Convert.ToDecimal(DataRow1[11].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 3 && s.AzAnbarId == _AnbarId).Sum(s => s.Meghdar);
                                            DataRow1[13] = Convert.ToDecimal(DataRow1[13].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NoeAmaliatCode == 3 && s.AzAnbarId == _AnbarId).Sum(s => s.Mablag);
                                            DataRow1[12] = Convert.ToDecimal(DataRow1[13].ToString()) != 0 ? Convert.ToDecimal(DataRow1[13].ToString()) / Convert.ToDecimal(DataRow1[11].ToString()) : 0;


                                        }
                                    }

                                }
                            }
                            DataRow1[14] = Convert.ToDecimal(DataRow1[5].ToString()) + Convert.ToDecimal(DataRow1[8].ToString()) - Convert.ToDecimal(DataRow1[11].ToString());
                            DataRow1[16] = Convert.ToDecimal(DataRow1[7].ToString()) + Convert.ToDecimal(DataRow1[10].ToString()) - Convert.ToDecimal(DataRow1[13].ToString());
                            DataRow1[15] = Convert.ToDecimal(DataRow1[16].ToString()) != 0 ? Convert.ToDecimal(DataRow1[16].ToString()) / Convert.ToDecimal(DataRow1[14].ToString()) : 0;

                            if (Convert.ToDecimal(DataRow1[0].ToString()) != 0)
                                dt.Rows.Add(DataRow1);

                        }
                        //ds.Tables.Add(dt);

                        if (dt.Rows.Count > 0)
                        {

                            gridControl_MeghdariVRiali.DataSource = dt;
                            gridControl_Meghdari.DataSource = dt;
                            gridControl_Riali.DataSource = dt;
                        }
                        else
                        {
                            gridControl_MeghdariVRiali.DataSource = null;
                            gridControl_Meghdari.DataSource = null;
                            gridControl_Riali.DataSource = null;
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

        private void FrmMojodiAnbarVKala_Load(object sender, EventArgs e)
        {
            FillcmbAnbarName();
            FillbandedGridView();
        }

        private void btnReloadNameAnbar_Click(object sender, EventArgs e)
        {
            FillcmbAnbarName();
            cmbAnbarName.SetEditValue(0);
        }

        private void cmbAnbarName_EditValueChanged(object sender, EventArgs e)
        {
            FillbandedGridView();
        }

        private void xtcMojodiAnbarVKala_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtcMojodiAnbarVKala.SelectedTabPageIndex == 0)
            {
                bandedGridView_MeghdariVRiali.Columns[5].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[6].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[7].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[8].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[9].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[10].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[11].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[12].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[13].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[14].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[15].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[16].Visible = true;
            }
            else if (xtcMojodiAnbarVKala.SelectedTabPageIndex == 1)
            {
                bandedGridView_Meghdari.Columns[5].Visible = true;
                bandedGridView_Meghdari.Columns[6].Visible = false;
                bandedGridView_Meghdari.Columns[7].Visible = false;
                bandedGridView_Meghdari.Columns[8].Visible = true;
                bandedGridView_Meghdari.Columns[9].Visible = false;
                bandedGridView_Meghdari.Columns[10].Visible = false;
                bandedGridView_Meghdari.Columns[11].Visible = true;
                bandedGridView_Meghdari.Columns[12].Visible = false;
                bandedGridView_Meghdari.Columns[13].Visible = false;
                bandedGridView_Meghdari.Columns[14].Visible = true;
                bandedGridView_Meghdari.Columns[15].Visible = false;
                bandedGridView_Meghdari.Columns[16].Visible = false;
            }
            else if (xtcMojodiAnbarVKala.SelectedTabPageIndex == 2)
            {
                bandedGridView_Riali.Columns[5].Visible = false;
                bandedGridView_Riali.Columns[6].Visible = false;
                bandedGridView_Riali.Columns[7].Visible = true;
                bandedGridView_Riali.Columns[8].Visible = false;
                bandedGridView_Riali.Columns[9].Visible = false;
                bandedGridView_Riali.Columns[10].Visible = true;
                bandedGridView_Riali.Columns[11].Visible = false;
                bandedGridView_Riali.Columns[12].Visible = false;
                bandedGridView_Riali.Columns[13].Visible = true;
                bandedGridView_Riali.Columns[14].Visible = false;
                bandedGridView_Riali.Columns[15].Visible = false;
                bandedGridView_Riali.Columns[16].Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAnbarName_DrawListBoxItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (e.Index == 0)
                return;
            int ItemId = Convert.ToInt32(e.Item);
            using (var db = new MyContext())
            {
                try
                {
                    var _Isactive = db.EpListAnbarhas.FirstOrDefault(s => s.SalId == _SalId && s.Id == ItemId).IsActive;
                    if (_Isactive == false)
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Black;


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
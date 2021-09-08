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
using DBHesabdari_PG.Models.EP.CodingAnbar;
using HelpClassLibrary;

namespace AnbarVaKala.Reports
{
    public partial class FrmMojodiAnbarVKala : DevExpress.XtraEditors.XtraForm
    {
        public FrmMojodiAnbarVKala()
        {
            InitializeComponent();
        }

        int _SalId = 0;
        List<EpListAnbarha> _ListAnbarha;
        public void FillcmbAnbarName()
        {
            using (var db = new MyContext())
            {
                try
                {
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    _ListAnbarha = db.EpListAnbarhas.Where(s => s.SalId == _SalId).ToList();
                    epListAnbarhasBindingSource.DataSource = _ListAnbarha;
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
                    #region MyRegion
                    //_SalId = Convert.ToInt32(lblSalId.Text);
                    ////DataSet ds = new DataSet();
                    //DataTable dt = new DataTable();
                    //for (int ColumnCounter = 0; ColumnCounter < bandedGridView_MeghdariVRiali.Columns.Count; ColumnCounter++)
                    //    dt.Columns.Add(bandedGridView_MeghdariVRiali.Columns[ColumnCounter].FieldName);
                    //dt.Columns[0].DataType = typeof(decimal);
                    ////dt.Columns[1].DataType = typeof(decimal);
                    ////dt.Columns[2].DataType = typeof(decimal);
                    //dt.Columns[5].DataType = typeof(decimal);
                    //dt.Columns[6].DataType = typeof(decimal);
                    //dt.Columns[7].DataType = typeof(decimal);
                    //dt.Columns[8].DataType = typeof(decimal);
                    //dt.Columns[9].DataType = typeof(decimal);
                    //dt.Columns[10].DataType = typeof(decimal);
                    //dt.Columns[11].DataType = typeof(decimal);
                    //dt.Columns[12].DataType = typeof(decimal);
                    //dt.Columns[13].DataType = typeof(decimal);
                    //dt.Columns[14].DataType = typeof(decimal);
                    //dt.Columns[15].DataType = typeof(decimal);
                    //dt.Columns[16].DataType = typeof(decimal);

                    //var q2 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId && s.LevelNumber == 4).ToList();
                    //var q3 = db.AkAllAmaliateRozanehs.Where(s => s.SalId == _SalId).ToList();
                    //var q1 = q3.Select(s => s.KalaId).Distinct().ToList();
                    //if (q3.Count > 0)
                    //{
                    //    for (int RowCounter = 0; RowCounter < q1.Count; RowCounter++)
                    //    {
                    //        DataRow DataRow1 = dt.NewRow();
                    //        DataRow1.Table.Columns[0].DataType = typeof(decimal);
                    //        //DataRow1.Table.Columns[1].DataType = typeof(decimal);
                    //        //DataRow1.Table.Columns[2].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[5].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[6].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[7].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[8].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[9].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[10].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[11].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[12].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[13].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[14].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[15].DataType = typeof(decimal);
                    //        DataRow1.Table.Columns[16].DataType = typeof(decimal);

                    //        DataRow1[0] = 0;
                    //        //DataRow1[1] = 0;
                    //        //DataRow1[2] = 0;
                    //        DataRow1[5] = 0;
                    //        DataRow1[6] = 0;
                    //        DataRow1[7] = 0;
                    //        DataRow1[8] = 0;
                    //        DataRow1[9] = 0;
                    //        DataRow1[10] = 0;
                    //        DataRow1[11] = 0;
                    //        DataRow1[12] = 0;
                    //        DataRow1[13] = 0;



                    //        if (string.IsNullOrEmpty(cmbAnbarName.Text))
                    //        {
                    //            DataRow1[0] = q1[RowCounter];
                    //            DataRow1[1] = dt.Rows.Count + 1;
                    //            DataRow1[2] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).KeyCode;
                    //            DataRow1[3] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).LevelName;
                    //            DataRow1[4] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).EpNameKala1.VahedKala1Name;

                    //            DataRow1[5] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 1).Sum(s => s.Meghdar);
                    //            DataRow1[7] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 1).Sum(s => s.Mablag);
                    //            DataRow1[6] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 1).Sum(s => s.Mablag) != 0 ? q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 1).Sum(s => s.Mablag) / q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 1).Sum(s => s.Meghdar) : 0;

                    //            DataRow1[8] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2).Sum(s => s.Meghdar);
                    //            DataRow1[10] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2).Sum(s => s.Mablag);
                    //            DataRow1[9] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2).Sum(s => s.Mablag) != 0 ? q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2).Sum(s => s.Mablag) / q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2).Sum(s => s.Meghdar) : 0;

                    //            DataRow1[11] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3).Sum(s => s.Meghdar);
                    //            DataRow1[13] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3).Sum(s => s.Mablag);
                    //            DataRow1[12] = q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3).Sum(s => s.Mablag) != 0 ? q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3).Sum(s => s.Mablag) / q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3).Sum(s => s.Meghdar) : 0;

                    //            //DataRow1[14] = Convert.ToDecimal(DataRow1[5].ToString()) + Convert.ToDecimal(DataRow1[8].ToString()) - Convert.ToDecimal(DataRow1[11].ToString());
                    //            //DataRow1[16] = Convert.ToDecimal(DataRow1[7].ToString()) + Convert.ToDecimal(DataRow1[10].ToString()) - Convert.ToDecimal(DataRow1[13].ToString());
                    //            //DataRow1[15] = Convert.ToDecimal(DataRow1[16].ToString()) != 0 ? Convert.ToDecimal(DataRow1[16].ToString()) / Convert.ToDecimal(DataRow1[14].ToString()) : 0;
                    //            //dt.Rows.Add(DataRow1);

                    //        }
                    //        else
                    //        {
                    //            var CheckedList = cmbAnbarName.Properties.GetItems().GetCheckedValues();
                    //            if (CheckedList.Count > 0)
                    //            {
                    //                foreach (var item in CheckedList)
                    //                {
                    //                    //CheckedItems += item.ToString() + ",";
                    //                    int _AnbarId = Convert.ToInt32(item);
                    //                    if (q3.Any(s => s.AzAnbarId == _AnbarId && s.KalaId == q1[RowCounter]))
                    //                    {
                    //                        DataRow1[0] = q1[RowCounter];
                    //                        DataRow1[1] = dt.Rows.Count + 1;
                    //                        DataRow1[2] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).KeyCode;
                    //                        DataRow1[3] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).LevelName;
                    //                        DataRow1[4] = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).EpNameKala1.VahedKala1Name;

                    //                        //decimal a = Convert.ToDecimal(DataRow1[5].ToString());
                    //                        DataRow1[5] = Convert.ToDecimal(DataRow1[5].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 1 && s.AzAnbarId == _AnbarId).Sum(s => s.Meghdar);
                    //                        DataRow1[7] = Convert.ToDecimal(DataRow1[7].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 1 && s.AzAnbarId == _AnbarId).Sum(s => s.Mablag);
                    //                        DataRow1[6] = Convert.ToDecimal(DataRow1[7].ToString()) != 0 ? Convert.ToDecimal(DataRow1[7].ToString()) / Convert.ToDecimal(DataRow1[5].ToString()) : 0;

                    //                        DataRow1[8] = Convert.ToDecimal(DataRow1[8].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.AzAnbarId == _AnbarId).Sum(s => s.Meghdar);
                    //                        DataRow1[10] = Convert.ToDecimal(DataRow1[10].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.AzAnbarId == _AnbarId).Sum(s => s.Mablag);
                    //                        DataRow1[9] = Convert.ToDecimal(DataRow1[10].ToString()) != 0 ? Convert.ToDecimal(DataRow1[10].ToString()) / Convert.ToDecimal(DataRow1[8].ToString()) : 0;

                    //                        DataRow1[11] = Convert.ToDecimal(DataRow1[11].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId).Sum(s => s.Meghdar);
                    //                        DataRow1[13] = Convert.ToDecimal(DataRow1[13].ToString()) + q3.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId).Sum(s => s.Mablag);
                    //                        DataRow1[12] = Convert.ToDecimal(DataRow1[13].ToString()) != 0 ? Convert.ToDecimal(DataRow1[13].ToString()) / Convert.ToDecimal(DataRow1[11].ToString()) : 0;


                    //                    }
                    //                }

                    //            }
                    //        }
                    //        DataRow1[14] = Convert.ToDecimal(DataRow1[5].ToString()) + Convert.ToDecimal(DataRow1[8].ToString()) - Convert.ToDecimal(DataRow1[11].ToString());
                    //        DataRow1[16] = Convert.ToDecimal(DataRow1[7].ToString()) + Convert.ToDecimal(DataRow1[10].ToString()) - Convert.ToDecimal(DataRow1[13].ToString());
                    //        DataRow1[15] = Convert.ToDecimal(DataRow1[16].ToString()) != 0 ? Convert.ToDecimal(DataRow1[16].ToString()) / Convert.ToDecimal(DataRow1[14].ToString()) : 0;

                    //        if (Convert.ToDecimal(DataRow1[0].ToString()) != 0)
                    //            dt.Rows.Add(DataRow1);

                    //    }
                    //    //ds.Tables.Add(dt);

                    //    if (dt.Rows.Count > 0)
                    //    {

                    //        gridControl_MeghdariVRiali.DataSource = dt;
                    //        gridControl_Meghdari.DataSource = dt;
                    //        gridControl_Riali.DataSource = dt;
                    //    }
                    //    else
                    //    {
                    //        gridControl_MeghdariVRiali.DataSource = null;
                    //        gridControl_Meghdari.DataSource = null;
                    //        gridControl_Riali.DataSource = null;
                    //    }

                    //}

                    #endregion
                    _SalId = Convert.ToInt32(lblSalId.Text);
                    var StartDate = Convert.ToDateTime(txtAzTarikh.Text);
                    var EndDate = Convert.ToDateTime(txtTaTarikh.Text);
                    int yyyy1 = Convert.ToInt32(txtAzTarikh.Text.Substring(0, 4));
                    int MM1 = Convert.ToInt32(txtAzTarikh.Text.Substring(5, 2));
                    int dd1 = Convert.ToInt32(txtAzTarikh.Text.Substring(8, 2));
                    Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.DecrementDay();

                    var CheckedList = cmbAnbarName.Properties.GetItems().GetCheckedValues();
                    if (CheckedList.Count > 0)
                    {
                        List<AKAmaliatAnbarVKala_Riz> _List1 = new List<AKAmaliatAnbarVKala_Riz>();

                        foreach (var item in CheckedList)
                        {
                            int _AnbarId = Convert.ToInt32(item);
                            var qq1 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.DateTimeSanad <= EndDate).ToList();
                            var qq2 = qq1.Where(s => s.BeAnbarId == _AnbarId && s.NameAmaliatCode == 2).ToList();
                            var qq3 = qq1.Where(s => s.AzAnbarId == _AnbarId && s.NameAmaliatCode == 3).ToList();
                            //List<AKAmaliatAnbarVKala_Riz> List = new List<AKAmaliatAnbarVKala_Riz>();
                            if (qq2.Count > 0)
                                _List1.AddRange(qq2);
                            if (qq3.Count > 0)
                                _List1.AddRange(qq3);


                            //var q6 = db.AKAmaliatAnbarVKala_Rizs.Where(s => s.SalId == _SalId && s.AzAnbarId == _AnbarId && s.DateTimeSanad <= EndDate).ToList();
                            //if (q6.Count > 0)
                            //    _List1.AddRange(q6);
                        }

                        if (_List1.Count > 0)
                        {
                            _List1 = _List1.OrderBy(s => s.DateTimeSanad).ThenBy(s => s.Id).ToList();
                            var q1 = _List1.Select(s => s.KalaId).Distinct().ToList();

                            var q2 = db.EpAllCodingKalas.Where(s => s.SalId == _SalId && s.LevelNumber == 4).ToList();
                            var q5 = db.EpVahedKalas.Where(s => s.SalId == _SalId).ToList();

                            List<AKAmaliatAnbarVKala_Riz> _List2 = new List<AKAmaliatAnbarVKala_Riz>();

                            for (int RowCounter = 0; RowCounter < q1.Count; RowCounter++)
                            {
                                AKAmaliatAnbarVKala_Riz obj2 = new AKAmaliatAnbarVKala_Riz();

                                obj2.KalaId = q1[RowCounter];
                                obj2.KalaCode_NM = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).KeyCode.ToString();
                                obj2.KalaName_NM = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).LevelName;
                                int _VahedKalaId = q2.FirstOrDefault(s => s.Id == q1[RowCounter]).VahedAsliKalaId;
                                obj2.VahedeKalaName_NM = q5.FirstOrDefault(s => s.Id == _VahedKalaId).Name;

                                obj2.MeghdarMo_NM = 0;
                                obj2.NerkhMo_NM = 0;
                                obj2.MablagMo_NM = 0;
                                obj2.MeghdarVa_NM = 0;
                                obj2.NerkhVa_NM = 0;
                                obj2.MablagVa_NM = 0;
                                obj2.MeghdarSa_NM = 0;
                                obj2.NerkhSa_NM = 0;
                                obj2.MablagSa_NM = 0;
                                obj2.MeghdarMa_NM = 0;
                                obj2.NerkhMa_NM = 0;
                                obj2.MablagMa_NM = 0;

                                foreach (var item in CheckedList)
                                {
                                    int _AnbarId = Convert.ToInt32(item);
                                    if (_List1.Any(s => s.KalaId == q1[RowCounter]))
                                    {

                                        if (chkIsEdgham.Checked)
                                        {
                                            decimal _MeghdarMo = obj2.MeghdarMo_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.BeAnbarId == _AnbarId && s.DateTimeSanad < StartDate).Sum(s => s.Meghdar);
                                            decimal _MablagMo = obj2.MablagMo_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.BeAnbarId == _AnbarId && s.DateTimeSanad < StartDate).Sum(s => s.Mablag);
                                            decimal _MeghdarSa = obj2.MeghdarSa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId && s.DateTimeSanad < StartDate).Sum(s => s.Meghdar);
                                            decimal _MablagSa = obj2.MablagSa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId && s.DateTimeSanad < StartDate).Sum(s => s.Mablag);
                                            obj2.MeghdarMo_NM = _MeghdarMo - _MeghdarSa;
                                            obj2.MablagMo_NM = _MablagMo - _MablagSa;
                                            obj2.NerkhMo_NM = obj2.MeghdarMo_NM != 0 ? obj2.MablagMo_NM / obj2.MeghdarMo_NM : 0;

                                            obj2.MeghdarVa_NM = obj2.MeghdarVa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.BeAnbarId == _AnbarId && s.DateTimeSanad >= StartDate).Sum(s => s.Meghdar);
                                            obj2.MablagVa_NM = obj2.MablagVa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.BeAnbarId == _AnbarId && s.DateTimeSanad >= StartDate).Sum(s => s.Mablag);
                                            obj2.NerkhVa_NM = obj2.MeghdarVa_NM != 0 ? obj2.MablagVa_NM / obj2.MeghdarVa_NM : 0;

                                            obj2.MeghdarSa_NM = obj2.MeghdarSa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId && s.DateTimeSanad >= StartDate).Sum(s => s.Meghdar);
                                            obj2.MablagSa_NM = obj2.MablagSa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId && s.DateTimeSanad >= StartDate).Sum(s => s.Mablag);
                                            obj2.NerkhSa_NM = obj2.MeghdarSa_NM != 0 ? obj2.MablagSa_NM / obj2.MeghdarSa_NM : 0;
                                        }
                                        else
                                        {
                                            obj2.MeghdarVa_NM = obj2.MeghdarVa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.BeAnbarId == _AnbarId).Sum(s => s.Meghdar);
                                            obj2.MablagVa_NM = obj2.MablagVa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 2 && s.BeAnbarId == _AnbarId).Sum(s => s.Mablag);
                                            obj2.NerkhVa_NM = obj2.MeghdarVa_NM != 0 ? obj2.MablagVa_NM / obj2.MeghdarVa_NM : 0;

                                            obj2.MeghdarSa_NM = obj2.MeghdarSa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId).Sum(s => s.Meghdar);
                                            obj2.MablagSa_NM = obj2.MablagSa_NM + _List1.Where(s => s.KalaId == q1[RowCounter] && s.NameAmaliatCode == 3 && s.AzAnbarId == _AnbarId).Sum(s => s.Mablag);
                                            obj2.NerkhSa_NM = obj2.MeghdarSa_NM != 0 ? obj2.MablagSa_NM / obj2.MeghdarSa_NM : 0;
                                        }
                                    }
                                }
                                obj2.MeghdarMa_NM = obj2.MeghdarMo_NM + obj2.MeghdarVa_NM - obj2.MeghdarSa_NM;
                                obj2.MablagMa_NM = obj2.MablagMo_NM + obj2.MablagVa_NM - obj2.MablagSa_NM;
                                obj2.NerkhMa_NM = obj2.MeghdarMa_NM != 0 ? obj2.MablagMa_NM / obj2.MeghdarMa_NM : 0;

                                _List2.Add(obj2);
                            }

                            if (_List2.Count > 0)
                                amaliatAnbarVKala_RizsBindingSource.DataSource = _List2;
                            else
                                amaliatAnbarVKala_RizsBindingSource.Clear();
                        }
                        else
                            amaliatAnbarVKala_RizsBindingSource.Clear();
                    }
                    else
                        amaliatAnbarVKala_RizsBindingSource.Clear();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public int _EditValueId = 0;
        private void FrmMojodiAnbarVKala_Load(object sender, EventArgs e)
        {
            cmbNoeGozaresh.SelectedIndex = 0;
            chkIsEdgham.Checked = false;
            //cmbAnbarName.Properties.Items[3].CheckState = CheckState.Checked ;

            HelpClass1.DateTimeMask(txtAzTarikh);
            HelpClass1.DateTimeMask(txtTaTarikh);
            using (var db = new MyContext())
            {
                try
                {
                    int _DoreMaliId = Convert.ToInt32(lblSalId.Text);
                    var q = db.MsDoreMalis.FirstOrDefault(s => s.MsDoreMaliId == _DoreMaliId).StartDoreMali;
                    if (q != null)
                        txtAzTarikh.Text = q.ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTaTarikh.Text = DateTime.Now.ToString();
            textEdit1.Focus();

            FillcmbAnbarName();
            int a = _ListAnbarha.FirstOrDefault(s => s.SalId == _SalId).Id;
            if (_EditValueId != 0)
                cmbAnbarName.SetEditValue(_EditValueId);
            else
                cmbAnbarName.SetEditValue(a);

            FillbandedGridView();
        }

        private void btnReloadNameAnbar_Click(object sender, EventArgs e)
        {
            FillcmbAnbarName();
            cmbAnbarName.SetEditValue(0);
            amaliatAnbarVKala_RizsBindingSource.Clear();
        }

        private void cmbAnbarName_EditValueChanged(object sender, EventArgs e)
        {
            FillbandedGridView();
            txtAzTarikh.Focus();
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

        private void cmbNoeGozaresh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNoeGozaresh.SelectedIndex == 0)
            {
                bandedGridView_MeghdariVRiali.Columns[4].Visible = true;
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
            }
            else if (cmbNoeGozaresh.SelectedIndex == 1)
            {
                bandedGridView_MeghdariVRiali.Columns[4].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[5].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[6].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[7].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[8].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[9].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[10].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[11].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[12].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[13].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[14].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[15].Visible = false;
            }
            else if (cmbNoeGozaresh.SelectedIndex == 2)
            {
                bandedGridView_MeghdariVRiali.Columns[4].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[5].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[6].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[7].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[8].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[9].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[10].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[11].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[12].Visible = true;
                bandedGridView_MeghdariVRiali.Columns[13].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[14].Visible = false;
                bandedGridView_MeghdariVRiali.Columns[15].Visible = true;
            }

        }

        private void btnDisplyList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAnbarName.Text) || cmbAnbarName.EditValue == null)
                cmbAnbarName.ShowPopup();
            else
                FillbandedGridView();

        }

        private void bandedGridView_MeghdariVRiali_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void btnKardeksKala_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAnbarName.Text) || cmbAnbarName.EditValue == null)
            {
                XtraMessageBox.Show("لطفاً انبار مورد نظر را انتخاب کنید",
                                  "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbAnbarName.ShowPopup();
            }
            else
            {
                var CheckedList = cmbAnbarName.Properties.GetItems().GetCheckedValues();
                if (CheckedList.Count > 1)
                {
                    XtraMessageBox.Show("گزارش کاردکس کالا برای بیش از یک انبار مقدور نیست",
                  "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbAnbarName.ShowPopup();
                }
                else
                {
                    FrmKardeksKala fm = new FrmKardeksKala();
                    // fm.MdiParent = this;
                    fm.lblUserId.Text = lblUserId.Text;
                    fm.lblUserName.Text = lblUserName.Text;
                    fm.lblSalId.Text = lblSalId.Text;
                    fm.lblSalMali.Text = lblSalMali.Text;
                    fm.txtAzTarikh.Text = txtAzTarikh.Text;
                    fm.txtTaTarikh.Text = txtTaTarikh.Text;
                    fm._chkIsEdgham = chkIsEdgham.Checked ? true : false;
                    fm.cmbAnbarName.EditValue = Convert.ToInt32(cmbAnbarName.EditValue);
                    fm.cmbKalaName.EditValue = Convert.ToInt32(bandedGridView_MeghdariVRiali.GetFocusedRowCellValue("KalaId").ToString());
                    fm.cmbNoeGozaresh.SelectedIndex = Convert.ToInt32(cmbNoeGozaresh.SelectedIndex);
                    fm.Show();
                }
            }
        }

        private void chkIsEdgham_CheckedChanged(object sender, EventArgs e)
        {
            gridBand2.Visible = chkIsEdgham.Checked ? true : false;
            btnDisplyList_Click(null, null);
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmbAnbarName.ShowPopup();

        }
    }
}
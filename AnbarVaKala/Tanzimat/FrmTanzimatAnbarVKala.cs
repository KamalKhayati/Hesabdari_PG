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
using DevExpress.XtraTreeList;
using DBHesabdari_PG.Models.Ms.SystemUsers;
using HelpClassLibrary;

namespace AnbarVaKala.Tanzimat
{
    public partial class FrmTanzimatAnbarVKala : DevExpress.XtraEditors.XtraForm
    {
        public FrmTanzimatAnbarVKala()
        {
            InitializeComponent();
        }

        private void chkIsSetAllUser_CheckedChanged(object sender, EventArgs e)
        {

            chkIsSetAllUser.Text = chkIsSetAllUser.Checked ? "اعمال به همه کاربران" : "اعمال به کاربران خاص";
            //if (chkIsSetAllUser.Checked)
            //    cmbAllUser.EditValue = 0;
            cmbAllUser.Enabled = btnAllUser.Enabled = chkIsSetAllUser.Checked ? false : true;
        }

        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            _level = e.Node.Level;
            _KeyId = Convert.ToInt32(e.Node.GetValue(colKeyId));
            if (_level == 2)
            {
                panelControl2.Visible = true;

                using (var db = new MyContext())
                {
                    try
                    {
                        var node1 = treeList1.FindNodeByKeyID(_KeyId);
                        var q = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == _KeyId);

                        //int _NodeId = e.Node.Id;
                        //var node1 = treeList1.FindNodeByKeyID(_KeyId);
                        //object b = treeList1.GetDataRecordByNode(node1);
                        // _KeyId= Convert.ToInt32(treeList1.GetRowCellValue(node1, colKeyId));
                        //var q = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == this._KeyId);
                        if (q != null)
                        {
                            //q.IsChecked = node1.Checked;
                            //db.SaveChanges();

                            chkIsSetAllUser.Checked = q.IsSetAllUser;

                            if (!string.IsNullOrEmpty(q.UserId))
                                cmbAllUser.SetEditValue(q.UserId);
                            else
                                cmbAllUser.SetEditValue(0);

                        }

                        BeforeEditIsSetAllUser = chkIsSetAllUser.Checked;
                        BeforeEditcmbAllUser = cmbAllUser.Text;

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                panelControl2.Visible = false;
                cmbAllUser.SetEditValue(0);
            }

           // _KeyId = Convert.ToInt32(e.Node.GetValue(colKeyId));
            if (_KeyId.ToString().Length == 4)
            {
                if (treeList1.FindNodeByKeyID(_KeyId).CheckState == CheckState.Checked)
                {
                    treeList1.GetNodeList().ForEach(item =>
                    {
                        if (item[colKeyId].ToString().Length == 2)
                        {
                            if (_KeyId.ToString().Substring(0, 2) == item[colKeyId].ToString().Substring(0, 2))
                            {
                                var node1 = treeList1.FindNodeByKeyID(item[colKeyId]);
                                treeList1.SetNodeCheckState(node1, CheckState.Checked, false);
                            }
                        }
                    });
                }
            }
            else if (_KeyId.ToString().Length == 7)
            {
                if (treeList1.FindNodeByKeyID(_KeyId).CheckState == CheckState.Checked)
                {
                    treeList1.GetNodeList().ForEach(item =>
                    {
                        if (item[colKeyId].ToString().Length == 4)
                        {
                            if (_KeyId.ToString().Substring(0, 4) == item[colKeyId].ToString().Substring(0, 4))
                            {
                                var node1 = treeList1.FindNodeByKeyID(item[colKeyId]);
                                //node1.e
                                treeList1.SetNodeCheckState(node1, CheckState.Checked, false);
                            }
                        }
                        else if (item[colKeyId].ToString().Length == 2)
                        {
                            if (_KeyId.ToString().Substring(0, 2) == item[colKeyId].ToString().Substring(0, 2))
                            {
                                var node1 = treeList1.FindNodeByKeyID(item[colKeyId]);
                                treeList1.SetNodeCheckState(node1, CheckState.Checked, false);
                            }
                        }
                    });
                }
            }

        }

        private void FrmTanzimatAnbarVKala_Load(object sender, EventArgs e)
        {
            treeList1.OptionsView.CheckBoxStyle = DefaultNodeCheckBoxStyle.Check;
            treeList1.OptionsView.RootCheckBoxStyle = NodeCheckBoxStyle.None;
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.TzTanzimatSystems.ToList();
                    tzTanzimatSystemsBindingSource.DataSource = q1;
                    treeList1.ExpandAll();

                    for (int i = 0; i < q1.Count; i++)
                    {
                        var node1 = treeList1.FindNodeByKeyID(q1[i].KeyId);
                        if (node1 != null)
                        {
                            if (node1.Level == 0)
                            {
                                //TreeListNode node1 = treeList1.FindNodeByFieldValue("DEPARTMENT", "Sales and Marketing");
                                //node1.TreeList.ForeColor = Color.GreenYellow;
                                node1.ChildrenCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.None;
                            }
                            else if (node1.Level == 1)
                            {
                                node1.ChildrenCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.Check;
                            }
                            node1.Checked = q1[i].IsChecked;
                        }


                    }

                    var q2 = db.MsUsers.ToList();
                    msUsersBindingSource.DataSource = q2;

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Appearance.ForeColor = Color.Green;
            }
            else if (e.Node.Level == 1)
            {
                e.Appearance.ForeColor = Color.Red;

            }
        }

        bool BeforeEditIsCheckedNode;
        bool BeforeEditIsSetAllUser;
        string BeforeEditcmbAllUser = string.Empty;
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
        }

        int _level = 0;
        int _KeyId = 0;
        private void treeList1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            _level = e.Node.Level;
            if (_level == 2)
            {
                panelControl2.Visible = true;

                using (var db = new MyContext())
                {
                    try
                    {
                        _KeyId = Convert.ToInt32(treeList1.GetFocusedRowCellValue(colKeyId));
                        var node1 = treeList1.FindNodeByKeyID(_KeyId);
                        var q = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == _KeyId);
                        if (q != null)
                        {
                            chkIsSetAllUser.Checked = q.IsSetAllUser;

                            if (!string.IsNullOrEmpty(q.UserId))
                                cmbAllUser.SetEditValue(q.UserId);
                            else
                                cmbAllUser.SetEditValue(0);

                        }

                        BeforeEditIsSetAllUser = chkIsSetAllUser.Checked;
                        BeforeEditcmbAllUser = cmbAllUser.Text;

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                panelControl2.Visible = false;
                cmbAllUser.SetEditValue(0);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    //_KeyId = Convert.ToInt32(treeList1.GetFocusedRowCellValue(colKeyId));
                    var node1 = treeList1.FindNodeByKeyID(_KeyId);

                    if (node1.Checked != BeforeEditIsCheckedNode)
                    {
                        var q = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == _KeyId);
                        if (q != null)
                        {
                            q.IsChecked = node1.Checked;
                            db.SaveChanges();
                        }
                    }

                    if (chkIsSetAllUser.Checked != BeforeEditIsSetAllUser)
                    {
                        var q = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == _KeyId);
                        q.IsSetAllUser = chkIsSetAllUser.Checked;
                        db.SaveChanges();

                        if (chkIsSetAllUser.Checked)
                        {
                            var q1 = db.R_MsUser_B_TzTanzimatSystems.Where(s => s.TanzimatSystemId == _KeyId).ToList();
                            if (q1.Count > 0)
                            {
                                db.R_MsUser_B_TzTanzimatSystems.RemoveRange(q1);
                                //db.SaveChanges();
                                q.UserId = string.Empty;
                                db.SaveChanges();
                            }
                        }
                    }
                    if (chkIsSetAllUser.Checked == false && cmbAllUser.Text != BeforeEditcmbAllUser)
                    {
                        string CheckedItems = string.Empty;
                        var CheckedList = cmbAllUser.Properties.GetItems().GetCheckedValues();
                        List<R_MsUser_B_TzTanzimatSystem> obj03 = new List<R_MsUser_B_TzTanzimatSystem>();
                        var q4 = db.TzTanzimatSystems.FirstOrDefault(s => s.KeyId == _KeyId);

                        var q3 = db.R_MsUser_B_TzTanzimatSystems.Where(s => s.TanzimatSystemId == _KeyId).ToList();
                        if (q3.Count > 0)
                        {
                            db.R_MsUser_B_TzTanzimatSystems.RemoveRange(q3);
                            q4.UserId = string.Empty;
                            db.SaveChanges();
                        }

                        if (CheckedList.Count > 0)
                        {
                            foreach (var item in CheckedList)
                            {
                                CheckedItems += item.ToString() + ",";

                                R_MsUser_B_TzTanzimatSystem obj1 = new R_MsUser_B_TzTanzimatSystem();
                                //obj1.SalId = _SalId;
                                //obj1.AnbarhId = _AnbarId;
                                obj1.MsUserId = Convert.ToInt32(item);
                                obj1.TanzimatSystemId = _KeyId;

                                obj03.Add(obj1);

                            }
                            //db.R_MsUser_B_TzTanzimatSystems.AddRange(obj03);
                            //db.SaveChanges();

                            if (q4 != null)
                            {
                                q4.UserId = CheckedItems;
                                q4.R_MsUser_B_TzTanzimatSystems = obj03;
                            }
                            db.SaveChanges();
                        }
                    }

                    var q5 = db.TzTanzimatSystems.ToList();
                    tzTanzimatSystemsBindingSource.DataSource = q5;

                    for (int i = 0; i < q5.Count; i++)
                    {
                        var node2 = treeList1.FindNodeByKeyID(q5[i].KeyId);
                        if (node2 != null)
                        {
                            if (node2.Level == 0)
                            {
                                //TreeListNode node1 = treeList1.FindNodeByFieldValue("DEPARTMENT", "Sales and Marketing");
                                //node1.TreeList.ForeColor = Color.GreenYellow;
                                node2.ChildrenCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.None;
                            }
                            else if (node2.Level == 1)
                            {
                                node2.ChildrenCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.Check;
                            }
                            // node1.Checked = q1[i].IsChecked;
                        }


                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.ToString(),
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void treeList1_BeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            BeforeEditIsCheckedNode = e.Node.Checked;
        }

        private void treeList1_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList view = sender as TreeList;
            //view.IndicatorWidth = 60;
            // Handle this event to paint RowIndicator manually
            //GridView view = sender as GridView;
            if (e.Info.IsRowIndicator && e.Node.Id > -1)
            {
                e.Info.DisplayText = (e.Node.Id + 1).ToString();
            }

        }
    }
}

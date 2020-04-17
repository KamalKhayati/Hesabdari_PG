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
using EtelaatePaye.CodingHesabdari;

namespace Hesabdari_PG.Forms.AP.Hesabdari
{
    public partial class FrmHesabTafsiliLevelsSelected : DevExpress.XtraEditors.XtraForm
    {
        FrmMain Fm;
        public FrmHesabTafsiliLevelsSelected(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            FrmHesabhaTafsili fm = new FrmHesabhaTafsili();
            fm.MdiParent = Fm;
            fm.lblUserId.Text = Fm.txtUserId.Caption;
            fm.lblUserName.Text = Fm. txtUserName.Caption;
            fm.lblSalId.Text = Fm. _SalId;
            fm.lblSalMali.Text = Fm._SalMali;
            fm._levelNamber = 1;
            Fm.ActiveForm(fm);
            this.Close();

        }

    }
}
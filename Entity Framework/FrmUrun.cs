using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Framework
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Tbl_Urun.ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.URUNAD = txad.Text;
            t.MARKA = txmarka.Text;
            t.STOK = short.Parse(txstok.Text);
            t.KATEGORI = int.Parse(txkategori.Text);
            t.FIYAT = decimal.Parse(txfiyat.Text);
            t.DURUM = true; 
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txid.Text);
            var urun = db.Tbl_Urun.Find(x);
            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Urun
                              select new 
                              {
                                  ID = x.URUNID,
                                  AD = x.URUNAD
                              }
                              ).ToList();

            txkategori.ValueMember = "ID";
            txkategori.DisplayMember = "AD";
            txkategori.DataSource = kategoriler;
        }
    }
}

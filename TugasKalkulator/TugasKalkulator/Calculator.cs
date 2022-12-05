using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasKalkulator
{
    public partial class Calculator : Form
    {
        public delegate void CreateUpdateEventHandler(Data data);
        public event CreateUpdateEventHandler OnCreate;
        public event CreateUpdateEventHandler OnUpdate;
        private bool isNewData = true;
        private Data data;
        public string select;

        public Calculator()
        {
            InitializeComponent();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (isNewData) data = new Data();

            if (txtNilaiA.Text == "")
            {
                MessageBox.Show("Silahkan Isi Nilai A!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNilaiA.Focus();
            }
            else if (txtNilaiB.Text == "")
            {
                MessageBox.Show("Silahkan Isi Nilai B!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNilaiA.Focus();
            }
            else if (cbxOperasi.Text == "")
            {
                MessageBox.Show("Silahkan Pilih Operasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxOperasi.Focus();
            }
            else
            {
                if (select == "Penjumlahan")
                {
                    data.Hasil = "Hasil Penjumlahan Dari " + txtNilaiA.Text + " + " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) + int.Parse(txtNilaiB.Text));
                }
                else if (select == "Pengurangan")
                {
                    data.Hasil = "Hasil Pengurangan Dari " + txtNilaiA.Text + " - " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) - int.Parse(txtNilaiB.Text));
                }
                else if (select == "Perkalian")
                {
                    data.Hasil = "Hasil Perkalian Dari " + txtNilaiA.Text + " x " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) * int.Parse(txtNilaiB.Text));
                }
                else if (select == "Pembagian")
                {
                    data.Hasil = "Hasil Pembagian Dari " + txtNilaiA.Text + " : " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) / int.Parse(txtNilaiB.Text));
                }
                if (isNewData) // data baru
                {
                    OnCreate(data);
                }
                else // update
                {
                    OnUpdate(data); // panggil event OnUpdate
                    this.Close();
                }
            }
        }
        private void cbxOperasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            select = cbxOperasi.SelectedItem.ToString();
        }
    }
}

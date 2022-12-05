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
    public partial class HasilPerhitungan : Form
    {
        private IList<Data> dataCalc = new List<Data>();

        public HasilPerhitungan()
        {
            InitializeComponent();
        }
        private void btnHitung_Click(object sender, EventArgs e)
        {
            Calculator kalkulator = new Calculator();
            kalkulator.OnCreate += KalKulator_OnCreate;
            kalkulator.ShowDialog();
        }

        private void KalKulator_OnCreate(Data data)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            dataCalc.Add(data);
            listHasil.Items.Add(data.Hasil);
        }

    }
}

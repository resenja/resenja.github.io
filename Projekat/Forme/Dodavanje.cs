using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Baza;
using Sesija;

namespace Forme
{
    public partial class Dodavanje : Form
    {
        public Dodavanje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string atribut1 = textBox2.Text;
            if (id != "" && atribut1 != "")
            {
                Objekat objekat = new Objekat
                {
                    id = int.Parse(id),
                    atribut1 = atribut1
                };
                try
                {
                    Broker.DajSesiju().UbaciUBazu(objekat);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}

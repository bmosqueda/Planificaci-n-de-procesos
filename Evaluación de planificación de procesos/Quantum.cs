using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluación_de_planificación_de_procesos
{
    public partial class Quantum : Form
    {
        public Quantum()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            (this.Owner as Form1).Quantum = (int)nudQuantum.Value;
        }
    }
}

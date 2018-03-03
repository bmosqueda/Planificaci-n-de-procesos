using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Evaluación_de_planificación_de_procesos
{
    public partial class Form1 : Form
    {
        private List<Proceso> tiempoProcesos;
        private bool[] panelActivo;
        private int numProcesos;
        private int timeMax;

        /// <summary>Clase que genera labels especiales para las tablas</summary>
        public class LabelTabla : Label
        {
            public LabelTabla(int num)
            {
                this.Size = new Size(125, 50);
                this.BorderStyle = BorderStyle.Fixed3D;
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.Text = num.ToString();
            }

            //Labels para diagrmas de Gantt
            public LabelTabla(Proceso proceso, int timeProcesa)
            {
                this.Size = new Size(30 * proceso.tiempoProcesamiento, 82);
                this.Margin = new Padding(0);
                this.BorderStyle = BorderStyle.FixedSingle;
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.Text = "P" + proceso.numeroProceso;

                ToolTip message = new ToolTip();
                message.SetToolTip(this, "Tiempo total procesamiento = " + proceso.tiempoProcesamiento);

                this.Controls.Add(new LabelTabla(timeProcesa, 30 * proceso.tiempoProcesamiento));
            }

            //Label de subíndice dentro de los Labels de procesos del diagrama de Gantt
            private LabelTabla(int tiempo, int width)
            {
                this.Font = new Font("Microsoft Office Preview Font", 9);
                this.Text = tiempo.ToString();
                this.TextAlign = ContentAlignment.BottomRight;
                this.Size = new Size(width, 15);
            }
        }

        public class Proceso
        {
            public int numeroProceso { get; set; }
            public int tiempoProcesamiento { get; set; }

            public Proceso( int numProceso, int tiempo )
            {
                numeroProceso = numProceso;
                tiempoProcesamiento = tiempo;
            }
        }

        public Form1()
        {
            tiempoProcesos = new List<Proceso>();
            panelActivo = new bool[4];
            numProcesos = 0;
            timeMax = 0;

            //FirstComeFirstServed
            panelActivo[0] = false;
            //ShortestJobFirst
            panelActivo[1] = false;
            //LargestJobFirst
            panelActivo[2] = false;
            //RoundRobin
            panelActivo[3] = false;

            InitializeComponent();
        }

        //Llena la tabla para FCFS
        private void btnGenerarProcesos_Click(object sender, EventArgs e)
        {
            //Si se presiona el botón con los mismos valores que ya se calcularon no se debe de hacer nada
            if(numProcesos != (int)udNumProcesos.Value || timeMax != (int)udNumTimeMax.Value )
            {
                flpTabla.SelectedIndex = 0;
                numProcesos = (int)udNumProcesos.Value;
                timeMax = (int)udNumTimeMax.Value;

                //Se limpian todas las tablas cada vez que se generan nuevos valores 
                flPanelTablaFCFS.Controls.Clear();
                flpTablaSJF.Controls.Clear();
                flpTablaLJF.Controls.Clear();
                flpTablaRR.Controls.Clear();

                Random aleatorio = new Random();
                lblProcesos.Text = "|   ";
                tiempoProcesos.Clear();

                for (int i = 0; i < numProcesos; i++)
                {
                    int num = aleatorio.Next(1, timeMax);
                    Proceso proceso = new Proceso(i + 1, num);
                    tiempoProcesos.Add(proceso);
                    lblProcesos.Text += "P" + (i + 1) + " = " + num + "   |   ";

                    LabelTabla labelProceso = new LabelTabla(i + 1);
                    flPanelTablaFCFS.Controls.Add(labelProceso);

                    LabelTabla labelTiempo = new LabelTabla(num);
                    flPanelTablaFCFS.Controls.Add(labelTiempo);

                    if (i % 2 == 0)
                    {
                        labelProceso.BackColor = Color.FromArgb(96, 192, 205);
                        labelTiempo.BackColor = Color.FromArgb(96, 192, 205);
                    }
                }
                flPanelGanttFCFS.Controls.Clear();
                flPanelGanttSJF.Controls.Clear();
                flPanelGanttLJF.Controls.Clear();
                flPanelGanttRR.Controls.Clear();

                calcularPromediosFCFS(0);

                panelActivo[0] = true;
               
                //ShortestJobFirst
                panelActivo[1] = false;
                //LargestJobFirst
                panelActivo[2] = false;
                //RoundRobin
                panelActivo[3] = false;
            }
        }

        //Llenas las tablas SJF, LJF, RR
        public void llenarTabla(ref FlowLayoutPanel contenedorTabla, List<Proceso> procesos)
        {
            for (int i = 0; i < numProcesos; i++)
            {
                LabelTabla labelProceso = new LabelTabla(procesos[i].numeroProceso);
                contenedorTabla.Controls.Add(labelProceso);

                LabelTabla labelTiempo = new LabelTabla(procesos[i].tiempoProcesamiento);
                contenedorTabla.Controls.Add(labelTiempo);

                if (i % 2 == 0)
                {
                    labelProceso.BackColor = Color.FromArgb(96, 192, 205);
                    labelTiempo.BackColor = Color.FromArgb(96, 192, 205);
                }
            }
        }

        public void ordenarProceosMenorAMayor()
        {
            for( int i = 0; i < numProcesos - 1; i++ )
            {
                for( int j = 0; j < numProcesos - i - 1; j++ )
                {
                    if(tiempoProcesos[j].tiempoProcesamiento > tiempoProcesos[j + 1].tiempoProcesamiento)
                    {
                        Proceso temp = tiempoProcesos[j];
                        tiempoProcesos[j] = tiempoProcesos[j + 1];
                        tiempoProcesos[j + 1] = temp;
                    }
                }
            }
        }

        public void ordenarProceosMayorAMenor()
        {
            for (int i = 0; i < numProcesos - 1; i++)
            {
                for (int j = 0; j < numProcesos - i - 1; j++)
                {
                    if (tiempoProcesos[j].tiempoProcesamiento < tiempoProcesos[j + 1].tiempoProcesamiento)
                    {
                        Proceso temp = tiempoProcesos[j];
                        tiempoProcesos[j] = tiempoProcesos[j + 1];
                        tiempoProcesos[j + 1] = temp;
                    }
                }
            }
        }

        public void ordenarPorNumeroDeProceso()
        {
            for (int i = 0; i < numProcesos - 1; i++)
            {
                for (int j = 0; j < numProcesos - i - 1; j++)
                {
                    if (tiempoProcesos[j].numeroProceso > tiempoProcesos[j + 1].numeroProceso)
                    {
                        Proceso temp = tiempoProcesos[j];
                        tiempoProcesos[j] = tiempoProcesos[j + 1];
                        tiempoProcesos[j + 1] = temp;
                    }
                }
            }
        }

        //Cálculo de Cmax, tiempo promedo de espera y tiempo promedio de respuesta de todos los algoritmos y hacer diagramas de Gantt
        //FCFS, SJF o LJF dependiendo del numero enviado
        private void calcularPromediosFCFS(int panel)   //0 = FCFS      1 = SJF       2 = LJF 
        {
            int cmax = 0;
            int totalEspera = 0;
            int siguiente = 0;

            int totalRespuesta = 0;

            for (int i = 0; i < numProcesos; i++)
            {
                //De esta forma se deja fuera la suma del último elemento porque el primero no espera nada
                totalEspera += siguiente;
                siguiente += tiempoProcesos[i].tiempoProcesamiento;

                cmax += tiempoProcesos[i].tiempoProcesamiento;

                totalRespuesta += siguiente;
                Console.WriteLine(totalRespuesta);

                if(panel == 0)
                {
                    flPanelGanttFCFS.Controls.Add(new LabelTabla(tiempoProcesos[i], cmax));
                }
                else if(panel == 1)
                {
                    flPanelGanttSJF.Controls.Add(new LabelTabla(tiempoProcesos[i], cmax));
                }
                else
                {
                    flPanelGanttLJF.Controls.Add(new LabelTabla(tiempoProcesos[i], cmax));
                }
            }

            if (panel == 0)
            {
                //Para hacer que se active el scroll horizontal en lugar de que crezca el panel a lo alto
                flPanelGanttFCFS.WrapContents = false;
                lblCmax.Text = "Cmax: " + cmax;
                lblPromEspera.Text = "Promedio espera: " + ((double)totalEspera / numProcesos);
                lblPromRespuesta.Text = "Promedio respuesta: " + ((double)totalRespuesta / numProcesos);
            }
            else if (panel == 1)
            {
                //Para hacer que se active el scroll horizontal en lugar de que crezca el panel a lo alto
                flPanelGanttSJF.WrapContents = false;
                lblCmaxSJF.Text = "Cmax: " + cmax;
                lblEsperaSJF.Text = "Promedio espera: " + ((double)totalEspera / numProcesos);
                lblRespuestaSJF.Text = "Promedio respuesta: " + ((double)totalRespuesta / numProcesos);
            }
            else
            {
                //Para hacer que se active el scroll horizontal en lugar de que crezca el panel a lo alto
                flPanelGanttLJF.WrapContents = false;
                lblCmaxLJF.Text = "Cmax: " + cmax;
                lblEsperaLJF.Text = "Promedio espera: " + ((double)totalEspera / numProcesos);
                lblRespuestaLJF.Text = "Promedio respuesta: " + ((double)totalRespuesta / numProcesos);
            }
        }

        private void flpTablaLJF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flpTabla.SelectedIndex == 1)
            {
                if( !panelActivo[1] )
                {
                    ordenarProceosMenorAMayor();
                    llenarTabla(ref flpTablaSJF, tiempoProcesos);
                    calcularPromediosFCFS(1);
                    panelActivo[1] = true;
                }
            }
            else if (flpTabla.SelectedIndex == 2)
            {
                if (!panelActivo[2])
                {
                    ordenarProceosMayorAMenor();
                    llenarTabla(ref flpTablaLJF, tiempoProcesos);
                    calcularPromediosFCFS(2);
                    panelActivo[2] = true;
                }
            }
            else if (flpTabla.SelectedIndex == 3)
            {
                if (!panelActivo[3])
                {
                    ordenarPorNumeroDeProceso();
                    llenarTabla(ref flpTablaRR, tiempoProcesos);
                    panelActivo[3] = true;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Evaluación_de_planificación_de_procesos
{
    public partial class Form1 : Form
    {
        private static Color[] colores = new Color[24]
        {
            Color.FromArgb(72, 201, 176),
            Color.FromArgb(187, 143, 206),
            Color.FromArgb(229, 152, 102),
            Color.FromArgb(93, 173, 226),
            Color.FromArgb(244, 208, 63),
            Color.FromArgb(236, 112, 99),
            Color.FromArgb(166, 172, 175),
            Color.FromArgb(255, 160, 122),
            Color.FromArgb(255, 0, 0),
            Color.FromArgb(255,255,0),
            Color.FromArgb(255,255,255),
            Color.FromArgb(0,255,0),
            Color.FromArgb(0,255,255),
            Color.FromArgb(255,0,255),
            Color.FromArgb(114, 112, 202),
            Color.FromArgb(234, 136, 48),
            Color.FromArgb(234, 66, 48),
            Color.FromArgb(30, 145, 133),
            Color.FromArgb(91, 211, 72),
            Color.FromArgb(194, 40, 116),
            Color.FromArgb(255, 235, 87),
            Color.FromArgb(56, 175, 203),
            Color.FromArgb(32, 126, 144),
            Color.FromArgb(223, 46, 70)
        };
        private List<Proceso> tiempoProcesos;
        private bool[] panelActivo;
        private int numProcesos;

        //Sólo para Round Robin
        public int Quantum;
        //Se usa para determinar el número de iteraciones al calcular lo de Round Robin
        private int timeMax;

        /// <summary>Clase que genera labels especiales para las tablas</summary>
        public class LabelsEspeciales : Label
        {
            /// <summary>Crea una instancia de una etiqueta con el formato para la tabla</summary>
            /// <param name="num">Número de proceso para que quede de la forma P1,...,Pn</param>
            public LabelsEspeciales(int numProceso)
            {
                this.Size = new Size(125, 50);
                this.BorderStyle = BorderStyle.Fixed3D;
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.Text = numProceso.ToString();
            }

            /// <summary>Crea una instancia para hacer una etiqueta con el formato del diagrama de Gantt en FCFS, SJF y LJF</summary>
            /// <param name="proceso"></param>
            /// <param name="timeProcesa"></param>
            /// <param name="color"></param>
            public LabelsEspeciales(Proceso proceso, int timeProcesa, int color)
            {
                this.BackColor = colores[color];
                this.Size = new Size(40 * proceso.tiempoProcesamiento, 82);
                this.Margin = new Padding(0);
                this.BorderStyle = BorderStyle.FixedSingle;
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.Text = "P" + proceso.numeroProceso;
                this.Margin = new Padding(0,10,0,0);

                ToolTip message = new ToolTip();
                message.SetToolTip(this, "Tiempo procesamiento = " + proceso.tiempoProcesamiento);

                this.Controls.Add(new LabelsEspeciales(timeProcesa, 40 * proceso.tiempoProcesamiento));
            }

            /// <summary>Crea una instancia para el diagrama de Gantt de Round Robin</summary>
            /// <param name="numProceso">Número de proceso para mostrar en la etiqueta P1..Pn</param>
            /// <param name="tiempoProcesamiento">Para calcular el tamaño de la etiqueta, normalmente es un Qunantum</param>
            /// <param name="indice">Valor de la etiqueta mostrada en la parte superior</param>
            public LabelsEspeciales(int numProceso, int tiempoProcesamiento, int indice, int color)
            {
                this.BackColor = colores[color];
                this.Size = new Size(40 * tiempoProcesamiento, 82);
                this.Margin = new Padding(0);
                this.BorderStyle = BorderStyle.FixedSingle;
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.Text = "P" + numProceso;
                this.Margin = new Padding(0, 10, 0, 0);

                ToolTip message = new ToolTip();
                message.SetToolTip(this, "Tiempo procesamiento = " + tiempoProcesamiento);

                this.Controls.Add(new LabelsEspeciales(indice, 40 * tiempoProcesamiento));
            }

            /// <summary>Crea una instancia de subíndice dentro de los Labels de procesos del diagrama de Gantt</summary>
            /// <param name="tiempo"></param>
            /// <param name="width">El mismo que la etiqueta "padre"</param>
            private LabelsEspeciales(int tiempo, int width)
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
            this.Quantum = 1;

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
                //Se limpia la lista que guarda todos los procesos anteriores
                tiempoProcesos.Clear();

                for (int i = 0; i < numProcesos; i++)
                {
                    int num = aleatorio.Next(1, timeMax);
                    Proceso proceso = new Proceso(i + 1, num);
                    tiempoProcesos.Add(proceso);
                    lblProcesos.Text += "P" + (i + 1) + " = " + num + "   |   ";

                    LabelsEspeciales labelProceso = new LabelsEspeciales(i + 1);
                    flPanelTablaFCFS.Controls.Add(labelProceso);

                    LabelsEspeciales labelTiempo = new LabelsEspeciales(num);
                    flPanelTablaFCFS.Controls.Add(labelTiempo);

                    if (i % 2 == 0)
                    {
                        labelProceso.BackColor = Color.FromArgb(96, 192, 205);
                        labelTiempo.BackColor = Color.FromArgb(96, 192, 205);
                    }
                }
                //Se limpian todos los paneles de diagramas de Gantt
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
                LabelsEspeciales labelProceso = new LabelsEspeciales(procesos[i].numeroProceso);
                contenedorTabla.Controls.Add(labelProceso);

                LabelsEspeciales labelTiempo = new LabelsEspeciales(procesos[i].tiempoProcesamiento);
                contenedorTabla.Controls.Add(labelTiempo);

                if (i % 2 == 0)
                {
                    labelProceso.BackColor = Color.FromArgb(96, 192, 205);
                    labelTiempo.BackColor = Color.FromArgb(96, 192, 205);
                }
            }
        }

        //Para Short Job First
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

        //Para Largest Job First
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

        //Para Round Robin
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
                    flPanelGanttFCFS.Controls.Add(new LabelsEspeciales(tiempoProcesos[i], cmax, i));
                }
                else if(panel == 1)
                {
                    flPanelGanttSJF.Controls.Add(new LabelsEspeciales(tiempoProcesos[i], cmax, i));
                }
                else
                {
                    flPanelGanttLJF.Controls.Add(new LabelsEspeciales(tiempoProcesos[i], cmax, i));
                }
            }

            if (panel == 0)
            {
                //Para hacer que se active el scroll horizontal en lugar de que crezca el panel a lo alto
                flPanelGanttFCFS.WrapContents = false;
                lblCmax.Text = "Cmax: " + cmax;
                lblPromEspera.Text = "Promedio espera: " + Math.Round(((double)totalEspera / numProcesos),4);
                lblPromRespuesta.Text = "Promedio respuesta: " + Math.Round(((double)totalRespuesta / numProcesos),4);
            }
            else if (panel == 1)
            {
                //Para hacer que se active el scroll horizontal en lugar de que crezca el panel a lo alto
                flPanelGanttSJF.WrapContents = false;
                lblCmaxSJF.Text = "Cmax: " + cmax;
                lblEsperaSJF.Text = "Promedio espera: " + Math.Round(((double)totalEspera / numProcesos),4);
                lblRespuestaSJF.Text = "Promedio respuesta: " + Math.Round(((double)totalRespuesta / numProcesos),4);
            }
            else
            {
                //Para hacer que se active el scroll horizontal en lugar de que crezca el panel a lo alto
                flPanelGanttLJF.WrapContents = false;
                lblCmaxLJF.Text = "Cmax: " + cmax;
                lblEsperaLJF.Text = "Promedio espera: " + Math.Round(((double)totalEspera / numProcesos),4);
                lblRespuestaLJF.Text = "Promedio respuesta: " + Math.Round(((double)totalRespuesta / numProcesos),4);
            }
        }

        private void calcularPromediosRR()
        {
            //Para recuperar los valores al final
            Proceso[] listRoundRobin = new Proceso[numProcesos];
            respaldarLista(ref listRoundRobin);
            Console.WriteLine(tiempoProcesos[0].tiempoProcesamiento);

            //matriz de sumas de espera y respuesta, indice 0 en las filas es para espera, 1 para respuesta y el 2 para el valor anteterior con el que se calculará la espera
            int[,] esperaRespuesta = new int[3, numProcesos];

            int iteraciones = 0;
            getNumeroDeVueltas(ref iteraciones);

            int totalEspera = 0;
            int totalRespuesta = 0;
            int cmax = 0;
            int indices = numProcesos;

            for( int i = 0; i < iteraciones; i++ )
            {
                for( int j = 0; j < numProcesos; j++ )
                {
                    if (listRoundRobin[j].tiempoProcesamiento > this.Quantum)
                    {
                        //Cada que entre 
                        esperaRespuesta[0, j] += cmax - esperaRespuesta[2, j];
                        cmax += this.Quantum;
                        esperaRespuesta[2, j] = cmax;

                        LabelsEspeciales labelRR = new LabelsEspeciales(listRoundRobin[j].numeroProceso, this.Quantum, cmax, j);
                        listRoundRobin[j].tiempoProcesamiento -= this.Quantum;
                        flPanelGanttRR.Controls.Add(labelRR);
                    }
                    else if(listRoundRobin[j].tiempoProcesamiento > 0)  //Igual o menor se deja en 0 su valor
                    {
                        esperaRespuesta[0, j] += cmax - esperaRespuesta[2, j];
                        cmax += listRoundRobin[j].tiempoProcesamiento;


                        //Llegados a este punto será la última instancia, cuando ya acabó el proceso, ya no se ejecutará otra vez
                        esperaRespuesta[1, j] = cmax;

                        LabelsEspeciales labelRR = new LabelsEspeciales(listRoundRobin[j].numeroProceso, listRoundRobin[j].tiempoProcesamiento, cmax, j);
                        listRoundRobin[j].tiempoProcesamiento = 0;
                        flPanelGanttRR.Controls.Add(labelRR);
                    }
                }
            }
            Console.WriteLine(tiempoProcesos[0].tiempoProcesamiento);
            flPanelGanttRR.WrapContents = false;

            calcularTotalEsperaRespuesta(ref totalEspera, ref totalRespuesta, esperaRespuesta);
            
            lblCmaxRR.Text = "Cmax: " + cmax;
            lblEsperaRR.Text = "Promedio espera: " + Math.Round(((double)totalEspera / numProcesos), 4);
            lblRespuestaRR.Text = "Promedio respuesta: " + Math.Round(((double)totalRespuesta / numProcesos),4);
        }

        private void calcularTotalEsperaRespuesta(ref int totalEspera, ref int totalRespuesta, int[,] esperaRespuesta)
        {
            //No se toma en cuenta la tercer fila
            for(int j = 0; j < numProcesos; j++)
            {
                totalEspera += esperaRespuesta[0, j];
                totalRespuesta += esperaRespuesta[1, j];
            }
            Console.WriteLine("Suma total espera:" + totalEspera);
            Console.WriteLine("Suma total respuesta:" + totalRespuesta);
        }

        private void respaldarLista(ref Proceso[] arreglo)
        {
            for(int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = new Proceso(tiempoProcesos[i].numeroProceso, tiempoProcesos[i].tiempoProcesamiento);
            }
        }

        /// <summary>Para Round Robin, obtiene el número de iteraciones que se deben dar para calcular el RounRobin con base al Quantum</summary>
        private void getNumeroDeVueltas(ref int iteraciones)
        {
            int mayor = 0;
            foreach(Proceso proceso in tiempoProcesos)
            {
                if (proceso.tiempoProcesamiento > mayor)
                    mayor = proceso.tiempoProcesamiento;
            }

            iteraciones = mayor / this.Quantum + 1;
            Console.WriteLine("Iteraciones totales = " + iteraciones);
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
                    Quantum ventana = new Quantum();
                    if(ventana.ShowDialog(this) == DialogResult.OK)
                    {
                        lblQuantum.Text = "Quantum: " + this.Quantum;
                        ordenarPorNumeroDeProceso();
                        llenarTabla(ref flpTablaRR, tiempoProcesos);
                        calcularPromediosRR();
                        panelActivo[3] = true;
                    }
                }
            }
        }

    }
}

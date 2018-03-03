namespace Evaluación_de_planificación_de_procesos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.udNumProcesos = new System.Windows.Forms.NumericUpDown();
            this.udNumTimeMax = new System.Windows.Forms.NumericUpDown();
            this.flpTabla = new System.Windows.Forms.TabControl();
            this.pageFCFS = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flPanelTablaFCFS = new System.Windows.Forms.FlowLayoutPanel();
            this.pageSJF = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flpTablaSJF = new System.Windows.Forms.FlowLayoutPanel();
            this.pageLJF = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flpTablaLJF = new System.Windows.Forms.FlowLayoutPanel();
            this.pageRR = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.flpTablaRR = new System.Windows.Forms.FlowLayoutPanel();
            this.gpProcesos = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProcesos = new System.Windows.Forms.Label();
            this.btnGenerarProcesos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udNumProcesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udNumTimeMax)).BeginInit();
            this.flpTabla.SuspendLayout();
            this.pageFCFS.SuspendLayout();
            this.pageSJF.SuspendLayout();
            this.pageLJF.SuspendLayout();
            this.pageRR.SuspendLayout();
            this.gpProcesos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de procesos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiempo máximo de ejecución";
            // 
            // udNumProcesos
            // 
            this.udNumProcesos.Location = new System.Drawing.Point(66, 48);
            this.udNumProcesos.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.udNumProcesos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udNumProcesos.Name = "udNumProcesos";
            this.udNumProcesos.Size = new System.Drawing.Size(120, 26);
            this.udNumProcesos.TabIndex = 4;
            this.udNumProcesos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // udNumTimeMax
            // 
            this.udNumTimeMax.Location = new System.Drawing.Point(334, 48);
            this.udNumTimeMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udNumTimeMax.Name = "udNumTimeMax";
            this.udNumTimeMax.Size = new System.Drawing.Size(120, 26);
            this.udNumTimeMax.TabIndex = 5;
            this.udNumTimeMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flpTabla
            // 
            this.flpTabla.Controls.Add(this.pageFCFS);
            this.flpTabla.Controls.Add(this.pageSJF);
            this.flpTabla.Controls.Add(this.pageLJF);
            this.flpTabla.Controls.Add(this.pageRR);
            this.flpTabla.Location = new System.Drawing.Point(52, 202);
            this.flpTabla.Name = "flpTabla";
            this.flpTabla.SelectedIndex = 0;
            this.flpTabla.Size = new System.Drawing.Size(852, 426);
            this.flpTabla.TabIndex = 6;
            this.flpTabla.SelectedIndexChanged += new System.EventHandler(this.flpTablaLJF_SelectedIndexChanged);
            // 
            // pageFCFS
            // 
            this.pageFCFS.Controls.Add(this.label3);
            this.pageFCFS.Controls.Add(this.label4);
            this.pageFCFS.Controls.Add(this.flPanelTablaFCFS);
            this.pageFCFS.Location = new System.Drawing.Point(4, 29);
            this.pageFCFS.Name = "pageFCFS";
            this.pageFCFS.Padding = new System.Windows.Forms.Padding(3);
            this.pageFCFS.Size = new System.Drawing.Size(844, 393);
            this.pageFCFS.TabIndex = 0;
            this.pageFCFS.Text = "First Come, First Served";
            this.pageFCFS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 50);
            this.label3.TabIndex = 1;
            this.label3.Text = "# Proceso";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(141, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 50);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tiempo procesamineto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flPanelTablaFCFS
            // 
            this.flPanelTablaFCFS.AutoScroll = true;
            this.flPanelTablaFCFS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flPanelTablaFCFS.Location = new System.Drawing.Point(10, 68);
            this.flPanelTablaFCFS.Name = "flPanelTablaFCFS";
            this.flPanelTablaFCFS.Size = new System.Drawing.Size(281, 309);
            this.flPanelTablaFCFS.TabIndex = 0;
            // 
            // pageSJF
            // 
            this.pageSJF.Controls.Add(this.label5);
            this.pageSJF.Controls.Add(this.label6);
            this.pageSJF.Controls.Add(this.flpTablaSJF);
            this.pageSJF.Location = new System.Drawing.Point(4, 29);
            this.pageSJF.Name = "pageSJF";
            this.pageSJF.Padding = new System.Windows.Forms.Padding(3);
            this.pageSJF.Size = new System.Drawing.Size(844, 393);
            this.pageSJF.TabIndex = 1;
            this.pageSJF.Text = "Shortest Job First";
            this.pageSJF.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(10, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 50);
            this.label5.TabIndex = 4;
            this.label5.Text = "# Proceso";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(141, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 50);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tiempo procesamineto";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpTablaSJF
            // 
            this.flpTablaSJF.AutoScroll = true;
            this.flpTablaSJF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTablaSJF.Location = new System.Drawing.Point(10, 68);
            this.flpTablaSJF.Name = "flpTablaSJF";
            this.flpTablaSJF.Size = new System.Drawing.Size(281, 309);
            this.flpTablaSJF.TabIndex = 3;
            // 
            // pageLJF
            // 
            this.pageLJF.Controls.Add(this.label7);
            this.pageLJF.Controls.Add(this.label8);
            this.pageLJF.Controls.Add(this.flpTablaLJF);
            this.pageLJF.Location = new System.Drawing.Point(4, 29);
            this.pageLJF.Name = "pageLJF";
            this.pageLJF.Size = new System.Drawing.Size(844, 393);
            this.pageLJF.TabIndex = 2;
            this.pageLJF.Text = "Largest Job First";
            this.pageLJF.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(10, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 50);
            this.label7.TabIndex = 4;
            this.label7.Text = "# Proceso";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(141, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 50);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tiempo procesamineto";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpTablaLJF
            // 
            this.flpTablaLJF.AutoScroll = true;
            this.flpTablaLJF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTablaLJF.Location = new System.Drawing.Point(10, 68);
            this.flpTablaLJF.Name = "flpTablaLJF";
            this.flpTablaLJF.Size = new System.Drawing.Size(281, 309);
            this.flpTablaLJF.TabIndex = 3;
            // 
            // pageRR
            // 
            this.pageRR.Controls.Add(this.label9);
            this.pageRR.Controls.Add(this.label10);
            this.pageRR.Controls.Add(this.flpTablaRR);
            this.pageRR.Location = new System.Drawing.Point(4, 29);
            this.pageRR.Name = "pageRR";
            this.pageRR.Size = new System.Drawing.Size(844, 393);
            this.pageRR.TabIndex = 3;
            this.pageRR.Text = "Round Robin";
            this.pageRR.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(10, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 50);
            this.label9.TabIndex = 4;
            this.label9.Text = "# Proceso";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(141, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 50);
            this.label10.TabIndex = 5;
            this.label10.Text = "Tiempo procesamineto";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpTablaRR
            // 
            this.flpTablaRR.AutoScroll = true;
            this.flpTablaRR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTablaRR.Location = new System.Drawing.Point(10, 68);
            this.flpTablaRR.Name = "flpTablaRR";
            this.flpTablaRR.Size = new System.Drawing.Size(281, 309);
            this.flpTablaRR.TabIndex = 3;
            // 
            // gpProcesos
            // 
            this.gpProcesos.Controls.Add(this.panel1);
            this.gpProcesos.Location = new System.Drawing.Point(56, 96);
            this.gpProcesos.Name = "gpProcesos";
            this.gpProcesos.Size = new System.Drawing.Size(844, 100);
            this.gpProcesos.TabIndex = 7;
            this.gpProcesos.TabStop = false;
            this.gpProcesos.Text = "Tiempo de los procesos";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblProcesos);
            this.panel1.Location = new System.Drawing.Point(6, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 69);
            this.panel1.TabIndex = 0;
            // 
            // lblProcesos
            // 
            this.lblProcesos.AutoSize = true;
            this.lblProcesos.Location = new System.Drawing.Point(13, 14);
            this.lblProcesos.Name = "lblProcesos";
            this.lblProcesos.Size = new System.Drawing.Size(0, 20);
            this.lblProcesos.TabIndex = 0;
            // 
            // btnGenerarProcesos
            // 
            this.btnGenerarProcesos.Location = new System.Drawing.Point(567, 32);
            this.btnGenerarProcesos.Name = "btnGenerarProcesos";
            this.btnGenerarProcesos.Size = new System.Drawing.Size(148, 42);
            this.btnGenerarProcesos.TabIndex = 1;
            this.btnGenerarProcesos.Text = "Generar procesos";
            this.btnGenerarProcesos.UseVisualStyleBackColor = true;
            this.btnGenerarProcesos.Click += new System.EventHandler(this.btnGenerarProcesos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 640);
            this.Controls.Add(this.btnGenerarProcesos);
            this.Controls.Add(this.gpProcesos);
            this.Controls.Add(this.flpTabla);
            this.Controls.Add(this.udNumTimeMax);
            this.Controls.Add(this.udNumProcesos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.udNumProcesos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udNumTimeMax)).EndInit();
            this.flpTabla.ResumeLayout(false);
            this.pageFCFS.ResumeLayout(false);
            this.pageSJF.ResumeLayout(false);
            this.pageLJF.ResumeLayout(false);
            this.pageRR.ResumeLayout(false);
            this.gpProcesos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udNumProcesos;
        private System.Windows.Forms.NumericUpDown udNumTimeMax;
        private System.Windows.Forms.TabControl flpTabla;
        private System.Windows.Forms.TabPage pageFCFS;
        private System.Windows.Forms.TabPage pageSJF;
        private System.Windows.Forms.TabPage pageLJF;
        private System.Windows.Forms.TabPage pageRR;
        private System.Windows.Forms.GroupBox gpProcesos;
        private System.Windows.Forms.Label lblProcesos;
        private System.Windows.Forms.Button btnGenerarProcesos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flPanelTablaFCFS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flpTablaSJF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flpTablaLJF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flpTablaRR;
    }
}


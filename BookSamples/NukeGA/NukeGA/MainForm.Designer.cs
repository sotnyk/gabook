namespace NukeGA
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lFitness = new System.Windows.Forms.Label();
			this.bStartStop = new System.Windows.Forms.Button();
			this.bLoadSample = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pbSample = new System.Windows.Forms.PictureBox();
			this.pbBest = new System.Windows.Forms.PictureBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbBest)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lFitness);
			this.panel1.Controls.Add(this.bStartStop);
			this.panel1.Controls.Add(this.bLoadSample);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(217, 396);
			this.panel1.TabIndex = 1;
			// 
			// lFitness
			// 
			this.lFitness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lFitness.AutoSize = true;
			this.lFitness.Location = new System.Drawing.Point(9, 374);
			this.lFitness.Name = "lFitness";
			this.lFitness.Size = new System.Drawing.Size(43, 13);
			this.lFitness.TabIndex = 2;
			this.lFitness.Text = "Fitness:";
			// 
			// bStartStop
			// 
			this.bStartStop.Enabled = false;
			this.bStartStop.Location = new System.Drawing.Point(6, 39);
			this.bStartStop.Name = "bStartStop";
			this.bStartStop.Size = new System.Drawing.Size(146, 23);
			this.bStartStop.TabIndex = 1;
			this.bStartStop.Text = "Start";
			this.bStartStop.UseVisualStyleBackColor = true;
			this.bStartStop.Click += new System.EventHandler(this.bStartStop_Click);
			// 
			// bLoadSample
			// 
			this.bLoadSample.Location = new System.Drawing.Point(5, 9);
			this.bLoadSample.Name = "bLoadSample";
			this.bLoadSample.Size = new System.Drawing.Size(147, 23);
			this.bLoadSample.TabIndex = 0;
			this.bLoadSample.Text = "Load sample...";
			this.bLoadSample.UseVisualStyleBackColor = true;
			this.bLoadSample.Click += new System.EventHandler(this.bLoadSample_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(217, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pbSample);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pbBest);
			this.splitContainer1.Size = new System.Drawing.Size(638, 396);
			this.splitContainer1.SplitterDistance = 321;
			this.splitContainer1.TabIndex = 2;
			// 
			// pbSample
			// 
			this.pbSample.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbSample.Location = new System.Drawing.Point(0, 0);
			this.pbSample.Name = "pbSample";
			this.pbSample.Size = new System.Drawing.Size(321, 396);
			this.pbSample.TabIndex = 2;
			this.pbSample.TabStop = false;
			// 
			// pbBest
			// 
			this.pbBest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbBest.Location = new System.Drawing.Point(0, 0);
			this.pbBest.Name = "pbBest";
			this.pbBest.Size = new System.Drawing.Size(313, 396);
			this.pbBest.TabIndex = 3;
			this.pbBest.TabStop = false;
			// 
			// timer
			// 
			this.timer.Interval = 5000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Pictures|*.jpg;*.png;*.tif;*.bmp;*.gif|All files|*.*";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(855, 396);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nuke GA";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbBest)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lFitness;
		private System.Windows.Forms.Button bStartStop;
		private System.Windows.Forms.Button bLoadSample;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PictureBox pbSample;
		private System.Windows.Forms.PictureBox pbBest;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}


namespace SalesAnt
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
			this.pbResult = new System.Windows.Forms.PictureBox();
			this.bStartStop = new System.Windows.Forms.Button();
			this.bStep = new System.Windows.Forms.Button();
			this.bClear = new System.Windows.Forms.Button();
			this.nudTowns = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nudAlpha = new System.Windows.Forms.NumericUpDown();
			this.nudBeta = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lBestWayLength = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lStepCount = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.bCopyLog = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTowns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBeta)).BeginInit();
			this.SuspendLayout();
			// 
			// pbResult
			// 
			this.pbResult.Location = new System.Drawing.Point(12, 12);
			this.pbResult.Name = "pbResult";
			this.pbResult.Size = new System.Drawing.Size(512, 512);
			this.pbResult.TabIndex = 0;
			this.pbResult.TabStop = false;
			// 
			// bStartStop
			// 
			this.bStartStop.Location = new System.Drawing.Point(533, 14);
			this.bStartStop.Name = "bStartStop";
			this.bStartStop.Size = new System.Drawing.Size(125, 26);
			this.bStartStop.TabIndex = 0;
			this.bStartStop.Text = "Старт";
			this.bStartStop.UseVisualStyleBackColor = true;
			this.bStartStop.Click += new System.EventHandler(this.bStartStop_Click);
			// 
			// bStep
			// 
			this.bStep.Location = new System.Drawing.Point(533, 46);
			this.bStep.Name = "bStep";
			this.bStep.Size = new System.Drawing.Size(125, 26);
			this.bStep.TabIndex = 1;
			this.bStep.Text = "Шаг";
			this.bStep.UseVisualStyleBackColor = true;
			this.bStep.Click += new System.EventHandler(this.bStep_Click);
			// 
			// bClear
			// 
			this.bClear.Location = new System.Drawing.Point(533, 498);
			this.bClear.Name = "bClear";
			this.bClear.Size = new System.Drawing.Size(125, 26);
			this.bClear.TabIndex = 5;
			this.bClear.Text = "Очистить";
			this.bClear.UseVisualStyleBackColor = true;
			this.bClear.Click += new System.EventHandler(this.bClear_Click);
			// 
			// nudTowns
			// 
			this.nudTowns.Location = new System.Drawing.Point(533, 472);
			this.nudTowns.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTowns.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudTowns.Name = "nudTowns";
			this.nudTowns.Size = new System.Drawing.Size(120, 20);
			this.nudTowns.TabIndex = 4;
			this.nudTowns.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(530, 456);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Количество городов:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(530, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Параметр альфа:";
			// 
			// nudAlpha
			// 
			this.nudAlpha.DecimalPlaces = 3;
			this.nudAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudAlpha.Location = new System.Drawing.Point(533, 109);
			this.nudAlpha.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudAlpha.Name = "nudAlpha";
			this.nudAlpha.Size = new System.Drawing.Size(120, 20);
			this.nudAlpha.TabIndex = 2;
			this.nudAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// nudBeta
			// 
			this.nudBeta.DecimalPlaces = 3;
			this.nudBeta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudBeta.Location = new System.Drawing.Point(533, 148);
			this.nudBeta.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudBeta.Name = "nudBeta";
			this.nudBeta.Size = new System.Drawing.Size(120, 20);
			this.nudBeta.TabIndex = 3;
			this.nudBeta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(530, 132);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Параметр бета:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(530, 403);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Длина лучшего пути:";
			// 
			// lBestWayLength
			// 
			this.lBestWayLength.AutoSize = true;
			this.lBestWayLength.Location = new System.Drawing.Point(530, 426);
			this.lBestWayLength.Name = "lBestWayLength";
			this.lBestWayLength.Size = new System.Drawing.Size(37, 13);
			this.lBestWayLength.TabIndex = 4;
			this.lBestWayLength.Text = "          ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(530, 354);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Номер шага:";
			// 
			// lStepCount
			// 
			this.lStepCount.AutoSize = true;
			this.lStepCount.Location = new System.Drawing.Point(530, 377);
			this.lStepCount.Name = "lStepCount";
			this.lStepCount.Size = new System.Drawing.Size(37, 13);
			this.lStepCount.TabIndex = 4;
			this.lStepCount.Text = "          ";
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// bCopyLog
			// 
			this.bCopyLog.Location = new System.Drawing.Point(533, 184);
			this.bCopyLog.Name = "bCopyLog";
			this.bCopyLog.Size = new System.Drawing.Size(125, 23);
			this.bCopyLog.TabIndex = 6;
			this.bCopyLog.Text = "Лог в клипбоард";
			this.bCopyLog.UseVisualStyleBackColor = true;
			this.bCopyLog.Click += new System.EventHandler(this.bCopyLog_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(665, 539);
			this.Controls.Add(this.bCopyLog);
			this.Controls.Add(this.lStepCount);
			this.Controls.Add(this.lBestWayLength);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nudBeta);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nudAlpha);
			this.Controls.Add(this.nudTowns);
			this.Controls.Add(this.bClear);
			this.Controls.Add(this.bStep);
			this.Controls.Add(this.bStartStop);
			this.Controls.Add(this.pbResult);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "SalesAnt - демо решения задачи коммивояжера при помощи муравьиных алгоритмов";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTowns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBeta)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbResult;
		private System.Windows.Forms.Button bStartStop;
		private System.Windows.Forms.Button bStep;
		private System.Windows.Forms.Button bClear;
		private System.Windows.Forms.NumericUpDown nudTowns;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudAlpha;
		private System.Windows.Forms.NumericUpDown nudBeta;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lBestWayLength;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lStepCount;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button bCopyLog;
	}
}


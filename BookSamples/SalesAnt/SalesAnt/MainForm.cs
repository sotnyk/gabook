using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalesAnt
{
	public partial class MainForm : Form
	{
		AntOptimizer antOptimizer = null;

		StringBuilder log = new StringBuilder();

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			InitNewOptimizer();
		}

		private void bClear_Click(object sender, EventArgs e)
		{
			InitNewOptimizer();
		}

		private void InitNewOptimizer()
		{
			antOptimizer = new AntOptimizer((int) nudTowns.Value);
			log.Length = 0;
			log.AppendLine("Towns:\t" + nudTowns.Value);
			log.AppendLine("Alpha:\t" + nudAlpha.Value);
			log.AppendLine("Beta:\t" + nudBeta.Value);
			log.AppendLine();
			log.AppendLine("Best Way Length");
		}

		private void bStep_Click(object sender, EventArgs e)
		{
			OneStep();
		}

		private void OneStep()
		{
			antOptimizer.Step((double)nudAlpha.Value, (double)nudBeta.Value, 1);
			pbResult.Image = antOptimizer.DrawMap(512, 512);
			lBestWayLength.Text = "" + antOptimizer.BestWayLength;
			lStepCount.Text = "" + antOptimizer.StepCount;
			log.AppendLine("" + antOptimizer.BestWayLength);
		}

		private void bStartStop_Click(object sender, EventArgs e)
		{
			if (timer.Enabled)
			{
				timer.Enabled = false;
				bStartStop.Text = "Старт";
				bStep.Enabled = true;
			}
			else
			{
				bStartStop.Text = "Пауза";
				bStep.Enabled = false;
				timer.Enabled = true;

			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			OneStep();
		}

		private void bCopyLog_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(log.ToString());
			}
			// catch all exceptions when we work with clipboard
			catch { }
		}
	}
}

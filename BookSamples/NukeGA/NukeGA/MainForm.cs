using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace NukeGA
{
	public partial class MainForm : Form
	{

		Thread processingThread = null;
		bool abortFlag = false;

		public const int GenerationSize = 1000;
		public const int ExplositionsNumber = 40;
		public const bool UseElitism = true;
		public const double CrossoverProb = 0.4;
		public const double MutationProb = 0.1;
        public const double SteppingProb = 0.0;
		public int IterationCounter = 0;
		List<Individual> generation = null;
		TaskSpecification spec = null;
		Bitmap sampleBitmap = null;
		Size sampleSize;
		Individual bestIndividual = null;
		static Random rnd = new Random();
		public string filename = null;
		public string logFilename = null;


		public MainForm()
		{
			InitializeComponent();
		}

		private void bLoadSample_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				filename = openFileDialog.FileName;
				logFilename = filename + ".txt";
				MemoryStream ms = new MemoryStream(File.ReadAllBytes(filename));
				pbSample.Image = new Bitmap(ms);
				bStartStop.Enabled = true;
                generation = null;
                bStartStop.Text = "Start";
                IterationCounter = 0;
			}
		}

		private void bStartStop_Click(object sender, EventArgs e)
		{
			if (processingThread != null)
			{
				timer.Enabled = false;
				abortFlag = true;
				processingThread.Join();
				processingThread = null;
				//lFitness.Text = "Fitness: " + fitness.ToString();
				bStartStop.Text = "Continue";
				bLoadSample.Enabled = true;
			}
			else
			{
				sampleBitmap = (Bitmap)pbSample.Image.Clone();
				sampleSize = sampleBitmap.Size;
				bStartStop.Text = "Stop";
				timer.Enabled = true;
				bLoadSample.Enabled = false;
				processingThread = new Thread(new ThreadStart(Start));
				processingThread.IsBackground = true;
				CreateNewLogHeader();
                abortFlag = false;
				processingThread.Start();
			}
		}

		private void CreateNewLogHeader()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("GenerationSize=" + GenerationSize);
			sb.AppendLine("ExplositionsNumber=" + ExplositionsNumber);
			sb.AppendLine("UseElitism=" + UseElitism);
			sb.AppendLine("CrossoverProb=" + CrossoverProb);
			sb.AppendLine("MutationProb=" + MutationProb);
            sb.AppendLine("SteppingProb=" + SteppingProb);
            sb.AppendLine("Initial black points = " + BitmapUtils.CalcBlackPoints(sampleBitmap));
			sb.AppendLine();
			sb.AppendLine("Iter.\tFitness");
			File.WriteAllText(logFilename, sb.ToString());
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			Individual safeIndividual = bestIndividual;
			if (safeIndividual != null)
			{
				lFitness.Text = "Fitness=" + safeIndividual.Fitness + ", Iteration=" + IterationCounter;
				pbBest.Image = safeIndividual.GenerateBitmap(spec);
			}
			else
			{
				lFitness.Text = "Fitness not calculated";
				pbBest.Image = null;
			}
		}

		private void Start()
		{
			spec = new TaskSpecification()
			{
				Bound = new RectangleF(0, 0,
					sampleBitmap.Width, sampleBitmap.Height),
				KillingRadius = Math.Max(sampleBitmap.Width, sampleBitmap.Height) / 10,
				ExplositionsNumber = ExplositionsNumber,
				OriginalField = sampleBitmap,
			};
			if (generation == null)
			{
				generation = RandomGeneration();
				CalcFitnesses();
			}
			while (!abortFlag)
			{
				SaveBestImage();
				generation = NewGeneration(generation);
				CalcFitnesses();
				File.AppendAllText(logFilename, "" + IterationCounter + "\t" + generation[0].Fitness
					+ Environment.NewLine);
				IterationCounter++;

				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		private List<Individual> RandomGeneration()
		{
			var result = new List<Individual>(GenerationSize);
			for (int i = 0; i < GenerationSize; ++i)
				result.Add(Individual.GenerateRandom(spec));
			return result;
		}

		private void CalcFitnesses()
		{
			generation.ForEach(p => p.CalcFitness(spec));
			generation.Sort((a, b) => a.Fitness.CompareTo(b.Fitness));
			bestIndividual = generation[0];
		}

		private void SaveBestImage()
		{
            string newFile = Path.Combine(
                Path.GetDirectoryName(filename),
                Path.GetFileNameWithoutExtension(filename) + "_" +
                IterationCounter.ToString("000000") + ".png"
                );
			using (Bitmap theBest = bestIndividual.GenerateBitmap(spec))
				theBest.Save(newFile, System.Drawing.Imaging.ImageFormat.Png);
		}

		private List<Individual> NewGeneration(List<Individual> generation)
		{
			var result = new List<Individual>(GenerationSize);

			if (UseElitism)
				result.Add(generation[0].Clone());

			while (result.Count < GenerationSize)
			{
				Individual parent1 = GetTournamentResult(generation);
				Individual newIndividual = parent1.Clone();
				if (rnd.NextDouble() < CrossoverProb)
				{
					Individual parent2 = GetTournamentResult(generation);
					newIndividual.SpatialCrossoverWith(parent2, spec);
				}
				if (rnd.NextDouble() < MutationProb)
					newIndividual.Mutate(spec);
                if (rnd.NextDouble() < SteppingProb)
                    newIndividual.Stepping(spec);

				result.Add(newIndividual);
			}

			return result;
		}

		private Individual GetTournamentResult(List<Individual> generation)
		{
			int p1 = rnd.Next(GenerationSize);
			int p2 = rnd.Next(GenerationSize);
			return generation[Math.Min(p1, p2)];
		}
	}
}

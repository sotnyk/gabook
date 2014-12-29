using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGP
{
	public class GPWorld
	{
		private static char[] _possibleLetters = "abcdefghijklmnopqrstuvwxyz' ABCDEFGHIJKLMNOPQRSTUVWXYZ,;.-? \r\n".ToCharArray();
		private Random _rnd = new Random();
		private StringBuilder _sb = new StringBuilder();

		public const string SecretPattern =
@"To be, or not to be, that is the question;
Whether 'tis nobler in the mind to suffer
The Slings and Arrows of outrageous Fortune
Or to take arms against a sea of troubles,
And by opposing, end them. To die, to sleep;
No more; and by a sleep to say we end
The heart-ache and the thousand natural shocks
That flesh is heir to - 'tis a consummation
Devoutly to be wish'd. To die, to sleep;
To sleep, perchance to dream. Ay, there's the rub,
For in that sleep of death what dreams may come,
When we have shuffled off this mortal coil,
Must give us pause. There's the respect
That makes calamity of so long life,
For who would bear the whips and scorns of time,
Th'oppressor's wrong, the proud man's contumely,
The pangs of dispriz'd love, the law's delay,
The insolence of office, and the spurns
That patient merit of th'unworthy takes,
When he himself might his quietus make
With a bare bodkin? who would fardels bear,
To grunt and sweat under a weary life,
But that the dread of something after death,
The undiscovered country from whose bourn
No traveller returns, puzzles the will,
And makes us rather bear those ills we have
Than fly to others that we know not of?
Thus conscience does make cowards of us all,
And thus the native hue of resolution
Is sicklied o'er with the pale cast of thought,
And enterprises of great pitch and moment
With this regard their currents turn away,
And lose the name of action.";
		public List<Individual> Generation;
		public const int GenerationSize = 100000;
        public const double CrossoverProbability = 0.4;
        public const double MutationProbability = 0.2;

		public GPWorld()
		{
			Generation = GenerateRandomGeneration();
            SortGeneration(Generation);
		}

        private void SortGeneration(List<Individual> generation)
        {
            generation.Sort((y, x) => x.Fitness.CompareTo(y.Fitness));
        }

		private List<Individual> GenerateRandomGeneration()
		{
			List<Individual> result = new List<Individual>();
			for (int i = 0; i < GenerationSize; ++i)
			{
				int length = _rnd.Next(1, SecretPattern.Length * 2);
				_sb.Length = 0;
				for (int l = 0; l < length; ++l)
				{
                    _sb.Append(RandomPossibleChar());
				}
				result.Add(new Individual()
					{
						Genome = _sb.ToString(),
					}
				);
				result[i].Fitness = CalcFitness(result[i].Genome);
			}
			return result;
		}

        private char RandomPossibleChar()
        {
            return _possibleLetters[_rnd.Next(_possibleLetters.Length)];
        }
        
		public double CalcFitness(string genome)
		{
			double result = 0;
			int maxLength = Math.Max(SecretPattern.Length, genome.Length);
			int minLength = Math.Min(SecretPattern.Length, genome.Length);

			for (int i = 0; i < maxLength; ++i)
			{
				if (i >= minLength)
				{
					result -= 1;
				}
				else if (genome[i] != SecretPattern[i])
				{
					result -= 1;
				}
				else
				{
					result += 1;
				}
			}

			return result;
		}

        public void Next(bool useElitism)
        {
            List<Individual> newGeneration = new List<Individual>();

            if (useElitism)
                newGeneration.Add(Generation[0]);

			while (newGeneration.Count < GenerationSize)
			{
				// Tурнирный выбор предков из более приспособленной половины
				int parent1a = _rnd.Next(GenerationSize / 2);
				int parent1b = _rnd.Next(GenerationSize / 2);
				int parent2a = _rnd.Next(GenerationSize / 2);
				int parent2b = _rnd.Next(GenerationSize / 2);
				int parent1 = Math.Min(parent1a, parent1b);
				int parent2 = Math.Min(parent2a, parent2b);

				string newGenome = (_rnd.NextDouble() < CrossoverProbability) ?
					Crossover(Generation[parent1].Genome, Generation[parent2].Genome) :
					Generation[parent1].Genome;

				if (_rnd.NextDouble() < MutationProbability)
					newGenome = Mutate(newGenome);

				Individual individual = new Individual()
				{
					Genome = newGenome,
				};
				individual.Fitness = CalcFitness(individual.Genome);
				newGeneration.Add(individual);
			}

            SortGeneration(newGeneration);
            Generation = newGeneration;
        }

        private string Mutate(string genome)
        {
            // Случайная вставка
            if (_rnd.NextDouble() < 0.33)
            {
                int pos = _rnd.Next(genome.Length + 1);
                _sb.Length = 0;
                for (int i = 0; i < pos; ++i)
                    _sb.Append(genome[i]);
                _sb.Append(RandomPossibleChar());
                for (int i=pos; i<genome.Length; ++i)
                    _sb.Append(genome[i]);
                genome = _sb.ToString();
            }

            // Случайное удаление
            if (genome.Length > 0 && _rnd.NextDouble() < 0.33)
            {
                int pos = _rnd.Next(genome.Length);
                genome = genome.Remove(pos, 1);
            }

            // Случайное изменение
            if (genome.Length > 0 && _rnd.NextDouble() < 0.33)
            {
                int pos = _rnd.Next(genome.Length);
                _sb.Length = 0;
                for (int i = 0; i < genome.Length; ++i)
                    if (i != pos)
                        _sb.Append(genome[i]);
                    else
                        _sb.Append(RandomPossibleChar());

                genome = _sb.ToString();
            }

            return genome;
        }

        private string Crossover(string genome1, string genome2)
        {
            int pos = _rnd.Next(genome1.Length);

            _sb.Length = 0;
            for (int i = 0; i < genome1.Length; ++i)
                if (i > pos)
                    _sb.Append(genome1[i]);
                else
                    if (i < genome2.Length)
                        _sb.Append(genome2[i]);
                    else
                        _sb.Append(RandomPossibleChar());
            return _sb.ToString();
        }
	}
}

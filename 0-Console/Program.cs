using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace winFrac
{
	static class Program
	{
		static void Main(string[] args)
		{
			TestDesFractions();

			//DeveloppementAlgorithmeLimiteDecimalDansInt32();

			//Calcul.CalculParEnonce("2/3 + 4/5");

			//TestsRegex();
		}

		private static void TestsRegex()
		{
			// Créez un motif pour un mot commençant par la lettre "A" 
			//string motifDecimal = @"[\+\-]?\d+,\d+"; // decimal
			//string motifDecimal = @"[\+\-]?\d+\s"; // entier
			string motifDecimal = @"[\+\-]{2,}\s"; // plusieurs signes égaux
												   //string motifDecimal = @"[\+\-]?\d+/[\+\-]?\d+"; // fraction
												   //Créer une expression régulière
			Regex r = new Regex(motifDecimal);
			// chaîne de caracteres  
			string Personnes = "   -125/-56   10,53  --14.56     45/654    42, -65   -78  -57,89 -  +253,6958  ++++ -- Alb Arta ";
			// Récupérer tous les correspondants
			MatchCollection matchedPers = r.Matches(Personnes);
			// Afficher les correspondants
			for (int i = 0; i < matchedPers.Count; i++)
				Console.WriteLine(matchedPers[i].Value[0]);
			Personnes = Regex.Replace(Personnes, "\\+", "");
			Console.WriteLine(Personnes);
			Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
			//(\b\S +\b)(?=.*\1)
			var words = new HashSet<string>();
			string text = "   -125/-56   10,53  --14.56     45/654    42, -65   -78  -57,89 -  +253,6958  ++++ -- Alb Arta "; // "I like the environment. The environment is good.";
			text = Regex.Replace(text, "\\w+", m =>                 // "\\w+"
			{
				if (words.Add(m.Value.ToUpperInvariant()))
				{
					return m.Value;
				}
				else
				{
					return String.Empty;
				}
			});
			Console.WriteLine(text);
		}

		private static void DeveloppementAlgorithmeLimiteDecimalDansInt32()
		{
			decimal decimalValue = 214748.3647m; // 2147483647 int32 MaxValue
			string stringValue = decimalValue.ToString();
			Console.WriteLine(stringValue);
			int position = decimalValue.ToString().IndexOf(','); // si -1 => pas de virgule
			Console.WriteLine(position);
			if (position != -1)
			{
				string stringSansVirgule = decimalValue.ToString().Remove(position, 1);
				Console.WriteLine(stringSansVirgule);

				bool intValide = false;
				while (intValide == false)
				{
					long testValue = long.Parse(stringSansVirgule);
					Console.WriteLine(testValue);
					intValide = testValue <= int.MaxValue;
					Console.WriteLine(intValide);
					if (intValide == false)
					{
						stringSansVirgule = stringSansVirgule.Remove(stringSansVirgule.Length - 1);
						Console.WriteLine(stringSansVirgule);
					}
				}
				stringValue = stringSansVirgule.Insert(position, ",");
				Console.WriteLine(stringValue);
				decimalValue = decimal.Parse(stringValue);
				Console.WriteLine(decimalValue);
			}
		}

		private static void TestDesFractions()
		{
			Fraction fraction1 = new Fraction(0.75m);
			Fraction fraction2 = new Fraction("9/12");
			Fraction fraction3 = new Fraction(-015.50m);

			List<Fraction> listeFractions = new List<Fraction>() { fraction1, fraction2, fraction3 };

			List<Fraction> sorted = listeFractions.OrderBy(x => x.Denominateur).ToList();
			Console.WriteLine(String.Join(Environment.NewLine, sorted));
			Console.WriteLine(fraction1 != fraction2);
			decimal deci = (decimal)fraction2;
			Console.WriteLine(deci);
			Console.WriteLine("**************************");
			Console.WriteLine(fraction3);
			Fraction test = new Fraction(25, 10);
			Console.WriteLine(test);
			Console.WriteLine("Test Décimale");
			Fraction test3 = new Fraction(2147483647m); // 2147483647 int32 MaxValue
			Console.WriteLine(test3);
			Console.WriteLine(fraction2.CompareTo(fraction1));
			Console.WriteLine(fraction2.Equals(fraction1));
			Console.WriteLine(fraction2 >= fraction1);
			Console.WriteLine("**************************");
			Fraction testX = new(1.5m);
			Console.WriteLine(testX);
			Console.WriteLine("**************************");
			Console.WriteLine(fraction1 + fraction2);
			Console.WriteLine(fraction1 - fraction2);
			Console.WriteLine("**************************");
			Fraction testSiEstBonFormat;
			try
			{
				testSiEstBonFormat = new("+-3/2");
				Console.WriteLine(testSiEstBonFormat);
			}
			catch (Exception)
			{
				Console.WriteLine("Ce n'est pas le format d'un objet");
			}
			try
			{
				testSiEstBonFormat = new("3/2");
				Console.WriteLine(testSiEstBonFormat);
			}
			catch (Exception)
			{
				Console.WriteLine("Ce n'est pas le format d'un objet");
			}
			bool tryDecimal = decimal.TryParse("+321,456", out _);
			Console.WriteLine(tryDecimal);
			Console.WriteLine("**************************");
			string enonceDecimal = "1,5 + 1,25";
			Console.WriteLine(Calcul.CalculParEnonce(enonceDecimal));
		}
	}
}

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace winFrac
{
	public static class Calcul
	{
		public static string CalculParEnonce(string pEnonce)
		{
			string[] tableauSignes = { "+", "-", "*", "/", "<", ">", "<=", ">=", "==", "!=", "?" }; // CARACTERES_AUTORISES = @"[^0-9,+-*/<>=!?_ ]"
			string resultatString = String.Empty;
			string[] tableauEnonce = pEnonce.Split(' ');
			Fraction[] tableauFraction = new Fraction[tableauEnonce.Count()];
			for (int i = 0; i < tableauEnonce.Count(); i++)
			{
				if (!tableauSignes.Any(tableauEnonce[i].Equals))
				{
					if (decimal.TryParse(tableauEnonce[i], out decimal fracDecim))
					{
						tableauFraction[i] = new Fraction(fracDecim);
					}
					else
					{
						tableauFraction[i] = new Fraction(tableauEnonce[i]);
					}
				}
				Console.WriteLine(tableauFraction[i]);
			}
			Console.Write("Résultat : ");
			for (int i = 0; i < tableauEnonce.Count(); i++)
			{
				if (tableauSignes.Any(tableauEnonce[i].Equals))
				{
					switch (tableauEnonce[i])
					{
						case "+":
							resultatString = (tableauFraction[i - 1] + tableauFraction[i + 1]).ToString();
							break;
						case "-":
							resultatString = (tableauFraction[i - 1] - tableauFraction[i + 1]).ToString();
							break;
						case "*":
							resultatString = (tableauFraction[i - 1] * tableauFraction[i + 1]).ToString();
							break;
						case "/":
							resultatString = (tableauFraction[i - 1] / tableauFraction[i + 1]).ToString();
							break;
						case "<":
							resultatString = (tableauFraction[i - 1] < tableauFraction[i + 1]).ToString();
							break;
						case ">":
							resultatString = (tableauFraction[i - 1] > tableauFraction[i + 1]).ToString();
							break;
						case "<=":
							resultatString = (tableauFraction[i - 1] <= tableauFraction[i + 1]).ToString();
							break;
						case ">=":
							resultatString = (tableauFraction[i - 1] >= tableauFraction[i + 1]).ToString();
							break;
						case "==":
							resultatString = (tableauFraction[i - 1] == tableauFraction[i + 1]).ToString();
							break;
						case "!=":
							resultatString = (tableauFraction[i - 1] != tableauFraction[i + 1]).ToString();
							break;
						case "?":
							resultatString = (tableauFraction[i - 1].CompareTo(tableauFraction[i + 1])).ToString();
							break;
						default:
							Console.WriteLine("Le signe n'existe pas");
							break;
					}
				}
			}
			return resultatString;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace winFrac
{
	public static class GestionFichiers
	{
		private static readonly string separateurColonnes = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
		private const string CHEMIN_FICHIER = @".\ListeDesOperationsDeCalcul.csv";

		public static bool SauverDansFichierCSV(string pEnonce, string pReponse)
		{
			try
			{
				string dateTime = DateTime.UtcNow.ToString();
				string texteSauvegarde = $"{dateTime}{separateurColonnes}=(\"{pEnonce}\"){separateurColonnes}=(\"{pReponse}\")" + Environment.NewLine;
				File.AppendAllText(CHEMIN_FICHIER, texteSauvegarde);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static List<string> LireFichierCSV()
		{
			IEnumerable<string> texteLu = File.ReadLines(CHEMIN_FICHIER);
			List<string> listRetournee = new List<string>();
			foreach (var line in texteLu)
			{
				string[] temp = line.Split(';');
				string enonce = NettoyerStringCSV(temp[1]);
				string reponse = NettoyerStringCSV(temp[2]);
				listRetournee.Add($"({temp[0]}) {enonce} = {reponse}");
			}
			return listRetournee;
		}

		private static string NettoyerStringCSV(string pString)
		{
			string stringNetoye = pString.Remove(0, 3);
			stringNetoye = stringNetoye.Remove(stringNetoye.Length - 2);
			return pString;
		}
	}
}

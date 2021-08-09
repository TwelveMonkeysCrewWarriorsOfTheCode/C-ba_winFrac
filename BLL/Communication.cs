using System.Collections.Generic;

namespace winFrac
{
	public static class Communication
	{
		public static bool EnvoyerDonneesAlaDAL(string pEnonce, string pReponse)
		{
			return GestionFichiers.SauverDansFichierCSV(pEnonce, pReponse);
		}

		public static List<string> DemanderDonneesAlaDAL()
		{
			return GestionFichiers.LireFichierCSV();
		}
	}
}

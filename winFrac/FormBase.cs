using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace winFrac
{
	public partial class FormBase : Form
	{
		private const string SEULEMENT_CARACTERES_AUTORISES = @"[^0-9,+\-\*/<>=!\?\s]"; // ajouter _
		private const string CARRACTERES_DOUBLES_INTERDITS = @"(\s{2})|(\+{2})|(-{2})|(\*{2})|(/{2})|(<{2})|(>{2})|(={3})|(!{2})|(\?{2})|(_{2})";
		private const string ESPACE_AU_DEBUT_INTERDIT = @"^\s";
		private const string LIMITER_SAISIE_A_DEUX_FRACTIONS = @"^\S+\s\S+\s\S+\s";
		private List<string> listeEnonceTests = null;
		private string formatF1;
		private string formatOp;
		private string formatF2;

		public FormBase()
		{
			InitializeComponent();
		}

		private void textBoxEnonceArithmetique_TextChanged(object sender, EventArgs e)
		{
			if (Regex.IsMatch(textBoxEnonceArithmetique.Text, ESPACE_AU_DEBUT_INTERDIT)
				|| Regex.IsMatch(textBoxEnonceArithmetique.Text, SEULEMENT_CARACTERES_AUTORISES)
				|| Regex.IsMatch(textBoxEnonceArithmetique.Text, CARRACTERES_DOUBLES_INTERDITS)
				|| Regex.IsMatch(textBoxEnonceArithmetique.Text, LIMITER_SAISIE_A_DEUX_FRACTIONS))
			{
				//MessageBox.Show("Caractères autorisés :\n" +
				//				"0-9  ,  +  -  *  /\n" +
				//				"<  >  <=  >=\n" +
				//				"==  !=  ?  _\n" +
				//				"[espace]\n" +
				//				"Voir menu \"Aide\"");
				textBoxEnonceArithmetique.Text = textBoxEnonceArithmetique.Text.Remove(textBoxEnonceArithmetique.Text.Length - 1);
				textBoxEnonceArithmetique.Select(textBoxEnonceArithmetique.Text.Length, 0);
			}
			if (Regex.IsMatch(textBoxEnonceArithmetique.Text, @"^\S+"))
			{
				listeEnonceTests = textBoxEnonceArithmetique.Text.Split(' ').ToList();
				formatF1 = TesterSiEstUneFraction(listeEnonceTests[0], "F1");
				statusLabelValideArithmetique.Text = $"{formatF1}";
				listeEnonceTests = null;
			}
			if (Regex.IsMatch(textBoxEnonceArithmetique.Text, @"^\S+\s\S+"))
			{
				listeEnonceTests = textBoxEnonceArithmetique.Text.Split(' ').ToList();
				if (Regex.IsMatch(listeEnonceTests[1], @"^\+$|^-$|^\*$|^/$|^<=?$|^>=?$|^={2}$|^!=$|^\?$")) // ajouter _
				{
					formatOp = "Opérateur valide";
				}
				else
				{
					formatOp = "Opérateur non valide";
				}
				statusLabelValideArithmetique.Text = $"{formatF1} | {formatOp}";
				listeEnonceTests = null;
			}
			if (Regex.IsMatch(textBoxEnonceArithmetique.Text, @"^\S+\s\S+\s\S+"))
			{
				listeEnonceTests = textBoxEnonceArithmetique.Text.Split(' ').ToList();
				formatF2 = TesterSiEstUneFraction(listeEnonceTests[2], "F2");
				statusLabelValideArithmetique.Text = $"{formatF1} | {formatOp} | {formatF2}";
				listeEnonceTests = null;
			}
			if (Regex.IsMatch(textBoxEnonceArithmetique.Text, @"^$"))
			{
				statusLabelValideArithmetique.Text = "Message de validité du format";
			}
		}

		private string TesterSiEstUneFraction(string pAtester, string pIndiceFraction)
		{
			if (Regex.IsMatch(pAtester, @"^[+-]?\d+(?:,\d+)?$")) // regex à vérifier pour decimal universal @"^[+-]?(?:\d+|\d{1,3}(?:,\d{3})*)(?:\.\d*)?$"
			{
				return $"{pIndiceFraction} est une fraction (decimal)";
			}
			else if (Regex.IsMatch(pAtester, @"^[+-]?\d+/[+-]?\d+$"))
			{
				return $"{pIndiceFraction} est une fraction (a/b)";
			}
			else
			{
				return $"{pIndiceFraction} n'est pas une fraction";
			}
		}

		private void textBoxEnonceArithmetique_MouseDown(object sender, MouseEventArgs e)
		{
			//textBoxEnonceArithmetique.Clear();
		}

		private void buttonCalculArithmetique_Click(object sender, EventArgs e)
		{
			try
			{
				labelReponseArithmetique.Text = Calcul.CalculParEnonce(textBoxEnonceArithmetique.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("Erreur de calcul");
			}

			// faire un try catch si ça c'est bien passé
			Communication.EnvoyerDonneesAlaDAL(textBoxEnonceArithmetique.Text, labelReponseArithmetique.Text);
		}

		private void buttonClearArithmetique_Click(object sender, EventArgs e)
		{
			textBoxEnonceArithmetique.Clear();
			textBoxEnonceArithmetique.Focus();
			labelReponseArithmetique.Text = "Réponse";
		}

		private void labelReponseArithmetique_DoubleClick(object sender, EventArgs e)
		{
			Clipboard.SetText(labelReponseArithmetique.Text);
		}

		private void labelReponseArithmetique_TextChanged(object sender, EventArgs e)
		{

		}

		private void labelReponseArithmetique_MouseHover(object sender, EventArgs e)
		{
			labelCopierArithmetique.Visible = true;
		}

		private void labelReponseArithmetique_MouseLeave(object sender, EventArgs e)
		{
			// augmenter le temps d'affichage
			labelCopierArithmetique.Visible = false;
		}

		private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (ListeOperations lstOp = new())
			{
				lstOp.ShowDialog();
			}
		}

		private void enregistrerLeRésultatObtenuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// enregistrer le fichier ailleurs et le vider
			//Outils.EnvoyerDonneesAlaDAL(textBoxEnonceArithmetique.Text, labelReponseArithmetique.Text);
		}

		private void FormBase_Load(object sender, EventArgs e)
		{
			textBoxEnonceArithmetique.Focus();
		}
	}
}

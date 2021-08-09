using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace winFrac
{
	public class Fraction : IEquatable<Fraction>, IComparable<Fraction>
	{
		#region Variables Propriétés Paramètres

		private const int BASE_DENOMINATEUR_FRAC_VIRGULE = 10;
		private const int DENOMINATEUR_D_UN_ENTIER = 1;
		private const int PAS_DE_DECIMALES = 0;
		private const char SEPARATEUR_FRAC = '/';
		private const int DENOMINATEUR_UN = 1;
		private const int UNITE_UN = 1;
		private int numerateur;
		private int denominateur;

		public int Numerateur { get => numerateur; set => numerateur = value; }
		public int Denominateur { get => denominateur; set => denominateur = value; }

		#endregion

		#region Constructeurs

		/// <summary>
		/// Fraction constructeur avec 2 paramètres
		/// Le Dénominateur ne peut pas être égal à zéro
		/// </summary>
		/// <param name="pNumerateur">Numérateur en chiffre</param>
		/// <param name="pDenominateur">Dénominateur en chiffre</param>
		public Fraction(int pNumerateur, int pDenominateur)
		{
			if (pDenominateur == 0)
			{
				throw new DivideByZeroException("Le dénominateur ne peut pas être égal à zéro");
			}
			Numerateur = pNumerateur;
			Denominateur = pDenominateur;
			SimplifierLaFraction();
		}

		/// <summary>
		/// Fraction Constructeur avec un string de chiffres contenant un séparateur "/"
		/// </summary>
		/// <param name="fractionAvecSeparateur">string "Numérateur/Dénominateur"</param>
		public Fraction(string fractionAvecSeparateur)
		{
			if (string.IsNullOrWhiteSpace(fractionAvecSeparateur))
			{
				throw new ArgumentOutOfRangeException("Fraction au Format A/B", fractionAvecSeparateur, "Le dénominateur ne peut pas être vide");
			}
			if (!fractionAvecSeparateur.Contains(SEPARATEUR_FRAC))
			{
				throw new ArgumentOutOfRangeException("Fraction au Format A/B", fractionAvecSeparateur, "Le Séparateur \"/\" n'existe pas");
			}
			string[] separation = fractionAvecSeparateur.Split(SEPARATEUR_FRAC);
			if (!int.TryParse(separation[0], out int gauche))
			{
				throw new ArgumentOutOfRangeException("Fraction au Format A/B", separation[0], "Le Numérateur n'est pas un nombre");
			}
			if (!int.TryParse(separation[1], out int droite))
			{
				throw new ArgumentOutOfRangeException("Fraction au Format A/B", separation[0], "Le Dénominateur n'est pas un nombre");
			}
			if (droite == 0)
			{
				throw new DivideByZeroException("Le dénominateur ne peut pas être égal à zéro");
			}
			Numerateur = gauche;
			Denominateur = droite;
			SimplifierLaFraction();
		}

		/// <summary>
		/// Fraction Constructeur avec un nombre de type décimal
		/// </summary>
		/// <param name="fractionVirgule">nombre de type décimal</param>
		public Fraction(decimal fractionVirgule)
		{
			decimal valeurLimitee = 0;
			try
			{
				valeurLimitee = LimiterTailleDecimalDansInt32(fractionVirgule);
			}
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine($"La valeur décimale ne peut-être supérieure à {int.MaxValue}");
			}
			int nombreDecimales = valeurLimitee.ToString(CultureInfo.InvariantCulture).Trim('0').SkipWhile(virgule => virgule != '.').Skip(1).Count();
			if (nombreDecimales == PAS_DE_DECIMALES)
			{
				Numerateur = (int)valeurLimitee;
				Denominateur = DENOMINATEUR_D_UN_ENTIER;
			}
			else
			{
				Numerateur = (int)(valeurLimitee * (decimal)Math.Pow(BASE_DENOMINATEUR_FRAC_VIRGULE, nombreDecimales));
				Denominateur = (int)Math.Pow(BASE_DENOMINATEUR_FRAC_VIRGULE, nombreDecimales);
			}
			SimplifierLaFraction();
		}

		/// <summary>
		/// Méthode d'instance respectant la règle de simplification de toute fraction
		/// </summary>
		/// <returns>L'objet Fraction simplifié</returns>
		private Fraction SimplifierLaFraction()
		{
			if (Denominateur < 0)
			{
				Numerateur = -Numerateur;
				Denominateur = -Denominateur;
			}
			int refNumerateur = Numerateur;
			int refDenominateur = Denominateur;
			int pGdivCom = CalculerPlusGrandDiviseurCommun(ref refNumerateur, ref refDenominateur);
			Numerateur /= pGdivCom;
			Denominateur /= pGdivCom;
			return this;
		}

		// Ajouter un constructeur avec entier et reste en fraction 7 5/6
		#endregion

		#region Overrides

		/// <summary>
		/// Affichage de l'objet Fraction
		/// </summary>
		/// <returns>Un string différent suivant la valeur de la fraction</returns>
		public override string ToString()
		{
			if (Denominateur == DENOMINATEUR_UN)
			{
				return Numerateur.ToString();
			}
			else if (Denominateur == Numerateur)
			{
				return UNITE_UN.ToString();
			}
			else if (Denominateur < Numerateur)
			{
				int nombre = Numerateur / Denominateur;
				int numerateurFractionReste = Numerateur % Denominateur;
				return $"{nombre} {numerateurFractionReste}/{Denominateur}";
			}
			else
			{
				return $"{Numerateur}/{Denominateur}";
			}
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Fraction);
		}

		public bool Equals(Fraction other)
		{
			return other != null &&
				   Numerateur == other.Numerateur &&
				   Denominateur == other.Denominateur;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Numerateur, Denominateur);
		}

		public int CompareTo(Fraction other)
		{
			decimal decFraction = (decimal)this;
			decimal decOther = (decimal)other;
			return decFraction.CompareTo(decOther);
		}

		#endregion

		#region Conversions

		/// <summary>
		/// (Conversion Explicit) Converti l'objet Fraction en Decimal de façon explicit car perte de données =>
		/// 3x1/3 en decimal = 0.9999999999999999999999999999 (28 chiffres après la virgule)
		/// </summary>
		/// <param name="pFraction">Objet Fraction à convertir</param>
		public static explicit operator decimal(Fraction pFraction) => (decimal)pFraction.Numerateur / pFraction.Denominateur;

		#endregion

		#region Opérateurs

		public static Fraction operator +(Fraction pGauche, Fraction pDroite)
		{
			int pPmultCom = CalculerPlusPetitMultiplicateurCommun(pGauche.Denominateur, pDroite.Denominateur);
			int resultatNumerateur = pGauche.Numerateur * (pPmultCom / pGauche.Denominateur) + pDroite.Numerateur * (pPmultCom / pDroite.Denominateur);
			int resultatDenominateur = pPmultCom;
			return new(resultatNumerateur, resultatDenominateur);
		}

		public static Fraction operator -(Fraction pGauche, Fraction pDroite)
		{
			int pPmultCom = CalculerPlusPetitMultiplicateurCommun(pGauche.Denominateur, pDroite.Denominateur);
			int resultatNumerateur = pGauche.Numerateur * (pPmultCom / pGauche.Denominateur) - pDroite.Numerateur * (pPmultCom / pDroite.Denominateur);
			int resultatDenominateur = pPmultCom;
			return new(resultatNumerateur, resultatDenominateur);
		}

		public static Fraction operator *(Fraction pGauche, Fraction pDroite)
		{
			int resultatNumerateur = pGauche.Numerateur * pDroite.Numerateur;
			int resultatDenominateur = pGauche.Denominateur * pDroite.Denominateur;
			return new(resultatNumerateur, resultatDenominateur);
		}

		public static Fraction operator /(Fraction pGauche, Fraction pDroite)
		{
			int resultatNumerateur = pGauche.Numerateur * pDroite.Denominateur;
			int resultatDenominateur = pGauche.Denominateur * pDroite.Numerateur;
			return new(resultatNumerateur, resultatDenominateur);
		}

		public static bool operator <(Fraction pGauche, Fraction pDroite) => (decimal)pGauche < (decimal)pDroite;

		public static bool operator >(Fraction pGauche, Fraction pDroite) => (decimal)pGauche > (decimal)pDroite;

		public static bool operator <=(Fraction pGauche, Fraction pDroite) => (decimal)pGauche <= (decimal)pDroite;

		public static bool operator >=(Fraction pGauche, Fraction pDroite) => (decimal)pGauche >= (decimal)pDroite;

		public static bool operator ==(Fraction pGauche, Fraction pDroite) => EqualityComparer<Fraction>.Default.Equals(pGauche, pDroite);

		public static bool operator !=(Fraction pGauche, Fraction pDroite) => !(pGauche == pDroite);

		#endregion

		#region Méthodes

		/// <summary>
		/// Plus Grand Diviseur Commun par la méthode Euclidienne
		/// </summary>
		/// <param name="pGauche">Nombre à Gauche</param>
		/// <param name="pDroite">Nombre à Droite</param>
		/// <returns>Nombre</returns>
		private static int CalculerPlusGrandDiviseurCommun(ref int pGauche, ref int pDroite)
		{
			RendrePositif(ref pGauche, ref pDroite);
			int temp;
			while (pDroite > 0)
			{
				temp = pGauche % pDroite;
				pGauche = pDroite;
				pDroite = temp;
			}
			int pGdivCom = pGauche;
			return pGdivCom;
		}

		/// <summary>
		/// Plus Petit Multiplicateur Commun par la méthode Euclidienne
		/// </summary>
		/// <param name="pGauche">Nombre à Gauche</param>
		/// <param name="pDroite">Nombre à Droite</param>
		/// <returns>Nombre</returns>
		private static int CalculerPlusPetitMultiplicateurCommun(int pGauche, int pDroite)
		{
			RendrePositif(ref pGauche, ref pDroite);
			return pGauche * pDroite / CalculerPlusGrandDiviseurCommun(ref pGauche, ref pDroite);
		}

		/// <summary>
		/// Vérifier si les nombres servant de base au calcul sont négatifs et les rendre positifs
		/// </summary>
		/// <param name="pGauche">Nombre à Gauche</param>
		/// <param name="pDroite">Nombre à Droite</param>
		private static void RendrePositif(ref int pGauche, ref int pDroite)
		{
			pGauche = Math.Abs(pGauche);
			pDroite = Math.Abs(pDroite);
		}

		/// <summary>
		/// Limiter la taille du nombre décimal afin qu'il puisse être converti en une Fraction qui est limitée en Int32
		/// </summary>
		/// <param name="pDecimalValeur">Nombre décimal</param>
		/// <exception cref="ArgumentOutOfRangeException">valeur décimale ne peut-être supérieure à int.MaxValue</exception>
		private static decimal LimiterTailleDecimalDansInt32(decimal pDecimalValeur)
		{
			string stringValue = pDecimalValeur.ToString();
			int position = stringValue.IndexOf(',');
			if (position != -1)
			{
				string stringSansVirgule = pDecimalValeur.ToString().Remove(position, 1);
				bool intValide = false;
				while (intValide == false)
				{
					long testValeur = long.Parse(stringSansVirgule);
					intValide = testValeur <= int.MaxValue;
					if (intValide == false)
					{
						stringSansVirgule = stringSansVirgule.Remove(stringSansVirgule.Length - 1);
					}
				}
				stringValue = stringSansVirgule.Insert(position, ",");
				pDecimalValeur = decimal.Parse(stringValue);
				return pDecimalValeur;
			}
			if (pDecimalValeur > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("fractionVirgule", $"La valeur décimale ne peut-être supérieure à {int.MaxValue}");
			}
			else
			{
				return pDecimalValeur;
			}
		}

		internal static string EstCeUneFractionEtQuelFormat(string pPseudoFraction)
		{
			return null;
		}
		#endregion
		
	}
}

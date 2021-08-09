using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace winFrac
{
	[TestClass]
	public class FractionsTDD
	{
		/// <summary>
		/// Vérifie le bon fonctionnement du constructeur avec 2 paramètres (int Numérateur, int Dénominateur)
		/// </summary>
		[TestMethod]
		public void TestConstructAvec2parametres()
		{
			// arrangement
			Fraction f1;

			// action
			f1 = new Fraction(2, 3);

			// affirmer
			Assert.AreEqual(2, f1.Numerateur);
			Assert.AreEqual(3, f1.Denominateur);
		}

		/// <summary>
		/// Vérifie si constructeur avec 2 paramètres dont le Dénominateur égal zéro renvoi une erreur car diviser par zéro est interdit
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(DivideByZeroException))]
		public void TestConstructAvec2parametresDontDenominateurEstZero()
		{
			// arrangement
			Fraction f1;

			// action
			f1 = new Fraction(2, 0);

			// affirmer
			// retourne une erreur
		}

		[TestMethod]
		public void TestConstructAvecSeparateur()
		{
			// arrangement
			Fraction f1;

			// action
			f1 = new Fraction("5/10");

			// affirmer
			Assert.AreEqual(1, f1.Numerateur);
			Assert.AreEqual(2, f1.Denominateur);
		}
		
		[TestMethod]
		[ExpectedException(typeof(DivideByZeroException))]
		public void TestConstructAvecSeparateurEtDenominateurEgalAzero()
		{
			// arrangement
			Fraction f1;

			// action
			f1 = new Fraction("5/0");

			// affirmer
			// erreur
		}


		//[DataRow(-17, 5, DisplayName = "Fraction(-17, 5)")]
		//[DataRow(5, 2, DisplayName = "Fraction(-17, 5)")]
	}
}

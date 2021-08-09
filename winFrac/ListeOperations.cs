using System;
using System.Windows.Forms;

namespace winFrac
{
	public partial class ListeOperations : Form
	{
		public ListeOperations()
		{
			InitializeComponent();
		}

		private void listBoxOperations_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void ListeOperations_Load(object sender, EventArgs e)
		{
			listBoxOperations.DataSource = Communication.DemanderDonneesAlaDAL();
		}
	}
}

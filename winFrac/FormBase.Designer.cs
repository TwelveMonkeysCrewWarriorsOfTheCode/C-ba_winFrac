
namespace winFrac
{
	partial class FormBase
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enregistrerLeRésultatObtenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabelValideArithmetique = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControlFractions = new System.Windows.Forms.TabControl();
			this.tabPageArithmetique = new System.Windows.Forms.TabPage();
			this.labelCopierArithmetique = new System.Windows.Forms.Label();
			this.buttonClearArithmetique = new System.Windows.Forms.Button();
			this.textBoxEnonceArithmetique = new System.Windows.Forms.TextBox();
			this.labelReponseArithmetique = new System.Windows.Forms.Label();
			this.buttonCalculArithmetique = new System.Windows.Forms.Button();
			this.tabPageComparaison = new System.Windows.Forms.TabPage();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabControlFractions.SuspendLayout();
			this.tabPageArithmetique.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.aideToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(665, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fichierToolStripMenuItem
			// 
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.enregistrerLeRésultatObtenuToolStripMenuItem});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			this.fichierToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
			this.fichierToolStripMenuItem.Text = "Fichier";
			// 
			// nouveauToolStripMenuItem
			// 
			this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
			this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
			this.nouveauToolStripMenuItem.Text = "Lire les résultats sauvegardés";
			this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
			// 
			// enregistrerLeRésultatObtenuToolStripMenuItem
			// 
			this.enregistrerLeRésultatObtenuToolStripMenuItem.Name = "enregistrerLeRésultatObtenuToolStripMenuItem";
			this.enregistrerLeRésultatObtenuToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
			this.enregistrerLeRésultatObtenuToolStripMenuItem.Text = "Enregistrer le résultat obtenu";
			this.enregistrerLeRésultatObtenuToolStripMenuItem.Click += new System.EventHandler(this.enregistrerLeRésultatObtenuToolStripMenuItem_Click);
			// 
			// aideToolStripMenuItem
			// 
			this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
			this.aideToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
			this.aideToolStripMenuItem.Text = "Aide";
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelValideArithmetique});
			this.statusStrip1.Location = new System.Drawing.Point(0, 188);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(665, 26);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLabelValideArithmetique
			// 
			this.statusLabelValideArithmetique.Name = "statusLabelValideArithmetique";
			this.statusLabelValideArithmetique.Size = new System.Drawing.Size(211, 20);
			this.statusLabelValideArithmetique.Text = "Message de validité du format";
			// 
			// tabControlFractions
			// 
			this.tabControlFractions.Controls.Add(this.tabPageArithmetique);
			this.tabControlFractions.Controls.Add(this.tabPageComparaison);
			this.tabControlFractions.Location = new System.Drawing.Point(0, 31);
			this.tabControlFractions.Name = "tabControlFractions";
			this.tabControlFractions.SelectedIndex = 0;
			this.tabControlFractions.Size = new System.Drawing.Size(667, 154);
			this.tabControlFractions.TabIndex = 2;
			// 
			// tabPageArithmetique
			// 
			this.tabPageArithmetique.Controls.Add(this.labelCopierArithmetique);
			this.tabPageArithmetique.Controls.Add(this.buttonClearArithmetique);
			this.tabPageArithmetique.Controls.Add(this.textBoxEnonceArithmetique);
			this.tabPageArithmetique.Controls.Add(this.labelReponseArithmetique);
			this.tabPageArithmetique.Controls.Add(this.buttonCalculArithmetique);
			this.tabPageArithmetique.Location = new System.Drawing.Point(4, 29);
			this.tabPageArithmetique.Name = "tabPageArithmetique";
			this.tabPageArithmetique.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageArithmetique.Size = new System.Drawing.Size(659, 121);
			this.tabPageArithmetique.TabIndex = 0;
			this.tabPageArithmetique.Text = "Opération Arithmétique";
			this.tabPageArithmetique.UseVisualStyleBackColor = true;
			// 
			// labelCopierArithmetique
			// 
			this.labelCopierArithmetique.AutoSize = true;
			this.labelCopierArithmetique.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			this.labelCopierArithmetique.ForeColor = System.Drawing.Color.Gray;
			this.labelCopierArithmetique.Location = new System.Drawing.Point(482, 35);
			this.labelCopierArithmetique.Name = "labelCopierArithmetique";
			this.labelCopierArithmetique.Size = new System.Drawing.Size(130, 15);
			this.labelCopierArithmetique.TabIndex = 6;
			this.labelCopierArithmetique.Text = "Double-clic pour Copier";
			this.labelCopierArithmetique.Visible = false;
			// 
			// buttonClearArithmetique
			// 
			this.buttonClearArithmetique.Location = new System.Drawing.Point(65, 47);
			this.buttonClearArithmetique.Name = "buttonClearArithmetique";
			this.buttonClearArithmetique.Size = new System.Drawing.Size(27, 27);
			this.buttonClearArithmetique.TabIndex = 5;
			this.buttonClearArithmetique.Text = "X";
			this.buttonClearArithmetique.UseVisualStyleBackColor = true;
			this.buttonClearArithmetique.Click += new System.EventHandler(this.buttonClearArithmetique_Click);
			// 
			// textBoxEnonceArithmetique
			// 
			this.textBoxEnonceArithmetique.Location = new System.Drawing.Point(98, 48);
			this.textBoxEnonceArithmetique.Name = "textBoxEnonceArithmetique";
			this.textBoxEnonceArithmetique.Size = new System.Drawing.Size(278, 27);
			this.textBoxEnonceArithmetique.TabIndex = 1;
			this.textBoxEnonceArithmetique.TextChanged += new System.EventHandler(this.textBoxEnonceArithmetique_TextChanged);
			this.textBoxEnonceArithmetique.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxEnonceArithmetique_MouseDown);
			// 
			// labelReponseArithmetique
			// 
			this.labelReponseArithmetique.AutoSize = true;
			this.labelReponseArithmetique.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.labelReponseArithmetique.Location = new System.Drawing.Point(482, 50);
			this.labelReponseArithmetique.Name = "labelReponseArithmetique";
			this.labelReponseArithmetique.Size = new System.Drawing.Size(66, 20);
			this.labelReponseArithmetique.TabIndex = 4;
			this.labelReponseArithmetique.Text = "Réponse";
			this.labelReponseArithmetique.TextChanged += new System.EventHandler(this.labelReponseArithmetique_TextChanged);
			this.labelReponseArithmetique.DoubleClick += new System.EventHandler(this.labelReponseArithmetique_DoubleClick);
			this.labelReponseArithmetique.MouseLeave += new System.EventHandler(this.labelReponseArithmetique_MouseLeave);
			this.labelReponseArithmetique.MouseHover += new System.EventHandler(this.labelReponseArithmetique_MouseHover);
			// 
			// buttonCalculArithmetique
			// 
			this.buttonCalculArithmetique.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonCalculArithmetique.Location = new System.Drawing.Point(382, 47);
			this.buttonCalculArithmetique.Name = "buttonCalculArithmetique";
			this.buttonCalculArithmetique.Size = new System.Drawing.Size(94, 27);
			this.buttonCalculArithmetique.TabIndex = 2;
			this.buttonCalculArithmetique.Text = "Résultat";
			this.buttonCalculArithmetique.UseVisualStyleBackColor = true;
			this.buttonCalculArithmetique.Click += new System.EventHandler(this.buttonCalculArithmetique_Click);
			// 
			// tabPageComparaison
			// 
			this.tabPageComparaison.Location = new System.Drawing.Point(4, 29);
			this.tabPageComparaison.Name = "tabPageComparaison";
			this.tabPageComparaison.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageComparaison.Size = new System.Drawing.Size(659, 121);
			this.tabPageComparaison.TabIndex = 1;
			this.tabPageComparaison.Text = "Opération de Comparaison";
			this.tabPageComparaison.UseVisualStyleBackColor = true;
			// 
			// FormBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(665, 214);
			this.Controls.Add(this.tabControlFractions);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "FormBase";
			this.Text = "winFrac - v.1.0 -";
			this.Load += new System.EventHandler(this.FormBase_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControlFractions.ResumeLayout(false);
			this.tabPageArithmetique.ResumeLayout(false);
			this.tabPageArithmetique.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelValideArithmetique;
		private System.Windows.Forms.TabControl tabControlFractions;
		private System.Windows.Forms.TabPage tabPageArithmetique;
		private System.Windows.Forms.TabPage tabPageComparaison;
		private System.Windows.Forms.TextBox textBoxEnonceArithmetique;
		public System.Windows.Forms.Label labelReponseArithmetique;
		private System.Windows.Forms.Button buttonCalculArithmetique;
		private System.Windows.Forms.Button buttonClearArithmetique;
		private System.Windows.Forms.Label labelCopierArithmetique;
		private System.Windows.Forms.ToolStripMenuItem enregistrerLeRésultatObtenuToolStripMenuItem;
	}
}


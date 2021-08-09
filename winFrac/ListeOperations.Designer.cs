
namespace winFrac
{
	partial class ListeOperations
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBoxOperations = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBoxOperations
			// 
			this.listBoxOperations.FormattingEnabled = true;
			this.listBoxOperations.ItemHeight = 20;
			this.listBoxOperations.Location = new System.Drawing.Point(12, 12);
			this.listBoxOperations.Name = "listBoxOperations";
			this.listBoxOperations.Size = new System.Drawing.Size(513, 404);
			this.listBoxOperations.TabIndex = 0;
			this.listBoxOperations.SelectedIndexChanged += new System.EventHandler(this.listBoxOperations_SelectedIndexChanged);
			// 
			// ListeOperations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 425);
			this.Controls.Add(this.listBoxOperations);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "ListeOperations";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Liste des Opérations enregistrées";
			this.Load += new System.EventHandler(this.ListeOperations_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxOperations;
	}
}
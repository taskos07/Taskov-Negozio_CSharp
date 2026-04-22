namespace Taskov_Negozio_CSharp
{
    partial class FormElenco
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxProdotti = new System.Windows.Forms.ListBox();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnCarica = new System.Windows.Forms.Button();
            this.labelTotale = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // listBoxProdotti
            this.listBoxProdotti.FormattingEnabled = true;
            this.listBoxProdotti.ItemHeight = 16;
            this.listBoxProdotti.Location = new System.Drawing.Point(10, 10);
            this.listBoxProdotti.Name = "listBoxProdotti";
            this.listBoxProdotti.Size = new System.Drawing.Size(460, 200);
            this.listBoxProdotti.TabIndex = 0;

            // btnAggiungi
            this.btnAggiungi.Location = new System.Drawing.Point(10, 220);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(140, 30);
            this.btnAggiungi.TabIndex = 1;
            this.btnAggiungi.Text = "Aggiungi Prodotto";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);

            // btnSalva
            this.btnSalva.Location = new System.Drawing.Point(160, 220);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(140, 30);
            this.btnSalva.TabIndex = 2;
            this.btnSalva.Text = "Salva CSV";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);

            // btnCarica
            this.btnCarica.Location = new System.Drawing.Point(310, 220);
            this.btnCarica.Name = "btnCarica";
            this.btnCarica.Size = new System.Drawing.Size(140, 30);
            this.btnCarica.TabIndex = 3;
            this.btnCarica.Text = "Carica CSV";
            this.btnCarica.UseVisualStyleBackColor = true;
            this.btnCarica.Click += new System.EventHandler(this.btnCarica_Click);

            // labelTotale
            this.labelTotale.AutoSize = true;
            this.labelTotale.Location = new System.Drawing.Point(10, 270);
            this.labelTotale.Name = "labelTotale";
            this.labelTotale.Size = new System.Drawing.Size(123, 16);
            this.labelTotale.TabIndex = 4;
            this.labelTotale.Text = "Valore totale: €0,00";

            // FormElenco
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.labelTotale);
            this.Controls.Add(this.btnCarica);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.listBoxProdotti);
            this.Name = "FormElenco";
            this.Text = "Gestione Magazzino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox listBoxProdotti;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCarica;
        private System.Windows.Forms.Label labelTotale;
    }
}
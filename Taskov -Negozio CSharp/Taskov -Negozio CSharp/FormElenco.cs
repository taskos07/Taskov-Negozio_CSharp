using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Taskov_Negozio_CSharp
{
    public partial class FormElenco : Form
    {
        private List<Prodotto> prodotti = new List<Prodotto>();

        public FormElenco()
        {
            InitializeComponent();
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aggiungi Prodotto");
            AggiornaListaEtotale();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Salva CSV");
        }

        private void btnCarica_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Carica CSV");
        }

        private void AggiornaListaEtotale()
        {
            listBoxProdotti.Items.Clear();

            if (CalcolaTotale(out decimal totale))
            {
                foreach (var prodotto in prodotti)
                {
                    listBoxProdotti.Items.Add($"{prodotto.Marca} - {prodotto.Modello}");
                }
                labelTotale.Text = $"Valore totale: €{totale:F2}";
            }
        }

        private bool CalcolaTotale(out decimal totale)
        {
            totale = 0;
            foreach (var prodotto in prodotti)
            {
                totale += prodotto.Prezzo * prodotto.Quantita;
            }
            return true;
        }
    }

    public class Prodotto
    {
        public string Marca { get; set; }
        public string Modello { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
    }
}
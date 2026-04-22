using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;

public partial class FormElenco : Form
{
    private List<Prodotto> prodotti = new List<Prodotto>();
    private const string CSV_PATH = "prodotti.csv";

    public FormElenco()
    {
        InitializeComponent();
        CaricaCSVAlAvvio();
    }

    private void InitializeComponent()
    {
        this.listBoxProdotti = new ListBox();
        this.btnAggiungi = new Button();
        this.btnSalvaCSV = new Button();
        this.btnCaricaCSV = new Button();
        this.lblTotale = new Label();

        // ListBox
        this.listBoxProdotti.Dock = DockStyle.Top;
        this.listBoxProdotti.Height = 200;

        // Bottone Aggiungi
        this.btnAggiungi.Text = "Aggiungi Prodotto";
        this.btnAggiungi.Click += BtnAggiungi_Click;
        this.btnAggiungi.Top = 210;

        // Bottone Salva CSV
        this.btnSalvaCSV.Text = "Salva CSV";
        this.btnSalvaCSV.Click += BtnSalvaCSV_Click;
        this.btnSalvaCSV.Top = 240;
        this.btnSalvaCSV.Left = 100;

        // Bottone Carica CSV
        this.btnCaricaCSV.Text = "Carica CSV";
        this.btnCaricaCSV.Click += BtnCaricaCSV_Click;
        this.btnCaricaCSV.Top = 240;
        this.btnCaricaCSV.Left = 200;

        // Label Totale
        this.lblTotale.Text = "Totale Magazzino: €0.00";
        this.lblTotale.Top = 270;
        this.lblTotale.AutoSize = true;

        this.Controls.Add(this.listBoxProdotti);
        this.Controls.Add(this.btnAggiungi);
        this.Controls.Add(this.btnSalvaCSV);
        this.Controls.Add(this.btnCaricaCSV);
        this.Controls.Add(this.lblTotale);

        this.Text = "Taskov Negozio - Gestione Prodotti";
        this.Size = new System.Drawing.Size(400, 350);
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private ListBox listBoxProdotti;
    private Button btnAggiungi;
    private Button btnSalvaCSV;
    private Button btnCaricaCSV;
    private Label lblTotale;

    private void BtnAggiungi_Click(object sender, EventArgs e)
    {
        FormInserimento formInserimento = new FormInserimento();
        if (formInserimento.ShowDialog() == DialogResult.OK)
        {
            prodotti.Add(formInserimento.NuovoProdotto);
            AggiornaListBox();
            AggiornaLabelTotale();
        }
    }

    private void BtnSalvaCSV_Click(object sender, EventArgs e)
    {
        SalvaCSV();
        MessageBox.Show("Prodotti salvati con successo!", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnCaricaCSV_Click(object sender, EventArgs e)
    {
        CaricaCSV();
        AggiornaListBox();
        AggiornaLabelTotale();
        MessageBox.Show("Prodotti caricati con successo!", "Caricamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void AggiornaListBox()
    {
        listBoxProdotti.Items.Clear();
        foreach (var prodotto in prodotti)
        {
            listBoxProdotti.Items.Add(prodotto);
        }
    }

    private void AggiornaLabelTotale()
    {
        decimal totale = CalcolaTotaleMagazzino(out decimal valoreTotale);
        lblTotale.Text = $"Totale Magazzino: €{valoreTotale:F2}";
    }

    private decimal CalcolaTotaleMagazzino(out decimal totale)
    {
        totale = prodotti.Sum(p => p.CalcolaValore());
        return totale;
    }

    private void SalvaCSV()
    {
        using (StreamWriter writer = new StreamWriter(CSV_PATH))
        {
            writer.WriteLine("Marca,Modello,Prezzo,Quantita");
            foreach (var prodotto in prodotti)
            {
                writer.WriteLine($"{prodotto.Marca},{prodotto.Modello},{prodotto.Prezzo:F2},{prodotto.Quantita}");
            }
        }
    }

    private void CaricaCSV()
    {
        if (!File.Exists(CSV_PATH))
            return;

        prodotti.Clear();
        using (StreamReader reader = new StreamReader(CSV_PATH))
        {
            string header = reader.ReadLine(); // Salta header
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    prodotti.Add(new Prodotto(
                        parts[0],
                        parts[1],
                        decimal.Parse(parts[2]),
                        int.Parse(parts[3])
                    ));
                }
            }
        }
    }

    private void CaricaCSVAlAvvio()
    {
        CaricaCSV();
        AggiornaListBox();
        AggiornaLabelTotale();
    }
}
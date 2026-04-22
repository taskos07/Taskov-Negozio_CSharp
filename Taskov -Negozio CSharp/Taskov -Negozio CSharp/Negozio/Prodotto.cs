public class Prodotto
{
    private string Codice { get; set; }
    private string Modello { get; set; }
    private string Marca { get; set; }
    private double PrezzoUnitario { get; set; }
    private int Quantita { get; set; }

    
    public Prodotto(string codice, string modello, string marca, double prezzoUnitario, int quantita)
    {
        Codice = codice;
        Modello = modello;
        Marca = marca;
        PrezzoUnitario = prezzoUnitario;
        Quantita = quantita;
    }
    
    public void CalcolaTotale(out double totale)
    {
        totale = PrezzoUnitario * Quantita;
    }
    
    public void ApplicaPromozione(ref double sconto)
    {
        if (PrezzoUnitario > 500)
        {
            sconto += sconto * 0.05; // Aumenta lo sconto del 5%
        }
    }
    
    public string DettagliTecnici(params string[] specifiche)
    {
        if (specifiche == null || specifiche.Length == 0)
            return "Nessuna specifica disponibile";

        return string.Join(" , ", specifiche);
    }
    
    public double CalcolaScontoProgressivo(double prezzo, int anniModello)
    {
        double prezzoScontato = prezzo;

        while (anniModello > 0)
        {
            prezzoScontato *= 0.90; // Riduce il prezzo del 10% (mantiene il 90%)
            anniModello--;
        }

        return prezzoScontato;
    }
    
    public override string ToString()
    {
        return $"Codice: {Codice}, Marca: {Marca}, Modello: {Modello}, " +
               $"Prezzo Unitario: €{PrezzoUnitario}, Quantità: {Quantita}";
    }
}
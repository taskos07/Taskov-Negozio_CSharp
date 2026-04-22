public class Ordine
{
    private int NumeroOrdine { get; set; }
    private DateTime Data { get; set; }
    public List<Prodotto> ListaProdotti { get; set; }

    public Ordine()
    {
        ListaProdotti = new List<Prodotto>();
    }

    public void CalcolaTotale(out double totale)
    {
        totale = 0;
        foreach (var prodotto in ListaProdotti)
        {
            totale += prodotto.PrezzoUnitario;
        }
    }

    public bool VerificaSoglia(in double soglia)
    {
        double totale;
        CalcolaTotale(out totale);
        return totale > soglia;
    }
}
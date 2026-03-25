public class Sala
{
    public string Nome { get; private set; }
    private List<Posto> posti;
    private int capienza;
    private int nCorridoi;
    private List<string> addetti;

    public Sala(string nome, int capienza, int nCorridoi)
    {
        this.Nome = nome;
        this.capienza = capienza;
        this.nCorridoi = nCorridoi;
        this.posti = new List<Posto>();
        this.addetti = new List<string>();
    }

    public void AggiungiPosto(Posto p) { if (posti.Count < capienza) posti.Add(p); }
    public void AggiungiAddetto(string a) => addetti.Add(a);
    
    public int PostiLiberi() 
    {
        return posti.Count(p => p.StatoAttuale == Posto.Stato.libero);
    }
    
    public int PostiOccupati() => posti.Count(p => p.StatoAttuale == Posto.Stato.occupato);
    public bool IsVuota() => posti.All(p => p.StatoAttuale == Posto.Stato.libero);

    public override string ToString()
    {
        return $"Sala: {Nome} | Capienza: {capienza} | Corridoi: {nCorridoi} | Addetti: {string.Join(", ", addetti)}";
    }
}
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

    public void AggiungiPosto(Posto p)
    {
        if (posti.Count < capienza) posti.Add(p);
    }

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

    public bool TrovaPostoLibero(List<Posto> posti, out Posto trovato)
    {
        trovato = null;
        foreach (Posto p in posti)
        {
            if (p.StatoAttuale == p.Stato.libero)
                trovato = p;
        }

        return PostiLiberi() > 0;
    }

    public bool OccupaPosto(Posto posto)
    {
        if (posto.StatoAttuale == posto.Stato.libero)
        {
            posto.StatoAttuale == posto.Stato.occupato;
            return true;

        }

        else if (posto.StatoAttuale == posto.Stato.occupato)
        {
            return false;
        }

        else
        {
            Console.WriteLine("Errore,il posto non è disponibile");
            return false;
        }
    }

    public bool isVip(in Posto p) //in passa un alias alla variabile originale (evitando la copia) ma lo dichiara a sola lettura. Il compilatore impedisce qualsiasi assegnazione al parametro all'interno del metodo, garantendo che il valore del chiamante non venga mai alterato.
    {
        return p.TipoPosto == Posto.Tipo.vip;
    }

    public void PrenotaPosto(List<Posto> posti, int numero, out string messaggio)
    {
        messaggio = "";
        Posto trovato = null;
        for (int i = 0; i < posti.Count; i++)
        {
            if (posti[i].Numero == numero)
            {
                trovato = posti[i];
                break;
            }
        }

        if (trovato == null)
        {
            messaggio = "Errore, il posto da lei cercato non è stato trovato.";
            return;
        }

        if (trovato.StatoAttuale == Posto.Stato.libero)
        {
            trovato.StatoAttuale = Posto.Stato.occupato;
            messaggio = "Hai prenotato questo posto";
        }
        else if (trovato.StatoAttuale == Posto.Stato.occupato)
        {
            trovato.StatoAttuale = Posto.Stato.occupato;
            messaggio = "Questo posto è già occupato.";
        }
        
    }

    public bool CercaPostiVipLiberi(List<Posto> posti)
    {
        List<Posto> risultato = new List<Posto>();
        for (int i = 0; i < posti.Count; i++)
        {
            if (posti[i].StatoAttuale == Posto.Stato.libero || posti[i].TipoPosto == Posto.Tipo.vip)
                risultato.Add(posti[i]);
        }

        return false;
    }

    public bool CercaAddettoPerSala(Sala sala, string nomeAddetto)
    {
        List<string> addetti = new List<string>(sala.addetti);
        
    }
    
}

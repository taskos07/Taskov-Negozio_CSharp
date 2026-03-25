class Program
{
    static void Main()
    {
        List<Sala> cinema = new List<Sala>();
        
        for (int i = 1; i <= 3; i++)
        {
            Sala s = new Sala($"Sala {i}", 25, 2);
            s.AggiungiAddetto("Addetto " + i);
            
            for (int n = 1; n <= 20; n++)
            {
                Posto.Stato statoIniziale = (i == 1 && n <= 11) ? Posto.Stato.occupato : Posto.Stato.libero;
                if (i == 3) statoIniziale = Posto.Stato.libero;

                s.AggiungiPosto(new Posto('A', n, Posto.Tipo.standard, statoIniziale));
            }
            cinema.Add(s);
        }

      
        Console.WriteLine(" STATO SALE ");
        foreach (var s in cinema)
        {
            Console.WriteLine($"{s} -> Liberi: {s.PostiLiberi()}");
        }

        
        Console.WriteLine("\n SALE CON > 10 OCCUPATI ");
        var occupate = cinema.Where(s => s.PostiOccupati() > 10);
        foreach (var s in occupate) Console.WriteLine(s.Nome);

        
        Console.WriteLine("\n SALE COMPLETAMENTE VUOTE ");
        var vuote = cinema.Where(s => s.IsVuota());
        foreach (var s in vuote) Console.WriteLine(s.Nome);
    }
}
public class Posto
{
    public enum Tipo { standard, vip }
    public enum Stato { libero, occupato, nd } 

    public char Fila { get; private set; }
    public int Numero { get; private set; }
    public Tipo TipoPosto { get; private set; }
    public Stato StatoAttuale { get; set; } 

    public Posto(char fila, int numero, Tipo tipo, Stato stato)
    {
        this.Fila = fila;
        this.Numero = numero;
        this.TipoPosto = tipo;
        this.StatoAttuale = stato;
    }

    public override string ToString()
    {
        return $"Fila {Fila}, Numero {Numero} [{TipoPosto}] - Stato: {StatoAttuale}";
    }
}
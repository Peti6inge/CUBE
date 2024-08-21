public class Joueur
{
    // Attributs
    public bool isHost { get; set; }
    public string name { get; }
    public Perso[] persos { get; set; }

    // Constructeur
    public Joueur(string name, bool isHost, Perso[] persos)
    {
        this.name = name;
        this.isHost = isHost;
        this.persos = persos;
    }
}

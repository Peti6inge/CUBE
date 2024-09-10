public class Pierre
{
    // Attributs // DONE
    public bool lumiere { get; set; }
    public bool isHost { get; set; }
    public List<Case> myCases { get; set; }

    // Constructeur // DONE
    public Pierre(bool lumiere, bool isHost)
    {
        this.lumiere = lumiere;
        this.isHost = isHost;
        myCases = new List<Case>();
        if (lumiere)
        {
            if (isHost)
            {
                myCases.Add(Jeu.host.grid[3, 3]);
                myCases.Add(Jeu.host.grid[3, 4]);
                myCases.Add(Jeu.host.grid[4, 3]);
                myCases.Add(Jeu.host.grid[4, 4]);
            }
            else
            {
                myCases.Add(Jeu.client.grid[3, 3]);
                myCases.Add(Jeu.client.grid[3, 4]);
                myCases.Add(Jeu.client.grid[4, 3]);
                myCases.Add(Jeu.client.grid[4, 4]);
            }
        }
    }

    // Méthodes public
}
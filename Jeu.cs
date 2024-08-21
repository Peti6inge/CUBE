#pragma warning disable CS8618

public class Jeu
{
    // Attributs // DONE
    public static Pierre pierrelumierehost;
    public static Pierre pierrelumiereclient;
    public static Pierre pierreombrehost;
    public static Pierre pierreombreclient;

    public static Joueur? joueurHost1 { get; set; }
    public static Joueur? joueurHost2 { get; set; }
    public static Joueur? joueurHost3 { get; set; }
    public static Joueur? joueurHost4 { get; set; }

    public static Joueur? joueurClient1 { get; set; }
    public static Joueur? joueurClient2 { get; set; }
    public static Joueur? joueurClient3 { get; set; }
    public static Joueur? joueurClient4 { get; set; }

    public static Perso roninjaHost { get; set; }
    public static Perso elfeeHost { get; set; }
    public static Perso fantomageHost { get; set; }
    public static Perso piratitanHost { get; set; }

    public static Perso roninjaClient { get; set; }
    public static Perso elfeeClient { get; set; }
    public static Perso fantomageClient { get; set; }
    public static Perso piratitanClient { get; set; }

    public static Face north { get; set; }
    public static Face south { get; set; }
    public static Face east { get; set; }
    public static Face west { get; set; }
    public static Face host { get; set; }
    public static Face client { get; set; }

    public static int nbTours { get; set; }
    public static bool pierrelumierehostobtenue { get; set; }
    public static bool pierrelumiereclientobtenue { get; set; }

    // Méthodes public

    public static void InitJeu() // TODO : Récupérer les attaques des personnages
    {
        List<string>? roninjaHostAttaques = new List<string> { "DragNDrop" };
        List<string>? elfeeHostAttaques = new List<string> { "DragNDrop" };
        List<string>? fantomageHostAttaques = new List<string> { "DragNDrop" };
        List<string>? piratitanHostAttaques = new List<string> { "DragNDrop" };
        List<string>? roninjaClientAttaques = new List<string> { "DragNDrop" };
        List<string>? elfeeClientAttaques = new List<string> { "DragNDrop" };
        List<string>? fantomageClientAttaques = new List<string> { "DragNDrop" };
        List<string>? piratitanClientAttaques = new List<string> { "DragNDrop" };

        north = new Face("North");
        south = new Face("South");
        east = new Face("East");
        west = new Face("West");
        host = new Face("Host");
        client = new Face("Client");

        roninjaHost = new Perso("Roninja", true, roninjaHostAttaques);
        elfeeHost = new Perso("Elfee", true, elfeeHostAttaques);
        fantomageHost = new Perso("Fantomage", true, fantomageHostAttaques);
        piratitanHost = new Perso("Piratitan", true, piratitanHostAttaques);
        roninjaClient = new Perso("Roninja", false, roninjaClientAttaques);
        elfeeClient = new Perso("Elfee", false, elfeeClientAttaques);
        fantomageClient = new Perso("Fantomage", false, fantomageClientAttaques);
        piratitanClient = new Perso("Piratitan", false, piratitanClientAttaques);

        pierrelumierehost = new Pierre(true, true);
        pierrelumiereclient = new Pierre(true, false);
        pierreombrehost = new Pierre(false, true);
        pierreombreclient = new Pierre(false, false);

        nbTours = 0;
        
        pierrelumiereclientobtenue = false;
        pierrelumierehostobtenue = false;
    }

    public static void LancerPartie() // TODO
    {
        List<Perso> hosts = new List<Perso>
        {
            roninjaHost,
            elfeeHost,
            fantomageHost,
            piratitanHost
        };
        List<Perso> clients = new List<Perso>
        {
            roninjaClient,
            elfeeClient,
            fantomageClient,
            piratitanClient
        };

        Random rng = new Random();
        Shuffle(hosts, rng);
        Shuffle(clients, rng);

        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i < hosts.Count)
                {
                    // hosts[i].play();
                }

                if (i < clients.Count)
                {
                    // clients[i].play();
                }
            }
            nbTours++;
        }
    }

    public static List<Perso> PersosHost() // DONE
    {
        return new List<Perso> { roninjaHost, elfeeHost, fantomageHost, piratitanHost };
    }

    public static List<Perso> PersosClient() // DONE
    {
        return new List<Perso> { roninjaClient, elfeeClient, fantomageClient, piratitanClient };
    }

    public static List<Perso> Persos() // DONE
    {
        return new List<Perso>
        {
            roninjaHost,
            elfeeHost,
            fantomageHost,
            piratitanHost,
            roninjaClient,
            elfeeClient,
            fantomageClient,
            piratitanClient
        };
    }

    public static List<InvocationNonBloquante> GetInvocationsNonBloquantes() // DONE
    {
        List<InvocationNonBloquante> res = new List<InvocationNonBloquante>();

        InvocationNonBloquante? candidate;

        if (piratitanHost.attaques.ContainsKey("Bombe"))
        {
            candidate = ((Bombe)piratitanHost.attaques["Bombe"]).getBombe();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (piratitanClient.attaques.ContainsKey("Bombe"))
        {
            candidate = ((Bombe)piratitanClient.attaques["Bombe"]).getBombe();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (elfeeHost.attaques.ContainsKey("EspritElfique"))
        {
            candidate = ((EspritElfique)elfeeHost.attaques["EspritElfique"]).getEspritElfique();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (elfeeClient.attaques.ContainsKey("EspritElfique"))
        {
            candidate = ((EspritElfique)elfeeClient.attaques["EspritElfique"]).getEspritElfique();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (piratitanHost.attaques.ContainsKey("Mouette"))
        {
            candidate = ((Mouette)piratitanHost.attaques["Mouette"]).getMouette();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (piratitanClient.attaques.ContainsKey("Mouette"))
        {
            candidate = ((Mouette)piratitanClient.attaques["Mouette"]).getMouette();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (fantomageHost.attaques.ContainsKey("Crapeau"))
        {
            candidate = ((Crapeau)fantomageHost.attaques["Crapeau"]).getCrapeau();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (fantomageClient.attaques.ContainsKey("Crapeau"))
        {
            candidate = ((Crapeau)fantomageClient.attaques["Crapeau"]).getCrapeau();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        return res;
    }

    public static void PierreToTable(Pierre pierre) // DONE
    {
        if (pierre.isHost)
        {
            host.grid[3, 3].addPierre(pierre, true);
            host.grid[3, 4].addPierre(pierre, true);
            host.grid[4, 3].addPierre(pierre, true);
            host.grid[4, 4].addPierre(pierre, true);
        }
        else
        {
            client.grid[3, 3].addPierre(pierre, true);
            client.grid[3, 4].addPierre(pierre, true);
            client.grid[4, 3].addPierre(pierre, true);
            client.grid[4, 4].addPierre(pierre, true);
        }
    }

    public static void EncaissePierre(Pierre pierre) // TODO : Gérer la win
    {
        if (pierre.isHost)
        {
            if (pierre.lumiere)
            {
                pierrelumierehostobtenue = true;
                PierreToTable(pierreombrehost);
            }
            else
            {
                // win client
            }
        }
        else
        {
            if (pierre.lumiere)
            {
                pierrelumiereclientobtenue = true;
                PierreToTable(pierreombreclient);
            }
            else
            {
                // win host
            }
        }
    }

    // Méthodes private

    private static void Shuffle<T>(List<T> list, Random rng) // DONE
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

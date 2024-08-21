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

    public enum CibleType
    {
        DragNDrop,
        InvocationNonBloquante,
        InvocationSimpleBloquante,
        InvocationDoubleBloquante,
        FreeOnPerso,
        Miniaturisation,
        Teleport,
        FreeOnCase,
        FreeOnFace,
        Etincelle,
        Ancre,
        AttireRepousse,
        PersoFriendly,
        PersoEnnemy,
        Soin,
        Altruisme,
        PersoEtInvocEnnemy,
        FrappeDuPirate,
        FrappeDuTitan,
        TonneauOuClone,
        PorterDeposer,
        Planche,
        Gravite,
        ChargeDuTitan,
        HautesHerbes,
        Reanimation,
        FlecheDeLumiere,
        DerobadeDeLOmbre,
        PiegeSimple,
        PiegeLineaire,
        Acide,
        Derobade,
        Transposition,
        Inversion,
        PoseGlissante,
        FeuFollet,
        Rappel,
        CaseDeRapatriement,
        Memoire,
        EnvolAtterissage,
        Esquive,
        SortDeProtection
    }

    public enum DirectionType
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum SpawnType
    {
        Roninja,
        Elfee,
        Fantomage,
        Piratitan
    }

    public enum CaseType
    {
        Vide,
        SimpleObstacle,
        Table,
        DoubleObstacleHaut,
        DoubleObstacleBas,
        DoubleObstacleGauche,
        DoubleObstacleDroite,
        Trou,
        Camouflage,
        Glissante
    }

    public enum FaceType
    {
        Host,
        Client,
        North,
        South,
        East,
        West
    }

    public enum InvocationType
    {
        Carosse,
        Bombe,
        EspritElfique,
        Crapeau,
        Mouette,
        Tonneau,
        Coffre,
        Clone,
        GrossePotion
    }

    public enum PiegeType
    {
        PiegeLineaire,
        PiegeALoup,
        CaseTerrifiante
    }

    public enum PersoType
    {
        Roninja,
        Elfee,
        Fantomage,
        Piratitan
    }

    public enum AttaqueType
    {
        carosse,
        bombe,
        espritElfique,
        crapeau,
        mouette,
        tonneau,
        coffre,
        clone,
        dragAndDrop,
        ancre,
        bondDuTitan,
        chargeDuTitan,
        coupDeFeu,
        etincelle,
        flaque,
        frappeDuPirate,
        frappeDuTitan,
        harpon,
        invincibilite,
        longueVue,
        planche,
        porterDeposer,
        poudre,
        sabre,
        altruisme,
        coupDeBaguette,
        derniereVolontee,
        elixirAgressif,
        envolAtterissage,
        esquive,
        fleche,
        flecheDeLumiere,
        flechePatiente,
        hautesHerbes,
        miniaturisation,
        petitSoin,
        poudreBienfaisante,
        poudreSoporifique,
        poudreStimulante,
        reanimation,
        soinTotal,
        acide,
        attire,
        brume,
        couteauDeLancee,
        derobadeDeLOmbre,
        derobade,
        entrave,
        feinte,
        invisibilite,
        katana,
        kunai,
        memoire,
        piegeALoup,
        piegeLineaire,
        pirouette,
        poison,
        repousse,
        teleport,
        bouleDeFeu,
        bouletFantomatique,
        buff,
        caseDeRapatriement,
        caseTerrifiante,
        clairvoyance,
        coupDeBaton,
        eauVaseuse,
        feuFollet,
        gravite,
        inversion,
        jouvence,
        mainsMaudites,
        malediction,
        rappel,
        sortDeProtection,
        transposition,
        voileDInvisibilite
    }

    // Méthodes public

    public static void InitJeu() // TODO : Récupérer les attaques des personnages
    {
        List<int>? roninjaHostAttaques = new List<int> { AttaqueType.dragAndDrop };
        List<int>? elfeeHostAttaques = new List<int> { AttaqueType.dragAndDrop };
        List<int>? fantomageHostAttaques = new List<int> { AttaqueType.dragAndDrop };
        List<int>? piratitanHostAttaques = new List<int> { AttaqueType.dragAndDrop };
        List<int>? roninjaClientAttaques = new List<int> { AttaqueType.dragAndDrop };
        List<int>? elfeeClientAttaques = new List<int> { AttaqueType.dragAndDrop };
        List<int>? fantomageClientAttaques = new List<int> { AttaqueType.dragAndDrop };
        List<int>? piratitanClientAttaques = new List<int> { AttaqueType.dragAndDrop };

        north = new Face(FaceType.North);
        south = new Face(FaceType.South);
        east = new Face(FaceType.East);
        west = new Face(FaceType.West);
        host = new Face(FaceType.Host);
        client = new Face(FaceType.Client);

        roninjaHost = new Perso(PersoType.Roninja, true, roninjaHostAttaques);
        elfeeHost = new Perso(PersoType.Elfee, true, elfeeHostAttaques);
        fantomageHost = new Perso(PersoType.Fantomage, true, fantomageHostAttaques);
        piratitanHost = new Perso(PersoType.Piratitan, true, piratitanHostAttaques);
        roninjaClient = new Perso(PersoType.Roninja, false, roninjaClientAttaques);
        elfeeClient = new Perso(PersoType.Elfee, false, elfeeClientAttaques);
        fantomageClient = new Perso(PersoType.Fantomage, false, fantomageClientAttaques);
        piratitanClient = new Perso(PersoType.Piratitan, false, piratitanClientAttaques);

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

        if (piratitanHost.attaques.ContainsKey(InvocationType.Bombe))
        {
            candidate = ((Bombe)piratitanHost.attaques[InvocationType.Bombe]).getBombe();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (piratitanClient.attaques.ContainsKey(InvocationType.Bombe))
        {
            candidate = ((Bombe)piratitanClient.attaques[InvocationType.Bombe]).getBombe();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (elfeeHost.attaques.ContainsKey(InvocationType.EspritElfique))
        {
            candidate = (
                (EspritElfique)elfeeHost.attaques[InvocationType.EspritElfique]
            ).getEspritElfique();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (elfeeClient.attaques.ContainsKey(InvocationType.EspritElfique))
        {
            candidate = (
                (EspritElfique)elfeeClient.attaques[InvocationType.EspritElfique]
            ).getEspritElfique();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (piratitanHost.attaques.ContainsKey(InvocationType.Mouette))
        {
            candidate = ((Mouette)piratitanHost.attaques[InvocationType.Mouette]).getMouette();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (piratitanClient.attaques.ContainsKey(InvocationType.Mouette))
        {
            candidate = ((Mouette)piratitanClient.attaques[InvocationType.Mouette]).getMouette();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (fantomageHost.attaques.ContainsKey(InvocationType.Crapeau))
        {
            candidate = ((Crapeau)fantomageHost.attaques[InvocationType.Crapeau]).getCrapeau();
            if (candidate != null)
            {
                res.Add(candidate);
            }
        }

        if (fantomageClient.attaques.ContainsKey(InvocationType.Crapeau))
        {
            candidate = ((Crapeau)fantomageClient.attaques[InvocationType.Crapeau]).getCrapeau();
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

    public static List<Face> getFaces() // DONE
    {
        return new List<Face> { north, south, east, west, host, client };
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

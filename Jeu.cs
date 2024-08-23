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
        dragNDrop,
        invocationNonBloquante,
        invocationSimpleBloquante,
        invocationDoubleBloquante,
        freeOnPerso,
        miniaturisation,
        teleport,
        freeOnCase,
        freeOnFace,
        etincelle,
        ancre,
        attireRepousse,
        persoFriendly,
        persoEnnemy,
        soin,
        altruisme,
        persoEtInvocEnnemy,
        frappeDuPirate,
        frappeDuTitan,
        tonneauOuClone,
        porterDeposer,
        planche,
        gravite,
        chargeDuTitan,
        hautesHerbes,
        reanimation,
        flecheDeLumiere,
        derobadeDeLOmbre,
        piegeSimple,
        piegeLineaire,
        acide,
        derobade,
        transposition,
        inversion,
        poseGlissante,
        feuFollet,
        rappel,
        caseDeRapatriement,
        memoire,
        envolAtterissage,
        esquive,
        sortDeProtection,
        none
    }

    public enum DirectionType
    {
        Up,
        Down,
        Left,
        Right,
        RotLeft,
        RotRight,
        none
    }

    public enum SpawnType
    {
        Roninja,
        Elfee,
        Fantomage,
        Piratitan,
        none
    }

    public enum CaseType
    {
        Roninja,
        Elfee,
        Fantomage,
        Piratitan,
        Vide,
        SimpleObstacle,
        Table,
        DoubleObstacleHaut,
        DoubleObstacleBas,
        DoubleObstacleGauche,
        DoubleObstacleDroite,
        Trou,
        Camouflage,
        Glissante,
        none
    }

    public enum FaceType
    {
        Host,
        Client,
        North,
        South,
        East,
        West,
        none
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
        GrossePotion,
        none
    }

    public enum PiegeType
    {
        PiegeLineaire,
        PiegeALoup,
        CaseTerrifiante,
        none
    }

    public enum PersoType
    {
        Roninja,
        Elfee,
        Fantomage,
        Piratitan,
        none
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
        voileDInvisibilite,
        none
    }

    public enum EtatType
    {
        normal,
        ko,
        winClient,
        winHost
    }

    // Méthodes public

    public static void InitJeu() // TODO : Récupérer les attaques des personnages
    {
        List<AttaqueType>? roninjaHostAttaques = new List<AttaqueType> { AttaqueType.dragAndDrop };
        List<AttaqueType>? elfeeHostAttaques = new List<AttaqueType> { AttaqueType.dragAndDrop };
        List<AttaqueType>? fantomageHostAttaques = new List<AttaqueType>
        {
            AttaqueType.dragAndDrop
        };
        List<AttaqueType>? piratitanHostAttaques = new List<AttaqueType>
        {
            AttaqueType.dragAndDrop
        };
        List<AttaqueType>? roninjaClientAttaques = new List<AttaqueType>
        {
            AttaqueType.dragAndDrop
        };
        List<AttaqueType>? elfeeClientAttaques = new List<AttaqueType> { AttaqueType.dragAndDrop };
        List<AttaqueType>? fantomageClientAttaques = new List<AttaqueType>
        {
            AttaqueType.dragAndDrop
        };
        List<AttaqueType>? piratitanClientAttaques = new List<AttaqueType>
        {
            AttaqueType.dragAndDrop
        };

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

        if (piratitanHost.attaques.ContainsKey(AttaqueType.bombe))
        {
            candidate = ((Bombe)piratitanHost.attaques[AttaqueType.bombe]).getBombe();
            if (candidate != null)
                res.Add(candidate);
        }

        if (piratitanClient.attaques.ContainsKey(AttaqueType.bombe))
        {
            candidate = ((Bombe)piratitanClient.attaques[AttaqueType.bombe]).getBombe();
            if (candidate != null)
                res.Add(candidate);
        }

        if (elfeeHost.attaques.ContainsKey(AttaqueType.espritElfique))
        {
            candidate = (
                (EspritElfique)elfeeHost.attaques[AttaqueType.espritElfique]
            ).getEspritElfique();
            if (candidate != null)
                res.Add(candidate);
        }

        if (elfeeClient.attaques.ContainsKey(AttaqueType.espritElfique))
        {
            candidate = (
                (EspritElfique)elfeeClient.attaques[AttaqueType.espritElfique]
            ).getEspritElfique();
            if (candidate != null)
                res.Add(candidate);
        }

        if (piratitanHost.attaques.ContainsKey(AttaqueType.mouette))
        {
            candidate = ((Mouette)piratitanHost.attaques[AttaqueType.mouette]).getMouette();
            if (candidate != null)
                res.Add(candidate);
        }

        if (piratitanClient.attaques.ContainsKey(AttaqueType.mouette))
        {
            candidate = ((Mouette)piratitanClient.attaques[AttaqueType.mouette]).getMouette();
            if (candidate != null)
                res.Add(candidate);
        }

        if (fantomageHost.attaques.ContainsKey(AttaqueType.crapeau))
        {
            candidate = ((Crapeau)fantomageHost.attaques[AttaqueType.crapeau]).getCrapeau();
            if (candidate != null)
                res.Add(candidate);
        }

        if (fantomageClient.attaques.ContainsKey(AttaqueType.crapeau))
        {
            candidate = ((Crapeau)fantomageClient.attaques[AttaqueType.crapeau]).getCrapeau();
            if (candidate != null)
                res.Add(candidate);
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

    public static void EncaissePierre(Pierre pierre) // DONE
    {
        if (pierre.isHost)
        {
            if (pierre.lumiere)
            {
                pierrelumierehostobtenue = true;
                PierreToTable(pierreombrehost);
            }
        }
        else
        {
            if (pierre.lumiere)
            {
                pierrelumiereclientobtenue = true;
                PierreToTable(pierreombreclient);
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

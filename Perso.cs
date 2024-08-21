public class Perso
{
    // Attributs // DONE
    public string type { get; set; }
    public bool isHost { get; set; }
    public int hp { get; set; }
    public int hpMax { get; set; }
    public int energie { get; set; }
    public int energieActive { get; set; }
    public Pierre? pierre { get; set; }
    public bool poudre { get; set; }
    public bool invincible { get; set; }
    public Perso? porte { get; set; }
    public List<Perso> harponne { get; set; }
    public bool enVol { get; set; }
    public bool esquive { get; set; }
    public Dictionary<int, int> buffEnergie { get; set; }
    public Dictionary<int, int> buffHp { get; set; }
    public int coolDownKO { get; set; } // 0 si pas KO
    public bool passeTour { get; set; }
    public float boostDegats { get; set; }
    public Dictionary<int, float> buffBoostDegats { get; set; }
    public int invisibilite { get; set; } // 0 = visible, positif = invisible
    public bool pirouette { get; set; }
    public bool feinte { get; set; }
    public bool mainsMaudites { get; set; }
    public bool malediction { get; set; }
    public bool derniereVolonte { get; set; }
    public bool miniaturisation { get; set; }
    public Case? myCase { get; set; }
    public Case? temoinDePosition { get; set; }
    public Dictionary<string, Attaque> attaques { get; set; }
    private static readonly Dictionary<string, Type> attaqueTypes = new Dictionary<string, Type>
    {
        { "DragNDrop", typeof(DragNDrop) },
        { "Ancre", typeof(Ancre) },
        { "Bombe", typeof(Bombe) },
        { "BondDuTitan", typeof(BondDuTitan) },
        { "ChargeDuTitan", typeof(ChargeDuTitan) },
        { "Coffre", typeof(Coffre) },
        { "CoupDeFeu", typeof(CoupDeFeu) },
        { "Etincelle", typeof(Etincelle) },
        { "Flaque", typeof(Flaque) },
        { "FrappeDuPirate", typeof(FrappeDuPirate) },
        { "FrappeDuTitan", typeof(FrappeDuTitan) },
        { "Harpon", typeof(Harpon) },
        { "Invincibilite", typeof(Invincibilite) },
        { "LongueVue", typeof(LongueVue) },
        { "Mouette", typeof(Mouette) },
        { "Planche", typeof(Planche) },
        { "PorterDeposer", typeof(PorterDeposer) },
        { "Poudre", typeof(Poudre) },
        { "Sabre", typeof(Sabre) },
        { "Tonneau", typeof(Tonneau) },
        { "Altruisme", typeof(Altruisme) },
        { "Carosse", typeof(Carosse) },
        { "CoupDeBaguette", typeof(CoupDeBaguette) },
        { "DerniereVolonte", typeof(DerniereVolonte) },
        { "ElixirAgressif", typeof(ElixirAgressif) },
        { "EnvolAtterissage", typeof(EnvolAtterissage) },
        { "EspritElfique", typeof(EspritElfique) },
        { "Esquive", typeof(Esquive) },
        { "Fleche", typeof(Fleche) },
        { "FlecheDeLumiere", typeof(FlecheDeLumiere) },
        { "FlechePatiente", typeof(FlechePatiente) },
        { "HautesHerbes", typeof(HautesHerbes) },
        { "Miniaturisation", typeof(Miniaturisation) },
        { "PetitSoin", typeof(PetitSoin) },
        { "PoudreBienfaisante", typeof(PoudreBienfaisante) },
        { "PoudreSoporifique", typeof(PoudreSoporifique) },
        { "PoudreStimulante", typeof(PoudreStimulante) },
        { "Reanimation", typeof(Reanimation) },
        { "SoinTotal", typeof(SoinTotal) },
        { "Acide", typeof(Acide) },
        { "Attire", typeof(Attire) },
        { "Brume", typeof(Brume) },
        { "Clone", typeof(Clone) },
        { "CouteauDeLancee", typeof(CouteauDeLancee) },
        { "DerobadeDeLOmbre", typeof(DerobadeDeLOmbre) },
        { "Derobade", typeof(Derobade) },
        { "Entrave", typeof(Entrave) },
        { "Feinte", typeof(Feinte) },
        { "Invisibilite", typeof(Invisibilite) },
        { "Katana", typeof(Katana) },
        { "Kunai", typeof(Kunai) },
        { "Memoire", typeof(Memoire) },
        { "PiegeALoup", typeof(PiegeALoup) },
        { "PiegeLineaire", typeof(PiegeLineaire) },
        { "Pirouette", typeof(Pirouette) },
        { "Poison", typeof(Poison) },
        { "Repousse", typeof(Repousse) },
        { "Teleport", typeof(Teleport) },
        { "BouleDeFeu", typeof(BouleDeFeu) },
        { "BouletFantomatique", typeof(BouletFantomatique) },
        { "Buff", typeof(Buff) },
        { "CaseDeRapatriement", typeof(CaseDeRapatriement) },
        { "CaseTerrifiante", typeof(CaseTerrifiante) },
        { "Clairvoyance", typeof(Clairvoyance) },
        { "CoupDeBaton", typeof(CoupDeBaton) },
        { "Crapeau", typeof(Crapeau) },
        { "EauVaseuse", typeof(EauVaseuse) },
        { "FeuFollet", typeof(FeuFollet) },
        { "Gravite", typeof(Gravite) },
        { "Inversion", typeof(Inversion) },
        { "Jouvence", typeof(Jouvence) },
        { "MainsMaudites", typeof(MainsMaudites) },
        { "Malediction", typeof(Malediction) },
        { "Rappel", typeof(Rappel) },
        { "SortDeProtection", typeof(SortDeProtection) },
        { "Transposition", typeof(Transposition) },
        { "VoileDInvisibilite", typeof(VoileDInvisibilite) }
    };

    // Constructeur // DONE
    public Perso(String type, bool isHost, List<string> attaques)
    {
        this.type = type;
        this.isHost = isHost;
        hp = 10;
        hpMax = 10;
        energie = 8;
        energieActive = 0;
        pierre = null;
        poudre = false;
        invincible = false;
        porte = null;
        harponne = new List<Perso>();
        enVol = false;
        esquive = false;
        buffEnergie = new Dictionary<int, int>();
        buffHp = new Dictionary<int, int>();
        coolDownKO = 0;
        passeTour = false;
        boostDegats = 1;
        buffBoostDegats = new Dictionary<int, float>();
        invisibilite = 0;
        pirouette = false;
        feinte = false;
        mainsMaudites = false;
        malediction = false;
        derniereVolonte = false;
        miniaturisation = false;
        switch (type)
        {
            case "Roninja":
                myCase = isHost ? Jeu.host.grid[2, 2] : Jeu.client.grid[2, 2];
                break;
            case "Elfee":
                myCase = isHost ? Jeu.host.grid[2, 5] : Jeu.client.grid[2, 5];
                break;
            case "Fantomage":
                myCase = isHost ? Jeu.host.grid[5, 2] : Jeu.client.grid[5, 2];
                break;
            case "Piratitan":
                myCase = isHost ? Jeu.host.grid[5, 5] : Jeu.client.grid[5, 5];
                break;
            default:
                break;
        }
        temoinDePosition = null;
        this.attaques = new Dictionary<string, Attaque>();
        foreach (string attaque in attaques)
        {
            if (attaqueTypes.TryGetValue(attaque, out Type? myType))
            {
                var constructor = myType.GetConstructor(new[] { typeof(Perso) });
                if (constructor != null)
                {
                    this.attaques.Add(attaque, (Attaque)constructor.Invoke(new object[] { this }));
                }
            }
        }
    }

    // Méthodes public

    public void play() //TODO : Jouer même si KO ou passe son tour /!\ important pour l'actualisation des sorts /!\
    {
        debutTour();
        if (coolDownKO == 0)
        {
            if (passeSonTour())
            {
                return;
            }
            else
            {
                //TODO : Tour de jeu
            }
        }

        finTour();
    }

    public void debutTour() // DONE
    {
        temoinDePosition = null;

        foreach (Attaque attaque in attaques.Values)
        {
            attaque.debutTour();
        }
        
        derniereVolonte = false;

        energieActive = energie;

        desactiverInvincible();

        desactiverPirouette();

        desactiverDerniereVolonte();

        if (attaques.ContainsKey("ElixirAgressif"))
        {
            ((ElixirAgressif)attaques["ElixirAgressif"]).debutTour();
        }

        if (attaques.ContainsKey("Harpon"))
        {
            ((Harpon)attaques["Harpon"]).desactiver();
        }

        if (attaques.ContainsKey("Ancre"))
        {
            ((Ancre)attaques["Ancre"]).debutTour();
        }

        if (attaques.ContainsKey("Altruisme"))
        {
            ((Altruisme)attaques["Altruisme"]).debutTour();
        }

        if (attaques.ContainsKey("Brume"))
        {
            ((Brume)attaques["Brume"]).desactiver();
        }

        if (attaques.ContainsKey("Invisibilite"))
        {
            ((Invisibilite)attaques["Invisibilite"]).desactiver();
        }

        if (attaques.ContainsKey("VoileDInvisibilite"))
        {
            ((VoileDInvisibilite)attaques["VoileDInvisibilite"]).desactiver();
        }

        if (attaques.ContainsKey("Malediction"))
        {
            ((Malediction)attaques["Malediction"]).desactiver();
        }

        if (buffHp.ContainsKey(1))
        {
            activerBuffHp();
        }
        List<int> keys = new List<int>(buffHp.Keys);
        keys.Sort();
        foreach (int key in keys)
        {
            buffHp[key] -= 1;
        }

        if (buffEnergie.ContainsKey(1))
        {
            activerBuffEnergie();
        }
        keys = new List<int>(buffEnergie.Keys);
        keys.Sort();
        foreach (int key in keys)
        {
            buffEnergie[key] -= 1;
        }

        if (myCase != null)
        {
            InvocationNonBloquante? espritElfiqueCandidat;

            if (isHost)
                espritElfiqueCandidat = myCase.face.espritElfiqueHost();
            else
                espritElfiqueCandidat = myCase.face.espritElfiqueClient();

            if (espritElfiqueCandidat != null)
                espritElfiqueCandidat.activer(this);
        }

        if (buffBoostDegats.ContainsKey(1))
        {
            activerBuffBoostDegats();
        }
        keys = new List<int>(buffBoostDegats.Keys);
        keys.Sort();
        foreach (int key in keys)
        {
            buffBoostDegats[key] -= 1;
        }

        if (coolDownKO != 0)
        {
            coolDownKO--;
            if (coolDownKO == 0)
            {
                respawn();
            }
        }
    }

    public void finTour() // DONE
    {
        desactiverPoudre();

        desactivermainsMaudites();

        if (attaques.ContainsKey("LongueVue"))
        {
            ((LongueVue)attaques["LongueVue"]).desactiver();
        }

        foreach (InvocationSimpleBloquante potion in grossesPotionsAActiver())
        {
            potion.activer();
        }

        foreach (InvocationDoubleBloquante carosse in carossesAActiver())
        {
            carosse.activer();
        }

        if (pierre != null && pierre.isHost == isHost)
        {
            dropPierre();
            estKO(roninjaPortePierre: true);
        }
    }

    public void estKO(bool roninjaPortePierre = false, bool tombeDansTrou = false) // DONE
    {
        temoinDePosition = null;
        hp = 0;
        hpMax = 10;
        miniaturisation = false;
        if (attaques.ContainsKey("LongueVue"))
        {
            ((LongueVue)attaques["LongueVue"]).desactiver();
        }

        desactiverPoudre();

        desactivermainsMaudites();

        desactiverInvincible();

        desactiverAncre();

        desactiverPirouette();

        desactiverHarpons();

        reveal();

        if (attaques.ContainsKey("Altruisme"))
        {
            ((Altruisme)attaques["Altruisme"]).desactiver();
        }

        if (sousAltruisme())
        {
            Perso elfeeAlliee;
            if (isHost)
                elfeeAlliee = Jeu.elfeeHost;
            else
                elfeeAlliee = Jeu.elfeeClient;

            ((Altruisme)elfeeAlliee.attaques["Altruisme"]).desactiver();
        }

        desactiverElixirAgressifIfOnMe();

        desactiverEsquive();

        desactiverFeinte();

        desactiverPasseTour();

        if (derniereVolonte)
            activerDerniereVolonte();

        coolDownKO = malediction ? 3 : 2;

        if (malediction)
        {
            Perso fantomageAdverse;
            if (isHost)
                fantomageAdverse = Jeu.fantomageClient;
            else
                fantomageAdverse = Jeu.fantomageHost;

            ((Malediction)fantomageAdverse.attaques["Malediction"]).desactiver();
        }

        buffEnergie.Clear();

        buffHp.Clear();

        buffBoostDegats.Clear();

        if (pierre != null)
        {
            dropPierre();
        }

        Perso? piratitanCandidat = estPortePar();
        if (piratitanCandidat != null)
        {
            piratitanCandidat.porte = null;
        }
        if (porte != null)
        {
            Perso persoTombant = porte;
            porte = null;
            persoTombant.persoPorteTombe();
        }

        if (myCase != null)
            myCase.persoLeaveCase(this);

        enVol = false;

        energie = 0;

        boostDegats = 1;
    }

    public void respawn() // DONE
    {
        hp = 10;
        hpMax = 10;
        energie = 8;
        energieActive = 0;
        pierre = null;
        poudre = false;
        invincible = false;
        porte = null;
        harponne = new List<Perso>();
        enVol = false;
        esquive = false;
        coolDownKO = 0;
        passeTour = false;
        boostDegats = 1;
        invisibilite = 0;
        pirouette = false;
        feinte = false;
        mainsMaudites = false;
        malediction = false;
        miniaturisation = false;
        switch (type)
        {
            case "Roninja":
                if (isHost)
                    Jeu.host.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case "Elfee":
                if (isHost)
                    Jeu.host.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case "Fantomage":
                if (isHost)
                    Jeu.host.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case "Piratitan":
                if (isHost)
                    Jeu.host.grid[5, 5].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[5, 5].persoEnterCase(this, newFace: true, respawn: true);
                break;
            default:
                break;
        }
    }

    public void dropPierre(Case? caseCible = null) // DONE
    {
        caseCible = caseCible == null ? myCase : caseCible;
        if (caseCible == null || pierre == null)
            return;

        InvocationSimpleBloquante? coffreLePlusPres = caseCible.face.coffreLePlusPres(caseCible);

        if (caseCible.containsTableHost)
        {
            if (pierre.isHost)
                Jeu.PierreToTable(pierre);
            else
                Jeu.EncaissePierre(pierre);
        }
        else if (caseCible.containsTableClient)
        {
            if (pierre.isHost)
                Jeu.EncaissePierre(pierre);
            else
                Jeu.PierreToTable(pierre);
        }
        else if (coffreLePlusPres != null)
            coffreLePlusPres.activerCoffre(pierre);
        else if (caseCible.containsTrou)
            Jeu.PierreToTable(pierre);
        else
            caseCible.addPierre(pierre);

        pierre = null;
    }

    public void miss() // DONE
    { }

    public void reveal() // DONE
    {
        desactiverInvisibiliteIfOnMe(revealPerso: false);
        desactiverVoileDInvisibiliteIfOnMe(revealPerso: false);
        invisibilite = 0;
        temoinDePosition = null;
        activerFlechesPatientes();
    }

    public void infligeDegats(int degats, Perso? cible, bool reveal = true) // DONE
    {
        if (cible != null)
        {
            cible.recoitDegats((int)Math.Round(degats * boostDegats));
            cible.reveal();
        }
    }

    public void infligeDegats(int degats, InvocationSimpleBloquante? cible) // DONE
    {
        if (cible != null)
            cible.recoitDegats((int)Math.Round(degats * boostDegats));
    }

    public void infligeDegats(int degats, InvocationDoubleBloquante? cible) // DONE
    {
        if (cible != null)
            cible.recoitDegats((int)Math.Round(degats * boostDegats));
    }

    public void infligeDegats(int degats, InvocationNonBloquante? cible) // DONE
    {
        if (cible != null)
            cible.recoitDegats((int)Math.Round(degats * boostDegats));
    }

    public void infligeDegats(int degats, Object cible, bool reveal = true) // DONE
    {
        if (cible is Perso)
            infligeDegats(degats, (Perso)cible, reveal);
        else if (cible is InvocationSimpleBloquante)
            infligeDegats(degats, (InvocationSimpleBloquante)cible);
        else if (cible is InvocationDoubleBloquante)
            infligeDegats(degats, (InvocationDoubleBloquante)cible);
        else if (cible is InvocationNonBloquante)
            infligeDegats(degats, (InvocationNonBloquante)cible);
    }

    public void recoitDegats(int degats, bool ignoreFeinte = false) // DONE
    {
        if (hp <= 0)
        {
            return;
        }

        reveal();

        if (!ignoreFeinte && feinte && !getAncre() && estPortePar() != null)
        {
            recoitDegats(degats, ignoreFeinte: true);
            ((Feinte)attaques["Feinte"]).activerFeinte();
            return;
        }

        if (invincible)
            return;

        if (esquive)
        {
            esquive = false;
            return;
        }

        if (sousAltruisme())
        {
            if (isHost)
                Jeu.elfeeHost.recoitDegats(degats);
            else
                Jeu.elfeeClient.recoitDegats(degats);

            return;
        }
        hp -= Math.Min(hp, degats);
        if (hp <= 0)
            estKO();
        else if (enVol)
        {
            enVol = false;
            elfeeTombe();
        }
    }

    public void recoitSoin(int soin) // DONE
    {
        hp = Math.Min(hpMax, hp + soin);
    }

    public Object? nextObstacleDirection(string direction) // DONE
    // Renvoie null si rien OU si obstacle non invoqué, InvocationSimpleBloquante si ISB, InvocationDoubleBloquante si IDB, Perso si perso
    {
        if (myCase == null)
            return null;

        Case? c = myCase.nextCaseDirection(direction);

        if (
            c == null
            || c.containsSimpleObstacle
            || c.containsDoubleObstacle
            || c.containsTableClient
            || c.containsTableHost
            || c.obstacleSpawn != ""
        )
            return null;

        if (c.invocationSimpleBloquante != null)
            return c.invocationSimpleBloquante;

        if (c.invocationDoubleBloquante != null)
            return c.invocationDoubleBloquante;

        if (c.perso() != null)
            return c.perso();

        return null;
    }

    public bool canTryMoveDirection(string direction) // DONE
    {
        if (myCase == null)
            return false;
        Case? c = myCase.nextCaseDirection(direction);

        return c != null && (!c.face.faceVisible(isHost) || c.seemsWalkable(this));
    }

    public bool canMoveDirection(string direction) // DONE
    {
        if (myCase == null)
            return false;
        Case? c = myCase.nextCaseDirection(direction);

        return c != null && c.isWalkable(this);
    }

    public void tryMoveDirection(string direction) // DONE
    {
        energieActive--;
        if (canMoveDirection(direction))
        {
            moveDirection(direction);
        }
        else
            miss();
    }

    public void moveDirection(
        string direction,
        bool glissade = false,
        bool attiranceCrapeau = false,
        bool chargeDuTitan = false,
        bool bondDuTitan = false,
        bool porterDeposer = false,
        bool crapeauHost = false,
        bool crapeauClient = false
    ) // DONE
    {
        if (myCase == null)
            return;

        myCase.persoLeaveCase(this);

        if (porte != null && porte.myCase != null)
            porte.myCase.persoLeaveCase(this);

        Perso? persoPorteur = estPortePar();
        if (persoPorteur != null)
            persoPorteur.porte = null;

        switch (direction)
        {
            case "up":
                if (myCase.row == 0)
                {
                    switch (myCase.face.name)
                    {
                        case "north":
                            Jeu.client.grid[0, 7 - myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "south":
                            Jeu.client.grid[7, myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "east":
                            Jeu.client.grid[myCase.col, 0]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "west":
                            Jeu.client.grid[7 - myCase.col, 7]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "host":
                            Jeu.north.grid[7, myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "client":
                            Jeu.north.grid[0, 7 - myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    myCase
                        .face.grid[myCase.row - 1, myCase.col]
                        .persoEnterCase(
                            this,
                            crapeauHost: crapeauHost,
                            crapeauClient: crapeauClient
                        );
                }
                break;
            case "down":
                if (myCase.row == 7)
                {
                    switch (myCase.face.name)
                    {
                        case "north":
                            Jeu.host.grid[0, myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "south":
                            Jeu.host.grid[7, 7 - myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "east":
                            Jeu.host.grid[myCase.col, 7]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "west":
                            Jeu.host.grid[0, 7 - myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "host":
                            Jeu.south.grid[7, 7 - myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "client":
                            Jeu.south.grid[0, myCase.col]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    myCase
                        .face.grid[myCase.row + 1, myCase.col]
                        .persoEnterCase(
                            this,
                            crapeauHost: crapeauHost,
                            crapeauClient: crapeauClient
                        );
                }
                break;
            case "left":
                if (myCase.col == 0)
                {
                    switch (myCase.face.name)
                    {
                        case "north":
                            Jeu.west.grid[myCase.row, 7]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "south":
                            Jeu.east.grid[myCase.row, 7]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "east":
                            Jeu.north.grid[myCase.row, 7]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "west":
                            Jeu.south.grid[myCase.row, 7]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "host":
                            Jeu.west.grid[7, 7 - myCase.row]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "client":
                            Jeu.east.grid[0, myCase.row]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    myCase
                        .face.grid[myCase.row, myCase.col - 1]
                        .persoEnterCase(
                            this,
                            crapeauHost: crapeauHost,
                            crapeauClient: crapeauClient
                        );
                }
                break;
            case "right":
                if (myCase.col == 7)
                {
                    switch (myCase.face.name)
                    {
                        case "north":
                            Jeu.east.grid[myCase.row, 0]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "south":
                            Jeu.west.grid[myCase.row, 0]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "east":
                            Jeu.south.grid[myCase.row, 0]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "west":
                            Jeu.north.grid[myCase.row, 0]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "host":
                            Jeu.east.grid[7, myCase.row]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        case "client":
                            Jeu.west.grid[0, 7 - myCase.row]
                                .persoEnterCase(
                                    this,
                                    newFace: true,
                                    crapeauHost: crapeauHost,
                                    crapeauClient: crapeauClient
                                );
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    myCase
                        .face.grid[myCase.row, myCase.col + 1]
                        .persoEnterCase(
                            this,
                            crapeauHost: crapeauHost,
                            crapeauClient: crapeauClient
                        );
                }
                break;
            default:
                break;
        }
    }

    public Dictionary<Case, List<Object?>> ciblesByAttaque(Attaque attaque) // DONE : Renvoie les cibles possibles pour une attaque donnée
    {
        Dictionary<Case, List<Object?>> cibles = new Dictionary<Case, List<Object?>>();

        if (myCase == null)
            return cibles;

        List<Case> casesAPortee = myCase.casesAPortee(attaque.porteeMin, attaque.porteeMax);

        foreach (Case c in casesAPortee)
        {
            cibles.Add(c, ciblesByAttaqueByCase(attaque, c));
        }

        return cibles;
    }

    public List<Object?> ciblesByAttaqueByCase(Attaque attaque, Case c) // DONE : Renvoie les cibles possibles pour une attaque et une case données
    {
        List<Object?> cibles = new List<Object?>();

        foreach (InvocationNonBloquante i in c.invocationsNonBloquantes())
        {
            if (attaque.isUsable(c, i))
                cibles.Add(i);
        }

        List<Pierre> pierres = c.getContainsPierre();
        if (pierres.Count > 0)
        {
            foreach (Pierre p in pierres)
            {
                if (attaque.isUsable(c, p))
                    cibles.Add(p);
            }
        }

        if (attaque.isUsable(c, null))
            cibles.Add(null);

        if (attaque.isUsable(c, c.face))
            cibles.Add(c.face);

        if (c.invocationSimpleBloquante != null && attaque.isUsable(c, c.invocationSimpleBloquante))
            cibles.Add(c.invocationSimpleBloquante);

        if (c.invocationDoubleBloquante != null && attaque.isUsable(c, c.invocationDoubleBloquante))
            cibles.Add(c.invocationDoubleBloquante);

        Perso? perso = c.perso();
        if (perso != null && perso.isVisibleForMe(isHost))
        {
            if (attaque.isUsable(c, perso))
                cibles.Add(perso);
        }
        else
        {
            if (!c.containsTrou && attaque.isUsable(c, false))
                cibles.Add(false);
        }

        Perso? persoOver = c.persoOver();
        if (persoOver != null && persoOver.isVisibleForMe(isHost))
        {
            if (attaque.isUsable(c, persoOver))
                cibles.Add(persoOver);
        }
        else
        {
            if (attaque.isUsable(c, true))
                cibles.Add(true);
        }

        return cibles;
    }

    public Perso? estPortePar() // DONE
    {
        if (isHost && Jeu.piratitanHost.porte == this)
        {
            return Jeu.piratitanHost;
        }
        else if (!isHost && Jeu.piratitanClient.porte == this)
        {
            return Jeu.piratitanClient;
        }
        else
        {
            return null;
        }
    }

    public void tombeDansTrou() // DONE
    {
        if (!getAncre() && pirouette)
        {
            dropPierre();
            pirouette = false;
            ((Pirouette)attaques["Pirouette"]).activer();
        }
        else
        {
            estKO(tombeDansTrou: true);
        }
    }

    public Dictionary<string, InvocationNonBloquante> entitesInvoquees() // DONE
    {
        Dictionary<string, InvocationNonBloquante> entitesInvoquees =
            new Dictionary<string, InvocationNonBloquante>();
        InvocationNonBloquante? candidate;
        if (attaques.ContainsKey("Bombe"))
        {
            candidate = ((Bombe)attaques["Bombe"]).getBombe();
            if (candidate != null)
            {
                entitesInvoquees.Add("Bombe", candidate);
            }
        }

        if (attaques.ContainsKey("EspritElfique"))
        {
            candidate = ((EspritElfique)attaques["EspritElfique"]).getEspritElfique();
            if (candidate != null)
            {
                entitesInvoquees.Add("EspritElfique", candidate);
            }
        }

        if (attaques.ContainsKey("Mouette"))
        {
            candidate = ((Mouette)attaques["Mouette"]).getMouette();
            if (candidate != null)
            {
                entitesInvoquees.Add("Mouette", candidate);
            }
        }

        if (attaques.ContainsKey("Crapeau"))
        {
            candidate = ((Crapeau)attaques["Crapeau"]).getCrapeau();
            if (candidate != null)
            {
                entitesInvoquees.Add("Crapeau", candidate);
            }
        }

        return entitesInvoquees;
    }

    public bool isVisibleForMe(
        bool isHostPlayerWatching,
        bool faceDoitEtreVisible = false,
        bool caseDoitEtreOffBrume = false
    ) // DONE
    {
        if (isHostPlayerWatching == isHost)
            return true;
        else
        {
            bool res = invisibilite == 0;

            if (faceDoitEtreVisible)
                res = res && myCase != null && myCase.face.faceVisible(isHostPlayerWatching);

            if (caseDoitEtreOffBrume)
            {
                if (isHostPlayerWatching)
                    res = res && myCase != null && !myCase.containsBrumeRoninjaClient;
                else
                    res = res && myCase != null && !myCase.containsBrumeRoninjaHost;
            }
            
            return res;
        }
    }

    public bool isover() // DONE
    {
        return enVol || (estPortePar() != null);
    }

    public void desactiverHarpons() // DONE
    {
        if (harponne.Count != 0)
        {
            foreach (Perso harponneCandidat in harponne.ToList())
            {
                harponneCandidat.harponne.Remove(this);
                harponne.Remove(harponneCandidat);
            }
        }
    }

    public void desactiverHarpons(Face a, Face b) // DONE : Désactive les harpons si les faces a et b sont différentes
    {
        if (a != b)
            desactiverHarpons();
    }

    public bool getAncre() // DONE
    {
        if (
            (
                Jeu.piratitanClient.attaques.ContainsKey("Ancre")
                && ((Ancre)Jeu.piratitanClient.attaques["Ancre"]).getTargets().Contains(this)
            )
            || (
                Jeu.piratitanHost.attaques.ContainsKey("Ancre")
                && ((Ancre)Jeu.piratitanHost.attaques["Ancre"]).getTargets().Contains(this)
            )
        )
            return true;
        return false;
    }

    public bool sousAltruisme() // DONE
    {
        if (
            (
                Jeu.elfeeClient.attaques.ContainsKey("Altruisme")
                && ((Altruisme)Jeu.elfeeClient.attaques["Altruisme"]).getTarget() == this
            )
            || (
                Jeu.elfeeHost.attaques.ContainsKey("Altruisme")
                && ((Altruisme)Jeu.elfeeHost.attaques["Altruisme"]).getTarget() == this
            )
        )
            return true;
        return false;
    }

    public void activerFlechesPatientes() // DONE
    {
        if (myCase == null)
            return;

        int degats = isHost ? myCase.face.flechesPatientesClient : myCase.face.flechesPatientesHost;

        if (degats == 0)
            return;

        if (isHost)
        {
            myCase.face.flechesPatientesClient = 0;
            Jeu.elfeeClient.infligeDegats(degats, this);
        }
        else
        {
            myCase.face.flechesPatientesHost = 0;
            Jeu.elfeeHost.infligeDegats(degats, this);
        }
    }

    // Méthodes private

    private bool sousInvisibilite() // DONE
    {
        if (attaques.ContainsKey("Invisibilite"))
            return ((Invisibilite)attaques["Invisibilite"]).estActif();

        return false;
    }

    private void desactiverInvisibiliteIfOnMe(bool revealPerso = true) // DONE
    {
        if (sousInvisibilite())
            ((Invisibilite)attaques["Invisibilite"]).desactiver(reveal: revealPerso);
    }

    private bool sousVoileDInvisibilite() // DONE
    {
        Perso candidatVoileDInvisibilite;
        if (isHost)
            candidatVoileDInvisibilite = Jeu.fantomageHost;
        else
            candidatVoileDInvisibilite = Jeu.fantomageClient;

        return candidatVoileDInvisibilite.attaques.ContainsKey("VoileDInvisibilite")
            && (
                (VoileDInvisibilite)candidatVoileDInvisibilite.attaques["VoileDInvisibilite"]
            ).getPersoCible() == this;
    }

    private void desactiverVoileDInvisibiliteIfOnMe(bool revealPerso = true) // DONE
    {
        if (sousVoileDInvisibilite())
        {
            Perso candidatVoileDInvisibilite;
            if (isHost)
                candidatVoileDInvisibilite = Jeu.fantomageHost;
            else
                candidatVoileDInvisibilite = Jeu.fantomageClient;

            (
                (VoileDInvisibilite)candidatVoileDInvisibilite.attaques["VoileDInvisibilite"]
            ).desactiver(reveal: revealPerso);
        }
    }

    private void desactiverElixirAgressifIfOnMe() // DONE
    {
        Perso candidatElixirAgressif;
        if (isHost)
            candidatElixirAgressif = Jeu.elfeeHost;
        else
            candidatElixirAgressif = Jeu.elfeeClient;
        if (candidatElixirAgressif.attaques.ContainsKey("ElixirAgressif"))
            ((ElixirAgressif)candidatElixirAgressif.attaques["ElixirAgressif"]).desactiver(this);
        
    }

    private List<InvocationSimpleBloquante> grossesPotionsAActiver() // DONE
    {
        List<InvocationSimpleBloquante> potions = new List<InvocationSimpleBloquante>();
        if (myCase == null)
        {
            return potions;
        }
        Case caseCandidate;
        if (myCase.row != 0)
        {
            caseCandidate = myCase.face.grid[myCase.row - 1, myCase.col];
            var potion = caseCandidate.containsGrossePotion();
            if (potion != null && potion.isHost == isHost)
            {
                potions.Add(potion);
            }
        }
        if (myCase.row != 7)
        {
            caseCandidate = myCase.face.grid[myCase.row + 1, myCase.col];
            var potion = caseCandidate.containsGrossePotion();
            if (potion != null && potion.isHost == isHost)
            {
                potions.Add(potion);
            }
        }
        if (myCase.col != 0)
        {
            caseCandidate = myCase.face.grid[myCase.row, myCase.col - 1];
            var potion = caseCandidate.containsGrossePotion();
            if (potion != null && potion.isHost == isHost)
            {
                potions.Add(potion);
            }
        }
        if (myCase.col != 7)
        {
            caseCandidate = myCase.face.grid[myCase.row, myCase.col + 1];
            var potion = caseCandidate.containsGrossePotion();
            if (potion != null && potion.isHost == isHost)
            {
                potions.Add(potion);
            }
        }

        return potions;
    }

    private List<InvocationDoubleBloquante> carossesAActiver() // DONE
    {
        List<InvocationDoubleBloquante> carosses = new List<InvocationDoubleBloquante>();
        Case caseCandidate;
        if (myCase == null)
        {
            return carosses;
        }
        if (myCase.row != 0)
        {
            caseCandidate = myCase.face.grid[myCase.row - 1, myCase.col];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.row != 7)
        {
            caseCandidate = myCase.face.grid[myCase.row + 1, myCase.col];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.col != 0)
        {
            caseCandidate = myCase.face.grid[myCase.row, myCase.col - 1];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.col != 7)
        {
            caseCandidate = myCase.face.grid[myCase.row, myCase.col + 1];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.row != 0 && myCase.col != 0)
        {
            caseCandidate = myCase.face.grid[myCase.row - 1, myCase.col - 1];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.row != 0 && myCase.col != 7)
        {
            caseCandidate = myCase.face.grid[myCase.row - 1, myCase.col + 1];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.row != 7 && myCase.col != 0)
        {
            caseCandidate = myCase.face.grid[myCase.row + 1, myCase.col - 1];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.row != 7 && myCase.col != 7)
        {
            caseCandidate = myCase.face.grid[myCase.row + 1, myCase.col + 1];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.row > 1)
        {
            caseCandidate = myCase.face.grid[myCase.row - 2, myCase.col];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.row < 6)
        {
            caseCandidate = myCase.face.grid[myCase.row + 2, myCase.col];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.col > 1)
        {
            caseCandidate = myCase.face.grid[myCase.row, myCase.col - 2];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        if (myCase.col < 6)
        {
            caseCandidate = myCase.face.grid[myCase.row, myCase.col + 2];
            var carosse = caseCandidate.containsCarosse();
            if (carosse != null && carosse.isHost == isHost)
            {
                carosses.Add(carosse);
            }
        }
        return carosses;
    }

    private bool passeSonTour() // DONE
    {
        if (passeTour)
        {
            passeTour = false;
            return true;
        }
        return false;
    }

    private void desactiverInvincible() // DONE
    {
        if (invincible)
        {
            invincible = false;
        }
    }

    private void desactiverPirouette() // DONE
    {
        if (pirouette)
        {
            pirouette = false;
        }
    }

    private void activerBuffHp() // DONE
    {
        if (hp + buffHp[1] > hpMax)
            hp = 10;
        else if (hp + buffHp[1] < 0)
            hp = 0;
        else
            hp += buffHp[1];

        buffHp.Remove(1);
    }

    private void activerBuffEnergie() // DONE
    {
        energieActive += buffEnergie[1];
        buffEnergie.Remove(1);
    }

    private void activerBuffBoostDegats() // DONE
    {
        boostDegats = buffBoostDegats[1];
        buffBoostDegats.Remove(1);
    }

    private void desactiverPoudre() // DONE
    {
        poudre = false;
    }

    private void desactivermainsMaudites() // DONE
    {
        mainsMaudites = false;
    }

    private void desactiverAncre() // DONE
    {
        if (
            Jeu.piratitanClient.attaques.ContainsKey("Ancre")
            && ((Ancre)Jeu.piratitanClient.attaques["Ancre"]).getTargets().Contains(this)
        )
            ((Ancre)Jeu.piratitanClient.attaques["Ancre"]).desactiverAncre(this);
        if (
            Jeu.piratitanHost.attaques.ContainsKey("Ancre")
            && ((Ancre)Jeu.piratitanHost.attaques["Ancre"]).getTargets().Contains(this)
        )
            ((Ancre)Jeu.piratitanHost.attaques["Ancre"]).desactiverAncre(this);
    }

    private void desactiverEsquive() // DONE
    {
        esquive = false;
    }

    private void desactiverFeinte() // DONE
    {
        feinte = false;
    }

    private void desactiverPasseTour() // DONE
    {
        passeTour = false;
    }

    private void activerDerniereVolonte() // DONE
    {
        derniereVolonte = false;

        List<Perso> allies = isHost ? Jeu.PersosHost() : Jeu.PersosClient();
        allies.Remove(this);

        foreach (Perso p in allies)
            p.hp = p.hp == 0 ? 0 : p.hpMax;
    }

    private void desactiverDerniereVolonte() // DONE
    {
        derniereVolonte = false;
    }

    private void persoPorteTombe() // DONE
    {
        if (myCase != null)
        {
            myCase.persoEnterCase(this);
        }
    }

    private void elfeeTombe() // DONE
    {
        if (myCase == null)
            return;

        if (myCase.containsSimpleObstacle) // cas : chute sur un simple obstacle
        {
            myCase.containsSimpleObstacle = false;
            estKO();
        }
        else if (myCase.containsDoubleObstacle) // cas : chute sur un double obstacle
        {
            myCase.containsDoubleObstacle = false;
            myCase.getDeuxiemeCaseDoubleObstacle().containsDoubleObstacle = false;
            estKO();
        }
        else if (myCase.invocationSimpleBloquante != null) // cas : chute sur invocation simple bloquante
        {
            myCase.invocationSimpleBloquante.estKO();
            estKO();
        }
        else if (myCase.invocationDoubleBloquante != null) // cas : chute sur invocation double bloquante
        {
            myCase.invocationDoubleBloquante.estKO();
            estKO();
        }
        else
        {
            Perso? perso = myCase.perso();
            if (perso != null) // cas : chute sur un perso
            {
                perso.recoitDegats(4);
                estKO();
            }
            else // cas : chute sur une case vide
            {
                recoitDegats(4);
                myCase.persoEnterCase(this);
            }
        }
    }
}

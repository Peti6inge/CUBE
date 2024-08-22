public class Perso
{
    // Attributs // DONE
    public int type { get; set; }
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
    public Dictionary<int, Attaque> attaques { get; set; }
    private static readonly Dictionary<int, Type> attaqueTypes = new Dictionary<int, Type>
    {
        { (int)Jeu.AttaqueType.dragAndDrop, typeof(DragNDrop) },
        { (int)Jeu.AttaqueType.ancre, typeof(Ancre) },
        { (int)Jeu.AttaqueType.bombe, typeof(Bombe) },
        { (int)Jeu.AttaqueType.bondDuTitan, typeof(BondDuTitan) },
        { (int)Jeu.AttaqueType.chargeDuTitan, typeof(ChargeDuTitan) },
        { (int)Jeu.AttaqueType.coffre, typeof(Coffre) },
        { (int)Jeu.AttaqueType.coupDeFeu, typeof(CoupDeFeu) },
        { (int)Jeu.AttaqueType.etincelle, typeof(Etincelle) },
        { (int)Jeu.AttaqueType.flaque, typeof(Flaque) },
        { (int)Jeu.AttaqueType.frappeDuPirate, typeof(FrappeDuPirate) },
        { (int)Jeu.AttaqueType.frappeDuTitan, typeof(FrappeDuTitan) },
        { (int)Jeu.AttaqueType.harpon, typeof(Harpon) },
        { (int)Jeu.AttaqueType.invincibilite, typeof(Invincibilite) },
        { (int)Jeu.AttaqueType.longueVue, typeof(LongueVue) },
        { (int)Jeu.AttaqueType.mouette, typeof(Mouette) },
        { (int)Jeu.AttaqueType.planche, typeof(Planche) },
        { (int)Jeu.AttaqueType.porterDeposer, typeof(PorterDeposer) },
        { (int)Jeu.AttaqueType.poudre, typeof(Poudre) },
        { (int)Jeu.AttaqueType.sabre, typeof(Sabre) },
        { (int)Jeu.AttaqueType.tonneau, typeof(Tonneau) },
        { (int)Jeu.AttaqueType.altruisme, typeof(Altruisme) },
        { (int)Jeu.AttaqueType.carosse, typeof(Carosse) },
        { (int)Jeu.AttaqueType.coupDeBaguette, typeof(CoupDeBaguette) },
        { (int)Jeu.AttaqueType.derniereVolontee, typeof(DerniereVolonte) },
        { (int)Jeu.AttaqueType.elixirAgressif, typeof(ElixirAgressif) },
        { (int)Jeu.AttaqueType.envolAtterissage, typeof(EnvolAtterissage) },
        { (int)Jeu.AttaqueType.espritElfique, typeof(EspritElfique) },
        { (int)Jeu.AttaqueType.esquive, typeof(Esquive) },
        { (int)Jeu.AttaqueType.fleche, typeof(Fleche) },
        { (int)Jeu.AttaqueType.flecheDeLumiere, typeof(FlecheDeLumiere) },
        { (int)Jeu.AttaqueType.flechePatiente, typeof(FlechePatiente) },
        { (int)Jeu.AttaqueType.hautesHerbes, typeof(HautesHerbes) },
        { (int)Jeu.AttaqueType.miniaturisation, typeof(Miniaturisation) },
        { (int)Jeu.AttaqueType.petitSoin, typeof(PetitSoin) },
        { (int)Jeu.AttaqueType.poudreBienfaisante, typeof(PoudreBienfaisante) },
        { (int)Jeu.AttaqueType.poudreSoporifique, typeof(PoudreSoporifique) },
        { (int)Jeu.AttaqueType.poudreStimulante, typeof(PoudreStimulante) },
        { (int)Jeu.AttaqueType.reanimation, typeof(Reanimation) },
        { (int)Jeu.AttaqueType.soinTotal, typeof(SoinTotal) },
        { (int)Jeu.AttaqueType.acide, typeof(Acide) },
        { (int)Jeu.AttaqueType.attire, typeof(Attire) },
        { (int)Jeu.AttaqueType.brume, typeof(Brume) },
        { (int)Jeu.AttaqueType.clone, typeof(Clone) },
        { (int)Jeu.AttaqueType.couteauDeLancee, typeof(CouteauDeLancee) },
        { (int)Jeu.AttaqueType.derobadeDeLOmbre, typeof(DerobadeDeLOmbre) },
        { (int)Jeu.AttaqueType.derobade, typeof(Derobade) },
        { (int)Jeu.AttaqueType.entrave, typeof(Entrave) },
        { (int)Jeu.AttaqueType.feinte, typeof(Feinte) },
        { (int)Jeu.AttaqueType.invisibilite, typeof(Invisibilite) },
        { (int)Jeu.AttaqueType.katana, typeof(Katana) },
        { (int)Jeu.AttaqueType.kunai, typeof(Kunai) },
        { (int)Jeu.AttaqueType.memoire, typeof(Memoire) },
        { (int)Jeu.AttaqueType.piegeALoup, typeof(PiegeALoup) },
        { (int)Jeu.AttaqueType.piegeLineaire, typeof(PiegeLineaire) },
        { (int)Jeu.AttaqueType.pirouette, typeof(Pirouette) },
        { (int)Jeu.AttaqueType.poison, typeof(Poison) },
        { (int)Jeu.AttaqueType.repousse, typeof(Repousse) },
        { (int)Jeu.AttaqueType.teleport, typeof(Teleport) },
        { (int)Jeu.AttaqueType.bouleDeFeu, typeof(BouleDeFeu) },
        { (int)Jeu.AttaqueType.bouletFantomatique, typeof(BouletFantomatique) },
        { (int)Jeu.AttaqueType.buff, typeof(Buff) },
        { (int)Jeu.AttaqueType.caseDeRapatriement, typeof(CaseDeRapatriement) },
        { (int)Jeu.AttaqueType.caseTerrifiante, typeof(CaseTerrifiante) },
        { (int)Jeu.AttaqueType.clairvoyance, typeof(Clairvoyance) },
        { (int)Jeu.AttaqueType.coupDeBaton, typeof(CoupDeBaton) },
        { (int)Jeu.AttaqueType.crapeau, typeof(Crapeau) },
        { (int)Jeu.AttaqueType.eauVaseuse, typeof(EauVaseuse) },
        { (int)Jeu.AttaqueType.feuFollet, typeof(FeuFollet) },
        { (int)Jeu.AttaqueType.gravite, typeof(Gravite) },
        { (int)Jeu.AttaqueType.inversion, typeof(Inversion) },
        { (int)Jeu.AttaqueType.jouvence, typeof(Jouvence) },
        { (int)Jeu.AttaqueType.mainsMaudites, typeof(MainsMaudites) },
        { (int)Jeu.AttaqueType.malediction, typeof(Malediction) },
        { (int)Jeu.AttaqueType.rappel, typeof(Rappel) },
        { (int)Jeu.AttaqueType.sortDeProtection, typeof(SortDeProtection) },
        { (int)Jeu.AttaqueType.transposition, typeof(Transposition) },
        { (int)Jeu.AttaqueType.voileDInvisibilite, typeof(VoileDInvisibilite) }
    };

    // Constructeur // DONE
    public Perso(int type, bool isHost, List<int> attaques)
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
            case (int)Jeu.PersoType.Roninja:
                myCase = isHost ? Jeu.host.grid[2, 2] : Jeu.client.grid[2, 2];
                break;
            case (int)Jeu.PersoType.Elfee:
                myCase = isHost ? Jeu.host.grid[2, 5] : Jeu.client.grid[2, 5];
                break;
            case (int)Jeu.PersoType.Fantomage:
                myCase = isHost ? Jeu.host.grid[5, 2] : Jeu.client.grid[5, 2];
                break;
            case (int)Jeu.PersoType.Piratitan:
                myCase = isHost ? Jeu.host.grid[5, 5] : Jeu.client.grid[5, 5];
                break;
            default:
                break;
        }
        temoinDePosition = null;
        this.attaques = new Dictionary<int, Attaque>();
        foreach (int attaque in attaques)
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

        if (attaques.ContainsKey((int)Jeu.AttaqueType.elixirAgressif))
        {
            ((ElixirAgressif)attaques[(int)Jeu.AttaqueType.elixirAgressif]).debutTour();
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.harpon))
        {
            ((Harpon)attaques[(int)Jeu.AttaqueType.harpon]).desactiver();
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.ancre))
        {
            ((Ancre)attaques[(int)Jeu.AttaqueType.ancre]).debutTour();
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.altruisme))
        {
            ((Altruisme)attaques[(int)Jeu.AttaqueType.altruisme]).debutTour();
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.brume))
        {
            ((Brume)attaques[(int)Jeu.AttaqueType.brume]).desactiver();
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.invisibilite))
        {
            ((Invisibilite)attaques[(int)Jeu.AttaqueType.invisibilite]).desactiver();
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.voileDInvisibilite))
        {
            ((VoileDInvisibilite)attaques[(int)Jeu.AttaqueType.voileDInvisibilite]).desactiver();
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.malediction))
        {
            ((Malediction)attaques[(int)Jeu.AttaqueType.malediction]).desactiver();
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

        if (attaques.ContainsKey((int)Jeu.AttaqueType.longueVue))
        {
            ((LongueVue)attaques[(int)Jeu.AttaqueType.longueVue]).desactiver();
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

        if (attaques.ContainsKey((int)Jeu.AttaqueType.longueVue))
            ((LongueVue)attaques[(int)Jeu.AttaqueType.longueVue]).desactiver();

        desactiverPoudre();

        desactivermainsMaudites();

        desactiverInvincible();

        desactiverAncre();

        desactiverPirouette();

        desactiverHarpons();

        reveal();

        if (attaques.ContainsKey((int)Jeu.AttaqueType.altruisme))
            ((Altruisme)attaques[(int)Jeu.AttaqueType.altruisme]).desactiver();

        if (sousAltruisme())
        {
            Perso elfeeAlliee;
            if (isHost)
                elfeeAlliee = Jeu.elfeeHost;
            else
                elfeeAlliee = Jeu.elfeeClient;

            ((Altruisme)elfeeAlliee.attaques[(int)Jeu.AttaqueType.altruisme]).desactiver();
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

            ((Malediction)fantomageAdverse.attaques[(int)Jeu.AttaqueType.malediction]).desactiver();
        }

        buffEnergie.Clear();

        buffHp.Clear();

        buffBoostDegats.Clear();

        if (pierre != null)
            dropPierre();

        Perso? piratitanCandidat = estPortePar();
        if (piratitanCandidat != null)
            piratitanCandidat.porte = null;

        if (porte != null)
        {
            Perso persoTombant = porte;
            porte = null;
            if (myCase != null)
                myCase.persoLeaveCase(this);
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
            case (int)Jeu.PersoType.Roninja:
                if (isHost)
                    Jeu.host.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case (int)Jeu.PersoType.Elfee:
                if (isHost)
                    Jeu.host.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case (int)Jeu.PersoType.Fantomage:
                if (isHost)
                    Jeu.host.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case (int)Jeu.PersoType.Piratitan:
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
        else if (
            caseCible.containsSimpleObstacle
            || caseCible.containsDoubleObstacle
            || caseCible.obstacleSpawn != -1
        )
            caseCible.tryToAddAround(pierre);
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

        if (!ignoreFeinte && feinte && !isAncre() && estPortePar() != null)
        {
            recoitDegats(degats, ignoreFeinte: true);
            ((Feinte)attaques[(int)Jeu.AttaqueType.feinte]).activerFeinte();
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

    public Object? nextObstacleDirection(int direction) // DONE
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
            || c.obstacleSpawn != -1
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

    public bool canTryMoveDirection(int direction) // DONE
    {
        if (myCase == null)
            return false;
        Case? c = myCase.nextCaseDirection(direction);

        return c != null && (!c.face.faceVisible(isHost) || c.seemsWalkable(this));
    }

    public bool canMoveDirection(int direction) // DONE
    {
        if (myCase == null)
            return false;
        Case? c = myCase.nextCaseDirection(direction);

        return c != null && c.isWalkable(this);
    }

    public void tryMoveDirection(int direction) // DONE
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
        int direction,
        bool glissade = false,
        bool attiranceCrapeau = false,
        bool chargeDuTitan = false,
        bool bondDuTitan = false,
        bool porterDeposer = false,
        bool attire = false,
        bool repousse = false,
        bool gravite = false,
        bool crapeauHost = false,
        bool crapeauClient = false
    ) // DONE
    {
        if (myCase == null)
            return;

        Case? c = myCase.nextCaseDirection(direction);

        Face facePrecedente = myCase.face;
        Face nouvelleFace = c.face;

        Perso? persoPorteur = estPortePar();
        if (persoPorteur != null)
            persoPorteur.porte = null;

        myCase.persoLeaveCase(this);

        if (porte != null && porte.myCase != null)
            porte.myCase.persoLeaveCase(this);

        c.persoEnterCase(
            this,
            newFace: facePrecedente != nouvelleFace,
            crapeauHost: crapeauHost,
            crapeauClient: crapeauClient
        );
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
        if (!isAncre() && pirouette)
        {
            dropPierre();
            pirouette = false;
            ((Pirouette)attaques[(int)Jeu.AttaqueType.pirouette]).activer();
        }
        else
        {
            estKO(tombeDansTrou: true);
        }
    }

    public Dictionary<int, InvocationNonBloquante> entitesInvoquees() // DONE
    {
        Dictionary<int, InvocationNonBloquante> entitesInvoquees =
            new Dictionary<int, InvocationNonBloquante>();
        InvocationNonBloquante? candidate;
        if (attaques.ContainsKey((int)Jeu.AttaqueType.bombe))
        {
            candidate = ((Bombe)attaques[(int)Jeu.AttaqueType.bombe]).getBombe();
            if (candidate != null)
            {
                entitesInvoquees.Add((int)Jeu.InvocationType.Bombe, candidate);
            }
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.espritElfique))
        {
            candidate = (
                (EspritElfique)attaques[(int)Jeu.AttaqueType.espritElfique]
            ).getEspritElfique();
            if (candidate != null)
            {
                entitesInvoquees.Add((int)Jeu.InvocationType.EspritElfique, candidate);
            }
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.mouette))
        {
            candidate = ((Mouette)attaques[(int)Jeu.AttaqueType.mouette]).getMouette();
            if (candidate != null)
            {
                entitesInvoquees.Add((int)Jeu.InvocationType.Mouette, candidate);
            }
        }

        if (attaques.ContainsKey((int)Jeu.AttaqueType.crapeau))
        {
            candidate = ((Crapeau)attaques[(int)Jeu.AttaqueType.crapeau]).getCrapeau();
            if (candidate != null)
            {
                entitesInvoquees.Add((int)Jeu.InvocationType.Crapeau, candidate);
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

    public bool isAncre() // DONE
    {
        if (
            (
                Jeu.piratitanClient.attaques.ContainsKey((int)Jeu.AttaqueType.ancre)
                && ((Ancre)Jeu.piratitanClient.attaques[(int)Jeu.AttaqueType.ancre])
                    .getTargets()
                    .Contains(this)
            )
            || (
                Jeu.piratitanHost.attaques.ContainsKey((int)Jeu.AttaqueType.ancre)
                && ((Ancre)Jeu.piratitanHost.attaques[(int)Jeu.AttaqueType.ancre])
                    .getTargets()
                    .Contains(this)
            )
        )
            return true;
        return false;
    }

    public bool sousAltruisme() // DONE
    {
        if (
            (
                Jeu.elfeeClient.attaques.ContainsKey((int)Jeu.AttaqueType.altruisme)
                && ((Altruisme)Jeu.elfeeClient.attaques[(int)Jeu.AttaqueType.altruisme]).getTarget()
                    == this
            )
            || (
                Jeu.elfeeHost.attaques.ContainsKey((int)Jeu.AttaqueType.altruisme)
                && ((Altruisme)Jeu.elfeeHost.attaques[(int)Jeu.AttaqueType.altruisme]).getTarget()
                    == this
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

    public void rappelSpawn() // DONE
    {
        if (myCase == null)
            return;

        if (isAncre())
            return;

        bool nouvelleFace =
            isHost && myCase.face != Jeu.host || !isHost && myCase.face != Jeu.client;

        if (nouvelleFace)
            desactiverHarpons();

        if (pierre != null)
            dropPierre();

        Perso? piratitanCandidat = estPortePar();
        if (piratitanCandidat != null)
            piratitanCandidat.porte = null;

        if (porte != null)
        {
            Perso persoTombant = porte;
            porte = null;
            if (myCase != null)
                myCase.persoLeaveCase(this);
            persoTombant.persoPorteTombe();
        }

        if (myCase != null)
            myCase.persoLeaveCase(this);

        enVol = false;

        switch (type)
        {
            case (int)Jeu.PersoType.Roninja:
                if (isHost)
                    Jeu.host.grid[2, 2].persoEnterCase(this, newFace: nouvelleFace);
                else
                    Jeu.client.grid[2, 2].persoEnterCase(this, newFace: nouvelleFace);
                break;
            case (int)Jeu.PersoType.Elfee:
                if (isHost)
                    Jeu.host.grid[2, 5].persoEnterCase(this, newFace: nouvelleFace);
                else
                    Jeu.client.grid[2, 5].persoEnterCase(this, newFace: nouvelleFace);
                break;
            case (int)Jeu.PersoType.Fantomage:
                if (isHost)
                    Jeu.host.grid[5, 2].persoEnterCase(this, newFace: nouvelleFace);
                else
                    Jeu.client.grid[5, 2].persoEnterCase(this, newFace: nouvelleFace);
                break;
            case (int)Jeu.PersoType.Piratitan:
                if (isHost)
                    Jeu.host.grid[5, 5].persoEnterCase(this, newFace: nouvelleFace);
                else
                    Jeu.client.grid[5, 5].persoEnterCase(this, newFace: nouvelleFace);
                break;
            default:
                break;
        }
    }

    // Méthodes private

    private bool sousInvisibilite() // DONE
    {
        if (attaques.ContainsKey((int)Jeu.AttaqueType.invisibilite))
            return ((Invisibilite)attaques[(int)Jeu.AttaqueType.invisibilite]).estActif();

        return false;
    }

    private void desactiverInvisibiliteIfOnMe(bool revealPerso = true) // DONE
    {
        if (sousInvisibilite())
            ((Invisibilite)attaques[(int)Jeu.AttaqueType.invincibilite]).desactiver(
                reveal: revealPerso
            );
    }

    private bool sousVoileDInvisibilite() // DONE
    {
        Perso candidatVoileDInvisibilite;
        if (isHost)
            candidatVoileDInvisibilite = Jeu.fantomageHost;
        else
            candidatVoileDInvisibilite = Jeu.fantomageClient;

        return candidatVoileDInvisibilite.attaques.ContainsKey(
                (int)Jeu.AttaqueType.voileDInvisibilite
            )
            && (
                (VoileDInvisibilite)
                    candidatVoileDInvisibilite.attaques[(int)Jeu.AttaqueType.voileDInvisibilite]
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
                (VoileDInvisibilite)
                    candidatVoileDInvisibilite.attaques[(int)Jeu.AttaqueType.voileDInvisibilite]
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
        if (candidatElixirAgressif.attaques.ContainsKey((int)Jeu.AttaqueType.elixirAgressif))
            (
                (ElixirAgressif)candidatElixirAgressif.attaques[(int)Jeu.AttaqueType.elixirAgressif]
            ).desactiver(this);
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
            Jeu.piratitanClient.attaques.ContainsKey((int)Jeu.AttaqueType.ancre)
            && ((Ancre)Jeu.piratitanClient.attaques[(int)Jeu.AttaqueType.ancre])
                .getTargets()
                .Contains(this)
        )
            ((Ancre)Jeu.piratitanClient.attaques[(int)Jeu.AttaqueType.ancre]).desactiverAncre(this);
        if (
            Jeu.piratitanHost.attaques.ContainsKey((int)Jeu.AttaqueType.ancre)
            && ((Ancre)Jeu.piratitanHost.attaques[(int)Jeu.AttaqueType.ancre])
                .getTargets()
                .Contains(this)
        )
            ((Ancre)Jeu.piratitanHost.attaques[(int)Jeu.AttaqueType.ancre]).desactiverAncre(this);
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

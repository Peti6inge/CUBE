public class Perso
{
    // Attributs // DONE
    public Jeu.PersoType type { get; set; }
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
    public Dictionary<Jeu.AttaqueType, Attaque> attaques { get; set; }
    private static readonly Dictionary<Jeu.AttaqueType, Type> attaqueTypes = new Dictionary<
        Jeu.AttaqueType,
        Type
    >
    {
        { Jeu.AttaqueType.dragAndDrop, typeof(DragNDrop) },
        { Jeu.AttaqueType.ancre, typeof(Ancre) },
        { Jeu.AttaqueType.bombe, typeof(Bombe) },
        { Jeu.AttaqueType.bondDuTitan, typeof(BondDuTitan) },
        { Jeu.AttaqueType.chargeDuTitan, typeof(ChargeDuTitan) },
        { Jeu.AttaqueType.coffre, typeof(Coffre) },
        { Jeu.AttaqueType.coupDeFeu, typeof(CoupDeFeu) },
        { Jeu.AttaqueType.etincelle, typeof(Etincelle) },
        { Jeu.AttaqueType.flaque, typeof(Flaque) },
        { Jeu.AttaqueType.frappeDuPirate, typeof(FrappeDuPirate) },
        { Jeu.AttaqueType.frappeDuTitan, typeof(FrappeDuTitan) },
        { Jeu.AttaqueType.harpon, typeof(Harpon) },
        { Jeu.AttaqueType.invincibilite, typeof(Invincibilite) },
        { Jeu.AttaqueType.longueVue, typeof(LongueVue) },
        { Jeu.AttaqueType.mouette, typeof(Mouette) },
        { Jeu.AttaqueType.planche, typeof(Planche) },
        { Jeu.AttaqueType.porterDeposer, typeof(PorterDeposer) },
        { Jeu.AttaqueType.poudre, typeof(Poudre) },
        { Jeu.AttaqueType.sabre, typeof(Sabre) },
        { Jeu.AttaqueType.tonneau, typeof(Tonneau) },
        { Jeu.AttaqueType.altruisme, typeof(Altruisme) },
        { Jeu.AttaqueType.carosse, typeof(Carosse) },
        { Jeu.AttaqueType.coupDeBaguette, typeof(CoupDeBaguette) },
        { Jeu.AttaqueType.derniereVolontee, typeof(DerniereVolonte) },
        { Jeu.AttaqueType.elixirAgressif, typeof(ElixirAgressif) },
        { Jeu.AttaqueType.envolAtterissage, typeof(EnvolAtterissage) },
        { Jeu.AttaqueType.espritElfique, typeof(EspritElfique) },
        { Jeu.AttaqueType.esquive, typeof(Esquive) },
        { Jeu.AttaqueType.fleche, typeof(Fleche) },
        { Jeu.AttaqueType.flecheDeLumiere, typeof(FlecheDeLumiere) },
        { Jeu.AttaqueType.flechePatiente, typeof(FlechePatiente) },
        { Jeu.AttaqueType.hautesHerbes, typeof(HautesHerbes) },
        { Jeu.AttaqueType.miniaturisation, typeof(Miniaturisation) },
        { Jeu.AttaqueType.petitSoin, typeof(PetitSoin) },
        { Jeu.AttaqueType.poudreBienfaisante, typeof(PoudreBienfaisante) },
        { Jeu.AttaqueType.poudreSoporifique, typeof(PoudreSoporifique) },
        { Jeu.AttaqueType.poudreStimulante, typeof(PoudreStimulante) },
        { Jeu.AttaqueType.reanimation, typeof(Reanimation) },
        { Jeu.AttaqueType.soinTotal, typeof(SoinTotal) },
        { Jeu.AttaqueType.acide, typeof(Acide) },
        { Jeu.AttaqueType.attire, typeof(Attire) },
        { Jeu.AttaqueType.brume, typeof(Brume) },
        { Jeu.AttaqueType.clone, typeof(Clone) },
        { Jeu.AttaqueType.couteauDeLancee, typeof(CouteauDeLancee) },
        { Jeu.AttaqueType.derobadeDeLOmbre, typeof(DerobadeDeLOmbre) },
        { Jeu.AttaqueType.derobade, typeof(Derobade) },
        { Jeu.AttaqueType.entrave, typeof(Entrave) },
        { Jeu.AttaqueType.feinte, typeof(Feinte) },
        { Jeu.AttaqueType.invisibilite, typeof(Invisibilite) },
        { Jeu.AttaqueType.katana, typeof(Katana) },
        { Jeu.AttaqueType.kunai, typeof(Kunai) },
        { Jeu.AttaqueType.memoire, typeof(Memoire) },
        { Jeu.AttaqueType.piegeALoup, typeof(PiegeALoup) },
        { Jeu.AttaqueType.piegeLineaire, typeof(PiegeLineaire) },
        { Jeu.AttaqueType.pirouette, typeof(Pirouette) },
        { Jeu.AttaqueType.poison, typeof(Poison) },
        { Jeu.AttaqueType.repousse, typeof(Repousse) },
        { Jeu.AttaqueType.teleport, typeof(Teleport) },
        { Jeu.AttaqueType.bouleDeFeu, typeof(BouleDeFeu) },
        { Jeu.AttaqueType.bouletFantomatique, typeof(BouletFantomatique) },
        { Jeu.AttaqueType.buff, typeof(Buff) },
        { Jeu.AttaqueType.caseDeRapatriement, typeof(CaseDeRapatriement) },
        { Jeu.AttaqueType.caseTerrifiante, typeof(CaseTerrifiante) },
        { Jeu.AttaqueType.clairvoyance, typeof(Clairvoyance) },
        { Jeu.AttaqueType.coupDeBaton, typeof(CoupDeBaton) },
        { Jeu.AttaqueType.crapeau, typeof(Crapeau) },
        { Jeu.AttaqueType.eauVaseuse, typeof(EauVaseuse) },
        { Jeu.AttaqueType.feuFollet, typeof(FeuFollet) },
        { Jeu.AttaqueType.gravite, typeof(Gravite) },
        { Jeu.AttaqueType.inversion, typeof(Inversion) },
        { Jeu.AttaqueType.jouvence, typeof(Jouvence) },
        { Jeu.AttaqueType.mainsMaudites, typeof(MainsMaudites) },
        { Jeu.AttaqueType.malediction, typeof(Malediction) },
        { Jeu.AttaqueType.rappel, typeof(Rappel) },
        { Jeu.AttaqueType.sortDeProtection, typeof(SortDeProtection) },
        { Jeu.AttaqueType.transposition, typeof(Transposition) },
        { Jeu.AttaqueType.voileDInvisibilite, typeof(VoileDInvisibilite) }
    };

    // Constructeur // DONE
    public Perso(Jeu.PersoType type, bool isHost, List<Jeu.AttaqueType> attaques)
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
            case Jeu.PersoType.Roninja:
                myCase = isHost ? Jeu.host.grid[2, 2] : Jeu.client.grid[2, 2];
                break;
            case Jeu.PersoType.Elfee:
                myCase = isHost ? Jeu.host.grid[2, 5] : Jeu.client.grid[2, 5];
                break;
            case Jeu.PersoType.Fantomage:
                myCase = isHost ? Jeu.host.grid[5, 2] : Jeu.client.grid[5, 2];
                break;
            case Jeu.PersoType.Piratitan:
                myCase = isHost ? Jeu.host.grid[5, 5] : Jeu.client.grid[5, 5];
                break;
            default:
                break;
        }
        temoinDePosition = null;
        this.attaques = new Dictionary<Jeu.AttaqueType, Attaque>();
        foreach (Jeu.AttaqueType attaque in attaques)
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
        if (hp > 0)
        {
            while (!passeSonTour())
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

        if (attaques.ContainsKey(Jeu.AttaqueType.elixirAgressif))
        {
            ((ElixirAgressif)attaques[Jeu.AttaqueType.elixirAgressif]).debutTour();
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.harpon))
        {
            ((Harpon)attaques[Jeu.AttaqueType.harpon]).desactiver();
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.ancre))
        {
            ((Ancre)attaques[Jeu.AttaqueType.ancre]).debutTour();
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.altruisme))
        {
            ((Altruisme)attaques[Jeu.AttaqueType.altruisme]).debutTour();
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.brume))
        {
            ((Brume)attaques[Jeu.AttaqueType.brume]).desactiver();
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.invisibilite))
        {
            ((Invisibilite)attaques[Jeu.AttaqueType.invisibilite]).desactiver();
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.voileDInvisibilite))
        {
            ((VoileDInvisibilite)attaques[Jeu.AttaqueType.voileDInvisibilite]).desactiver();
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.malediction))
        {
            ((Malediction)attaques[Jeu.AttaqueType.malediction]).desactiver();
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
                espritElfiqueCandidat.activerEspritElfique(this);
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

        if (attaques.ContainsKey(Jeu.AttaqueType.longueVue))
        {
            ((LongueVue)attaques[Jeu.AttaqueType.longueVue]).desactiver();
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

        if (attaques.ContainsKey(Jeu.AttaqueType.longueVue))
            ((LongueVue)attaques[Jeu.AttaqueType.longueVue]).desactiver();

        desactiverPoudre();

        desactivermainsMaudites();

        desactiverInvincible();

        desactiverAncre();

        desactiverPirouette();

        desactiverHarpons();

        reveal(activeFlechesPatientes: false);

        if (attaques.ContainsKey(Jeu.AttaqueType.altruisme))
            ((Altruisme)attaques[Jeu.AttaqueType.altruisme]).desactiver();

        if (sousAltruisme())
        {
            Perso elfeeAlliee;
            if (isHost)
                elfeeAlliee = Jeu.elfeeHost;
            else
                elfeeAlliee = Jeu.elfeeClient;

            ((Altruisme)elfeeAlliee.attaques[Jeu.AttaqueType.altruisme]).desactiver();
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

            ((Malediction)fantomageAdverse.attaques[Jeu.AttaqueType.malediction]).desactiver();
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
            case Jeu.PersoType.Roninja:
                if (isHost)
                    Jeu.host.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case Jeu.PersoType.Elfee:
                if (isHost)
                    Jeu.host.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case Jeu.PersoType.Fantomage:
                if (isHost)
                    Jeu.host.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
                break;
            case Jeu.PersoType.Piratitan:
                if (isHost)
                    Jeu.host.grid[5, 5].persoEnterCase(this, newFace: true, respawn: true);
                else
                    Jeu.client.grid[5, 5].persoEnterCase(this, newFace: true, respawn: true);
                break;
            default:
                break;
        }
    }

    public Jeu.EtatType dropPierre(Case? caseCible = null) // DONE
    {
        Jeu.EtatType etat = Jeu.EtatType.normal;
        caseCible = caseCible == null ? myCase : caseCible;
        if (caseCible == null || pierre == null)
            return Jeu.EtatType.ko;

        InvocationSimpleBloquante? coffreLePlusPres = caseCible.face.coffreLePlusPres(caseCible);

        if (caseCible.containsTableHost)
        {
            if (pierre.isHost)
                Jeu.PierreToTable(pierre);
            else
            {
                Jeu.EncaissePierre(pierre);
                if (!pierre.lumiere)
                    etat = Jeu.EtatType.winHost;
            }
        }
        else if (caseCible.containsTableClient)
        {
            if (pierre.isHost)
                Jeu.EncaissePierre(pierre);
            else
            {
                Jeu.PierreToTable(pierre);
                if (!pierre.lumiere)
                    etat = Jeu.EtatType.winClient;
            }
        }
        else if (coffreLePlusPres != null)
            coffreLePlusPres.activerCoffre(pierre);
        else if (caseCible.containsTrou)
            Jeu.PierreToTable(pierre);
        else if (
            caseCible.containsSimpleObstacle
            || caseCible.containsDoubleObstacle
            || caseCible.obstacleSpawn != Jeu.SpawnType.none
        )
            caseCible.tryToAddAround(pierre);
        else
            caseCible.addPierre(pierre);

        pierre = null;
        return etat;
    }

    public void miss() // DONE
    { }

    public Jeu.EtatType reveal(bool activeFlechesPatientes = true) // DONE
    {
        desactiverInvisibiliteIfOnMe(revealPerso: false);
        desactiverVoileDInvisibiliteIfOnMe(revealPerso: false);
        invisibilite = 0;
        temoinDePosition = null;
        if (activeFlechesPatientes)
            return activerFlechesPatientes();
        return Jeu.EtatType.normal;
    }

    public Jeu.EtatType infligeDegatsPerso(int degats, Perso? cible, bool reveal = true) // DONE
    {
        if (cible != null)
        {
            Jeu.EtatType etat = cible.recoitDegats((int)Math.Round(degats * boostDegats));
            if (etat != Jeu.EtatType.ko)
                etat = cible.reveal();
            return etat;
        }
        return Jeu.EtatType.normal;
    }

    public Jeu.EtatType infligeDegatsInvocationSimpleBloquante(
        int degats,
        InvocationSimpleBloquante? cible
    ) // DONE
    {
        if (cible != null)
            return cible.recoitDegats((int)Math.Round(degats * boostDegats));

        return Jeu.EtatType.normal;
    }

    public Jeu.EtatType infligeDegatsInvocationDoubleBloquante(
        int degats,
        InvocationDoubleBloquante? cible
    ) // DONE
    {
        if (cible != null)
            return cible.recoitDegats((int)Math.Round(degats * boostDegats));

        return Jeu.EtatType.normal;
    }

    public Jeu.EtatType infligeDegatsInvocationNonBloquante(
        int degats,
        InvocationNonBloquante? cible
    ) // DONE
    {
        if (cible != null)
            return cible.recoitDegats((int)Math.Round(degats * boostDegats));

        return Jeu.EtatType.normal;
    }

    public Jeu.EtatType infligeDegats(int degats, Object? cible, bool reveal = true) // DONE
    {
        if (cible is Perso)
            return infligeDegatsPerso(degats, (Perso)cible, reveal);
        else if (cible is InvocationSimpleBloquante)
            return infligeDegatsInvocationSimpleBloquante(degats, (InvocationSimpleBloquante)cible);
        else if (cible is InvocationDoubleBloquante)
            return infligeDegatsInvocationDoubleBloquante(degats, (InvocationDoubleBloquante)cible);
        else if (cible is InvocationNonBloquante)
            return infligeDegatsInvocationNonBloquante(degats, (InvocationNonBloquante)cible);

        return Jeu.EtatType.normal;
    }

    public Jeu.EtatType recoitDegats(int degats, bool ignoreFeinte = false) // DONE
    {
        if (hp <= 0)
            return Jeu.EtatType.ko;

        reveal(activeFlechesPatientes: false);

        if (!ignoreFeinte && feinte && !isAncre() && estPortePar() != null)
        {
            Jeu.EtatType etat = recoitDegats(degats, ignoreFeinte: true);
            if (etat != Jeu.EtatType.ko)
                etat = ((Feinte)attaques[Jeu.AttaqueType.feinte]).activerFeinte();
            return etat;
        }

        if (invincible)
            return activerFlechesPatientes();

        if (esquive)
        {
            esquive = false;
            return activerFlechesPatientes();
        }

        if (sousAltruisme())
        {
            if (isHost)
                Jeu.elfeeHost.recoitDegats(degats);
            else
                Jeu.elfeeClient.recoitDegats(degats);
            return activerFlechesPatientes();
        }
        hp -= Math.Min(hp, degats);
        if (hp <= 0)
        {
            estKO();
            return Jeu.EtatType.ko;
        }
        else if (enVol)
        {
            enVol = false;
            if (elfeeTombe() == Jeu.EtatType.ko)
                return Jeu.EtatType.ko;
        }
        return activerFlechesPatientes();
    }

    public void recoitSoin(int soin) // DONE
    {
        hp = Math.Min(hpMax, hp + soin);
    }

    public Object? nextObstacleDirection(Jeu.DirectionType direction) // DONE
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
            || c.obstacleSpawn != Jeu.SpawnType.none
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

    public bool canTryMoveDirection(Jeu.DirectionType direction) // DONE
    {
        if (myCase == null)
            return false;
        Case? c = myCase.nextCaseDirection(direction);

        return c != null && (!c.face.faceVisible(isHost) || c.seemsWalkable(this));
    }

    public bool canMoveDirection(Jeu.DirectionType direction) // DONE
    {
        if (myCase == null)
            return false;
        Case? c = myCase.nextCaseDirection(direction);

        return c != null && c.isWalkable(this);
    }

    public void tryMoveDirection(Jeu.DirectionType direction) // DONE
    {
        energieActive--;
        if (canMoveDirection(direction))
            moveDirection(direction);
        else
            miss();
    }

    public Jeu.EtatType moveDirection(
        Jeu.DirectionType direction,
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
            return Jeu.EtatType.ko;

        Case? c = myCase.nextCaseDirection(direction);

        Face facePrecedente = myCase.face;
        Face nouvelleFace = c.face;

        Perso? persoPorteur = estPortePar();
        if (persoPorteur != null)
            persoPorteur.porte = null;

        myCase.persoLeaveCase(this);

        if (porte != null && porte.myCase != null)
            porte.myCase.persoLeaveCase(this);

        return c.persoEnterCase(
            this,
            direction: direction,
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

    public Jeu.EtatType tombeDansTrou() // DONE
    {
        if (!isAncre() && pirouette)
        {
            dropPierre();
            pirouette = false;
            return ((Pirouette)attaques[Jeu.AttaqueType.pirouette]).activer();
        }
        else
        {
            estKO(tombeDansTrou: true);
            return Jeu.EtatType.ko;
        }
    }

    public Dictionary<Jeu.InvocationType, InvocationNonBloquante> entitesInvoquees() // DONE
    {
        Dictionary<Jeu.InvocationType, InvocationNonBloquante> entitesInvoquees =
            new Dictionary<Jeu.InvocationType, InvocationNonBloquante>();
        InvocationNonBloquante? candidate;
        if (attaques.ContainsKey(Jeu.AttaqueType.bombe))
        {
            candidate = ((Bombe)attaques[Jeu.AttaqueType.bombe]).getBombe();
            if (candidate != null)
            {
                entitesInvoquees.Add(Jeu.InvocationType.Bombe, candidate);
            }
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.espritElfique))
        {
            candidate = ((EspritElfique)attaques[Jeu.AttaqueType.espritElfique]).getEspritElfique();
            if (candidate != null)
            {
                entitesInvoquees.Add(Jeu.InvocationType.EspritElfique, candidate);
            }
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.mouette))
        {
            candidate = ((Mouette)attaques[Jeu.AttaqueType.mouette]).getMouette();
            if (candidate != null)
            {
                entitesInvoquees.Add(Jeu.InvocationType.Mouette, candidate);
            }
        }

        if (attaques.ContainsKey(Jeu.AttaqueType.crapeau))
        {
            candidate = ((Crapeau)attaques[Jeu.AttaqueType.crapeau]).getCrapeau();
            if (candidate != null)
            {
                entitesInvoquees.Add(Jeu.InvocationType.Crapeau, candidate);
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
                Jeu.piratitanClient.attaques.ContainsKey(Jeu.AttaqueType.ancre)
                && ((Ancre)Jeu.piratitanClient.attaques[Jeu.AttaqueType.ancre])
                    .getTargets()
                    .Contains(this)
            )
            || (
                Jeu.piratitanHost.attaques.ContainsKey(Jeu.AttaqueType.ancre)
                && ((Ancre)Jeu.piratitanHost.attaques[Jeu.AttaqueType.ancre])
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
                Jeu.elfeeClient.attaques.ContainsKey(Jeu.AttaqueType.altruisme)
                && ((Altruisme)Jeu.elfeeClient.attaques[Jeu.AttaqueType.altruisme]).getTarget()
                    == this
            )
            || (
                Jeu.elfeeHost.attaques.ContainsKey(Jeu.AttaqueType.altruisme)
                && ((Altruisme)Jeu.elfeeHost.attaques[Jeu.AttaqueType.altruisme]).getTarget()
                    == this
            )
        )
            return true;
        return false;
    }

    public Jeu.EtatType activerFlechesPatientes() // DONE
    {
        if (myCase == null)
            return Jeu.EtatType.ko;

        int degats = isHost ? myCase.face.flechesPatientesClient : myCase.face.flechesPatientesHost;

        if (degats == 0)
            return Jeu.EtatType.normal;

        if (isHost)
        {
            myCase.face.flechesPatientesClient = 0;
            return Jeu.elfeeClient.infligeDegats(degats, this);
        }
        else
        {
            myCase.face.flechesPatientesHost = 0;
            return Jeu.elfeeHost.infligeDegats(degats, this);
        }
    }

    public Jeu.EtatType rappelSpawn() // DONE
    {
        if (myCase == null)
            return Jeu.EtatType.ko;

        if (isAncre())
            return Jeu.EtatType.normal;

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
            case Jeu.PersoType.Roninja:
                if (isHost)
                    return Jeu
                        .host.grid[2, 2]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[2, 2]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
            case Jeu.PersoType.Elfee:
                if (isHost)
                    return Jeu
                        .host.grid[2, 5]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[2, 5]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
            case Jeu.PersoType.Fantomage:
                if (isHost)
                    return Jeu
                        .host.grid[5, 2]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[5, 2]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
            case Jeu.PersoType.Piratitan:
                if (isHost)
                    return Jeu
                        .host.grid[5, 5]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[5, 5]
                        .persoEnterCase(
                            this,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
            default:
                return Jeu.EtatType.normal;
        }
    }

    public bool sousInvisibilite() // DONE
    {
        if (attaques.ContainsKey(Jeu.AttaqueType.invisibilite))
            return ((Invisibilite)attaques[Jeu.AttaqueType.invisibilite]).estActif();

        return false;
    }

    public bool sousVoileDInvisibilite() // DONE
    {
        Perso candidatVoileDInvisibilite;
        if (isHost)
            candidatVoileDInvisibilite = Jeu.fantomageHost;
        else
            candidatVoileDInvisibilite = Jeu.fantomageClient;

        return candidatVoileDInvisibilite.attaques.ContainsKey(Jeu.AttaqueType.voileDInvisibilite)
            && (
                (VoileDInvisibilite)
                    candidatVoileDInvisibilite.attaques[Jeu.AttaqueType.voileDInvisibilite]
            ).getPersoCible() == this;
    }

    // Méthodes private

    private void desactiverInvisibiliteIfOnMe(bool revealPerso = true) // DONE
    {
        if (sousInvisibilite())
            ((Invisibilite)attaques[Jeu.AttaqueType.invincibilite]).desactiver(reveal: revealPerso);
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
                    candidatVoileDInvisibilite.attaques[Jeu.AttaqueType.voileDInvisibilite]
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
        if (candidatElixirAgressif.attaques.ContainsKey(Jeu.AttaqueType.elixirAgressif))
            (
                (ElixirAgressif)candidatElixirAgressif.attaques[Jeu.AttaqueType.elixirAgressif]
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
            Jeu.piratitanClient.attaques.ContainsKey(Jeu.AttaqueType.ancre)
            && ((Ancre)Jeu.piratitanClient.attaques[Jeu.AttaqueType.ancre])
                .getTargets()
                .Contains(this)
        )
            ((Ancre)Jeu.piratitanClient.attaques[Jeu.AttaqueType.ancre]).desactiverAncre(this);
        if (
            Jeu.piratitanHost.attaques.ContainsKey(Jeu.AttaqueType.ancre)
            && ((Ancre)Jeu.piratitanHost.attaques[Jeu.AttaqueType.ancre])
                .getTargets()
                .Contains(this)
        )
            ((Ancre)Jeu.piratitanHost.attaques[Jeu.AttaqueType.ancre]).desactiverAncre(this);
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

    private Jeu.EtatType persoPorteTombe() // DONE
    {
        if (myCase != null)
            return myCase.persoEnterCase(this);
        return Jeu.EtatType.normal;
    }

    private Jeu.EtatType elfeeTombe() // DONE
    {
        if (myCase == null)
            return Jeu.EtatType.ko;

        if (myCase.containsSimpleObstacle) // cas : chute sur un simple obstacle
        {
            myCase.containsSimpleObstacle = false;
            estKO();
            return Jeu.EtatType.ko;
        }
        else if (myCase.containsDoubleObstacle) // cas : chute sur un double obstacle
        {
            myCase.containsDoubleObstacle = false;
            myCase.getDeuxiemeCaseDoubleObstacle().containsDoubleObstacle = false;
            estKO();
            return Jeu.EtatType.ko;
        }
        else if (myCase.invocationSimpleBloquante != null) // cas : chute sur invocation simple bloquante
        {
            myCase.invocationSimpleBloquante.estKO();
            estKO();
            return Jeu.EtatType.ko;
        }
        else if (myCase.invocationDoubleBloquante != null) // cas : chute sur invocation double bloquante
        {
            myCase.invocationDoubleBloquante.estKO();
            estKO();
            return Jeu.EtatType.ko;
        }
        else
        {
            Perso? perso = myCase.perso();
            if (perso != null) // cas : chute sur un perso
            {
                perso.recoitDegats(4);
                estKO();
                return Jeu.EtatType.ko;
            }
            else // cas : chute sur une case vide
            {
                Jeu.EtatType etat = recoitDegats(4);
                if (etat != Jeu.EtatType.ko)
                    etat = myCase.persoEnterCase(this);
                return etat;
            }
        }
    }
}

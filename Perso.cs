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
    public Case? temoinDePositionClairvoyance { get; set; }
    public Case? temoinDePositionMissTeleport { get; set; }
    public Dictionary<Features.AttaqueType, Attaque> attaques { get; set; }
    private static readonly Dictionary<Features.AttaqueType, Type> attaqueTypes = new Dictionary<
        Features.AttaqueType,
        Type
    >
    {
        { Features.AttaqueType.dragAndDrop, typeof(DragNDrop) },
        { Features.AttaqueType.ancre, typeof(Ancre) },
        { Features.AttaqueType.bombe, typeof(Bombe) },
        { Features.AttaqueType.bondDuTitan, typeof(BondDuTitan) },
        { Features.AttaqueType.chargeDuTitan, typeof(ChargeDuTitan) },
        { Features.AttaqueType.coffre, typeof(Coffre) },
        { Features.AttaqueType.coupDeFeu, typeof(CoupDeFeu) },
        { Features.AttaqueType.etincelle, typeof(Etincelle) },
        { Features.AttaqueType.flaque, typeof(Flaque) },
        { Features.AttaqueType.frappeDuPirate, typeof(FrappeDuPirate) },
        { Features.AttaqueType.frappeDuTitan, typeof(FrappeDuTitan) },
        { Features.AttaqueType.harpon, typeof(Harpon) },
        { Features.AttaqueType.invincibilite, typeof(Invincibilite) },
        { Features.AttaqueType.longueVue, typeof(LongueVue) },
        { Features.AttaqueType.mouette, typeof(Mouette) },
        { Features.AttaqueType.planche, typeof(Planche) },
        { Features.AttaqueType.porterDeposer, typeof(PorterDeposer) },
        { Features.AttaqueType.poudre, typeof(Poudre) },
        { Features.AttaqueType.sabre, typeof(Sabre) },
        { Features.AttaqueType.tonneau, typeof(Tonneau) },
        { Features.AttaqueType.altruisme, typeof(Altruisme) },
        { Features.AttaqueType.carosse, typeof(Carosse) },
        { Features.AttaqueType.coupDeBaguette, typeof(CoupDeBaguette) },
        { Features.AttaqueType.derniereVolontee, typeof(DerniereVolonte) },
        { Features.AttaqueType.elixirAgressif, typeof(ElixirAgressif) },
        { Features.AttaqueType.envolAtterissage, typeof(EnvolAtterissage) },
        { Features.AttaqueType.espritElfique, typeof(EspritElfique) },
        { Features.AttaqueType.esquive, typeof(Esquive) },
        { Features.AttaqueType.fleche, typeof(Fleche) },
        { Features.AttaqueType.flecheDeLumiere, typeof(FlecheDeLumiere) },
        { Features.AttaqueType.flechePatiente, typeof(FlechePatiente) },
        { Features.AttaqueType.hautesHerbes, typeof(HautesHerbes) },
        { Features.AttaqueType.miniaturisation, typeof(Miniaturisation) },
        { Features.AttaqueType.petitSoin, typeof(PetitSoin) },
        { Features.AttaqueType.poudreBienfaisante, typeof(PoudreBienfaisante) },
        { Features.AttaqueType.poudreSoporifique, typeof(PoudreSoporifique) },
        { Features.AttaqueType.poudreStimulante, typeof(PoudreStimulante) },
        { Features.AttaqueType.reanimation, typeof(Reanimation) },
        { Features.AttaqueType.soinTotal, typeof(SoinTotal) },
        { Features.AttaqueType.acide, typeof(Acide) },
        { Features.AttaqueType.attire, typeof(Attire) },
        { Features.AttaqueType.brume, typeof(Brume) },
        { Features.AttaqueType.clone, typeof(Clone) },
        { Features.AttaqueType.couteauDeLancee, typeof(CouteauDeLancee) },
        { Features.AttaqueType.derobadeDeLOmbre, typeof(DerobadeDeLOmbre) },
        { Features.AttaqueType.derobade, typeof(Derobade) },
        { Features.AttaqueType.entrave, typeof(Entrave) },
        { Features.AttaqueType.feinte, typeof(Feinte) },
        { Features.AttaqueType.invisibilite, typeof(Invisibilite) },
        { Features.AttaqueType.katana, typeof(Katana) },
        { Features.AttaqueType.kunai, typeof(Kunai) },
        { Features.AttaqueType.memoire, typeof(Memoire) },
        { Features.AttaqueType.piegeALoup, typeof(PiegeALoup) },
        { Features.AttaqueType.piegeLineaire, typeof(PiegeLineaire) },
        { Features.AttaqueType.pirouette, typeof(Pirouette) },
        { Features.AttaqueType.poison, typeof(Poison) },
        { Features.AttaqueType.repousse, typeof(Repousse) },
        { Features.AttaqueType.teleport, typeof(Teleport) },
        { Features.AttaqueType.bouleDeFeu, typeof(BouleDeFeu) },
        { Features.AttaqueType.bouletFantomatique, typeof(BouletFantomatique) },
        { Features.AttaqueType.buff, typeof(Buff) },
        { Features.AttaqueType.caseDeRapatriement, typeof(CaseDeRapatriement) },
        { Features.AttaqueType.caseTerrifiante, typeof(CaseTerrifiante) },
        { Features.AttaqueType.clairvoyance, typeof(Clairvoyance) },
        { Features.AttaqueType.coupDeBaton, typeof(CoupDeBaton) },
        { Features.AttaqueType.crapeau, typeof(Crapeau) },
        { Features.AttaqueType.eauVaseuse, typeof(EauVaseuse) },
        { Features.AttaqueType.feuFollet, typeof(FeuFollet) },
        { Features.AttaqueType.gravite, typeof(Gravite) },
        { Features.AttaqueType.inversion, typeof(Inversion) },
        { Features.AttaqueType.jouvence, typeof(Jouvence) },
        { Features.AttaqueType.mainsMaudites, typeof(MainsMaudites) },
        { Features.AttaqueType.malediction, typeof(Malediction) },
        { Features.AttaqueType.rappel, typeof(Rappel) },
        { Features.AttaqueType.sortDeProtection, typeof(SortDeProtection) },
        { Features.AttaqueType.transposition, typeof(Transposition) },
        { Features.AttaqueType.voileDInvisibilite, typeof(VoileDInvisibilite) }
    };

    // Constructeur // DONE
    public Perso(Jeu.PersoType type, bool isHost, List<Features.AttaqueType> attaques)
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
        temoinDePositionClairvoyance = null;
        temoinDePositionMissTeleport = null;
        this.attaques = new Dictionary<Features.AttaqueType, Attaque>();
        foreach (Features.AttaqueType attaque in attaques)
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

    public void play() //TODO
    {
        debutTour();
        if (hp > 0)
        {
            while (!passeSonTour())
            {
                //TODO : Ecouter une action à la fois
            }
        }

        finTour();
    }

    public void debutTour() // DONE
    {
        foreach (Attaque attaque in attaques.Values)
            attaque.debutTour();

        energieActive = energie;

        desactiverInvincible();

        desactiverPirouette();

        desactiverDerniereVolonte();

        temoinDePositionMissTeleport = null;

        if (attaques.ContainsKey(Features.AttaqueType.clairvoyance))
            ((Clairvoyance)attaques[Features.AttaqueType.clairvoyance]).desactiverClairvoyance();

        if (attaques.ContainsKey(Features.AttaqueType.elixirAgressif))
            ((ElixirAgressif)attaques[Features.AttaqueType.elixirAgressif]).debutTour();

        if (attaques.ContainsKey(Features.AttaqueType.harpon))
            ((Harpon)attaques[Features.AttaqueType.harpon]).desactiver();

        if (attaques.ContainsKey(Features.AttaqueType.ancre))
            ((Ancre)attaques[Features.AttaqueType.ancre]).debutTour();

        if (attaques.ContainsKey(Features.AttaqueType.altruisme))
            ((Altruisme)attaques[Features.AttaqueType.altruisme]).debutTour();

        if (attaques.ContainsKey(Features.AttaqueType.brume))
            ((Brume)attaques[Features.AttaqueType.brume]).desactiver();

        if (attaques.ContainsKey(Features.AttaqueType.invisibilite))
            ((Invisibilite)attaques[Features.AttaqueType.invisibilite]).desactiver();

        if (attaques.ContainsKey(Features.AttaqueType.voileDInvisibilite))
            ((VoileDInvisibilite)attaques[Features.AttaqueType.voileDInvisibilite]).desactiver();

        if (attaques.ContainsKey(Features.AttaqueType.malediction))
            ((Malediction)attaques[Features.AttaqueType.malediction]).desactiver();

        if (buffHp.ContainsKey(1))
            activerBuffHp();

        List<int> keys = new List<int>(buffHp.Keys);
        keys.Sort();
        foreach (int key in keys)
            buffHp[key] -= 1;

        if (buffEnergie.ContainsKey(1))
            activerBuffEnergie();

        keys = new List<int>(buffEnergie.Keys);
        keys.Sort();
        foreach (int key in keys)
            buffEnergie[key] -= 1;

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
            activerBuffBoostDegats();

        keys = new List<int>(buffBoostDegats.Keys);
        keys.Sort();
        foreach (int key in keys)
            buffBoostDegats[key] -= 1;

        if (coolDownKO != 0)
        {
            coolDownKO--;
            if (coolDownKO == 0)
                respawn();
        }
    }

    public void finTour() // DONE
    {
        desactiverPoudre();

        desactivermainsMaudites();

        if (attaques.ContainsKey(Features.AttaqueType.longueVue))
        {
            ((LongueVue)attaques[Features.AttaqueType.longueVue]).desactiver();
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
        temoinDePositionClairvoyance = null;
        temoinDePositionMissTeleport = null;
        hp = 0;
        hpMax = 10;
        miniaturisation = false;

        if (attaques.ContainsKey(Features.AttaqueType.longueVue))
            ((LongueVue)attaques[Features.AttaqueType.longueVue]).desactiver();

        desactiverPoudre();

        desactivermainsMaudites();

        desactiverInvincible();

        desactiverAncre();

        desactiverPirouette();

        desactiverHarpons();

        reveal(activeFlechesPatientes: false);

        if (attaques.ContainsKey(Features.AttaqueType.altruisme))
            ((Altruisme)attaques[Features.AttaqueType.altruisme]).desactiver();

        if (sousAltruisme())
        {
            Perso elfeeAlliee;
            if (isHost)
                elfeeAlliee = Jeu.elfeeHost;
            else
                elfeeAlliee = Jeu.elfeeClient;

            ((Altruisme)elfeeAlliee.attaques[Features.AttaqueType.altruisme]).desactiver();
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

            ((Malediction)fantomageAdverse.attaques[Features.AttaqueType.malediction]).desactiver();
        }

        buffEnergie.Clear();

        buffHp.Clear();

        buffBoostDegats.Clear();

        if (pierre != null)
            dropPierre();

        Perso? piratitanCandidat = estPortePar();
        if (piratitanCandidat != null)
            piratitanCandidat.porte = null;

        Face? facePrecedente = myCase != null ? myCase.face : null;

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

        if (facePrecedente != null)
            facePrecedente.maJEmbrumage();
    }

    public Jeu.EtatType respawn() // DONE
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
                    return Jeu.host.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    return Jeu.client.grid[2, 2].persoEnterCase(this, newFace: true, respawn: true);
            case Jeu.PersoType.Elfee:
                if (isHost)
                    return Jeu.host.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
                else
                    return Jeu.client.grid[2, 5].persoEnterCase(this, newFace: true, respawn: true);
            case Jeu.PersoType.Fantomage:
                if (isHost)
                    return Jeu.host.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
                else
                    return Jeu.client.grid[5, 2].persoEnterCase(this, newFace: true, respawn: true);
            case Jeu.PersoType.Piratitan:
                if (isHost)
                    return Jeu.host.grid[5, 5].persoEnterCase(this, newFace: true, respawn: true);
                else
                    return Jeu.client.grid[5, 5].persoEnterCase(this, newFace: true, respawn: true);
            default:
                return Jeu.EtatType.ok;
        }
    }

    public Jeu.EtatType dropPierre(Case? caseCible = null) // DONE
    {
        Jeu.EtatType etat = Jeu.EtatType.ok;
        caseCible = caseCible == null ? myCase : caseCible;
        if (caseCible == null || pierre == null)
            return Jeu.EtatType.ko;

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
        if (myCase == null)
            return Jeu.EtatType.ko;

        desactiverInvisibiliteIfOnMe(revealPerso: false);
        desactiverVoileDInvisibiliteIfOnMe(revealPerso: false);
        invisibilite = 0;

        bool containsBrumeAdverse = isHost
              ? myCase.containsBrumeRoninjaClient
              : myCase.containsBrumeRoninjaHost;

        if (activeFlechesPatientes
            && !containsBrumeAdverse)
            return activerFlechesPatientes();
        return Jeu.EtatType.ok;
    }

    public Jeu.EtatType infligeDegatsPerso(int degats, Perso? cible, bool reveal = true) // DONE
    {
        if (cible != null)
            return cible.recoitDegats((int)Math.Round(degats * boostDegats));

        return Jeu.EtatType.ok;
    }

    public Jeu.EtatType infligeDegatsInvocationSimpleBloquante(
        int degats,
        InvocationSimpleBloquante? cible
    ) // DONE
    {
        if (cible != null)
            return cible.recoitDegats((int)Math.Round(degats * boostDegats));

        return Jeu.EtatType.ok;
    }

    public Jeu.EtatType infligeDegatsInvocationDoubleBloquante(
        int degats,
        InvocationDoubleBloquante? cible
    ) // DONE
    {
        if (cible != null)
            return cible.recoitDegats((int)Math.Round(degats * boostDegats));

        return Jeu.EtatType.ok;
    }

    public Jeu.EtatType infligeDegatsInvocationNonBloquante(
        int degats,
        InvocationNonBloquante? cible
    ) // DONE
    {
        if (cible != null)
            return cible.recoitDegats((int)Math.Round(degats * boostDegats));

        return Jeu.EtatType.ok;
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

        return Jeu.EtatType.ok;
    }

    public Jeu.EtatType recoitDegats(int degats, bool ignoreFeinteEtFlechesPatientes = false) // DONE
    {
        if (myCase == null)
            return Jeu.EtatType.ko;

        if (hp <= 0)
            return Jeu.EtatType.ko;

        reveal(activeFlechesPatientes: false);

        bool containsBrumeAdverse;

        if (!ignoreFeinteEtFlechesPatientes && feinte && !isAncre() && estPortePar() != null)
        {
            Jeu.EtatType etat = recoitDegats(degats, ignoreFeinteEtFlechesPatientes: true);
            if (etat != Jeu.EtatType.ko)
                etat = ((Feinte)attaques[Features.AttaqueType.feinte]).activerFeinte();
            return etat;
        }

        if (invincible)
        {
            containsBrumeAdverse = isHost
                                        ? myCase.containsBrumeRoninjaClient
                                        : myCase.containsBrumeRoninjaHost;
            if (!containsBrumeAdverse && !ignoreFeinteEtFlechesPatientes)
                return activerFlechesPatientes();

            return Jeu.EtatType.ok;
        }
        if (esquive)
        {
            esquive = false;
            containsBrumeAdverse = isHost
                                        ? myCase.containsBrumeRoninjaClient
                                        : myCase.containsBrumeRoninjaHost;
            if (!containsBrumeAdverse && !ignoreFeinteEtFlechesPatientes)
                return activerFlechesPatientes();

            return Jeu.EtatType.ok;
        }

        if (sousAltruisme())
        {
            if (isHost)
                Jeu.elfeeHost.recoitDegats(degats);
            else
                Jeu.elfeeClient.recoitDegats(degats);

            containsBrumeAdverse = isHost
                                   ? myCase.containsBrumeRoninjaClient
                                   : myCase.containsBrumeRoninjaHost;
            if (!containsBrumeAdverse && !ignoreFeinteEtFlechesPatientes)
                return activerFlechesPatientes();

            return Jeu.EtatType.ok;
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
            Jeu.EtatType etatApresElfeeTombe = elfeeTombe();
            if (etatApresElfeeTombe != Jeu.EtatType.ok)
                return etatApresElfeeTombe;
        }

        containsBrumeAdverse = isHost
                                       ? myCase.containsBrumeRoninjaClient
                                       : myCase.containsBrumeRoninjaHost;
        if (!containsBrumeAdverse && !ignoreFeinteEtFlechesPatientes)
            return activerFlechesPatientes();

        return Jeu.EtatType.ok;
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

        bool leaveCamouflage = myCase.persoLeaveCase(this);

        if (porte != null && porte.myCase != null)
            porte.myCase.persoLeaveCase(porte);

        Jeu.EtatType etatApresEnterCase = c.persoEnterCase(
            this,
            leaveCamouflage: leaveCamouflage,
            direction: direction,
            newFace: facePrecedente != nouvelleFace,
            crapeauHost: crapeauHost,
            crapeauClient: crapeauClient
        );

        if (etatApresEnterCase == Jeu.EtatType.ko)
            return Jeu.EtatType.ko;

        return Jeu.EtatType.caseLeaved;
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
            return ((Pirouette)attaques[Features.AttaqueType.pirouette]).activer();
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
        if (attaques.ContainsKey(Features.AttaqueType.bombe))
        {
            candidate = ((Bombe)attaques[Features.AttaqueType.bombe]).getBombe();
            if (candidate != null)
            {
                entitesInvoquees.Add(Jeu.InvocationType.Bombe, candidate);
            }
        }

        if (attaques.ContainsKey(Features.AttaqueType.espritElfique))
        {
            candidate = ((EspritElfique)attaques[Features.AttaqueType.espritElfique]).getEspritElfique();
            if (candidate != null)
            {
                entitesInvoquees.Add(Jeu.InvocationType.EspritElfique, candidate);
            }
        }

        if (attaques.ContainsKey(Features.AttaqueType.mouette))
        {
            candidate = ((Mouette)attaques[Features.AttaqueType.mouette]).getMouette();
            if (candidate != null)
            {
                entitesInvoquees.Add(Jeu.InvocationType.Mouette, candidate);
            }
        }

        if (attaques.ContainsKey(Features.AttaqueType.crapeau))
        {
            candidate = ((Crapeau)attaques[Features.AttaqueType.crapeau]).getCrapeau();
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
                Jeu.piratitanClient.attaques.ContainsKey(Features.AttaqueType.ancre)
                && ((Ancre)Jeu.piratitanClient.attaques[Features.AttaqueType.ancre])
                    .getTargets()
                    .Contains(this)
            )
            || (
                Jeu.piratitanHost.attaques.ContainsKey(Features.AttaqueType.ancre)
                && ((Ancre)Jeu.piratitanHost.attaques[Features.AttaqueType.ancre])
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
                Jeu.elfeeClient.attaques.ContainsKey(Features.AttaqueType.altruisme)
                && ((Altruisme)Jeu.elfeeClient.attaques[Features.AttaqueType.altruisme]).getTarget()
                    == this
            )
            || (
                Jeu.elfeeHost.attaques.ContainsKey(Features.AttaqueType.altruisme)
                && ((Altruisme)Jeu.elfeeHost.attaques[Features.AttaqueType.altruisme]).getTarget()
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
            return Jeu.EtatType.ok;

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
            return Jeu.EtatType.ok;

        bool nouvelleFace =
            isHost && myCase.face != Jeu.host || !isHost && myCase.face != Jeu.client;

        if (nouvelleFace)
            desactiverHarpons();

        if (pierre != null)
            dropPierre();

        Perso? piratitanCandidat = estPortePar();
        if (piratitanCandidat != null)
            piratitanCandidat.porte = null;

        bool leaveCamouflage = false;

        if (porte != null)
        {
            Perso persoTombant = porte;
            porte = null;
            if (myCase != null)
                leaveCamouflage = myCase.persoLeaveCase(this);
            persoTombant.persoPorteTombe();
        }

        if (myCase != null)
            leaveCamouflage = myCase.persoLeaveCase(this);

        enVol = false;

        switch (type)
        {
            case Jeu.PersoType.Roninja:
                if (isHost)
                    return Jeu
                        .host.grid[2, 2]
                        .persoEnterCase(
                            this,
                            leaveCamouflage: leaveCamouflage,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[2, 2]
                        .persoEnterCase(
                            this,
                            leaveCamouflage: leaveCamouflage,
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
                            leaveCamouflage: leaveCamouflage,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[2, 5]
                        .persoEnterCase(
                            this,
                            leaveCamouflage: leaveCamouflage,
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
                            leaveCamouflage: leaveCamouflage,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[5, 2]
                        .persoEnterCase(
                            this,
                            leaveCamouflage: leaveCamouflage,
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
                            leaveCamouflage: leaveCamouflage,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
                else
                    return Jeu
                        .client.grid[5, 5]
                        .persoEnterCase(
                            this,
                            leaveCamouflage: leaveCamouflage,
                            newFace: nouvelleFace,
                            crapeauHost: true,
                            crapeauClient: true
                        );
            default:
                return Jeu.EtatType.caseLeaved;
        }
    }

    public bool sousInvisibilite() // DONE
    {
        if (attaques.ContainsKey(Features.AttaqueType.invisibilite))
            return ((Invisibilite)attaques[Features.AttaqueType.invisibilite]).estActif();

        return false;
    }

    public bool sousVoileDInvisibilite() // DONE
    {
        Perso candidatVoileDInvisibilite;
        if (isHost)
            candidatVoileDInvisibilite = Jeu.fantomageHost;
        else
            candidatVoileDInvisibilite = Jeu.fantomageClient;

        return candidatVoileDInvisibilite.attaques.ContainsKey(Features.AttaqueType.voileDInvisibilite)
            && (
                (VoileDInvisibilite)
                    candidatVoileDInvisibilite.attaques[Features.AttaqueType.voileDInvisibilite]
            ).getPersoCible() == this;
    }

    // Méthodes private

    private Jeu.EtatType desactiverInvisibiliteIfOnMe(bool revealPerso = true) // DONE
    {
        if (sousInvisibilite())
            return ((Invisibilite)attaques[Features.AttaqueType.invincibilite]).desactiver(reveal: revealPerso);
        return Jeu.EtatType.ok;
    }

    private Jeu.EtatType desactiverVoileDInvisibiliteIfOnMe(bool revealPerso = true) // DONE
    {
        if (sousVoileDInvisibilite())
        {
            Perso candidatVoileDInvisibilite;
            if (isHost)
                candidatVoileDInvisibilite = Jeu.fantomageHost;
            else
                candidatVoileDInvisibilite = Jeu.fantomageClient;
            return (
                   (VoileDInvisibilite)
                       candidatVoileDInvisibilite.attaques[Features.AttaqueType.voileDInvisibilite]
               ).desactiver(reveal: revealPerso);
        }
        return Jeu.EtatType.ok;
    }

    private void desactiverElixirAgressifIfOnMe() // DONE
    {
        Perso candidatElixirAgressif;
        if (isHost)
            candidatElixirAgressif = Jeu.elfeeHost;
        else
            candidatElixirAgressif = Jeu.elfeeClient;
        if (candidatElixirAgressif.attaques.ContainsKey(Features.AttaqueType.elixirAgressif))
            (
                (ElixirAgressif)candidatElixirAgressif.attaques[Features.AttaqueType.elixirAgressif]
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
            Jeu.piratitanClient.attaques.ContainsKey(Features.AttaqueType.ancre)
            && ((Ancre)Jeu.piratitanClient.attaques[Features.AttaqueType.ancre])
                .getTargets()
                .Contains(this)
        )
            ((Ancre)Jeu.piratitanClient.attaques[Features.AttaqueType.ancre]).desactiverAncre(this);
        if (
            Jeu.piratitanHost.attaques.ContainsKey(Features.AttaqueType.ancre)
            && ((Ancre)Jeu.piratitanHost.attaques[Features.AttaqueType.ancre])
                .getTargets()
                .Contains(this)
        )
            ((Ancre)Jeu.piratitanHost.attaques[Features.AttaqueType.ancre]).desactiverAncre(this);
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
        return Jeu.EtatType.ok;
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

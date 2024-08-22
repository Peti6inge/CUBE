public class Attaque
{
    // Attributs // DONE
    public Perso perso { get; set; }
    public int cout { get; set; }
    public int limitParTour { get; set; }
    public int nbLances { get; set; }
    public int limitParCible { get; set; }
    public Dictionary<Object, int>? nbLancesParCible { get; set; }
    public int cooldown { get; set; }
    public int cooldownRestant { get; set; }
    public int porteeMin { get; set; }
    public int porteeMax { get; set; }
    public bool ligneDeVue { get; set; }
    public bool aligne { get; set; }
    public List<Face> facesLances { get; set; }
    public int typeCible { get; set; }

    /*
    CIBLE :
    dragNDrop : Drag and Drop
    invocationNonBloquante : Bombe, Esprit Elfique, Mouette, Crapeau
    invocationSimpleBloquante : Coffre, Coup de baguette
    invocationDoubleBloquante : Carosse
    freeOnPerso : Poudre, Invincibilité, Dernière volontée, Clairvoyance, Invisibilité, Feinte, Pirouette
    miniaturisation : Miniaturisation
    teleport : Téléport
    freeOnCase :  Bond du titan
    freeOnFace : Flèche patiente, Longue-vue, Brume
    etincelle : Etincelle
    ancre : Ancre
    attireRepousse : Attire, Repousse
    persoFriendly : Poudre stimulante, Poudre bienfaisante, Elixir agressif, Voile d'invisibilité, Buff
    persoEnnemy : Harpon, Poudre soporifique, Poison, Entrave, Mains maudites, Malédiction, Boulet fantomatique
    soin : Petit soin, Soin total, Jouvence
    altruisme : Altruisme
    persoEtInvocEnnemy : Sabre, Coup de feu, Flèche, Katana, Couteau de lancée, Kunaï, Coup de bâton, Boule de feu
    frappeDuPirate : Frappe du pirate
    frappeDuTitan : Frappe du titan
    tonneauOuClone : Tonneau, Clone
    porterDeposer : Porter / Déposer
    planche : Planche
    gravite : Gravité
    chargeDuTitan : Charge du titan
    hautesHerbes : Hautes herbes
    reanimation : Réanimation
    flecheDeLumiere : Flèche de lumière
    derobadeDeLOmbre : Dérobade de l'ombre
    piegeSimple : Piège à loup, Case terrifiante
    piegeLineaire : Piège linéaire
    acide : Acide
    derobade : Dérobade
    transposition : Transposition
    inversion : Inversion
    poseGlissante : Flaque, Eau vaseuse
    feuFollet : Feu follet
    rappel : Rappel
    caseDeRapatriement: Case de rapatriement
    memoire: Mémoire
    envolAtterissage: Envol / Atterrissage
    esquive : Esquive
    sortDeProtection : Sort de protection
    */

    // Constructeur
    public Attaque(Perso perso)
    {
        this.perso = perso;
        nbLances = 0;
        nbLancesParCible = null;
        cooldownRestant = 0;
        facesLances = new List<Face>();
    }

    // Méthodes public
    public bool isUsable(Case myCase, Object? cible) // DONE
    {
        { // Conditions génériques
            if (perso.porte != null && typeCible != (int)Jeu.CibleType.porterDeposer)
                return false;

            if (perso.myCase == null)
                return false;

            if (perso.myCase.face != myCase.face)
                return false;

            if (cout > perso.energieActive)
                return false;

            if (limitParTour != 0 && nbLances >= limitParTour)
                return false;

            if (
                limitParCible != 0
                && nbLancesParCible != null
                && cible != null
                && nbLancesParCible.ContainsKey(cible)
                && nbLancesParCible[cible] >= limitParCible
            )
                return false;

            if (cooldownRestant != 0)
                return false;

            if (
                myCase.distance(perso.myCase) < porteeMin
                || myCase.distance(perso.myCase) > porteeMax
            )
                return false;

            if (ligneDeVue && !myCase.seemsAccessibleFrom(perso.myCase, perso.isHost))
                return false;

            if (aligne && !myCase.isAlignedWith(perso.myCase))
                return false;

            if (facesLances.Contains(myCase.face))
                return false;

            if (
                perso.isHost && myCase.containsBrumeRoninjaClient
                || !perso.isHost && myCase.containsBrumeRoninjaHost
            )
                return false;
        }

        switch (typeCible) // Conditions spécifiques
        {
            case (int)Jeu.CibleType.dragNDrop: // DONE
                if (perso.mainsMaudites) // cas : Mains maudites
                    return false;
                if (perso.pierre != null) // cas : Il possède une pierre
                {
                    if (cible != null)
                        return false;
                    if ((perso.pierre.lumiere == true) && (perso.pierre.isHost == perso.isHost)) // cas : Il possède la pierre lumière adverse
                    {
                        return false;
                    }
                    if (
                        myCase.containsDoubleObstacle
                        || myCase.containsSimpleObstacle
                        || myCase.obstacleSpawn != -1
                    ) // cas : La case contient un obstacle
                    {
                        return false;
                    }
                    return true;
                }
                else // cas : Il ne possède pas de pierre
                {
                    if (cible is Pierre) // cas : La cible est une pierre
                    {
                        Pierre ciblePierre = (Pierre)cible;
                        if (ciblePierre.isHost == perso.isHost) // cas : La cible est une pierre adverse
                            return false;
                    }
                    else if (cible is Perso) // cas : La cible est un perso
                    {
                        Perso ciblePerso = (Perso)cible;
                        if (ciblePerso.isHost == perso.isHost && ciblePerso.pierre != null) //La cible est un allié et possède une pierre
                            return true;
                    }
                    return false;
                }
            case (int)Jeu.CibleType.invocationNonBloquante: // DONE
                if (cible != null)
                    return false;
                if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.containsTrou
                    || myCase.invocationsNonBloquantes().Count == 4
                    || myCase.containsTableClient
                    || myCase.containsTableHost
                    || myCase.obstacleSpawn != -1
                )
                {
                    return false;
                }
                return true;
            case (int)Jeu.CibleType.invocationSimpleBloquante: // DONE
                if (cible != null)
                    return false;
                if (myCase.containsSimpleObstacle)
                    return true;
                return false;
            case (int)Jeu.CibleType.invocationDoubleBloquante: // DONE
                if (cible != null)
                    return false;
                if (myCase.containsDoubleObstacle)
                    return true;
                return false;
            case (int)Jeu.CibleType.freeOnPerso: // DONE
                if (cible is Perso && (Perso)cible == perso)
                    return true;
                return false;
            case (int)Jeu.CibleType.miniaturisation: // DONE
                if (cible is Perso && (Perso)cible == perso && !perso.miniaturisation)
                    return true;
                return false;
            case (int)Jeu.CibleType.teleport: // DONE
                if (perso.getAncre())
                    return false;

                if (
                    cible is Perso
                    && (Perso)cible == perso
                    && perso.attaques.ContainsKey((int)Jeu.AttaqueType.memoire)
                )
                {
                    Case? caseMemoire = (
                        (Memoire)perso.attaques[(int)Jeu.AttaqueType.memoire]
                    ).getTp();
                    if (caseMemoire != null)
                    // cas : Le perso a posé un TP
                    {
                        Perso? persoSurCaseMemoire = caseMemoire.perso();
                        if (
                            persoSurCaseMemoire != null
                            && persoSurCaseMemoire.isVisibleForMe(
                                perso.isHost,
                                faceDoitEtreVisible: true,
                                caseDoitEtreOffBrume: true
                            )
                        ) // cas : La case mémoire contient un perso visible
                            return false;
                        if (
                            myCase.isVisibleForMe(perso.isHost)
                            && (
                                myCase.containsSimpleObstacle
                                || myCase.containsDoubleObstacle
                                || myCase.invocationSimpleBloquante != null
                                || myCase.invocationDoubleBloquante != null
                                || myCase.containsTableClient
                                || myCase.containsTableHost
                                || myCase.obstacleSpawn != -1
                            )
                        ) // cas : La case est visible et contient un obstacle
                            return false;
                        return true;
                    }
                }
                return false;
            case (int)Jeu.CibleType.freeOnCase: // DONE
                if (cible == null)
                    return true;
                return false;
            case (int)Jeu.CibleType.freeOnFace: // DONE
                if (cible is Face)
                    return true;
                return false;
            case (int)Jeu.CibleType.etincelle: // DONE
                if (cible != null)
                    return false;
                if (!myCase.containsPoudre)
                    return false;
                return true;
            case (int)Jeu.CibleType.ancre: // DONE
                if (cible is bool && !(bool)cible && myCase.containsTrou) // cas : on ne peut pas tenter d'attaquer une cible sur un trou
                    return false;

                if (
                    (cible is bool && !(bool)cible)
                    || (
                        cible is InvocationSimpleBloquante
                        && ((InvocationSimpleBloquante)cible).type == (int)Jeu.InvocationType.Clone
                        && ((InvocationSimpleBloquante)cible).isHost == !perso.isHost
                    )
                )
                    return true;

                if (cible is Perso)
                {
                    Perso ciblePerso = (Perso)cible;
                    if (ciblePerso.estPortePar() != null) // Perso porté
                        return false;
                    if (ciblePerso.isHost != perso.isHost) // Perso ennemi
                        return true;
                    else if (!ciblePerso.getAncre()) // Perso allié non ancré
                        return true;
                }
                return false;
            case (int)Jeu.CibleType.attireRepousse: // DONE
                if (cible is bool && !(bool)cible && myCase.containsTrou) // cas : on ne peut pas tenter d'attaquer une cible sur un trou
                    return false;

                if (
                    cible is bool
                    || (
                        cible is InvocationSimpleBloquante
                        && ((InvocationSimpleBloquante)cible).type == (int)Jeu.InvocationType.Clone
                        && ((InvocationSimpleBloquante)cible).isHost == !perso.isHost
                    ) // cas : Cible est un clone ou on tente d'atteindre un perso invisible
                )
                    return true;

                if (cible is Perso) // cas : Cible est un perso
                {
                    Perso ciblePerso = (Perso)cible;
                    if (ciblePerso.isHost != perso.isHost) // Perso ennemi
                        return true;
                    else if (!ciblePerso.getAncre()) // Perso allié non ancré
                        return true;
                }
                return false;
            case (int)Jeu.CibleType.persoFriendly: // DONE
                if (cible is Perso && ((Perso)cible).isHost == perso.isHost)
                    return true;
                return false;
            case (int)Jeu.CibleType.persoEnnemy: // DONE
                if (cible is bool && !(bool)cible && myCase.containsTrou) // cas : on ne peut pas tenter d'attaquer une cible sur un trou
                    return false;

                if (
                    (cible is Perso && ((Perso)cible).isHost == !perso.isHost)
                    || cible is bool
                    || (
                        cible is InvocationSimpleBloquante
                        && ((InvocationSimpleBloquante)cible).type == (int)Jeu.InvocationType.Clone
                        && ((InvocationSimpleBloquante)cible).isHost == !perso.isHost
                    )
                )
                    return true;
                return false;
            case (int)Jeu.CibleType.soin: // DONE
                if (
                    (
                        cible is Perso
                        && ((Perso)cible).isHost == perso.isHost
                        && ((Perso)cible).hp < ((Perso)cible).hpMax
                    )
                    || (
                        cible is InvocationNonBloquante
                        && ((InvocationNonBloquante)cible).isHost == perso.isHost
                        && ((InvocationNonBloquante)cible).hp
                            < ((InvocationNonBloquante)cible).hpMax
                    )
                    || (
                        cible is InvocationSimpleBloquante
                        && ((InvocationSimpleBloquante)cible).isHost == perso.isHost
                        && ((InvocationSimpleBloquante)cible).hp
                            < ((InvocationSimpleBloquante)cible).hpMax
                    )
                    || (
                        cible is InvocationDoubleBloquante
                        && ((InvocationDoubleBloquante)cible).isHost == perso.isHost
                        && ((InvocationDoubleBloquante)cible).hp
                            < ((InvocationDoubleBloquante)cible).hpMax
                    )
                )
                    return true;
                return false;
            case (int)Jeu.CibleType.altruisme: // DONE
                if (
                    (cible is Perso && ((Perso)cible).isHost == perso.isHost)
                    || (
                        cible is InvocationNonBloquante
                        && ((InvocationNonBloquante)cible).isHost == perso.isHost
                    )
                    || (
                        cible is InvocationSimpleBloquante
                        && ((InvocationSimpleBloquante)cible).isHost == perso.isHost
                    )
                    || (
                        cible is InvocationDoubleBloquante
                        && ((InvocationDoubleBloquante)cible).isHost == perso.isHost
                    )
                )
                    return true;
                return false;
            case (int)Jeu.CibleType.persoEtInvocEnnemy: // DONE
                if (cible is bool && !(bool)cible && myCase.containsTrou) // cas : on ne peut pas tenter d'attaquer une cible sur un trou
                    return false;

                if (
                    (cible is Perso && ((Perso)cible).isHost == !perso.isHost)
                    || cible is bool
                    || (
                        cible is InvocationNonBloquante
                        && ((InvocationNonBloquante)cible).isHost == !perso.isHost
                    )
                    || (
                        cible is InvocationSimpleBloquante
                        && ((InvocationSimpleBloquante)cible).isHost == !perso.isHost
                    )
                    || (
                        cible is InvocationDoubleBloquante
                        && ((InvocationDoubleBloquante)cible).isHost == !perso.isHost
                    )
                )
                    return true;
                return false;
            case (int)Jeu.CibleType.frappeDuPirate: // DONE
                if (cible != null) // cas : Cible autre que la case
                    return false;
                else if (
                    myCase.invocationSimpleBloquante != null
                    && myCase.invocationSimpleBloquante.type == (int)Jeu.InvocationType.Clone
                ) // cas : La case contient un clone
                    return false;
                else if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.invocationDoubleBloquante != null
                    || myCase.invocationSimpleBloquante != null
                ) // cas : La case contient un obstacle
                    return true;
                else if (myCase.invocationsNonBloquantes().Count != 0) // cas : La case contient une invocation non bloquante
                {
                    Perso? persoCandidat = myCase.perso();
                    if (persoCandidat != null && persoCandidat.isVisibleForMe(perso.isHost)) // cas : La case contient un perso visible
                        return false;
                    return true;
                }
                return false;
            case (int)Jeu.CibleType.frappeDuTitan: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;
                else if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.containsTrou
                    || myCase.getContainsPierre().Count != 0
                    || myCase.invocationSimpleBloquante != null
                    || myCase.invocationDoubleBloquante != null
                    || myCase.invocationsNonBloquantes().Count != 0
                    || myCase.containsTableClient
                    || myCase.containsTableHost
                    || myCase.obstacleSpawn != -1
                ) // Cas : La case contient un obstacle
                    return false;
                else
                {
                    Perso? persoCandidat = myCase.perso();
                    if (persoCandidat != null && persoCandidat.isVisibleForMe(perso.isHost)) // Cas : La case contient un perso visible
                        return false;
                }
                return true;
            case (int)Jeu.CibleType.tonneauOuClone: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;
                else if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.containsTrou
                    || myCase.invocationSimpleBloquante != null
                    || myCase.invocationDoubleBloquante != null
                    || myCase.containsTableClient
                    || myCase.containsTableHost
                    || myCase.obstacleSpawn != -1
                ) // Cas : La case contient un obstacle
                    return false;
                else
                {
                    Perso? persoCandidat = myCase.perso();
                    if (persoCandidat != null && persoCandidat.isVisibleForMe(perso.isHost)) // Cas : La case contient un perso visible
                        return false;
                }
                return true;
            case (int)Jeu.CibleType.porterDeposer: // DONE
                if (perso.porte != null) // Cas : Le perso doit déposer sur une case
                {
                    if (cible != null) // Cas : Cible n'est pas une case
                        return false;
                    if (
                        myCase.containsSimpleObstacle
                        || myCase.containsDoubleObstacle
                        || myCase.invocationSimpleBloquante != null
                        || myCase.invocationDoubleBloquante != null
                        || myCase.containsTableClient
                        || myCase.containsTableHost
                        || myCase.obstacleSpawn != -1
                    ) // Cas : La case contient un obstacle
                        return false;
                    else
                    {
                        Perso? persoCandidat = myCase.perso();
                        if (persoCandidat != null && persoCandidat.isVisibleForMe(perso.isHost)) // Cas : La case contient un perso visible
                            return false;
                    }
                    return true;
                }
                else // Cas : Le perso doit porter un perso
                {
                    if (!(cible is Perso)) // Cas : Cible n'est pas un perso
                        return false;
                    Perso ciblePerso = (Perso)cible;
                    if (
                        ciblePerso.isHost == perso.isHost
                        && !ciblePerso.getAncre()
                        && !ciblePerso.enVol
                    ) // Cas : Cible est un allié portable
                        return true;
                    return false;
                }
            case (int)Jeu.CibleType.planche: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;
                if (myCase.containsTrou || myCase.containsGlissante)
                    return true;
                return false;
            case (int)Jeu.CibleType.gravite: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;

                if (!myCase.containsTrou)
                    return false;

                if (
                    perso.isHost && myCase.containsGraviteFantomageHost
                    || !perso.isHost && myCase.containsGraviteFantomageClient
                )
                    return false;

                return true;
            case (int)Jeu.CibleType.chargeDuTitan: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;
                else if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.invocationSimpleBloquante != null
                    || myCase.invocationDoubleBloquante != null
                    || myCase.containsTableClient
                    || myCase.containsTableHost
                    || myCase.obstacleSpawn != -1
                ) // Cas : La case contient un obstacle
                {
                    return false;
                }
                else
                {
                    Perso? persoCandidat = myCase.perso();
                    if (persoCandidat != null && persoCandidat.isVisibleForMe(perso.isHost)) // Cas : La case contient un perso visible
                        return false;
                }
                return true;
            case (int)Jeu.CibleType.hautesHerbes: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;
                if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.containsCamouflage
                    || myCase.containsTrou
                    || myCase.containsTableClient
                    || myCase.containsTableHost
                    || myCase.obstacleSpawn != -1
                ) // Cas : La case contient un obstacle
                {
                    return false;
                }
                return true;
            case (int)Jeu.CibleType.reanimation: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;

                if (
                    perso.isHost && myCase.face != Jeu.host
                    || !perso.isHost && myCase.face != Jeu.client
                ) // Cas : La case n'est pas sur la face du perso
                    return false;

                switch (myCase.obstacleSpawn)
                {
                    case -1: // Cas : La case n'est pas un spawn
                        return false;
                    case (int)Jeu.SpawnType.Roninja:
                        if (perso.isHost && Jeu.roninjaHost.coolDownKO == 0) // Cas : Le roninja host n'est pas KO
                            return false;
                        if (!perso.isHost && Jeu.roninjaClient.coolDownKO == 0) // Cas : Le roninja client n'est pas KO
                            return false;
                        return true;
                    case (int)Jeu.SpawnType.Fantomage:
                        if (perso.isHost && Jeu.fantomageHost.coolDownKO == 0) // Cas : Le fantomage host n'est pas KO
                            return false;
                        if (!perso.isHost && Jeu.fantomageClient.coolDownKO == 0) // Cas : Le fantomage client n'est pas KO
                            return false;
                        return true;
                    case (int)Jeu.SpawnType.Elfee:
                        if (perso.isHost && Jeu.elfeeHost.coolDownKO == 0) // Cas : L'elfee host n'est pas KO
                            return false;
                        if (!perso.isHost && Jeu.elfeeClient.coolDownKO == 0) // Cas : L'elfee client n'est pas KO
                            return false;
                        return true;
                    case (int)Jeu.SpawnType.Piratitan:
                        if (perso.isHost && Jeu.piratitanHost.coolDownKO == 0) // Cas : Le piratitan host n'est pas KO
                            return false;
                        if (!perso.isHost && Jeu.piratitanClient.coolDownKO == 0) // Cas : Le piratitan client n'est pas KO
                            return false;
                        return true;
                    default:
                        return false;
                }
            case (int)Jeu.CibleType.flecheDeLumiere: // DONE
                if (cible is Perso)
                {
                    Perso ciblePerso = (Perso)cible;
                    if (
                        ciblePerso.isHost == perso.isHost
                        && ciblePerso.pierre != null
                        && ciblePerso.pierre.lumiere
                    ) // Cas : La cible est un allié avec une pierre lumière
                        return true;
                }
                else if (cible is Pierre)
                {
                    Pierre pierre = (Pierre)cible;
                    if (pierre.lumiere && pierre.isHost == !perso.isHost) // Cas : La cible est une pierre lumière adverse
                        return true;
                }
                return false;
            case (int)Jeu.CibleType.derobadeDeLOmbre: // DONE
                if (cible is Perso)
                {
                    Perso ciblePerso = (Perso)cible;
                    if (
                        ciblePerso.isHost == perso.isHost
                        && ciblePerso.pierre != null
                        && !ciblePerso.pierre.lumiere
                    ) // Cas : La cible est un allié avec une pierre ombre
                        return true;
                }
                else if (cible is Pierre)
                {
                    Pierre pierre = (Pierre)cible;
                    if (!pierre.lumiere && pierre.isHost == !perso.isHost) // Cas : La cible est une pierre ombre adverse
                        return true;
                }
                return false;
            case (int)Jeu.CibleType.piegeSimple: // DONE
                if (cible != null)
                    return false;

                if (!caseSeemsPiegable(myCase))
                    return false;

                return true;
            case (int)Jeu.CibleType.piegeLineaire: // DONE
                if (cible != null)
                    return false;

                if (!caseSeemsPiegable(myCase))
                    return false;

                foreach (Case c in myCase.GetLine(myCase.face, perso.myCase, myCase))
                {
                    if (!caseSeemsPiegable(c))
                        return false;
                }
                return true;
            case (int)Jeu.CibleType.acide: // DONE
                if (cible != null)
                    return false;

                if (myCase.containsGlissante)
                    return true;

                return false;
            case (int)Jeu.CibleType.derobade: // DONE
                if (cible is bool && !(bool)cible && myCase.containsTrou) // cas : on ne peut pas tenter d'attaquer une cible sur un trou
                    return false;

                if (cible is Pierre)
                {
                    Pierre pierre = (Pierre)cible;
                    if (pierre.isHost == perso.isHost)
                        return true;
                }
                else if (cible is Perso)
                {
                    Perso ciblePerso = (Perso)cible;
                    if (ciblePerso.pierre != null && ciblePerso.pierre.isHost == perso.isHost)
                        return true;
                }
                else if (cible is bool)
                {
                    Perso? ciblePerso = (bool)cible ? myCase.persoOver() : myCase.perso();
                    if (
                        ciblePerso != null
                        && ciblePerso.pierre != null
                        && ciblePerso.pierre.isHost == perso.isHost
                    )
                        return true;
                }
                return false;
            case (int)Jeu.CibleType.transposition: // DONE
                if (perso.getAncre()) // Je suis ancré
                    return false;

                if (cible is Perso)
                {
                    Perso ciblePerso = (Perso)cible;
                    if (
                        ciblePerso.isHost == perso.isHost
                        && !ciblePerso.getAncre()
                        && !ciblePerso.enVol
                    ) // La cible est un allié non ancré et non en vol
                        return true;
                }
                else if (
                    cible is InvocationSimpleBloquante
                    && ((InvocationSimpleBloquante)cible).type == (int)Jeu.InvocationType.Clone
                    && ((InvocationSimpleBloquante)cible).isHost == perso.isHost
                ) // La cible est un clone allié
                {
                    return true;
                }

                return false;
            case (int)Jeu.CibleType.inversion: // DONE
                if (cible is bool && !(bool)cible && myCase.containsTrou) // cas : on ne peut pas tenter d'attaquer une cible sur un trou
                    return false;

                if (perso.getAncre()) // Je suis ancré
                    return false;
                if (cible is Perso)
                {
                    Perso ciblePerso = (Perso)cible;
                    if (
                        ciblePerso.isHost != perso.isHost
                        && !ciblePerso.enVol
                        && ciblePerso.pierre == null
                    ) // La cible est un ennemi non ancré et non en vol
                        return true;
                }
                else if (
                    cible is InvocationSimpleBloquante
                    && ((InvocationSimpleBloquante)cible).type == (int)Jeu.InvocationType.Clone
                    && ((InvocationSimpleBloquante)cible).isHost != perso.isHost
                )
                {
                    return true;
                }
                else if (cible is bool)
                {
                    Perso? ciblePerso = (bool)cible ? myCase.persoOver() : myCase.perso();
                    if (
                        ciblePerso != null
                        && ciblePerso.isHost != perso.isHost
                        && ciblePerso.pierre != null
                    )
                        return false;
                    return true;
                }
                return false;
            case (int)Jeu.CibleType.poseGlissante: // DONE
                if (cible != null)
                    return false;
                else if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.containsGlissante
                    || myCase.containsTrou
                    || myCase.containsTableClient
                    || myCase.containsTableHost
                    || myCase.obstacleSpawn != -1
                )
                    return false;
                return true;
            case (int)Jeu.CibleType.feuFollet: // DONE
                if (cible is bool && !(bool)cible && myCase.containsTrou) // cas : on ne peut pas tenter d'attaquer une cible sur un trou
                    return false;

                if (cible is Perso)
                {
                    Perso ciblePerso = (Perso)cible;
                    if (ciblePerso.pierre != null && ciblePerso.pierre.isHost != perso.isHost)
                        return true;
                }
                else if (cible is bool)
                {
                    Perso? ciblePerso = (bool)cible ? myCase.persoOver() : myCase.perso();
                    if (ciblePerso != null && ciblePerso.pierre != null)
                        return true;
                }
                return false;
            case (int)Jeu.CibleType.rappel: // DONE
                if (!(cible is Perso))
                    return false;
                else
                {
                    Perso ciblePerso = (Perso)cible;
                    if (
                        ciblePerso.isHost == perso.isHost
                        && !ciblePerso.getAncre()
                        && !ciblePerso.enVol
                    )
                        return true;
                }
                return false;
            case (int)Jeu.CibleType.caseDeRapatriement: // DONE
                if (cible != null) // Cas : Cible autre que la case
                    return false;
                if (
                    myCase.containsSimpleObstacle
                    || myCase.containsDoubleObstacle
                    || myCase.containsTrou
                    || myCase.invocationSimpleBloquante != null
                    || myCase.invocationDoubleBloquante != null
                    || myCase.containsTableClient
                    || myCase.containsTableHost
                    || myCase.obstacleSpawn != -1
                ) // Cas : La case contient un obstacle
                    return false;
                else if (myCase.containsCaseRappatriement()) // Cas : La case contient une case de rappatriement
                    return false;
                else
                {
                    Perso? persoCandidat = myCase.perso();
                    if (persoCandidat != null && persoCandidat.isVisibleForMe(perso.isHost)) // Cas : La case contient un perso visible
                        return false;
                }
                return true;
            case (int)Jeu.CibleType.memoire: // DONE²
                if (cible != null) // Cas : Cible autre que la case
                    return false;
                if (
                    (myCase.containsTPRoninjaHost() && perso.isHost)
                    || (myCase.containsTPRoninjaClient() && !perso.isHost)
                ) // Cas : La case contient déjà un TP Roninja
                    return false;
                return true;
            case (int)Jeu.CibleType.envolAtterissage: // DONE
                if (!(cible is Perso))
                    return false;
                else
                {
                    Perso ciblePerso = (Perso)cible;
                    if (ciblePerso != perso)
                        return false;
                    if (perso.enVol) // L'Elfée tente d'atterrir
                    {
                        if (
                            myCase.containsSimpleObstacle
                            || myCase.containsDoubleObstacle
                            || myCase.invocationSimpleBloquante != null
                            || myCase.invocationDoubleBloquante != null
                            || myCase.containsTableClient
                            || myCase.containsTableHost
                            || myCase.obstacleSpawn != -1
                        )
                            return false;
                        Perso? persoUnder = perso.myCase.perso();
                        if (persoUnder != null && persoUnder.isVisibleForMe(perso.isHost))
                            return false;
                        return true;
                    }
                    else // L'Elfée tente de s'envoler
                    {
                        Perso? persoOver = perso.myCase.persoOver();
                        if (persoOver != null && persoOver.isVisibleForMe(perso.isHost))
                            return false;
                        return true;
                    }
                }
            case (int)Jeu.CibleType.esquive: // DONE
                if (cible is Perso && (Perso)cible == perso && !((Perso)cible).esquive)
                    return true;
                return false;
            case (int)Jeu.CibleType.sortDeProtection: // DONE
                if (
                    cible is Perso
                    && ((Perso)cible).isHost == perso.isHost
                    && !((Perso)cible).esquive
                )
                    return true;
                return false;
            default:
                return true;
        }
    }

    // Méthodes protégées

    protected void uses(Object? cible = null) // DONE
    {
        perso.energieActive -= cout;

        nbLances++;

        if (limitParCible != 0 && cible != null && nbLancesParCible != null)
        {
            if (nbLancesParCible.ContainsKey(cible))
            {
                nbLancesParCible[cible]++;
            }
            else
            {
                nbLancesParCible.Add(cible, 1);
            }
        }

        cooldownRestant = cooldown;
    }

    protected bool missAndReveal(Case myCase) // DONE
    {
        Perso? persoToReveal = myCase.perso();

        if (persoToReveal != null)
        {
            perso.energieActive += cout - 1;
            perso.miss();
            persoToReveal.reveal();
            return true;
        }
        return false;
    }

    protected void attaqueBasiqueDegats(Case myCase, Object? cible, int degats) // DONE
    {
        if (cible == null)
            return;

        if (cible is bool)
        {
            Perso? persoCandidat = (bool)cible ? myCase.persoOver() : myCase.perso();
            if (persoCandidat != null)
                perso.infligeDegats(degats, persoCandidat);
        }
        else
            perso.infligeDegats(degats, cible);
    }

    protected void attaqueBasiqueSoin(Object? cible, int soin) // DONE
    {
        if (cible is Perso)
            ((Perso)cible).recoitSoin(soin);

        if (cible is InvocationNonBloquante)
            ((InvocationNonBloquante)cible).recoitSoin(soin);

        if (cible is InvocationSimpleBloquante)
            ((InvocationSimpleBloquante)cible).recoitSoin(soin);

        if (cible is InvocationDoubleBloquante)
            ((InvocationDoubleBloquante)cible).recoitSoin(soin);
    }

    // Méthodes privées

    private bool caseSeemsPiegable(Case myCase) // DONE
    {
        if (
            myCase.containsSimpleObstacle
            || myCase.containsDoubleObstacle
            || myCase.containsTrou
            || myCase.invocationSimpleBloquante != null
            || myCase.invocationDoubleBloquante != null
            || myCase.containsTableClient
            || myCase.containsTableHost
            || myCase.obstacleSpawn != -1
        ) // Cas : La case contient un obstacle
        {
            return false;
        }

        if (
            (perso.isHost && myCase.piegeHost != null)
            || (!perso.isHost && myCase.piegeClient != null)
        ) // Cas : La case contient un piège allié
            return false;

        Perso? persoCandidat = myCase.perso();
        if (persoCandidat != null && persoCandidat.isVisibleForMe(perso.isHost)) // Cas : La case contient un perso visible
            return false;

        return true;
    }

    public virtual void debutTour() // DONE
    {
        nbLances = 0;

        nbLancesParCible = new Dictionary<Object, int>();

        if (cooldownRestant > 0)
        {
            cooldownRestant--;
        }

        facesLances.Clear();
    }
}

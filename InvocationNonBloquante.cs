public class InvocationNonBloquante
{
    //attributs
    public Jeu.InvocationType type { get; set; }
    public bool isHost { get; set; }
    public int hp { get; set; }
    public int hpMax { get; set; }
    public Case myCase { get; set; }

    //Constructeur // DONE
    public InvocationNonBloquante(Jeu.InvocationType type, bool isHost, Case myCase)
    {
        this.type = type;
        this.isHost = isHost;
        this.myCase = myCase;
        switch (type)
        {
            case Jeu.InvocationType.Bombe:
                hp = hpMax = 8;
                break;
            case Jeu.InvocationType.EspritElfique:
                hp = hpMax = 7;
                break;
            case Jeu.InvocationType.Crapeau:
                hp = hpMax = 5;
                break;
            case Jeu.InvocationType.Mouette:
                hp = hpMax = 1;
                break;
        }
    }

    public void activerBombe(int poudre = 0) // DONE
    {
        Perso piratitanProprietaire = isHost ? Jeu.piratitanHost : Jeu.piratitanClient;

        estKO(bombeExplose: false);

        int portee = 1 + poudre / 2;

        List<Case> cases = new List<Case>();
        foreach (Case c in myCase.face.grid)
        {
            if (c.distance(myCase) <= portee)
                cases.Add(c);
        }

        cases.Sort((c1, c2) => c1.distance(myCase).CompareTo(c2.distance(myCase))); // tri par distance

        foreach (Case c in cases)
        {
            int degats = 1 + portee - c.distance(myCase);

            if (c.perso() != null)
                piratitanProprietaire.infligeDegats(degats, c.perso());

            if (c.persoOver() != null)
                piratitanProprietaire.infligeDegats(degats, c.persoOver());

            foreach (InvocationNonBloquante i in c.invocationsNonBloquantes())
            {
                if (i.hp > 0)
                    piratitanProprietaire.infligeDegats(degats, i);
            }
            if (c.invocationDoubleBloquante != null)
                piratitanProprietaire.infligeDegats(degats, c.invocationDoubleBloquante);
            else if (c.invocationSimpleBloquante != null)
                piratitanProprietaire.infligeDegats(degats, c.invocationSimpleBloquante);
        }
    }

    public void activerEspritElfique(Perso? perso) // DONE
    {
        if (perso != null)
        {
            perso.energieActive += 2;
        }
    }

    public Jeu.EtatType activerCrapeau(Perso? perso, bool crapeauHost, bool crapeauClient) // DONE
    {
        if (perso == null)
            return Jeu.EtatType.ko;
        if (perso.myCase == null)
            return Jeu.EtatType.ko;

        if (!myCase.accessibleFrom(perso.myCase))
        {
            missCrapeauObstacle(perso);
            return Jeu.EtatType.normal;
        }

        if (perso.isAncre())
        {
            missCrapeauAncre(perso);
            return Jeu.EtatType.normal;
        }

        if (isHost)
            crapeauHost = true;
        else
            crapeauClient = true;

        Jeu.DirectionType direction = perso.myCase.directionTo(myCase);
        return perso.moveDirection(
            direction,
            attiranceCrapeau: true,
            crapeauHost: crapeauHost,
            crapeauClient: crapeauClient
        );
    }

    public Jeu.EtatType recoitDegats(int degats) // DONE
    {
        if (sousAltruisme())
        {
            if (isHost)
                Jeu.elfeeHost.recoitDegats(degats);
            else
                Jeu.elfeeClient.recoitDegats(degats);

            return Jeu.EtatType.normal;
        }
        hp -= Math.Min(hp, degats);
        if (hp <= 0)
        {
            estKO();
            return Jeu.EtatType.ko;
        }
        return Jeu.EtatType.normal;
    }

    public void recoitSoin(int soin) // DONE
    {
        hp = Math.Min(hpMax, hp + soin);
    }

    public void estKO(bool bombeExplose = true) // DONE
    {
        hp = 0;
        if (sousAltruisme())
        {
            Perso elfeeAlliee;
            if (isHost)
                elfeeAlliee = Jeu.elfeeHost;
            else
                elfeeAlliee = Jeu.elfeeClient;

            ((Altruisme)elfeeAlliee.attaques[Jeu.AttaqueType.altruisme]).desactiver();
        }

        Perso proprietaire;
        switch (type)
        {
            case Jeu.InvocationType.Bombe:
                proprietaire = isHost ? Jeu.piratitanHost : Jeu.piratitanClient;
                ((Bombe)proprietaire.attaques[Jeu.AttaqueType.bombe]).setBombeNull();
                if (bombeExplose)
                    activerBombe();
                break;
            case Jeu.InvocationType.EspritElfique:
                proprietaire = isHost ? Jeu.elfeeHost : Jeu.elfeeClient;
                (
                    (EspritElfique)proprietaire.attaques[Jeu.AttaqueType.espritElfique]
                ).setEspritElfiqueNull();
                break;
            case Jeu.InvocationType.Mouette:
                proprietaire = isHost ? Jeu.piratitanHost : Jeu.piratitanClient;
                ((Mouette)proprietaire.attaques[Jeu.AttaqueType.mouette]).setMouetteNull();
                break;
            case Jeu.InvocationType.Crapeau:
                proprietaire = isHost ? Jeu.fantomageHost : Jeu.fantomageClient;
                ((Crapeau)proprietaire.attaques[Jeu.AttaqueType.crapeau]).setCrapeauNull();
                break;
        }
    }

    public void missCrapeauObstacle(
        Perso perso
    ) // TODO
    { }

    public void missCrapeauAncre(
        Perso perso
    ) // TODO
    { }

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
}

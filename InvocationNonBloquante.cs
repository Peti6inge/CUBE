public class InvocationNonBloquante
{
    //attributs
    public string type { get; set; }
    public bool isHost { get; set; }
    public int hp { get; set; }
    public int hpMax { get; set; }
    public Case myCase { get; set; }

    //Constructeur // DONE
    public InvocationNonBloquante(string type, bool isHost, Case myCase)
    {
        this.type = type;
        this.isHost = isHost;
        this.myCase = myCase;
        switch (type)
        {
            case "Bombe":
                hp = hpMax = 8;
                break;
            case "EspritElfique":
                hp = hpMax = 7;
                break;
            case "Crapeau":
                hp = hpMax = 5;
                break;
            case "Mouette":
                hp = hpMax = 1;
                break;
        }
    }

    public void activer(Perso? perso = null, bool crapeauHost = false, bool crapeauClient = false) // DONE
    {
        switch (type)
        {
            case "Bombe":
                activerBombe();
                break;
            case "EspritElfique":
                activerEspritElfique(perso);
                break;
            case "Crapeau":
                activerCrapeau(perso, crapeauHost, crapeauClient);
                break;
        }
    }

    public void activerBombe(int poudre = 0) // DONE
    {
        Perso piratitanProprietaire = isHost ? Jeu.piratitanHost : Jeu.piratitanClient;

        hp = 0;

        int portee = 1 + poudre / 2;

        List<Case> cases = new List<Case>();
        foreach (Case c in myCase.face.grid)
        {
            if (c.distance(myCase) <= portee)
            {
                cases.Add(c);
            }
        }

        foreach (Case c in cases)
        {
            int degats = 1 + portee - c.distance(myCase);

            if (c.perso() != null)
                piratitanProprietaire.infligeDegats(degats, c.perso());

            if (c.persoOver() != null)
                piratitanProprietaire.infligeDegats(degats, c.persoOver());

            foreach (InvocationNonBloquante i in c.invocationsNonBloquantes())
                piratitanProprietaire.infligeDegats(degats, i);

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

    public void activerCrapeau(Perso? perso, bool crapeauHost, bool crapeauClient) // DONE
    {
        if (perso == null)
            return;
        if (perso.myCase == null)
            return;
        if (!myCase.accessibleFrom(perso.myCase))
        {
            missCrapeauObstacle(perso);
            return;
        }
        if (perso.getAncre())
        {
            missCrapeauAncre(perso);
            return;
        }
        if (isHost)
            crapeauHost = true;
        else
            crapeauClient = true;
        string direction = "";
        //TODO : direction
        if (perso.myCase.row < myCase.row)
            direction = "down";
        else if (perso.myCase.row > myCase.row)
            direction = "up";
        else if (perso.myCase.col < myCase.col)
            direction = "right";
        else if (perso.myCase.col > myCase.col)
            direction = "left";
        perso.moveDirection(
            direction,
            attiranceCrapeau: true,
            crapeauHost: crapeauHost,
            crapeauClient: crapeauClient
        );
    }

    public void recoitDegats(int degats) // DONE
    {
        if (sousAltruisme())
        {
            if (isHost)
            {
                Jeu.elfeeHost.recoitDegats(degats);
            }
            else
            {
                Jeu.elfeeClient.recoitDegats(degats);
            }
            return;
        }
        hp -= Math.Min(hp, degats);
        if (hp <= 0)
            estKO();
    }

    public void recoitSoin(int soin) // DONE
    {
        hp = Math.Min(hpMax, hp + soin);
    }

    public void estKO(bool bombeExplose = true) // DONE
    {
        if (sousAltruisme())
        {
            Perso elfeeAlliee;
            if (isHost)
                elfeeAlliee = Jeu.elfeeHost;

            else
                elfeeAlliee = Jeu.elfeeClient;

            ((Altruisme)elfeeAlliee.attaques["Altruisme"]).desactiver();
        }

        Perso proprietaire;
        switch (type)
        {
            case "Bombe":
                proprietaire = isHost ? Jeu.piratitanHost : Jeu.piratitanClient;
                ((Bombe)proprietaire.attaques["Bombe"]).setBombeNull();
                if (bombeExplose)
                    activerBombe();
                break;
            case "EspritElfique":
                proprietaire = isHost ? Jeu.elfeeHost : Jeu.elfeeClient;
                ((EspritElfique)proprietaire.attaques["EspritElfique"]).setEspritElfiqueNull();
                break;
            case "Mouette":
                proprietaire = isHost ? Jeu.piratitanHost : Jeu.piratitanClient;
                ((Mouette)proprietaire.attaques["Mouette"]).setMouetteNull();
                break;
            case "Crapeau":
                proprietaire = isHost ? Jeu.fantomageHost : Jeu.fantomageClient;
                ((Crapeau)proprietaire.attaques["Crapeau"]).setCrapeauNull();
                break;
        }
    }

    public void missCrapeauObstacle(Perso perso) // TODO
    {

    }

    public void missCrapeauAncre(Perso perso) // TODO
    {

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
}

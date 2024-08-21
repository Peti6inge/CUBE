public class InvocationDoubleBloquante
{
    // attributs
    public string type { get; set; }
    public bool isHost { get; set; }
    public int hp { get; set; }
    public int hpMax { get; set; }
    public Case myCase1 { get; set; }
    public Case myCase2 { get; set; }

    // Constructeur // DONE
    public InvocationDoubleBloquante(string type, bool isHost, Case myCase1, Case myCase2)
    {
        this.type = type;
        this.isHost = isHost;
        this.myCase1 = myCase1;
        this.myCase2 = myCase2;
        switch (type)
        {
            case "Carosse":
                hp = hpMax = 10;
                break;
        }
    }

    public void activer(Perso? perso = null) // DONE
    {
        switch (type)
        {
            case "Carosse":
                activerCarosse(perso);
                break;
        }
    }

    public void activerCarosse(Perso? perso) // DONE
    {
        if (perso != null)
        {
            perso.hp += 3;
        }
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

    public void estKO() // DONE
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
        myCase1.invocationDoubleBloquante = null;
        myCase2.invocationDoubleBloquante = null;
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

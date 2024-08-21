public class InvocationSimpleBloquante
{
    // attributs
    public string type { get; set; }
    public bool isHost { get; set; }
    public int hp { get; set; }
    public int hpMax { get; set; }
    public Case myCase { get; set; }

    // Constructeur // DONE
    public InvocationSimpleBloquante(string type, bool isHost, Case myCase)
    {
        this.type = type;
        this.isHost = isHost;
        this.myCase = myCase;
        switch (type)
        {
            case "Tonneau":
                hp = hpMax = 3;
                break;
            case "Coffre":
                hp = hpMax = 5;
                break;
            case "GrossePotion":
                hp = hpMax = 5;
                break;
            case "Clone":
                hp = hpMax = 1;
                break;
        }
    }

    public void activer(Perso? perso = null, Pierre? pierre = null) // DONE
    {
        switch (type)
        {
            case "Coffre":
                activerCoffre(pierre);
                break;
            case "GrossePotion":
                activerGrossePotion(perso);
                break;
        }
    }

    public void activerCoffre(Pierre? pierre) // DONE
    {
        if (pierre != null)
            myCase.addPierre(pierre);
    }

    public void activerGrossePotion(Perso? perso) // DONE
    {
        if (perso != null)
            perso.hp += 2;
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
        myCase.invocationSimpleBloquante = null;
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

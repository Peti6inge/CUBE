public class InvocationDoubleBloquante
{
    // attributs
    public Jeu.InvocationType type { get; set; }
    public bool isHost { get; set; }
    public int hp { get; set; }
    public int hpMax { get; set; }
    public Case myCase1 { get; set; }
    public Case myCase2 { get; set; }

    // Constructeur // DONE
    public InvocationDoubleBloquante(
        Jeu.InvocationType type,
        bool isHost,
        Case myCase1,
        Case myCase2
    )
    {
        this.type = type;
        this.isHost = isHost;
        this.myCase1 = myCase1;
        this.myCase2 = myCase2;
        switch (type)
        {
            case Jeu.InvocationType.Carosse:
                hp = hpMax = 10;
                break;
        }
    }

    public void activer(Perso? perso = null) // DONE
    {
        switch (type)
        {
            case Jeu.InvocationType.Carosse:
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

    public Jeu.EtatType recoitDegats(int degats) // DONE
    {
        if (sousAltruisme())
        {
            if (isHost)
                Jeu.elfeeHost.recoitDegats(degats);
            else
                Jeu.elfeeClient.recoitDegats(degats);

            return Jeu.EtatType.ok;
        }

        hp -= Math.Min(hp, degats);
        if (hp <= 0)
        {
            estKO();
            return Jeu.EtatType.ko;
        }
        return Jeu.EtatType.ok;
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

            ((Altruisme)elfeeAlliee.attaques[Features.AttaqueType.altruisme]).desactiver();
        }
        myCase1.invocationDoubleBloquante = null;
        myCase2.invocationDoubleBloquante = null;
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
}

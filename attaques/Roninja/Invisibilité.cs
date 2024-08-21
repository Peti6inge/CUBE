public class Invisibilite : Attaque
{
    // Attributs // DONE
    private bool actif;

    // Constructeur // DONE
    public Invisibilite(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = (int)Jeu.CibleType.freeOnPerso";
        actif = false;
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        actif = true;
        perso.invisibilite++;
    }

    public void desactiver(bool reveal = true) // DONE
    {
        if (actif)
        {
            actif = false;
            perso.invisibilite = Math.Max(0, perso.invisibilite - 1);
            if (perso.invisibilite == 0 && reveal)
                perso.reveal();
        }
    }

    public bool estActif() // DONE
    {
        return actif;
    }
}

public class VoileDInvisibilite : Attaque
{
    // Attributs // DONE
    Perso? persoCible;

    // Constructeur // DONE
    public VoileDInvisibilite(Perso perso)
        : base(perso)
    {
        cout = 3;
        limitParTour = 1;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.persoFriendly;
        persoCible = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        persoCible = (Perso?)cible;
        if (persoCible == null)
            return;

        persoCible.invisibilite++;
    }

    public void desactiver(bool reveal = true) // DONE
    {
        if (persoCible != null)
        {
            Perso? persoTemp = persoCible;
            persoCible = null;
            persoTemp.invisibilite = Math.Max(0, persoTemp.invisibilite - 1);

            if (persoTemp.invisibilite == 0 && reveal)
                persoTemp.reveal();
        }
    }

    public Perso? getPersoCible() // DONE
    {
        return persoCible;
    }
}

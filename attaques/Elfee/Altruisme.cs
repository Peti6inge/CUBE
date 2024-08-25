public class Altruisme : Attaque
{
    // Attributs // DONE
    private Object? cibleAltruisme;
    private int toursRestants;

    // Constructeur // DONE
    public Altruisme(Perso perso)
        : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.altruisme;
        toursRestants = 0;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        cibleAltruisme = cible;
        toursRestants = 2;
    }

    public override void debutTour() // DONE
    {
        base.debutTour();

        if (toursRestants > 0)
        {
            toursRestants--;
            if (toursRestants == 0)
                desactiver();
        }
    }

    public void desactiver() // DONE
    {
        toursRestants = 0;
        cibleAltruisme = null;
    }

    public Object? getTarget() // DONE
    {
        return cibleAltruisme;
    }
}
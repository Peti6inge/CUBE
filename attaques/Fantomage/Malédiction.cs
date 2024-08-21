public class Malediction : Attaque
{
    // Attributs // DONE
    private Perso? persoCible; 

    // Constructeur // DONE
    public Malediction(Perso perso) : base(perso)
    {
        cout = 2;
        limitParTour = 1;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.persoEnnemy";
        persoCible = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }

    public void desactiver()
    {
        if (persoCible != null)
        {
            persoCible.malediction = false;
            persoCible = null;
        }
    }
}
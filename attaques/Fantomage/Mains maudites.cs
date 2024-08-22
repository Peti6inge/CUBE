public class MainsMaudites : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public MainsMaudites(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.persoEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoCible;
        if (cible is Perso)
        {
            persoCible = (Perso)cible;
            persoCible.mainsMaudites = true;
        }
        else if (cible is bool)
        {
            persoCible = (bool)cible ? myCase.persoOver() : myCase.perso();
            if (persoCible != null)
                persoCible.mainsMaudites = true;
        }
    }
}

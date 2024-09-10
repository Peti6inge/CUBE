public class SortDeProtection : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public SortDeProtection(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.sortDeProtection;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoCible = (Perso?)cible;
        if (persoCible != null)
            persoCible.esquive = true;
    }
}

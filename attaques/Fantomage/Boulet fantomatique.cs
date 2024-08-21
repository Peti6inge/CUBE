public class BouletFantomatique : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public BouletFantomatique(Perso perso) : base(perso)
    {
        cout = 1;
        limitParCible = 3;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.persoEnnemy";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
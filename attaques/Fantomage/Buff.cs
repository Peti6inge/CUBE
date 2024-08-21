public class Buff : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Buff(Perso perso) : base(perso)
    {
        cout = 2;
        limitParCible = 1;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.persoFriendly";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
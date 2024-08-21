public class Invincibilite : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Invincibilite(Perso perso) : base(perso)
    {
        cout = 6;
        limitParTour = 1;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = (int)Jeu.CibleType.freeOnPerso";
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        perso.invincible = true;
    }
}

public class Invincibilite : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Invincibilite(Perso perso) : base(perso)
    {
        cout = 4;
        limitParTour = 1;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.freeOnPerso;
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        perso.invincible = true;
    }
}
public class Reanimation : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Reanimation(Perso perso) : base(perso)
    {
        cout = 8;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.reanimation";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
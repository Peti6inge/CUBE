public class Derobade : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Derobade(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.derobade";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
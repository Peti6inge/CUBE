public class Acide : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Acide(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.acide";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
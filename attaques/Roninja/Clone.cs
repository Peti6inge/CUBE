public class Clone : Attaque
{
    // Attributs // DONE
    private InvocationSimpleBloquante? myClone;
    
    // Constructeur // DONE
    public Clone(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.tonneauOuClone";
        myClone = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO : Penser à activer les pièges
    }

    public InvocationSimpleBloquante? getClone()
    {
        return myClone;
    }
}
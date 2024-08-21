public class PoudreSoporifique : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public PoudreSoporifique(Perso perso) : base(perso)
    {
        cout = 7;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.persoEnnemy";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
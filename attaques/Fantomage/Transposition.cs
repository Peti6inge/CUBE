public class Transposition : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Transposition(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.transposition;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        if (cible is InvocationSimpleBloquante) // Cas : Transposition avec le clone
        {
            InvocationSimpleBloquante clone = (InvocationSimpleBloquante)cible;
            
        }
        else if (cible is Perso) // Cas : Transposition avec un allié
        {
            Perso ciblePerso = (Perso)cible;
            
        }
    }
}

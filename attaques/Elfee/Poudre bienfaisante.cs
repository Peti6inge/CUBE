public class PoudreBienfaisante : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public PoudreBienfaisante(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = true;
        typeCible = "persoFriendly";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
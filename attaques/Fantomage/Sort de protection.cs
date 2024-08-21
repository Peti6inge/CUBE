public class SortDeProtection : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public SortDeProtection(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = "sortDeProtection";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
public class PiegeALoup : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public PiegeALoup(Perso perso) : base(perso)
    {
        cout = 5;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = true;
        typeCible = "piegeSimple";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
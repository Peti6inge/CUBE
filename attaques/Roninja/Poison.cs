public class Poison : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Poison(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = true;
        typeCible = "persoEnnemy";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
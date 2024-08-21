public class Attire : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Attire(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 2;
        porteeMax = 5;
        ligneDeVue = true;
        aligne = true;
        typeCible = "attireRepousse";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
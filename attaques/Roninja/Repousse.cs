public class Repousse : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Repousse(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 1;
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
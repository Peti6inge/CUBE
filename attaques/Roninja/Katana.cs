public class Katana : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Katana(Perso perso) : base(perso)
    {
        cout = 3;
        limitParCible = 1;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = "persoEtInvocEnnemy";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
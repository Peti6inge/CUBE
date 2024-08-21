public class CoupDeBaton : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public CoupDeBaton(Perso perso) : base(perso)
    {
        cout = 3;
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
public class CoupDeBaton : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public CoupDeBaton(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.persoEtInvocEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 2);
    }
}
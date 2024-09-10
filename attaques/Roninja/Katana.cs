public class Katana : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Katana(Perso perso) : base(perso)
    {
        cout = 1;
        limitParCible = 1;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.persoEtInvocEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 3);
    }
}
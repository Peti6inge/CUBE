public class Sabre : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Sabre(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.persoEtInvocEnnemy;
    }
    
    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 5);
    }
}
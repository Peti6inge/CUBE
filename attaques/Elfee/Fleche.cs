public class Fleche : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Fleche(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.persoEtInvocEnnemy;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 1);
    }
}
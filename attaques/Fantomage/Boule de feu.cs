public class BouleDeFeu : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public BouleDeFeu(Perso perso) : base(perso)
    {
        cout = 2;
        limitParCible = 2;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.persoEtInvocEnnemy;
    }
    
    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 1);
    }
}
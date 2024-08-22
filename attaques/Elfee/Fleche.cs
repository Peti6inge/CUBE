public class Fleche : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Fleche(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.persoEtInvocEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 1);
    }
}
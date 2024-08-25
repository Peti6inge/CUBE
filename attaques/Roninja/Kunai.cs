public class Kunai : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Kunai(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.persoEtInvocEnnemy;
        limitParTour = 3;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 1);
    }
}
public class PiegeLineaire : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public PiegeLineaire(Perso perso) : base(perso)
    {
        cout = 2;
        limitParTour = 2;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.piegeLineaire";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
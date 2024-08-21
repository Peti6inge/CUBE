public class PoudreStimulante : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public PoudreStimulante(Perso perso) : base(perso)
    {
        cout = 2;
        limitParTour = 2;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = true;
        typeCible = "persoFriendly";
    }
    
    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
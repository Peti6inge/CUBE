public class Rappel : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Rappel(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.rappel;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
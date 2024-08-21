public class MainsMaudites : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public MainsMaudites(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.persoEnnemy";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
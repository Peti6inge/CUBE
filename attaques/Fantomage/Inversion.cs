public class Inversion : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Inversion(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = false;
        typeCible = (int)Jeu.CibleType.inversion;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
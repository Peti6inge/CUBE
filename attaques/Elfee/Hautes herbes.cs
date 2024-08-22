public class HautesHerbes : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public HautesHerbes(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.hautesHerbes;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        myCase.containsCamouflage = true;
    }
}
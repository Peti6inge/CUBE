public class EauVaseuse : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public EauVaseuse(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 100;
        ligneDeVue = false;
        typeCible = "poseGlissante";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}
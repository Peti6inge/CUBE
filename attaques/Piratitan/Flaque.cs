public class Flaque : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Flaque(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 4;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.poseGlissante;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsGlissante = true;
    }
}
public class Planche : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Planche(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 2;
        ligneDeVue = true;
        typeCible = "planche";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsGlissante = false;
        myCase.containsTrou = false;
    }
}
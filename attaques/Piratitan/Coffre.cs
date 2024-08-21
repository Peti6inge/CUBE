public class Coffre : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Coffre(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 0;
        porteeMax = 5;
        ligneDeVue = true;
        typeCible = "invocationSimpleBloquante";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsSimpleObstacle = false;
        myCase.invocationSimpleBloquante = new InvocationSimpleBloquante("Coffre",perso.isHost, myCase);
    }
}
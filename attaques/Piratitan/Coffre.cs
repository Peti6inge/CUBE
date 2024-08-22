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
        typeCible = Jeu.CibleType.invocationSimpleBloquante;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsSimpleObstacle = false;
        myCase.invocationSimpleBloquante = new InvocationSimpleBloquante(Jeu.InvocationType.Coffre,perso.isHost, myCase);
    }
}
public class CoupDeBaguette : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public CoupDeBaguette(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.invocationSimpleBloquante;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsSimpleObstacle = false;
        myCase.invocationSimpleBloquante = new InvocationSimpleBloquante(
            Jeu.InvocationType.GrossePotion,
            perso.isHost,
            myCase
        );
    }
}

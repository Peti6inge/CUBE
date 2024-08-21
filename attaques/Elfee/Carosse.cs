public class Carosse : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Carosse(Perso perso) : base(perso)
    {
        cout = 5;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = true;
        typeCible = "invocationDoubleBloquante";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsDoubleObstacle = false;
        myCase.getDeuxiemeCaseDoubleObstacle().containsDoubleObstacle = false;
        
        myCase.invocationDoubleBloquante = new InvocationDoubleBloquante("Carosse", perso.isHost, myCase, myCase.getDeuxiemeCaseDoubleObstacle());
        myCase.getDeuxiemeCaseDoubleObstacle().invocationDoubleBloquante = myCase.invocationDoubleBloquante;
    }
}
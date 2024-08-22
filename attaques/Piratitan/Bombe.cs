public class Bombe : Attaque
{
    // Attributs // DONE
    private InvocationNonBloquante? bombe;

    // Constructeur // DONE
    public Bombe(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.invocationNonBloquante;
        bombe = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsPoudre = true;
        if (bombe != null)
            bombe.estKO(bombeExplose: false);
        bombe = new InvocationNonBloquante( (int)Jeu.InvocationType.Bombe, perso.isHost, myCase);
    }

    public InvocationNonBloquante? getBombe() // DONE
    {
        return bombe;
    }

    public void setBombeNull() // DONE
    {
        bombe = null;
    }
}
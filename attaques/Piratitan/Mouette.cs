public class Mouette : Attaque
{
    // Attributs // DONE
    private InvocationNonBloquante? mouette;

    // Constructeur // DONE
    public Mouette(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = "invocationNonBloquante";
        mouette = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (mouette != null)
            mouette.estKO();
        mouette = new InvocationNonBloquante("Mouette", perso.isHost, myCase);
    }

    public InvocationNonBloquante? getMouette() // DONE
    {
        return mouette;
    }

    public void setMouetteNull() // DONE
    {
        mouette = null;
    }
}
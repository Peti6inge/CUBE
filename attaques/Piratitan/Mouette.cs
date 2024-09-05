public class Mouette : Attaque
{
    // Attributs // DONE
    private InvocationNonBloquante? mouette;

    // Constructeur // DONE
    public Mouette(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.invocationNonBloquante;
        mouette = null;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (mouette != null)
            mouette.estKO();
        mouette = new InvocationNonBloquante(Jeu.InvocationType.Mouette    , perso.isHost, myCase);
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
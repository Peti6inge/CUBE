public class Crapeau : Attaque
{
    // Attributs // DONE
    private InvocationNonBloquante? crapeau;
    
    // Constructeur // DONE
    public Crapeau(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 0;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.invocationNonBloquante;
        crapeau = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (crapeau != null)
            crapeau.estKO();
        crapeau = new InvocationNonBloquante( Jeu.InvocationType.Crapeau, perso.isHost, myCase);
    }

    public InvocationNonBloquante? getCrapeau()
    {
        return crapeau;
    }

    public void setCrapeauNull()
    {
        crapeau = null;
    }

}
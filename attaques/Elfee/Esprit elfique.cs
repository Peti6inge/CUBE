public class EspritElfique : Attaque
{
    // Attributs // DONE
    private InvocationNonBloquante? espritElfique;

    // Constructeur // DONE
    public EspritElfique(Perso perso)
        : base(perso)
    {
        cout = 5;
        porteeMin = 0;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.invocationNonBloquante";
        espritElfique = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (espritElfique != null)
            espritElfique.estKO();
        espritElfique = new InvocationNonBloquante("EspritElfique", perso.isHost, myCase);
    }

    public InvocationNonBloquante? getEspritElfique()
    {
        return espritElfique;
    }

    public void setEspritElfiqueNull()
    {
        espritElfique = null;
    }
}

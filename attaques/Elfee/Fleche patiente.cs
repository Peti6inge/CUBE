public class FlechePatiente : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public FlechePatiente(Perso perso) : base(perso)
    {
        cout = 2;
        limitParTour = 1;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = (int)Jeu.CibleType.freeOnFace";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        if (perso.isHost)
            myCase.face.flechesPatientesHost++;
        else
            myCase.face.flechesPatientesClient++;
    }
}
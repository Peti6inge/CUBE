public class Piege
{
    // Attributs
    private string type;
    private bool isHost;
    Case myCase;
    Case? myCaseFinale;

    // Constructeur // DONE
    public Piege(string type, bool isHost, Case myCase, Case? myCaseFinale = null)
    {
        this.type = type;
        this.isHost = isHost;
        this.myCase = myCase;
        this.myCaseFinale = myCaseFinale;

        if (isHost)
            myCase.piegeHost = this;
        else
            myCase.piegeClient = this;

        if (myCaseFinale != null)
        {
            if (isHost)
            {
                myCaseFinale.piegeHost = this;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeHost = this;

            }
            else
            {
                myCaseFinale.piegeClient = this;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeClient = this;

            }
        }
    }

    // Méthodes publiques
    public void activer(Object cible) // DONE
    {
        switch (type)
        {
            case "PiegeLineaire":
                activerPiegeLineaire(cible);
                break;
            case "PiegeALoup":
                activerPiegeALoup(cible);
                break;
            case "CaseTerrifiante":
                activerCaseTerrifiante(cible);
                break;
        }
    }

    public void activerPiegeLineaire(Object cible) // DONE
    {
        if (myCaseFinale == null)
            return;
        if (isHost)
        {
            Jeu.roninjaHost.infligeDegats(1, cible);
            myCase.piegeHost = null;
            myCaseFinale.piegeHost = null;
            foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
            {
                c.piegeHost = null;
            }
        }
        else
        {
            Jeu.roninjaClient.infligeDegats(1, cible);
            myCase.piegeClient = null;
            myCaseFinale.piegeClient = null;
            foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
            {
                c.piegeClient = null;
            }
        }
    }

    public void activerPiegeALoup(Object cible) // DONE
    {
        if (isHost)
        {
            Jeu.roninjaHost.infligeDegats(3, cible);
            myCase.piegeHost = null;
        }
        else
        {
            Jeu.roninjaClient.infligeDegats(3, cible);
            myCase.piegeClient = null;
        }
    }

    public void activerCaseTerrifiante(Object cible) // DONE
    {
        if (cible is Perso)
            ((Perso)cible).passeTour = true;

        if (isHost)
            myCase.piegeHost = null;

        else
            myCase.piegeClient = null;

    }

    public void estDetruit() // DONE
    {
        if (isHost)
            myCase.piegeHost = null;
        else
            myCase.piegeClient = null;

        if (myCaseFinale != null)
        {
            if (isHost)
            {
                myCaseFinale.piegeHost = null;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeHost = null;

            }
            else
            {
                myCaseFinale.piegeClient = null;
                foreach (Case c in myCase.GetLine(myCase.face, myCase, myCaseFinale))
                    c.piegeClient = null;

            }
        }
    }
}

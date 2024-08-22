public class Face
{
    // Attributs // DONE
    public Jeu.FaceType name { get; set; }
    public Case[,] grid { get; set; }
    public bool longueVueHost { get; set; }
    public bool longueVueClient { get; set; }
    public int flechesPatientesHost { get; set; }
    public int flechesPatientesClient { get; set; }
    public bool brumeHost { get; set; }
    public bool brumeClient { get; set; }

    // Constructeur // DONE
    public Face(Jeu.FaceType name)
    {
        this.name = name;
        grid = new Case[8, 8];

        if (name == Jeu.FaceType.Host || name == Jeu.FaceType.Client)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if ((row == 1 || row == 6) && (col == 1 || col == 6))
                    {
                        grid[row, col] = new Case(Jeu.CaseType.SimpleObstacle, this, row, col);
                    }
                    else if ((row == 3 || row == 4) && (col == 3 || col == 4))
                    {
                        grid[row, col] = new Case(Jeu.CaseType.Table, this, row, col);
                    }
                    else if (row == 2 && col == 2)
                    {
                        grid[row, col] = new Case(Jeu.CaseType.Roninja, this, row, col);
                    }
                    else if (row == 2 && col == 5)
                    {
                        grid[row, col] = new Case(Jeu.CaseType.Elfee, this, row, col);
                    }
                    else if (row == 5 && col == 2)
                    {
                        grid[row, col] = new Case(Jeu.CaseType.Fantomage, this, row, col);
                    }
                    else if (row == 5 && col == 5)
                    {
                        grid[row, col] = new Case(Jeu.CaseType.Piratitan, this, row, col);
                    }
                    else
                    {
                        grid[row, col] = new Case(Jeu.CaseType.Vide, this, row, col);
                    }
                }
            }
        }
        else
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, "ingame");
            Random random = new Random();
            int randomIndex = random.Next(1, 21);
            string filePath = Path.Combine(directoryPath, $"Pattern_{randomIndex}.txt");
            string[] lines = File.ReadAllLines(filePath);
            for (int row = 0; row < 8; row++)
            {
                string[] values = lines[row]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < 8; col++)
                {
                    switch (values[col])
                    {
                        case "0":
                            grid[row, col] = new Case(Jeu.CaseType.Vide, this, row, col);
                            break;
                        case "1":
                            grid[row, col] = new Case(
                                Jeu.CaseType.SimpleObstacle,
                                this,
                                row,
                                col
                            );
                            break;
                        case "2H":
                            grid[row, col] = new Case(
                                Jeu.CaseType.DoubleObstacleHaut,
                                this,
                                row,
                                col
                            );
                            break;
                        case "2B":
                            grid[row, col] = new Case(
                                Jeu.CaseType.DoubleObstacleBas,
                                this,
                                row,
                                col
                            );
                            break;
                        case "2G":
                            grid[row, col] = new Case(
                                Jeu.CaseType.DoubleObstacleGauche,
                                this,
                                row,
                                col
                            );
                            break;
                        case "2D":
                            grid[row, col] = new Case(
                                Jeu.CaseType.DoubleObstacleDroite,
                                this,
                                row,
                                col
                            );
                            break;
                        case "3":
                            grid[row, col] = new Case(Jeu.CaseType.Trou, this, row, col);
                            break;
                        case "4":
                            grid[row, col] = new Case(Jeu.CaseType.Camouflage, this, row, col);
                            break;
                        case "5":
                            grid[row, col] = new Case(Jeu.CaseType.Glissante, this, row, col);
                            break;
                    }
                }
            }
        }

        longueVueHost = false;
        longueVueClient = false;
        flechesPatientesHost = 0;
        flechesPatientesClient = 0;
        brumeHost = false;
        brumeClient = false;
    }

    // Méthodes public
    public void maJEmbrumage(bool isHost) // DONE
    {
        if (isHost && !brumeHost || !isHost && !brumeClient)
        {
            return;
        }

        InvocationNonBloquante? mouetteCandidate = null;
        if (isHost && mouetteHost())
        {
            mouetteCandidate = (
                (Mouette)Jeu.piratitanHost.attaques[Jeu.AttaqueType.mouette]
            ).getMouette();
        }
        if (!isHost && mouetteClient())
        {
            mouetteCandidate = (
                (Mouette)Jeu.piratitanClient.attaques[Jeu.AttaqueType.mouette]
            ).getMouette();
        }

        bool[,] bools = new bool[8, 8];

        if (mouetteCandidate != null && this == mouetteCandidate.myCase.face)
        {
            bools[mouetteCandidate.myCase.row, mouetteCandidate.myCase.col] = true;
            if (mouetteCandidate.myCase.row != 0)
                bools[mouetteCandidate.myCase.row - 1, mouetteCandidate.myCase.col] = true;

            if (mouetteCandidate.myCase.row != 7)
                bools[mouetteCandidate.myCase.row + 1, mouetteCandidate.myCase.col] = true;

            if (mouetteCandidate.myCase.col != 0)
                bools[mouetteCandidate.myCase.row, mouetteCandidate.myCase.col - 1] = true;

            if (mouetteCandidate.myCase.col != 7)
                bools[mouetteCandidate.myCase.row, mouetteCandidate.myCase.col + 1] = true;
        }

        foreach (Perso perso in isHost ? Jeu.PersosHost() : Jeu.PersosClient())
        {
            if (perso.myCase != null && perso.myCase.face == this)
            {
                bools[perso.myCase.row, perso.myCase.col] = true;
                if (perso.myCase.row != 0)
                    bools[perso.myCase.row - 1, perso.myCase.col] = true;

                if (perso.myCase.row != 7)
                    bools[perso.myCase.row + 1, perso.myCase.col] = true;

                if (perso.myCase.col != 0)
                    bools[perso.myCase.row, perso.myCase.col - 1] = true;

                if (perso.myCase.col != 7)
                    bools[perso.myCase.row, perso.myCase.col + 1] = true;
            }
        }
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (isHost)
                    grid[row, col].containsBrumeRoninjaHost = bools[row, col];
                else
                    grid[row, col].containsBrumeRoninjaClient = bools[row, col];
            }
        }
    }

    public void maJEmbrumage() // DONE
    {
        maJEmbrumage(true);
        maJEmbrumage(false);
    }

    public bool faceVisible(bool isHost) // DONE
    {
        if (isHost)
        {
            return (Jeu.roninjaHost.myCase != null && this == Jeu.roninjaHost.myCase.face)
                || (Jeu.elfeeHost.myCase != null && this == Jeu.elfeeHost.myCase.face)
                || (Jeu.fantomageHost.myCase != null && this == Jeu.fantomageHost.myCase.face)
                || (Jeu.piratitanHost.myCase != null && this == Jeu.piratitanHost.myCase.face)
                || mouetteHost();
        }
        else
        {
            return (Jeu.roninjaClient.myCase != null && this == Jeu.roninjaClient.myCase.face)
                || (Jeu.elfeeClient.myCase != null && this == Jeu.elfeeClient.myCase.face)
                || (Jeu.fantomageClient.myCase != null && this == Jeu.fantomageClient.myCase.face)
                || (Jeu.piratitanClient.myCase != null && this == Jeu.piratitanClient.myCase.face)
                || mouetteClient();
        }
    }

    public bool mouetteHost() // DONE
    {
        if (Jeu.piratitanHost.attaques.ContainsKey(Jeu.AttaqueType.mouette))
        {
            InvocationNonBloquante? mouetteCandidate = (
                (Mouette)Jeu.piratitanHost.attaques[Jeu.AttaqueType.mouette]
            ).getMouette();
            if (mouetteCandidate != null && mouetteCandidate.myCase.face == this)
            {
                return true;
            }
        }
        return false;
    }

    public bool mouetteClient() // DONE
    {
        if (Jeu.piratitanClient.attaques.ContainsKey(Jeu.AttaqueType.mouette))
        {
            InvocationNonBloquante? mouetteCandidate = (
                (Mouette)Jeu.piratitanClient.attaques[Jeu.AttaqueType.mouette]
            ).getMouette();
            if (mouetteCandidate != null && mouetteCandidate.myCase.face == this)
            {
                return true;
            }
        }
        return false;
    }

    public void activerBrumeHost() // DONE
    {
        brumeHost = true;
        maJEmbrumage();
    }

    public void activerBrumeClient() // DONE
    {
        brumeClient = true;
        maJEmbrumage();
    }

    public void desactiverBrumeHost() // DONE
    {
        if (brumeHost)
        {
            brumeHost = false;
            foreach (Case case_ in grid)
            {
                case_.containsBrumeRoninjaHost = false;
            }
        }
    }

    public void desactiverBrumeClient() // DONE
    {
        if (brumeClient)
        {
            brumeClient = false;
            foreach (Case case_ in grid)
            {
                case_.containsBrumeRoninjaClient = false;
            }
        }
    }

    public InvocationNonBloquante? espritElfiqueHost() // DONE
    {
        if (Jeu.elfeeHost.attaques.ContainsKey(Jeu.AttaqueType.espritElfique))
        {
            InvocationNonBloquante? espritElfiqueCandidat = (
                (EspritElfique)Jeu.elfeeHost.attaques[Jeu.AttaqueType.espritElfique]
            ).getEspritElfique();
            if (espritElfiqueCandidat != null && espritElfiqueCandidat.myCase.face == this)
            {
                return espritElfiqueCandidat;
            }
        }
        return null;
    }

    public InvocationNonBloquante? espritElfiqueClient() // DONE
    {
        if (Jeu.elfeeClient.attaques.ContainsKey(Jeu.AttaqueType.espritElfique))
        {
            InvocationNonBloquante? espritElfiqueCandidat = (
                (EspritElfique)Jeu.elfeeClient.attaques[Jeu.AttaqueType.espritElfique]
            ).getEspritElfique();
            if (espritElfiqueCandidat != null && espritElfiqueCandidat.myCase.face == this)
            {
                return espritElfiqueCandidat;
            }
        }
        return null;
    }

    public InvocationSimpleBloquante? coffreLePlusPres(Case myCase) // DONE
    {
        List<InvocationSimpleBloquante> coffres = new List<InvocationSimpleBloquante>();
        foreach (Case c in grid)
        {
            if (
                c.invocationSimpleBloquante != null
                && c.invocationSimpleBloquante.type == Jeu.InvocationType.Coffre
            )
            {
                coffres.Add(c.invocationSimpleBloquante);
            }
        }
        InvocationSimpleBloquante? res = null;
        foreach (InvocationSimpleBloquante coffre in coffres)
        {
            if (res == null || myCase.distance(coffre.myCase) < myCase.distance(res.myCase))
            {
                res = coffre;
            }
        }
        return res;
    }

    // Méthodes private

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ POUR DEBOGAGE ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public String toString() // DONE
    {
        String res = "";
        //parcourt de grid
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                res += grid[row, col].toString() + " ";
            }
            res += "\n";
        }
        return res;
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ POUR DEBOGAGE ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}

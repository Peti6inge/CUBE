public class ChargeDuTitan : Attaque
{
    // Attributs // DONE
    private Dictionary<Face, Dictionary<int, int>> directionsAbsoluesToRelatives;

    // Constructeur // DONE
    public ChargeDuTitan(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.chargeDuTitan;
        directionsAbsoluesToRelatives = new Dictionary<Face, Dictionary<int, int>>()
        {
            {
                Jeu.host,
                new Dictionary<int, int>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Right },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.RotLeft },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.RotRight }
                }
            },
            {
                Jeu.client,
                new Dictionary<int, int>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.north,
                new Dictionary<int, int>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.south,
                new Dictionary<int, int>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.east,
                new Dictionary<int, int>
                {
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.west,
                new Dictionary<int, int>
                {
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
                }
            }
        };
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            if (perso.myCase == null)
                return;

            int direction = perso.myCase.directionTo(myCase);

            int absoluteDirection = getAbsoluteDirection(direction);
            int casesParcourues = 0;
            while (casesParcourues < 32)
            {
                int relativeDirection = getRelativeDirection(absoluteDirection);

                if (
                    perso.harponne.Count > 0
                    && perso.myCase.face != perso.myCase.nextCaseDirection(relativeDirection).face
                )
                    break;

                if (perso.canMoveDirection(relativeDirection))
                {
                    perso.moveDirection(relativeDirection, chargeDuTitan: true);
                    casesParcourues++;
                    if (perso.myCase.obstacleSpawn == Jeu.PersoType.Piratitan)
                        break;
                }
                else
                {
                    perso.recoitDegats(casesParcourues);

                    Object? obstacleRencontre = perso.nextObstacleDirection(relativeDirection);
                    if (obstacleRencontre != null)
                        perso.infligeDegats((int)(casesParcourues / 2), obstacleRencontre);

                    break;
                }
            }
        }
    }

    // Méthodes privées

    private int getRelativeDirection(int direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face][direction];
        return -1;
    }

    private int getAbsoluteDirection(int direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face]
                .FirstOrDefault(x => x.Value == direction)
                .Key;
        return -1;
    }
}

using System.Security.Cryptography;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

class Tests
{
    public static async Task Main()
    {
        var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(
            "AKIAQKPILYLME7VMUU6F",
            "fkT1A+kfBdaAMeIkqyAfpn5HS+JZol+4ISHPs99I"
        );
        dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3); // Remplacez par votre région
        var request = new GetItemRequest
        {
            TableName = "CubePlayers",
            Key = new Dictionary<string, AttributeValue>
            {
                {
                    "username",
                    new AttributeValue
                    {
                        S =
                            "6BuTNY00Elc7/ssapRuJs0kgnh6FZkNpP3uKYGAAT8s=@JcFCInELc8gAgu7BxMYY4/rd9x6it7rva97PlmJ4O2Y="
                    }
                }
            }
        };

        var response = await dynamoDBClient.GetItemAsync(request);
        if (response.Item != null)
        {
            Console.WriteLine(Dechiffrer(response.Item["score"].S));
        }
    }

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de communication en BDD ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static IAmazonDynamoDB dynamoDBClient;

    public static async Task creerJoueur(string username, string password)
    {
        username = Chiffrer(username);
        password = Chiffrer(password);
        var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(
            "AKIAQKPILYLME7VMUU6F",
            "fkT1A+kfBdaAMeIkqyAfpn5HS+JZol+4ISHPs99I"
        );
        dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3); // Remplacez par votre région
        var request = new UpdateItemRequest
        {
            TableName = "CubePlayers",
            Key = new Dictionary<string, AttributeValue>
            {
                {
                    "username",
                    new AttributeValue { S = username + "@" + password }
                }
            },
            AttributeUpdates = new Dictionary<string, AttributeValueUpdate>
            {
                {
                    "Age",
                    new AttributeValueUpdate
                    {
                        Action = "PUT",
                        Value = new AttributeValue { N = "30" }
                    }
                }
            }
        };

        var response = await dynamoDBClient.UpdateItemAsync(request);
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de communication en BDD ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de codage des sortsSkins ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static Dictionary<Enum, bool>? attaquesRoninja;
    private static Dictionary<Enum, bool>? attaquesPiratitan;
    private static Dictionary<Enum, bool>? attaquesFantomage;
    private static Dictionary<Enum, bool>? attaquesElfee;
    private static Dictionary<Enum, bool>? skinsRoninja;
    private static Dictionary<Enum, bool>? skinsPiratitan;
    private static Dictionary<Enum, bool>? skinsFantomage;
    private static Dictionary<Enum, bool>? skinsElfee;

    public static void algoCodageSort() // TODO : Récupérer les sortsSkins en BDD
    {
        attaquesPiratitan = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.ancre, false },
            { Jeu.AttaqueType.bombe, false },
            { Jeu.AttaqueType.bondDuTitan, false },
            { Jeu.AttaqueType.chargeDuTitan, false },
            { Jeu.AttaqueType.coffre, false },
            { Jeu.AttaqueType.coupDeFeu, false },
            { Jeu.AttaqueType.etincelle, false },
            { Jeu.AttaqueType.flaque, false },
            { Jeu.AttaqueType.frappeDuPirate, false },
            { Jeu.AttaqueType.frappeDuTitan, false },
            { Jeu.AttaqueType.harpon, false },
            { Jeu.AttaqueType.invincibilite, false },
            { Jeu.AttaqueType.longueVue, false },
            { Jeu.AttaqueType.mouette, false },
            { Jeu.AttaqueType.planche, false },
            { Jeu.AttaqueType.porterDeposer, false },
            { Jeu.AttaqueType.poudre, false },
            { Jeu.AttaqueType.sabre, false },
            { Jeu.AttaqueType.tonneau, false }
        };
        attaquesRoninja = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.acide, false },
            { Jeu.AttaqueType.attire, false },
            { Jeu.AttaqueType.brume, false },
            { Jeu.AttaqueType.clone, false },
            { Jeu.AttaqueType.couteauDeLancee, false },
            { Jeu.AttaqueType.derobadeDeLOmbre, false },
            { Jeu.AttaqueType.derobade, false },
            { Jeu.AttaqueType.entrave, false },
            { Jeu.AttaqueType.feinte, false },
            { Jeu.AttaqueType.invisibilite, false },
            { Jeu.AttaqueType.katana, false },
            { Jeu.AttaqueType.kunai, false },
            { Jeu.AttaqueType.memoire, false },
            { Jeu.AttaqueType.piegeALoup, false },
            { Jeu.AttaqueType.piegeLineaire, false },
            { Jeu.AttaqueType.pirouette, false },
            { Jeu.AttaqueType.poison, false },
            { Jeu.AttaqueType.repousse, false },
            { Jeu.AttaqueType.teleport, false }
        };
        attaquesFantomage = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.bouleDeFeu, false },
            { Jeu.AttaqueType.bouletFantomatique, false },
            { Jeu.AttaqueType.buff, false },
            { Jeu.AttaqueType.caseDeRapatriement, false },
            { Jeu.AttaqueType.caseTerrifiante, false },
            { Jeu.AttaqueType.clairvoyance, false },
            { Jeu.AttaqueType.coupDeBaton, false },
            { Jeu.AttaqueType.crapeau, false },
            { Jeu.AttaqueType.eauVaseuse, false },
            { Jeu.AttaqueType.feuFollet, false },
            { Jeu.AttaqueType.gravite, false },
            { Jeu.AttaqueType.inversion, false },
            { Jeu.AttaqueType.jouvence, false },
            { Jeu.AttaqueType.mainsMaudites, false },
            { Jeu.AttaqueType.malediction, false },
            { Jeu.AttaqueType.rappel, false },
            { Jeu.AttaqueType.sortDeProtection, false },
            { Jeu.AttaqueType.transposition, false },
            { Jeu.AttaqueType.voileDInvisibilite, false }
        };
        attaquesElfee = new Dictionary<Enum, bool>
        {
            { Jeu.AttaqueType.altruisme, false },
            { Jeu.AttaqueType.carosse, false },
            { Jeu.AttaqueType.coupDeBaguette, false },
            { Jeu.AttaqueType.derniereVolontee, false },
            { Jeu.AttaqueType.elixirAgressif, false },
            { Jeu.AttaqueType.envolAtterissage, false },
            { Jeu.AttaqueType.espritElfique, false },
            { Jeu.AttaqueType.esquive, false },
            { Jeu.AttaqueType.fleche, false },
            { Jeu.AttaqueType.flecheDeLumiere, false },
            { Jeu.AttaqueType.flechePatiente, false },
            { Jeu.AttaqueType.hautesHerbes, false },
            { Jeu.AttaqueType.miniaturisation, false },
            { Jeu.AttaqueType.petitSoin, false },
            { Jeu.AttaqueType.poudreBienfaisante, false },
            { Jeu.AttaqueType.poudreSoporifique, false },
            { Jeu.AttaqueType.poudreStimulante, false },
            { Jeu.AttaqueType.reanimation, false },
            { Jeu.AttaqueType.soinTotal, false }
        };

        // Codage d'un sort
        long sort = codageSortSkins(attaquesRoninja);

        // Décodage d'un sort (stockage dans les variables statiques)
        decodageSortSkins(attaquesRoninja, sort);
    }

    public static long codageSortSkins(Dictionary<Enum, bool> sortSkin)
    {
        long res = 0;
        long i = 1;
        foreach (bool val in sortSkin.Values)
        {
            res += val ? i : 0;
            i *= 2;
        }
        return res;
    }

    public static void decodageSortSkins(Dictionary<Enum, bool> sortSkin, long sort)
    {
        int i = 1;
        foreach (Jeu.AttaqueType val in sortSkin.Keys)
        {
            sortSkin[val] = IsBitSet(sort, i);
            i++;
        }
    }

    private static bool IsBitSet(long number, int bitPosition)
    {
        return (number & (1L << (bitPosition - 1))) != 0;
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de codage des sortsSkins ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Algorithme de chiffrement ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static string cle = "64ry1h6r1sdt6gh1st6gh1se6tg1sdth!";

    private static string Chiffrer(long valeurClair)
    {
        return Chiffrer(valeurClair.ToString());
    }

    private static string Chiffrer(string texteClair)
    {
        using (Aes aesAlg = Aes.Create())
        {
            // Convertir la clé et le vecteur d'initialisation (IV) en bytes
            byte[] cleBytes = Encoding.UTF8.GetBytes(cle);
            Array.Resize(ref cleBytes, 32); // Ajuster la taille de la clé à 256 bits (32 octets)

            aesAlg.Key = cleBytes;
            aesAlg.GenerateIV(); // Génère un IV aléatoire

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                // Ecriture de l'IV d'abord pour le récupérer lors du déchiffrement
                msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                using (
                    CryptoStream csEncrypt = new CryptoStream(
                        msEncrypt,
                        encryptor,
                        CryptoStreamMode.Write
                    )
                )
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    // Ecrire les données chiffrées dans le flux
                    swEncrypt.Write(texteClair);
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    private static string Dechiffrer(string texteChiffre)
    {
        byte[] fullCipher = Convert.FromBase64String(texteChiffre);

        using (Aes aesAlg = Aes.Create())
        {
            byte[] iv = new byte[aesAlg.BlockSize / 8];
            byte[] cipherText = new byte[fullCipher.Length - iv.Length];

            // Séparer l'IV du texte chiffré
            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

            byte[] cleBytes = Encoding.UTF8.GetBytes(cle);
            Array.Resize(ref cleBytes, 32); // Ajuster la taille de la clé à 256 bits (32 octets)

            aesAlg.Key = cleBytes;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            using (
                CryptoStream csDecrypt = new CryptoStream(
                    msDecrypt,
                    decryptor,
                    CryptoStreamMode.Read
                )
            )
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                // Lire les données déchiffrées du flux
                return srDecrypt.ReadToEnd();
            }
        }
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ Algorithme de chiffrement ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ POUR DEBOGAGE ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static void showGrid()
    {
        String faceNorth = Jeu.north.toString();
        String faceSouth = Jeu.south.toString();
        String faceEast = Jeu.east.toString();
        String faceWest = Jeu.west.toString();
        String faceHost = Jeu.host.toString();
        String faceClient = Jeu.client.toString();
        String grid = "                               ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += "                              |";
            grid += faceClient.Substring(i * 17, 16);
            grid += "|\n";
        }
        grid += "                               ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾\n";
        grid += "________________     ________________     ________________     ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += faceSouth.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceWest.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceNorth.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceEast.Substring(i * 17, 16);
            grid += "\n";
        }
        grid += "‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾\n";
        grid += "                               ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += "                              |";
            grid += faceHost.Substring(i * 17, 16);
            grid += "|\n";
        }
        grid += "                               ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾";
        Console.WriteLine(grid);
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ POUR DEBOGAGE ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}

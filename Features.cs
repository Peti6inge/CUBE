using System.Security.Cryptography;
using System.Text;

// AWS
// using Amazon.DynamoDBv2;
// using Amazon.DynamoDBv2.Model;
// AWS

public class Features
{

    public enum AttaqueType
    {
        carosse,
        bombe,
        espritElfique,
        crapeau,
        mouette,
        tonneau,
        coffre,
        clone,
        dragAndDrop,
        ancre,
        bondDuTitan,
        chargeDuTitan,
        coupDeFeu,
        etincelle,
        flaque,
        frappeDuPirate,
        frappeDuTitan,
        harpon,
        invincibilite,
        longueVue,
        planche,
        porterDeposer,
        poudre,
        sabre,
        altruisme,
        coupDeBaguette,
        derniereVolontee,
        elixirAgressif,
        envolAtterissage,
        esquive,
        fleche,
        flecheDeLumiere,
        flechePatiente,
        hautesHerbes,
        miniaturisation,
        petitSoin,
        poudreBienfaisante,
        poudreSoporifique,
        poudreStimulante,
        reanimation,
        soinTotal,
        acide,
        attire,
        brume,
        couteauDeLancee,
        derobadeDeLOmbre,
        derobade,
        entrave,
        feinte,
        invisibilite,
        katana,
        kunai,
        memoire,
        piegeALoup,
        piegeLineaire,
        pirouette,
        poison,
        repousse,
        teleport,
        bouleDeFeu,
        bouletFantomatique,
        buff,
        caseDeRapatriement,
        caseTerrifiante,
        clairvoyance,
        coupDeBaton,
        eauVaseuse,
        feuFollet,
        gravite,
        inversion,
        jouvence,
        mainsMaudites,
        malediction,
        rappel,
        sortDeProtection,
        transposition,
        voileDInvisibilite,
        none
    }

    public enum SkinType
    {
        roninjaBasique,
        elfeeBasique,
        fantomageBasique,
        piratitanBasique,
        none
    }

    public static void Main()
    {
        
    }

    // AWS
    // private static IAmazonDynamoDB? dynamoDBClient;
    // private static string c1 = "AKIAQKPILYLME7VMUU6F";
    // private static string cs = "fkT1A+kfBdaAMeIkqyAfpn5HS+JZol+4ISHPs99I";
    // AWS

    private static string pseudo = "";
    private static string username = "";
    private static int score;
    private static Dictionary<Enum, bool> attaquesRoninja = new Dictionary<Enum, bool>
        {
            { AttaqueType.acide, false },
            { AttaqueType.attire, false },
            { AttaqueType.brume, false },
            { AttaqueType.clone, false },
            { AttaqueType.couteauDeLancee, false },
            { AttaqueType.derobadeDeLOmbre, false },
            { AttaqueType.derobade, false },
            { AttaqueType.entrave, false },
            { AttaqueType.feinte, false },
            { AttaqueType.invisibilite, true },
            { AttaqueType.katana, false },
            { AttaqueType.kunai, false },
            { AttaqueType.memoire, false },
            { AttaqueType.piegeALoup, true },
            { AttaqueType.piegeLineaire, false },
            { AttaqueType.pirouette, false },
            { AttaqueType.poison, true },
            { AttaqueType.repousse, false },
            { AttaqueType.teleport, false }
        };
    private static Dictionary<Enum, bool> attaquesPiratitan = new Dictionary<Enum, bool>
        {
            { AttaqueType.ancre, false},
            { AttaqueType.bombe, true},
            { AttaqueType.bondDuTitan, false},
            { AttaqueType.chargeDuTitan, false},
            { AttaqueType.coffre, false},
            { AttaqueType.coupDeFeu, false},
            { AttaqueType.etincelle, true},
            { AttaqueType.flaque, false},
            { AttaqueType.frappeDuPirate, false},
            { AttaqueType.frappeDuTitan, false},
            { AttaqueType.harpon, false},
            { AttaqueType.invincibilite, false},
            { AttaqueType.longueVue, false},
            { AttaqueType.mouette, false},
            { AttaqueType.planche, false},
            { AttaqueType.porterDeposer, false},
            { AttaqueType.poudre, true},
            { AttaqueType.sabre, false},
            { AttaqueType.tonneau, false}
        };
    private static Dictionary<Enum, bool> attaquesFantomage = new Dictionary<Enum, bool>
        {
            { AttaqueType.bouleDeFeu, false},
            { AttaqueType.bouletFantomatique, false},
            { AttaqueType.buff, true},
            { AttaqueType.caseDeRapatriement, false},
            { AttaqueType.caseTerrifiante, false},
            { AttaqueType.clairvoyance, false},
            { AttaqueType.coupDeBaton, false},
            { AttaqueType.crapeau, true},
            { AttaqueType.eauVaseuse, false},
            { AttaqueType.feuFollet, false},
            { AttaqueType.gravite, false},
            { AttaqueType.inversion, false},
            { AttaqueType.jouvence, false},
            { AttaqueType.mainsMaudites, false},
            { AttaqueType.malediction, false},
            { AttaqueType.rappel, false},
            { AttaqueType.sortDeProtection, false},
            { AttaqueType.transposition, true},
            { AttaqueType.voileDInvisibilite, false}
        };
    private static Dictionary<Enum, bool> attaquesElfee = new Dictionary<Enum, bool>
        {
            { AttaqueType.altruisme, false},
            { AttaqueType.carosse, false},
            { AttaqueType.coupDeBaguette, false},
            { AttaqueType.derniereVolontee, false},
            { AttaqueType.elixirAgressif, false},
            { AttaqueType.envolAtterissage, true},
            { AttaqueType.espritElfique, false},
            { AttaqueType.esquive, false},
            { AttaqueType.fleche, false},
            { AttaqueType.flecheDeLumiere, false},
            { AttaqueType.flechePatiente, false},
            { AttaqueType.hautesHerbes, false},
            { AttaqueType.miniaturisation, false},
            { AttaqueType.petitSoin, false},
            { AttaqueType.poudreBienfaisante, false},
            { AttaqueType.poudreSoporifique, true},
            { AttaqueType.poudreStimulante, true},
            { AttaqueType.reanimation, false},
            { AttaqueType.soinTotal, false}
        };
    private static Dictionary<Enum, bool> skinsRoninja = new Dictionary<Enum, bool>
        {
            { SkinType.roninjaBasique, true}
        };
    private static Dictionary<Enum, bool> skinsPiratitan = new Dictionary<Enum, bool>
        {
            { SkinType.piratitanBasique, true}
        };
    private static Dictionary<Enum, bool> skinsFantomage = new Dictionary<Enum, bool>
        {
            { SkinType.fantomageBasique, true}
        };
    private static Dictionary<Enum, bool> skinsElfee = new Dictionary<Enum, bool>
        {
            { SkinType.elfeeBasique, true}
        };

    // AWS
    // // Algorithmes de communication en BDD

    // // Pour essayer de créer un joueur
    // // await createJoueur("pseudo", "password");

    // // Pour essayer de se connecter
    // // await connectJoueur("pseudo", "password");

    // // Pour essayer de mettre à jour les données du joueur
    // // username = "pseudo@password"; // username doit être initialisé
    // // score += 7; // Exemple de modification
    // // attaquesRoninja[AttaqueType.acide] = true; // Exemple de modification
    // // await updateJoueur();

    // public static async Task createJoueur(string givenPseudo, string givenPassword) // TODO : Gérer le cas où le pseudo est déjà utilisé
    // {
    //     // On se connecte à la BDD
    //     var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(c1, cs);
    //     dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3);

    //     // On teste si le pseudo est déjà utilisé
    //     var request1 = new GetItemRequest
    //     {
    //         TableName = "CubePlayers",
    //         Key = new Dictionary<string, AttributeValue>
    //         {
    //             {
    //                 "username",
    //                 new AttributeValue { S = givenPseudo}
    //             }
    //         }
    //     };
    //     var response1 = await dynamoDBClient.GetItemAsync(request1);

    //     // Si le pseudo est déjà utilisé, on arrête
    //     if (response1.Item.Count > 0)
    //     {
    //         Console.WriteLine("Ce pseudo est déjà utilisé");
    //         return;
    //     }

    //     // On assigne localement les valeurs du joueur
    //     username = givenPseudo + "@" + givenPassword;
    //     pseudo = givenPseudo;
    //     score = 500;

    //     // On crée un pseudo en BDD
    //     var request = new UpdateItemRequest
    //     {
    //         TableName = "CubePlayers",
    //         Key = new Dictionary<string, AttributeValue>
    //         {
    //             {
    //                 "username",
    //                 new AttributeValue { S = givenPseudo}
    //             }
    //         }
    //     };
    //     var response2 = dynamoDBClient.UpdateItemAsync(request);

    //     // On envoie les données en BDD
    //     await updateJoueur();
    // }

    // public static async Task updateJoueur()
    // {
    //     // On chiffre les données
    //     string usernameChiffre = Chiffrer(username, true);
    //     string scoreChiffre = Chiffrer(score);
    //     string attaquesRoninjaChiffre = Chiffrer(codageSortSkins(attaquesRoninja));
    //     string attaquesPiratitanChiffre = Chiffrer(codageSortSkins(attaquesPiratitan));
    //     string attaquesFantomageChiffre = Chiffrer(codageSortSkins(attaquesFantomage));
    //     string attaquesElfeeChiffre = Chiffrer(codageSortSkins(attaquesElfee));
    //     string skinsRoninjaChiffre = Chiffrer(codageSortSkins(skinsRoninja));
    //     string skinsPiratitanChiffre = Chiffrer(codageSortSkins(skinsPiratitan));
    //     string skinsFantomageChiffre = Chiffrer(codageSortSkins(skinsFantomage));
    //     string skinsElfeeChiffre = Chiffrer(codageSortSkins(skinsElfee));

    //     // On envoie les données en BDD
    //     var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(c1, cs);
    //     dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3);
    //     var request = new UpdateItemRequest
    //     {
    //         TableName = "CubePlayers",
    //         Key = new Dictionary<string, AttributeValue>
    //         {
    //             {
    //                 "username",
    //                 new AttributeValue { S = usernameChiffre}
    //             }
    //         },
    //         AttributeUpdates = new Dictionary<string, AttributeValueUpdate>
    //         {
    //             {
    //                 "score",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = scoreChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "attaquesRoninja",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = attaquesRoninjaChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "attaquesPiratitan",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = attaquesPiratitanChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "attaquesFantomage",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = attaquesFantomageChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "attaquesElfee",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = attaquesElfeeChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "skinsRoninja",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = skinsRoninjaChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "skinsPiratitan",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = skinsPiratitanChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "skinsFantomage",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = skinsFantomageChiffre },
    //                     Action = "PUT"
    //                 }
    //             },
    //             {
    //                 "skinsElfee",
    //                 new AttributeValueUpdate
    //                 {
    //                     Value = new AttributeValue { S = skinsElfeeChiffre },
    //                     Action = "PUT"
    //                 }
    //             }
    //         }
    //     };
    //     var response = await dynamoDBClient.UpdateItemAsync(request);
    // }

    // public static async Task connectJoueur(string givenPseudo, string givenPassword) // TODO : Gérer le cas : Mauvais pseudo ou mot de passe
    // {
    //     // On se connecte à la BDD
    //     var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(c1, cs);
    //     dynamoDBClient = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.EUWest3);

    //     // On chiffre les données
    //     string usernameChiffre = Chiffrer(givenPseudo + "@" + givenPassword, true);

    //     // On récupère les données en BDD
    //     var request = new GetItemRequest
    //     {
    //         TableName = "CubePlayers",
    //         Key = new Dictionary<string, AttributeValue>
    //         {
    //             {
    //                 "username",
    //                 new AttributeValue { S = usernameChiffre}
    //             }
    //         }
    //     };
    //     var response = await dynamoDBClient.GetItemAsync(request);

    //     // Si le pseudo ou le mot de passe est incorrect, on arrête
    //     if (response.Item.Count == 0)
    //     {
    //         Console.WriteLine("Mauvais pseudo ou mot de passe");
    //         return;
    //     }

    //     // On déchiffre les données
    //     pseudo = givenPseudo;
    //     username = givenPseudo + "@" + givenPassword;
    //     score = int.Parse(Dechiffrer(response.Item["score"].S));
    //     decodageSortSkins(attaquesRoninja, long.Parse(Dechiffrer(response.Item["attaquesRoninja"].S)));
    //     decodageSortSkins(attaquesPiratitan, long.Parse(Dechiffrer(response.Item["attaquesPiratitan"].S)));
    //     decodageSortSkins(attaquesFantomage, long.Parse(Dechiffrer(response.Item["attaquesFantomage"].S)));
    //     decodageSortSkins(attaquesElfee, long.Parse(Dechiffrer(response.Item["attaquesElfee"].S)));
    //     decodageSortSkins(skinsRoninja, long.Parse(Dechiffrer(response.Item["skinsRoninja"].S)));
    //     decodageSortSkins(skinsPiratitan, long.Parse(Dechiffrer(response.Item["skinsPiratitan"].S)));
    //     decodageSortSkins(skinsFantomage, long.Parse(Dechiffrer(response.Item["skinsFantomage"].S)));
    //     decodageSortSkins(skinsElfee, long.Parse(Dechiffrer(response.Item["skinsElfee"].S)));

    // }


    // // Algorithmes de chiffrement

    // private static string c2 = "64ry1h6r1sdt6gh1st6gh1se6tg1sdth!";
    // private static byte[] ivFixe = [
    // 0x94, 0x09, 0x26, 0x17, 0x06, 0x67, 0x92, 0x37,
    // 0x03, 0x67, 0x26, 0x67, 0x51, 0x56, 0x64, 0x30
    // ];

    // private static string Chiffrer(long valeurClair)
    // {
    //     return Chiffrer(valeurClair.ToString());
    // }

    // private static string Chiffrer(string texteClair, bool username = false)
    // {
    //     using (Aes aesAlg = Aes.Create())
    //     {
    //         aesAlg.GenerateIV();
    //         string myKey = username ? texteClair : c2;
    //         byte[] myIv = username ? ivFixe : aesAlg.IV;

    //         // Convertir la clé en bytes
    //         byte[] cleBytes = Encoding.UTF8.GetBytes(myKey);
    //         Array.Resize(ref cleBytes, 32); // Ajuster la taille de la clé à 256 bits (32 octets)

    //         aesAlg.Key = cleBytes;

    //         ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, myIv);

    //         using (MemoryStream msEncrypt = new MemoryStream())
    //         {
    //             // Ecriture de l'IV d'abord pour le récupérer lors du déchiffrement
    //             msEncrypt.Write(myIv, 0, myIv.Length);

    //             using (
    //                 CryptoStream csEncrypt = new CryptoStream(
    //                     msEncrypt,
    //                     encryptor,
    //                     CryptoStreamMode.Write
    //                 )
    //             )
    //             using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
    //             {
    //                 // Ecrire les données chiffrées dans le flux
    //                 swEncrypt.Write(texteClair);
    //             }

    //             return Convert.ToBase64String(msEncrypt.ToArray());
    //         }
    //     }
    // }

    // private static string Dechiffrer(string texteChiffre)
    // {
    //     byte[] fullCipher = Convert.FromBase64String(texteChiffre);

    //     using (Aes aesAlg = Aes.Create())
    //     {
    //         byte[] iv = new byte[aesAlg.BlockSize / 8];
    //         byte[] cipherText = new byte[fullCipher.Length - iv.Length];

    //         // Séparer l'IV du texte chiffré
    //         Array.Copy(fullCipher, iv, iv.Length);
    //         Array.Copy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

    //         byte[] cleBytes = Encoding.UTF8.GetBytes(c2);
    //         Array.Resize(ref cleBytes, 32); // Ajuster la taille de la clé à 256 bits (32 octets)

    //         aesAlg.Key = cleBytes;
    //         aesAlg.IV = iv;

    //         ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

    //         using (MemoryStream msDecrypt = new MemoryStream(cipherText))
    //         using (
    //             CryptoStream csDecrypt = new CryptoStream(
    //                 msDecrypt,
    //                 decryptor,
    //                 CryptoStreamMode.Read
    //             )
    //         )
    //         using (StreamReader srDecrypt = new StreamReader(csDecrypt))
    //         {
    //             // Lire les données déchiffrées du flux
    //             return srDecrypt.ReadToEnd();
    //         }
    //     }
    // }
    // AWS

    // Algorithmes de codage des sortsSkins

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
        foreach (Enum val in sortSkin.Keys)
        {
            sortSkin[val] = IsBitSet(sort, i);
            i++;
        }
    }

    private static bool IsBitSet(long number, int bitPosition)
    {
        return (number & (1L << (bitPosition - 1))) != 0;
    }

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

    public static void afficherDonneesJoueur()
    {
        Console.WriteLine("Les données du joueur test sont :");
        Console.WriteLine("Pseudo : " + pseudo);
        Console.WriteLine("Username : " + username);
        Console.WriteLine("Score : " + score);
        foreach (AttaqueType attaque in attaquesRoninja.Keys)
        {
            if (attaquesRoninja[attaque])
                Console.WriteLine("Attaque Roninja : " + attaque);
        }
        foreach (AttaqueType attaque in attaquesPiratitan.Keys)
        {
            if (attaquesPiratitan[attaque])
                Console.WriteLine("Attaque Piratitan : " + attaque);
        }
        foreach (AttaqueType attaque in attaquesFantomage.Keys)
        {
            if (attaquesFantomage[attaque])
                Console.WriteLine("Attaque Fantomage : " + attaque);
        }
        foreach (AttaqueType attaque in attaquesElfee.Keys)
        {
            if (attaquesElfee[attaque])
                Console.WriteLine("Attaque Elfee : " + attaque);
        }
        foreach (SkinType skin in skinsRoninja.Keys)
        {
            if (skinsRoninja[skin])
                Console.WriteLine("Skin Roninja : " + skin);
        }
        foreach (SkinType skin in skinsPiratitan.Keys)
        {
            if (skinsPiratitan[skin])
                Console.WriteLine("Skin Piratitan : " + skin);
        }
        foreach (SkinType skin in skinsFantomage.Keys)
        {
            if (skinsFantomage[skin])
                Console.WriteLine("Skin Fantomage : " + skin);
        }
        foreach (SkinType skin in skinsElfee.Keys)
        {
            if (skinsElfee[skin])
                Console.WriteLine("Skin Elfee : " + skin);
        }
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ POUR DEBOGAGE ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}

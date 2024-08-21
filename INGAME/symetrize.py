import os

def inverser_mots_dans_ligne(ligne):
    mots = ligne.split()
    return ' '.join(mots[::-1])

def inverser_fichiers_txt():
    # Parcourir tous les fichiers du répertoire courant
    for fichier in os.listdir():
        # Vérifier si le fichier est un fichier texte
        if fichier.endswith('.txt'):
            with open(fichier, 'r', encoding='utf-8') as f:
                lignes = f.readlines()
            
            # Inverser les mots de chaque ligne
            lignes_inversées = [inverser_mots_dans_ligne(ligne) for ligne in lignes]
            
            # Nommer le nouveau fichier
            nouveau_nom = fichier.replace('.txt', '_inverse.txt')
            
            # Sauvegarder les lignes inversées dans un nouveau fichier
            with open(nouveau_nom, 'w', encoding='utf-8') as f:
                f.writelines('\n'.join(lignes_inversées))

if __name__ == "__main__":
    inverser_fichiers_txt()

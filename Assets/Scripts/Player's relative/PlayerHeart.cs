using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHeart : MonoBehaviour {

    // Données pour la gestion de l'affichage des coeurs
    public Image heart1;
    public Image damagedHeart1;
    public Image heart2;
    public Image damagedHeart2;
    public Image heart3;
    public Image damagedHeart3;

    public GameObject GUI;

    // Fait gagner le joueur
    public void makeWin()
    {
        GUI.GetComponent<GUIController>().endGame(false); // Execution de la méthode de fin de jeu

    }

    // Mise à mort
    public void makeDead()
    {
        GUI.GetComponent<GUIController>().endGame(true); // Execution de la méthode de fin de jeu
        Destroy(gameObject); // Détruit le gameObject courrant (ici le joueur)

    }

    // Gestion de l'affichage des coeurs
    public void actualizePVs(int healthPower)
    {
        print(healthPower);
        switch (healthPower)
        {
            case 3:
                heart3.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                damagedHeart3.gameObject.SetActive(false);
                damagedHeart2.gameObject.SetActive(false);
                damagedHeart1.gameObject.SetActive(false);
                break;
            case 2:
                heart3.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                damagedHeart3.gameObject.SetActive(true);
                damagedHeart2.gameObject.SetActive(false);
                damagedHeart1.gameObject.SetActive(false);
                break;
            case 1:
                heart3.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart1.gameObject.SetActive(true);
                damagedHeart3.gameObject.SetActive(true);
                damagedHeart2.gameObject.SetActive(true);
                damagedHeart1.gameObject.SetActive(false);
                break;
            case 0:
                print("Game Over !"); // DEBUG !!!
                heart1.gameObject.SetActive(false);
                damagedHeart3.gameObject.SetActive(false);
                damagedHeart2.gameObject.SetActive(false);
                damagedHeart1.gameObject.SetActive(false);
                makeDead();
                break;
            default:
                print("Comportement annormal au niveau de l'affichage des PVs.");
                break;

        }

    }

}

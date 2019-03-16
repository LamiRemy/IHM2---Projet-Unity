using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public GameObject GUI;
    public int playerLevel = 1;
    public int healthPower; // Points de vie
    private int coinNumber = 0; // Nombre de pièces
    public GameObject feedbackDamage;

    void start()
    {
        // Mise a 0 du compteur (initialisation)
        GUI.GetComponent<GUIController>().actualizeCoinView(coinNumber);

    }

    // Health's method
    public void damage(int damagingPower)
    {
        healthPower -= damagingPower;
        Instantiate(feedbackDamage, transform.position, Quaternion.identity); // Son
        print("Vie restante : " + healthPower); // DEBUG
        gameObject.GetComponent<PlayerHeart>().actualizePVs(healthPower);
                
    }

    // Add coin's method
    public void addCoin()
    {
        coinNumber++;
        print("Pièces récoltées : " + coinNumber); // DEBUG 
        GUI.GetComponent<GUIController>().actualizeCoinView(coinNumber);

    }

    // Add health's method (with potion)
    public void addHealth()
    {
        healthPower++;
        print("PVs : " + healthPower);
        gameObject.GetComponent<PlayerHeart>().actualizePVs(healthPower);

    }

}

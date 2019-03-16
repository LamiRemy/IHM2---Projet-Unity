using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour {

    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().healthPower < 3)
            {
                collision.GetComponent<PlayerInventory>().addHealth();
                Instantiate(reward, transform.position, Quaternion.identity); // Son
                Destroy(gameObject.transform.root.gameObject); // Destruction de la potion
            }
            else
                print("Le personnage a trop de PVs pour prendre une potion !");
        }
    }
}

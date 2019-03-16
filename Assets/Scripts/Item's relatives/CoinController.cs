using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().addCoin();
            Instantiate(reward, transform.position, Quaternion.identity); // Son
            Destroy(gameObject.transform.root.gameObject); // Destruction de la pièce
        }
    }
}

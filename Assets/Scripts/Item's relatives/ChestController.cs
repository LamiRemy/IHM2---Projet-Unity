using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

    public GameObject feedbackChest;
    private Animator chestAnim;

    void Start()
    {
        chestAnim = gameObject.GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            chestAnim.SetBool("isOpened", true);
            Instantiate(feedbackChest, transform.position, Quaternion.identity); // Son
            collision.GetComponent<PlayerHeart>().makeWin(); // Win
            Debug.Log("Coffre ouvert !");
        }
    }
}

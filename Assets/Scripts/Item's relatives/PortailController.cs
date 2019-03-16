using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailController : MonoBehaviour
{
    public Collider2D secontPortail;
    private bool isComming = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isComming)
            {
                print("Teleport");
                float x = secontPortail.transform.position.x;
                float y = secontPortail.transform.position.y;
                collision.GetComponent<PlayerController>().Teleport(x, y);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (isComming)
            isComming = false;
        else
            isComming = true;
    }

}

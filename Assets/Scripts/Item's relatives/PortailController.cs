using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailController : MonoBehaviour
{
    public Collider2D secontPortail;
    private static bool isComming;


    public void Start()
    {
        isComming = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isComming)
            {
                isComming = true;
                print("Teleport");
                float x = secontPortail.transform.position.x;
                float y = secontPortail.transform.position.y;
                collision.GetComponent<PlayerController>().Teleport(x, y);
            }
            else if (isComming)
                isComming = false;
        }
    }

}

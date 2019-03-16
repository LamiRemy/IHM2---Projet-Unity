using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour {

    public int damagingPower;

    protected void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
            if (damagingPower > 0)
                hit.GetComponent<PlayerInventory>().damage(damagingPower);
        
        }
    }

    public void DestroyEnnemy()
    {
        Destroy(gameObject);
    }
}

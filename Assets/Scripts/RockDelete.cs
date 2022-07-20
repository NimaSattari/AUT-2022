using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDelete : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

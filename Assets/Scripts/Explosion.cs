using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject exp;
    public float expForce, radius;
    [SerializeField] GameObject deathCam;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Player playerScript;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Comp")
        {
            GameObject expInstance = Instantiate(exp, transform.position, transform.rotation);
            Destroy(expInstance, 3f);
            KnockBack();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            if(deathCam != null)
            {
                deathCam.SetActive(true);
            }
            if (gameOverPanel != null)
            {
                playerScript.gameOver = true;
                gameOverPanel.SetActive(true);
            }
            //Destroy(gameObject);
        }
    }

    void KnockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearby in colliders)
        {
            Rigidbody rigid = nearby.GetComponent<Rigidbody>();
            if(rigid != null)
            {
                rigid.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}

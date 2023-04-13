using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenPlatform : MonoBehaviour
{

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(fallen());
        }
    }

    IEnumerator fallen()
    {
        yield return new WaitForSeconds(0.3f);
        rb.constraints = RigidbodyConstraints2D.None;
        Destroy(gameObject,1.2f);

    }
}

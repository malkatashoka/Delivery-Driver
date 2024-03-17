using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float delayDestruction = 0f;

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    bool pickedUp = false;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Ouch, broke a headlight!");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !pickedUp)
        {
            Debug.Log("Picked up package");
            pickedUp = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, delayDestruction);
        }

        if (collision.tag == "Customer" && pickedUp)
        {
            Debug.Log("Package delivered");
            pickedUp = false;
            spriteRenderer.color = noPackageColor;
        }

        if (collision.tag == "Customer" && pickedUp)
        {
            Debug.Log("Sped up 2x");
            spriteRenderer.color = noPackageColor;
        }
    }
}


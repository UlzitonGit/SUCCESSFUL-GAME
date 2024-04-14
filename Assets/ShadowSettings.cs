using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSettings : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    PlayerMovement pl;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pl = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pl._isGrounded ==false ) spriteRenderer.enabled = false;
        if (pl._isGrounded == true) spriteRenderer.enabled = true;
    }
}

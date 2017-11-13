using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public static Checkpoint CurrentlyActiveCheckpoint;

    [SerializeField]
    private float activatedScale;

    [SerializeField]
    private float deactivatedScale;

    [SerializeField]
    private Color activatedColor;

    [SerializeField]
    private Color deactivatedColor;

    private bool isActive = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = deactivatedColor;
        transform.localScale *= deactivatedScale;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isActive)
        {
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
        isActive = true;
        CurrentlyActiveCheckpoint = this;
        transform.localScale = transform.localScale * activatedScale;
        spriteRenderer.color = activatedColor;

    }

    private void DeactivateCheckpoint()
    {
        if (CurrentlyActiveCheckpoint != null)
        {
            isActive = false;
            spriteRenderer.color = deactivatedColor;

        }
    }
}

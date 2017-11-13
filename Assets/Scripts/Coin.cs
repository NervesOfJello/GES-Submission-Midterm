using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    static int coinCount = 0;

    [SerializeField]
    float refuelAmount = 25;
    
    private Text coinCountText;

    //variables for components
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        //initialize component variables
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        //get the CoinText object and set it as our text variable
        coinCountText = GameObject.Find("CoinText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinCount++;

            audioSource.Play();

            PlayerMovement.jetpackFuel += refuelAmount;

            coinCountText.text = "Coins: " + coinCount;

            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;

            //Destroy(this.gameObject);
        }
    }
}

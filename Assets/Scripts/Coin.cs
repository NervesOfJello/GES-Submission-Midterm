using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    static int coinCount = 0;
    static public bool coinsMaxed = false;
    static int coinsLeft = 0;

    [SerializeField]
    static int levelCoinMax = 10;

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

        //set initial coin text
        coinsLeft = (levelCoinMax - coinCount);

        coinCountText.text = "Coins: " + coinCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinCount++;

            audioSource.Play();

            PlayerMovement.jetpackFuel += refuelAmount;

            coinsLeft = (levelCoinMax - coinCount);

            coinCountText.text = "Coins: " + coinCount;

            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;

            if (coinsLeft <= 0)
            {
                coinsMaxed = true;
            }
            //Destroy(this.gameObject);
        }
    }
}

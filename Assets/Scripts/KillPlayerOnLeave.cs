using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerOnLeave : MonoBehaviour {

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Exited Game Level");
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if (Checkpoint.CurrentlyActiveCheckpoint == null)
    //        {
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        }
    //        else
    //        {
    //            collision.gameObject.transform.position = Checkpoint.CurrentlyActiveCheckpoint.transform.position;
    //        }
    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited Game Level");
        if (collision.gameObject.tag == "Player")
        {
            if (Checkpoint.CurrentlyActiveCheckpoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                collision.gameObject.transform.position = Checkpoint.CurrentlyActiveCheckpoint.transform.position;
            }
        }
    }
}

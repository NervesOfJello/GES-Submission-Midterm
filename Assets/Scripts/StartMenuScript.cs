using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {

	public void StartButtonClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void CreditsButtonClick()
    {
        SceneManager.LoadScene("Level 1");
    }
}

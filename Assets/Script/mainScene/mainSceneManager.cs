using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Animal") && !PlayerPrefs.HasKey("Name"))
        {
            SceneManager.LoadScene("animalSelectScene");
        }
	}
	public void animalScene()
    {
        SceneManager.LoadScene("animalScene");
    }
    public void gameScene()
    {
        SceneManager.LoadScene("gameScene");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour {
    public int version; 
	// Use this for initialization
	void Start ()
    {
        Screen.orientation = ScreenOrientation.Portrait;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Wyjscie()
    {
        Application.Quit();
    }
    public void PlvsPl()
    {
        version = 1;
        PlayerPrefs.SetInt("version", version);
        SceneManager.LoadScene("connectgame");
       
    }
    public void Plvscom()
    {
        version = 2;
        PlayerPrefs.SetInt("version", version);
        SceneManager.LoadScene("connectgame");
       

    }
    public void mainmenu()
    {
        SceneManager.LoadScene("main menu");
    }
}

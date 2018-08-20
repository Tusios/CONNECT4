using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndCheck : MonoBehaviour
{
    GameObject finalscreen;
    Image win;
    public Sprite yellowpl;
    public Sprite redpl;
    

    // Use this for initialization
    void Start()
    {
        win = GameObject.Find("Winner").GetComponent<Image>();
        finalscreen = GameObject.Find("final");
        finalscreen.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void wincheck(int winred, int winyel)
    {
        if (winyel >= 4 || winred >= 4)
        {
            if (winyel >= 4)
            {
                Debug.Log("zolty wygral");
                finalscreen.SetActive(true);
                win.sprite = yellowpl;
                GetComponent<choice>().victory = true;
            }
            else if (winred >= 4)

            {
                Debug.Log("czerwony wygral");
                finalscreen.SetActive(true);
                win.sprite = redpl;
                GetComponent<choice>().victory = true;
            }
        }
       
    }
}

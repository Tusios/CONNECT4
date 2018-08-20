using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class choice : MonoBehaviour {

    public GameObject tokenr;
    public GameObject tokeny;
    public Sprite yellowpl;
    public Sprite redpl;
    public Sprite CPU;

    int draw;
    int round;
    int[,] array = new int[7, 6];
    int i = 0;
    int strona = 1;
    int winred = 1;
    int winyel = 1;
    int versiong;
    int balls;
    int kol;
    int wier;
    public bool victory = false;
    Transform but;
    System.Random side = new System.Random();

    // Use this for initialization
    void Start()
    {
        versiong = PlayerPrefs.GetInt("version");// sprawdzenie wersji, ustawienie orientacji, kolejności gracza, ustawienie obrazu końcowego oraz jego strony
        Screen.orientation = ScreenOrientation.Portrait;
        GameObject.Find("LeftArrow").GetComponent<Image>().enabled = true;
        GameObject.Find("RightArrow").GetComponent<Image>().enabled = false;
        if (versiong == 2)
        {
            round = 3;
            GameObject.Find("yellow player").GetComponent<Image>().sprite = CPU;
        }
        else
            round = 1;
        

    }
	


    public void zetonczerwony(Transform button)
    {

        if (round == 1)
        {


            if (button.localPosition.x == -260)
                wincheckR(0, button);
            else if (button.localPosition.x == -175)
                wincheckR(1, button);
            else if (button.localPosition.x == -88)
                wincheckR(2, button);
            else if (button.localPosition.x == 0)
                wincheckR(3, button);
            else if (button.localPosition.x == 88)
                wincheckR(4, button);
            else if (button.localPosition.x == 175)
                wincheckR(5, button);
            else if (button.localPosition.x == 260)
                wincheckR(6, button);



        }
        else if (round == 2)
        {

            if (button.localPosition.x == -260)
                wincheckY(0, button);
            else if (button.localPosition.x == -175)
                wincheckY(1, button);
            else if (button.localPosition.x == -88)
                wincheckY(2, button);
            else if (button.localPosition.x == 0)
                wincheckY(3, button);
            else if (button.localPosition.x == 88)
                wincheckY(4, button);
            else if (button.localPosition.x == 175)
                wincheckY(5, button);
            else if (button.localPosition.x == 260)
                wincheckY(6, button);
        }
       else if (round == 3)
        {


            if (button.localPosition.x == -260)
                wincheckR(0, button);
            else if (button.localPosition.x == -175)
                wincheckR(1, button);
            else if (button.localPosition.x == -88)
                wincheckR(2, button);
            else if (button.localPosition.x == 0)
                wincheckR(3, button);
            else if (button.localPosition.x == 88)
                wincheckR(4, button);
            else if (button.localPosition.x == 175)
                wincheckR(5, button);
            else if (button.localPosition.x == 260)
                wincheckR(6, button);
        }
       

    }
    public void wincheckR(int a, Transform button)// funkcja pobiera numer kolumny oraz lokalizacje przycisku
    {
        draw = 0;
        i = 0;
        do
        {
            if (array[a, i] ==0 )
            {
                array[a, i] = 1;
                kol = a;
                wier = i;
                break;
            }
            else
                i++;

        } while (i < 6);
       



        if (i < 6)
        {
            GameObject token = Instantiate(tokenr, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            draw = 0;
            token.transform.SetParent(this.transform, false);
            token.transform.localPosition = button.localPosition;
            token.name = "token" + a + i;
            GameObject.Find("LeftArrow").GetComponent<Image>().enabled = false;
            GameObject.Find("RightArrow").GetComponent<Image>().enabled = true;
            
        }
        else
        {
            for (int j = 0; j <= 6; j++)
            {
                if (array[j, 5] != 0)
                    draw++;
            }
            if (draw == 7)
            {
                Debug.Log("REMIS");
            }
            else
            {
                Debug.Log("zagraj gdzies indziej");
            }


        }
        if (i < 6)
        {
            wincheck(1, a);

            if (!victory)
            {
                if (round == 1)
                {
                    round = 2;
                }
                else if (round == 3)
                {
                    round = 4;
                    Invoke("ComputerAI", 1);
                }
            }
        }
    }
    public void wincheckY(int a, Transform button)
    {
        draw = 0;
        i = 0;
        do
        {
            if (array[a, i] != -1 && array[a, i] != 1)
            {
                array[a, i] = -1;
                break;
               
            }
            else
                i++;

        } while (i < 6);

        if (i < 6)
        {
            GameObject token = Instantiate(tokeny, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
          
            token.transform.SetParent(this.transform, false);
            token.transform.localPosition = button.localPosition;
            token.name = "token" + a + i;
            GameObject.Find("LeftArrow").GetComponent<Image>().enabled = true;
            GameObject.Find("RightArrow").GetComponent<Image>().enabled = false;
           
        }
        else
        {
            for (int j = 0; j <= 6; j++)
            {
                if (array[j, 5] != 0)
                    draw++;
            }
            if(draw == 7)
            {
                Debug.Log("REMIS");
            }
            else
            {
                Debug.Log("zagraj gdzies indziej");
            }
        }
        if (i < 6)
        {
            wincheck(2, a);

            if (!victory)
            {
                if (round == 2)
                    round = 1;
                else
                    round = 3;
            }
        }
    }
        
       
    void wincheck(int strona, int a)
    {
        winred = 1;
        winyel = 1;
        for (int n = a + 1, m = a - 1, j = 0; j <= 4; j++) // horizontal check
        {

            if (n < 7)
            {
                if (array[a, i] == array[n, i])
                {
                    if (strona == 2)
                    {
                        winyel++;
                        n++;
                    }
                    else if (strona == 1)
                    {
                        winred++;
                        n++;
                    }
                   
                }
            }
            else { }
            if (m >= 0)
            {
                if (array[a, i] == array[m, i])
                {
                    if (strona == 2)
                    {
                        winyel++;
                        m--;
                    }
                    else if (strona == 1)
                    {
                        winred++;
                        m--;
                    }
                }
            }
            else { }

             GetComponent<EndCheck>().wincheck(winred, winyel);
        }
            winyel = 1;
            winred = 1;
        for (int n = (a + 1), m = (a - 1), t = (i + 1), p = (i - 1), j = 1; j <= 4; j++)//right slant
        {
            if (n < 7 && t <= 5)
            {
                if (array[a, i] == array[n, t])

                {
                    if (strona == 2)
                    {
                        winyel++;
                        n++;
                        t++;
                    }
                    else if (strona == 1)

                    {
                        winred++;
                        n++;
                        t++;
                    }
                }
            }
            else
            { }

            if (m >= 0 && p >= 0)
            {
                if (array[a, i] == array[m, p])
                {
                    if (strona == 2)
                    {
                        winyel++;
                        m--;
                        p--;
                    }
                    else if (strona == 1)
                    {
                        winred++;
                        m--;
                        p--;
                    }
                }
            }
            else
            {
            }

             GetComponent<EndCheck>().wincheck(winred, winyel);
        }
            winred = 1;
            winyel = 1;
        for (int n = (a + 1), m = (a - 1), t = (i + 1), p = (i - 1), j = 1; j <= 4; j++)// left slant
        {
            if (n < 7 && p >= 0)
            {
                if (array[a, i] == array[n, p])
                {
                    if (strona == 2)
                    {
                        winyel++;
                        n++;
                        p--;
                    }
                    else if (strona == 1)
                    {
                        winred++;
                        n++;
                        p--;
                    }
                }
            }
            else
            {

            }

            if (m >= 0 && t <= 5)
            {
                if (array[a, i] == array[m, t])
                {
                    if (strona == 2)
                    {
                        winyel++;
                        m--;
                        t++;
                    }
                    else if (strona == 1)
                    {
                        winred++;
                        m--;
                        t++;
                    }
                }
            }
            else
            {

            }

            GetComponent<EndCheck>().wincheck(winred, winyel);
        }
        winred = 1;
        winyel = 1;
        for(int  p = i-1, j=1; j<=4;j++ )//vertical check
        {
            

                if (p >= 0)
                {
                    if (array[a, i] == array[a, p])
                    {
                        if (strona == 2)
                        {
                            p--;
                            winyel++;
                        }
                        else if (strona == 1)
                        {
                            p--;
                            winred++;
                        }
                    }
                }
                else
                { }
             GetComponent<EndCheck>().wincheck(winred, winyel);
        }
    }
    void ComputerAI()
    {


       
        
             if( balls == 0 )
                {
                int b = side.Next(0, 3);
            if (b == 0)
            {
                but = GameObject.Find("Column 3").GetComponent<Transform>();
                wincheckY(2, but);
                balls++;
            }
            else if (b == 1)
            {
                 but = GameObject.Find("Column 4").GetComponent<Transform>();
                wincheckY(3, but);
                balls++;
            }
            else if(b ==2)
            {
                but = GameObject.Find("Column 5").GetComponent<Transform>();
                wincheckY(4, but);
                balls++;
            }
                }
             else
        {
            // for(int g=0;g<=7;g++)
            int g = 0;
            GetComponent<AIScript>().dangercheck(array, g);
             
        }
          

    }
    public void wysylka (int a)
    {
        string papa = "Column " + (a+1);
        Debug.Log(papa);
        Transform kapa = GameObject.Find((papa)).GetComponent<Transform>() ;
        wincheckY(a, kapa);
    }
}
    


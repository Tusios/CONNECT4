using UnityEngine;
using System.Collections;
using System;

public class wintoken : MonoBehaviour
{
    int kolumna, wiersz, dangerver, dangerhor, dangerleft, dangerright, kolejnosc, maindanger;

    int[] danger = new int[7];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void simulation(int[,] tab, int a)


    {
        if (a > 6)
        {
            GetComponent<choice>().wysylka(kolejnosc);
        }
        else
        {
            dangerver = 0;
            dangerhor = 0;
            dangerleft = 0;
            dangerright = 0;
            wiersz = 7;
            for (int i = 0; i <= 5; i++)
            {
                if (tab[a, i] == 0)
                {
                    kolumna = a;
                    Debug.Log("kolumna = " + kolumna);
                    wiersz = i;
                    Debug.Log("wiersz = " + wiersz);
                    break;
                }

            }
            if (wiersz < 6)
            {
                for (int s = 0; s <= 1; s++)
                    for (int n = a + 1, m = a - 1, j = 0; j <= 2; j++) // horizontal check
                    {

                        if (n < 7)
                        {
                            if (tab[n, wiersz] == 1)

                                if (s == 0)
                                {
                                    dangerhor += 5;
                                    n++;
                                }
                                else if (s == 1)
                                {
                                    dangerhor -= 3;
                                    n = 7;

                                }

                                else if (tab[n, wiersz] == -1)
                                    if (s == 0)
                                    {
                                        dangerhor -= 3;
                                        n = 7;
                                    }

                                    else if (s == 1)
                                    {
                                        dangerhor += 5;
                                        n++;

                                    }
                                    else if (tab[n, wiersz] == 0)
                                        if (s == 0)
                                        {
                                          
                                            n++;

                                        }

                                        else if (s == 1)
                                        {
                                            n++;

                                        }
                        }

                        else {
                          
                        }


                        if (m >= 0)
                        {
                            if (tab[m, wiersz] == 1)
                            {
                                if (s == 0)
                                {
                                    dangerhor += 5;
                                    m--;
                                }
                                else if (s == 1)
                                {
                                    dangerhor -= 3;
                                    m = (-1);

                                }
                            }
                            else if (tab[m, wiersz] == -1)
                            {
                                if (s == 0)
                                {
                                    dangerhor -= 3;
                                    m = (-1);
                                }
                                else if (s == 1)
                                {
                                    dangerhor += 5;
                                    m--;

                                }
                            }
                            else if (tab[m, wiersz] == 0)
                            {
                                if (s == 0)
                                {
                                 
                                    m--;
                                }

                                else if (s == 1)
                                {
                                    m--;

                                }
                            }
                        }
                        else { }
                    }



                Debug.Log("horizonal" + dangerhor);
                for (int s = 0; s <= 1; s++)
                    for (int i = wiersz + 1; i >= 0; i--)//vertical check
                    {
                        if (wiersz == 5)
                        {
                            if (tab[kolumna, i - 1] == 1)
                            {
                                if (s == 0)
                                {
                                    dangerver += 5;
                                }
                                else if (s == 1)
                                {
                                    dangerver -= 3;
                                    break;
                                }
                            }
                            else if (tab[kolumna, i - 1] == 0)
                            {
                                if (s == 0)
                                {
                                    dangerver += 0;
                                }
                            }
                            else if (tab[kolumna, i - 1] == -1)
                            {
                                if (s == 0)
                                {
                                    dangerver -= 3;
                                    break;
                                }
                                else if (s == 1)
                                {
                                    dangerver += 5;
                                }
                            }
                        }
                        else
                        {
                            if (tab[kolumna, i] == 1)
                            {
                                if (s == 0)
                                {
                                    dangerver += 5;
                                }
                                else if (s == 1)
                                {
                                    dangerver -= 3;
                                    break;
                                }
                            }
                            else if (tab[kolumna, i] == 0)
                            {
                                if (s == 0)
                                {
                                    dangerver += 0;
                                }
                            }
                            else if (tab[kolumna, i] == -1)
                            {
                                if (s == 0)

                                {
                                    dangerver -= 3;
                                    break;
                                }
                                else if (s == 1)
                                {
                                    dangerver += 5;
                                }
                            }
                        }
                    }



                Debug.Log("vertical " + dangerver);
                for (int s = 0; s <= 1; s++)
                    for (int n = (a + 1), m = (a - 1), t = (wiersz + 1), p = (wiersz - 1), j = 1; j <= 3; j++)//right slant
                    {
                        if (n < 7 && t <= 5)//right side
                        {
                            if (tab[n, t] == 1)
                            {
                                if (s == 0)
                                {
                                    dangerright += 5;
                                    n++;
                                    t++;
                                }
                                else if (s == 1)
                                {
                                    dangerright -= 3;
                                    n = 7;
                                    t = 6;
                                }
                            }
                            else if (tab[n, t] == -1)
                            {
                                if (s == 0)

                                {
                                    dangerright -= 3;
                                    n = 7;
                                    t = 6;
                                }
                                else if (s == 1)
                                {
                                    dangerright += 5;
                                    n++;
                                    t++;
                                }
                            }
                            else if (tab[n, t] == 0)
                            {
                                if (s == 0)

                                {
                                    
                                    n++;
                                    t++;
                                }
                                else if (s == 1)
                                {
                                    n++;
                                    t++;
                                }
                            }
                        }

                        else
                        { }

                        if (m >= 0 && p >= 0)//left side
                        {
                            if (tab[m, p] == 1)
                            {
                                if (s == 0)

                                {
                                    dangerright += 5;
                                    m--;
                                    p--;
                                }
                                else if (s == 1)
                                {
                                    dangerright -= 3;
                                    m = (-1);
                                    p = (-1);
                                }
                            }
                            else if (tab[m, p] == -1)
                            {
                                if (s == 0)
                                {
                                    dangerright -= 3;
                                    m = (-1);
                                    p = (-1);
                                }
                                else if (s == 1)
                                {
                                    dangerright += 5;
                                    m--;
                                    p--;
                                }
                            }
                            else if (tab[m, p] == 0)
                            {
                                if (s == 0)
                                {
                                  
                                    m--;
                                    p--;
                                }
                                else if (s == 1)
                                {
                                    m--;
                                    p--;
                                }
                            }
                        }
                        else
                        {
                        }


                    }
                Debug.Log("dangerright = " + dangerright);
                for(int s=0;s<=1;s++)
                for (int n = (a + 1), m = (a - 1), t = (wiersz + 1), p = (wiersz - 1), j = 0; j <= 2; j++)// left slant
                {
                    if (n < 7 && p >= 0)
                    {
                            if (tab[n, p] == 1)
                            {

                                if (s == 0)
                                {
                                    dangerleft += 5;
                                    n++;
                                    p--;
                                }
                                else if (s == 1)
                                {
                                    dangerleft -= 3;
                                    n = 7;
                                    p = (-1);
                                }
                            }
                            else if (tab[n, p] == (-1))
                            {
                                if (s == 0)
                                {
                                    dangerleft -= 3;
                                    n = 7;
                                    p = (-1);
                                }
                                else if (s == 1)
                                {
                                    dangerleft += 5;
                                    n++;
                                    p--;
                                }
                            }
                            else if (tab[n, p] == 0)
                            {

                                if (s == 0)
                                {
                                    
                                    n++;
                                    p--;
                                }
                                else if (s == 1)
                                {
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
                            if (tab[m, t] == 1)
                            {
                                if (s == 0)

                                {

                                    dangerleft += 5;
                                    m--;
                                    t++;
                                }
                                else if (s == 1)
                                {
                                    dangerleft -= 3;
                                    m = (-1);
                                    t = 6;
                                }
                            }
                            else if (tab[m, t] == -1)
                            {
                                if (s == 0)

                                {
                                    dangerleft -= 3;
                                    m = (-1);
                                    t = 6;
                                }
                                else if (s == 1)
                                {
                                    dangerleft += 5;
                                    m--;
                                    t++;
                                }
                            }
                            else if (tab[m, t] == 0)
                            {
                                if (s == 0)

                                {
                                    dangerleft += 1;
                                    m--;
                                    t++;
                                }
                                else if (s == 1)
                                {
                                    m--;
                                    t++;
                                }
                            }
                    }
                    else
                    {

                    }

                }
            }



            else
            {
                dangerhor = -4;
                dangerver = -4;
                dangerright = -4;
                dangerleft = -4;
                Debug.Log("dangerhor =" + dangerhor);
                Debug.Log("dangerver =" + dangerver);
                Debug.Log("dangerright=" + dangerver);
                Debug.Log("dangerleft =" + dangerver);
            }


            danger[a] = 0;
            if (danger[a] < dangerhor)
            {
                danger[a] = dangerhor;
                Debug.Log("wartosc dangerhor = " + dangerhor);
            }
            if (danger[a] < dangerver)
            {
                danger[a] = dangerver;
                Debug.Log("wartosc dangerver = " + dangerver);
            }
            if (danger[a] < dangerright)
            {
                danger[a] = dangerright;
                Debug.Log("wartosc dangerright = " + dangerright);
            }
            if (danger[a] < dangerleft)
            {
                danger[a] = dangerleft;
                Debug.Log("wartosc dangerleft = " + dangerleft);
            }
            maindanger = 0;
            for (int j = 0; j <= 6; j++)
            {
                Debug.Log(j + " " + danger[j]);
                if (maindanger < danger[j])
                {
                    maindanger = danger[j];
                    kolejnosc = j;
                }

            }
            simulation(tab, ++a);

        }

    }
    }


     
    
    

    

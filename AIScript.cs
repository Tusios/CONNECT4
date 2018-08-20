using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour
{


    int [] danger = new int[7];
    int location;
    int maindanger;
    int[] chance = new int[7];

    void Start()
    {

    }
    public void dangercheck(int[,] tab, int kol)
    {
        if (kol > 6)
        {
            maindanger = 0;
            for (int i = 0; i <= 6; i++)
            {
                danger[i] = 0;
                chance[i] = 0;
            }
            GetComponent<choice>().wysylka(location);
        }
        else
        {
            danger[kol] = 0;
            int[] kolejnosc = { 0, 6, 5, 1, 2, 4, 3 };
            int wier = 7;
            chance[kol] = 0;
            int[] dangerhor = new int[4];
            int[] chancehor = new int[4];
            int dangerver = 0;
            int chancever = 0;
            int[] dangerleft = new int[4];
            int[] chanceleft = new int[4];
            int[] dangerright = new int[4];
            int[] chanceright = new int[4];
            Debug.Log("Glowne zagrozenie jest rowne na poczatku" + maindanger);
            for (int i = 0; i <= 5; i++)
            {
                if (tab[kol, i] == 0)
                {

                    Debug.Log("kolumna = " + kol);
                    wier = i;
                    Debug.Log("wiersz = " + wier);
                    break;
                }

            }

            for (int j = 0; j <= 3; j++)//horizontal check

                for (int i = kol - 3; i <= kol; i++)
                {
                    if ((i + j) >= 0 && (i + j) <= 6 && wier <= 5)
                    {
                        if (tab[(j + i), wier] == 1)
                        {
                            dangerhor[j]++;
                            chancehor[j]--;
                        }

                        else if (tab[(j + i), wier] == -1)
                        {
                            dangerhor[j]--;
                            chancehor[j]++;
                        }
                    }

                    else
                    {
                        dangerhor[j] = 0;
                        chancehor[j] = 0;
                        break;
                    }
                }
            // for (int j = 0; j <= 3; j++)
            //   Debug.Log("dangerhor = " + dangerhor[j] + " " + j);

            //vertical check
            if (wier <= 5)
            {
                for (int i = wier - 3; i <= wier; i++)
                    if ((i) >= 0 && (i) <= 5)
                    {
                        if (tab[kol, (i)] == 1)
                        {
                            dangerver++;
                            chancever--;
                        }
                        else if (tab[kol, (i)] == -1)
                        {
                            dangerver--;
                            chancever++;
                        }
                    }
                    else
                    {
                        dangerver = 0;
                        chancever = 0;
                        break;
                    }
            }

            //Debug.Log("zagrozenie poziom = " + dangerver);
            for (int j = 0; j <= 3; j++)//left slant
            {
                int w = wier - 3;
                for (int i = kol - 3; i <= kol; i++)
                {
                    if (((i + j) >= 0 && (w + j) >= 0) && ((i + j) <= 6 && (w + j) <= 5) && wier <= 5)
                    {
                        if (tab[(i + j), (w + j)] == 1)
                        {
                            dangerleft[j]++;
                            chanceleft[j]--;
                        }
                        else if (tab[(i + j), (w + j)] == -1)
                        {
                            dangerleft[j]--;
                            chanceleft[j]++;
                        }

                    }
                    else
                    {
                        dangerleft[j] = 0;
                        chanceleft[j] = 0;
                        break;
                    }
                    w++;
                }
            }
            /*
            for (int j = 0; j <= 3; j++)
               
            Debug.Log("zagrozenie left = " + dangerleft[j] +" " + j);
            */
            for (int j = 0; j <= 3; j++)//right slant
            {
                int w = wier - 3;
                for (int i = kol + 3; i >= kol; i--)
                {
                    if (((i - j) >= 0 && (w + j) >= 0) && ((i - j) <= 6 && (w + j) <= 5) && wier <= 5)
                    {
                        if (tab[(i - j), (w + j)] == 1)
                        {
                            dangerright[j]++;
                            chanceright[j]--;
                        }
                        else if (tab[(i - j), (w + j)] == -1)
                        {
                            dangerright[j]--;
                            chanceright[j]++;
                        }

                    }
                    else
                    {
                        dangerright[j] = 0;
                        chanceright[j] = 0;
                        break;
                    }
                    w++;
                }
            }

            if (tab[kol, 5] == 0)
            { 
                for (int j = 0; j <= 3; j++)
                {

                    if (danger[kol] < dangerhor[j])
                    {
                        danger[kol] = dangerhor[j];

                    }
                    if (danger[kol] < dangerver)
                    {
                        danger[kol] = dangerver;

                    }
                    if (danger[kol] < dangerleft[j])
                    {
                        danger[kol] = dangerleft[j];

                    }
                    if (danger[kol] < dangerright[j])
                    {
                        danger[kol] = dangerright[j];

                    }
                    if (chance[kol] <= chancehor[j])
                    {
                        chance[kol] = chancehor[j];

                    }
                    if (chance[kol] <= chancever)
                    {
                        chance[kol] = chancever;

                    }
                    if (chance[kol] <= chanceleft[j])
                    {
                        chance[kol] = chanceleft[j];

                    }
                    if (chance[kol] <= chanceright[j])
                    {
                        chance[kol] = chanceright[j];

                    }
                }
        }
            else
            {
                danger[kol] = -10;
                chance[kol] = -10;
            }

                simulation(tab, kol, (wier + 1));
                for (int i = 0; i <= 6; i++)
                {
                    int a = kolejnosc[i];
                    if (maindanger <= danger[a])
                    {
                        maindanger = danger[a];
                        location = a;
                    }
                }

                for (int i = 0; i <= 6; i++)
                {
                    int a = kolejnosc[i];
                    if (maindanger <= chance[a])
                    {
                        maindanger = chance[a];
                        location = a;
                    }


                }
                Debug.Log("glowne zagrozenie wynosi  " + maindanger + "oraz miejsce jest rowne " + location);

                dangercheck(tab, ++kol);
            }
        }
    

    void simulation(int[,]tab,int kolumna,int wiersz)
    {
        int[] fdangerhor = new int[4];
        int[] fchancehor = new int[4];
      
        int[] fdangerleft = new int[4];
        int[] fchanceleft = new int[4];
        int[] fdangerright = new int[4];
        int[] fchanceright = new int[4];

 
        for (int j = 0; j <= 3; j++)//horizontal check

            for (int i = kolumna - 3; i <= kolumna; i++)
            {
                if ((i + j) >= 0 && (i + j) <= 6 && wiersz <= 5)
                {
                    if (tab[(j + i), wiersz] == 1)
                    {
                        fdangerhor[j]++;
                        fchancehor[j]--;
                    }

                    else if (tab[(j + i), wiersz] == -1)
                    {
                        fdangerhor[j]--;
                        fchancehor[j]++;
                    }
                }
            }
        //for (int j = 0; j <= 3; j++)
          //  Debug.Log("dangerhor = " + fdangerhor[j] + " " + j);

       
       
       
        for (int j = 0; j <= 3; j++)//left slant
        {
            int w = wiersz - 3;
            for (int i = kolumna - 3; i <= kolumna; i++)
            {
                if (((i + j) >= 0 && (w + j) >= 0) && ((i + j) <= 6 && (w + j) <= 5) && wiersz <= 5)
                {
                    if (tab[(i + j), (w + j)] == 1)
                    {
                        fdangerleft[j]++;
                        fchanceleft[j]--;
                    }
                    else if (tab[(i + j), (w + j)] == -1)
                    {
                        fdangerleft[j]--;
                        fchanceleft[j]++;
                    }

                }
                w++;
            }

        }
        //for (int j = 0; j <= 3; j++)

          //  Debug.Log("zagrozenie left = " + fdangerleft[j] + " " + j);

        for (int j = 0; j <= 3; j++)//right slant
        {
            int w = wiersz - 3;
            for (int i = kolumna + 3; i >= kolumna; i--)
            {
                if (((i - j) >= 0 && (w + j) >= 0) && ((i - j) <= 6 && (w + j) <= 5) && wiersz <= 5)
                {
                    if (tab[(i - j), (w + j)] == 1)
                    {
                        fdangerright[j]++;
                        fchanceright[j]--;
                    }
                    else if (tab[(i - j), (w + j)] == -1)
                    {
                        fdangerright[j]--;
                        fchanceright[j]++;
                    }

                }
                w++;
            }
        }
        for (int j = 0; j <= 3; j++)
        {
            if (fdangerhor[j] == 3 || fdangerleft[j] == 3 || fdangerright[j] == 3)
            {
                danger[kolumna] -= 2;
                if (chance[kolumna] != 3)
                    chance[kolumna] -= 2;
            }
        }


    }


}
        
     
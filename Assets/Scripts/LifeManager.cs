using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public Player Player1;
    public Player Player2;

    int alivePlayers = 0;

    void Update()
    {
        if (Player1.amIAlive)
            { 
                alivePlayers++;
            Debug.Log("Player 1 is still alive");
            }

        if (Player2.amIAlive)
            {
                alivePlayers++;
            Debug.Log("Player 2 is still alive");
        }

        if (alivePlayers == 1)
        {
            Player WinnerPlayer;

        if(Player1.amIAlive)
            {
                WinnerPlayer = Player1;
            }

            else if (Player2.amIAlive)
            {
                WinnerPlayer = Player2;
            }

            else
            {
                WinnerPlayer = new Player();
            }
        }
        //Decirle al UI que el ganador es WinnerPlayer

    }
}

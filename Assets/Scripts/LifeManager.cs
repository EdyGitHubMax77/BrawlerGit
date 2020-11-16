using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public Player Player1;
    public Player Player2;

    public Transform RespawnPoint;

    public UIManager UIManager;

    int alivePlayers = 0;

    private void Start()
    {
        Player1.RespawnPoint = RespawnPoint;
        Player2.RespawnPoint = RespawnPoint;

        Player1.UIManager = UIManager;
        Player2.UIManager = UIManager;
    }

    void Update()
    {
        //Player Status De Vida
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

        //Declarar a jugador ganador
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

            UIManager.DeclareWinner(WinnerPlayer);
        }
        //Decirle al UI que el ganador es WinnerPlayer

        alivePlayers = 0;
    }
}

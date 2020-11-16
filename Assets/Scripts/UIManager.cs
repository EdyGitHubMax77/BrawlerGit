using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Player1LifesDisplay;
    public Text Player2LifesDisplay;

    public Text WinningText;

    public enum WhatPlayerAmI
    {
        P1,
        P2
    }

    //Actualización de Vidas
    public void UpdatePlayerData(Player player)

    {
        if (player.whatPlayerAmI == WhatPlayerAmI.P1)
        {
            Player1LifesDisplay.text = "Player 1, you have " + player.lifes + " left";
            StartCoroutine(AppearLifes(Player1LifesDisplay));
        }
        else
        {
            Player2LifesDisplay.text = "Player 2, you have " + player.lifes + " left";
            StartCoroutine(AppearLifes(Player2LifesDisplay));
        }
    }
    //Aparición de Vidas 
    IEnumerator AppearLifes(Text text)
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        text.gameObject.SetActive(false);
    }
    //Aparición de Mensaje Ganador
    public void DeclareWinner(Player player)
    {
        WinningText.text = "Winner player is " + player.whatPlayerAmI;
        WinningText.gameObject.SetActive(true);
    }

  
}

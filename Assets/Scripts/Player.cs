using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lifes = 3;

    public bool amIAlive = true;

    public Collider Hit;

    public Transform RespawnPoint;

    public UIManager.WhatPlayerAmI whatPlayerAmI;

    public UIManager UIManager;

    private void OnTriggerEnter(Collider collider)
    {
       //Disminución de vidas al caer de plataforma
        if (collider.gameObject.GetComponent<DangerZone>() != null)
        {
            Debug.Log("Toque la danger zone");
            lifes--;

            UIManager.UpdatePlayerData(this);

            Debug.Log("Ahora tengo " + lifes + " vidas");
            if (lifes == 0)
            {
                amIAlive = false;

                //Reaparición de personaje en plataforma inicial
                transform.position = RespawnPoint.position;
            }
            else
            {
                transform.position = RespawnPoint.position;
            }
        }
       else if (collider.gameObject.GetComponent<HitGiving>() != null)
        {
            if (collider.gameObject.transform.parent != this)
            {
                transform.position += new Vector3(0, 3, 0);
            }
            
        }
    }
    //Ataque de jugadores
    public void ActivateHitRoutine()
    {
        StartCoroutine(HitRoutine());
    }

    IEnumerator HitRoutine()
    {
        Hit.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Hit.gameObject.SetActive(false);
    }
}

 

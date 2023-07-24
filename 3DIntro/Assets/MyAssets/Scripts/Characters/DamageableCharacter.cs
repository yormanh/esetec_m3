using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour
{
    [SerializeField] protected int maxVida = 100;
    protected int vidaActual; //currentActual
    protected bool isMuerto = false;

    public int GetMaxVida () 
    { 
        return maxVida; 
    }

    public int GetVidaActual()
    {
        return vidaActual;
    }

    public void SetVida(int value)
    {
        vidaActual += value;
        vidaActual = Mathf.Clamp(vidaActual + value, 0, maxVida);


    }

    protected virtual void Start()
    {
        vidaActual = maxVida;
    }

    public void HacerDanyo(int danyo)
    {
        vidaActual -= danyo; //vidaActual = vidaActual - danyo

        vidaActual = Mathf.Clamp(vidaActual, 0, maxVida);

        if (vidaActual == 0)
            Morir();
    }
    protected virtual void Morir()
    {
        Debug.Log("Morir");
        isMuerto = true;
    }

    private void Curar(int cura)
    {
        if (!isMuerto)  //isMuerto == false
        {
            vidaActual += cura;
            vidaActual = Mathf.Clamp(vidaActual, 0, maxVida);
        }
    }

}

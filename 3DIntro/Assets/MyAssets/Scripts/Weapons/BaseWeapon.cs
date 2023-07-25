using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    //lo max que podemos tener
    [Header("Settings")]
    [SerializeField] protected int maxMunicion = 8; 
    [SerializeField] protected int maxMunicionInventario = 32;

    [SerializeField] private bool balasInfinitas = false;


    //Lo que tenemos actualmente
    protected int currentMunicion;
    protected int currentMunicionInventario;

    protected int damage = 10;
    protected float tiempoEntreDisparos = 0.2f; //cadencia

    [Header("Bala")]
    [SerializeField] AudioClip recargarAudio;

    bool hasWeapon; //tenemos el arma

    public bool GetHasWeapon()
    { 
        return hasWeapon;
    }

    public void SetHasWeapon(bool value)
    {
        hasWeapon = value;
    }

    public int GetCurrentMunicion()
    {
        return currentMunicion;
    }

    public int GetCurrentMunicionInventario()
    {
        return currentMunicionInventario;
    }

    public bool GetBalasInfinitas()
    {
        return balasInfinitas;
    }

    void Start()
    {
        //inicializar los valores actuales
        currentMunicion = maxMunicion;
        currentMunicionInventario = maxMunicionInventario;
    }

    public void AddCurrentMunicionInventario(int value)
    {
        currentMunicionInventario += value;
    }
    
    void Update()
    {
        
    }

    public virtual void Atacar()
    {

    }

    public virtual void PressTrigger()
    {

    }

    public virtual void ReleaseTrigger()
    {

    }

    public void Recargar()
    {
        int recargaMunicion = 0;
        //if (currentMunicion > maxMunicion - currentMunicion)
        //{
        //    recargaMunicion = maxMunicion - currentMunicion;
        //}
        //else
        //{
        //    recargaMunicion = currentMunicionInventario;
        //}


        Debug.Log("maxMunicion: " + maxMunicion);
        Debug.Log("currentMunicion: " + currentMunicion);
        Debug.Log("currentMunicionInventory: " + currentMunicionInventario);
        Debug.Log("resta: " + (maxMunicion - currentMunicion));
        //Debug.Log($"resta: {maxMunicion - currentMunicion}");
        recargaMunicion = Mathf.Min(maxMunicion
        - currentMunicion, currentMunicionInventario);

        if (recargaMunicion > 0)
        {
            AudioSource.PlayClipAtPoint(recargarAudio, 
                this.transform.position);
            currentMunicion += recargaMunicion;
            if (!balasInfinitas) //balasInfinitas == false
                currentMunicionInventario -= recargaMunicion;
        }
    }

}

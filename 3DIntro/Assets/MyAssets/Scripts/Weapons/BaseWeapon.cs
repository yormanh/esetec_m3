using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    //lo max que podemos tener    
    [SerializeField] protected int maxMunicion = 8; 
    [SerializeField] protected int maxMunicionInventario = 32;

    //Lo que tenemos actualmente
    protected int currentMunicion;
    protected int currentMunicionInventario;

    protected int damage = 10;
    protected float tiempoEntreDisparos = 0.2f; //cadencia

    void Start()
    {
        //inicializar los valores actuales
        currentMunicion = maxMunicion;
        currentMunicionInventario = maxMunicionInventario;
    }

    
    void Update()
    {
        
    }

    public virtual void Atacar()
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

        recargaMunicion = Mathf.Min(maxMunicion
        - currentMunicion, currentMunicionInventario);

        currentMunicion += recargaMunicion;
        currentMunicionInventario -= recargaMunicion;
    }

}

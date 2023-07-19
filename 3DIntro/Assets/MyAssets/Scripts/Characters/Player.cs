using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BaseWeapon _armaEquipada;
    
    void Start()
    {
        _armaEquipada = GetComponentInChildren<BaseWeapon>();
    }

    
    void Update()
    {
        
    }

    private void OnAtacar()
    {
        //Debug.Log("OnAtacar");
        _armaEquipada.Atacar();
    }

    private void OnRecargar()
    {
        //Debug.Log("OnRecargar");
        _armaEquipada.Recargar();
        
    }
}

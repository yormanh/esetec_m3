using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : DamageableCharacter
{
    private BaseWeapon _armaEquipada;
    
    protected override void Start()
    {
        base.Start();
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

    protected override void Morir()
    {
        base.Morir();

        this.enabled = false;
        this.GetComponent<FirstPersonController>().enabled = false;
        this.GetComponent<PlayerInput>().enabled = false;

        Invoke("MostrarGameOver", 2);

    }

    void MostrarGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}

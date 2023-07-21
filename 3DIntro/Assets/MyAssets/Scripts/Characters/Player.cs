using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : DamageableCharacter
{
    private BaseWeapon _armaEquipada;

    InputActionAsset _actionAssets = null;

    BaseWeapon[] _allWeapons; //todas las armas que se tiene


    private void Awake()
    {
        _actionAssets = GetComponent<PlayerInput>().actions;

        _allWeapons = GetComponentsInChildren<BaseWeapon>(includeInactive: true);
        
        _armaEquipada = GetComponentInChildren<BaseWeapon>();  //cogemos la primera


        foreach(BaseWeapon baseWeapon in _allWeapons)
        {
            baseWeapon.gameObject.SetActive(false);
        }
        _armaEquipada.gameObject.SetActive(true);
    }

    protected override void Start()
    {
        base.Start();
        _armaEquipada = GetComponentInChildren<BaseWeapon>();
        //Cursor.visible = false; hacer desaparecer el puntero del raton

        //Los inputs que hemos creado
        var triggerPress = _actionAssets.FindActionMap("Player").
            FindAction("TriggerPress");

        //Eventos
        triggerPress.performed += OnTriggerPress;
        triggerPress.canceled += OnTriggerPress;

    }

    public BaseWeapon GetArmaEquipada()
    {
        return _armaEquipada;
    }
    private void SetArmaEquipada (BaseWeapon value)
    {
        _armaEquipada = value;
    }

    void Update()
    {
        
    }

    private void OnTriggerPress()
    {
        //Debug.Log("OnAtacar");
        _armaEquipada.Atacar();
    }

    private void OnTriggerPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _armaEquipada.PressTrigger();
        }
        if (context.canceled)
        {
            _armaEquipada.ReleaseTrigger();
        }
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

        Invoke("MostrarGameOver", 2); //El nombre idéntico al de la función a llamar

    }

    void MostrarGameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("GameOver");
    }

}




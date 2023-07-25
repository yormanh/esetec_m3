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

    Keyboard _keyboard;


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
        _armaEquipada.SetHasWeapon(true);
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

        _keyboard = Keyboard.current;
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
        if (isMuerto)
            Morir();

        CambiarArma();
    }

    void CambiarArma()
    {
        //foreach(BaseWeapon baseWeapon in _allWeapons)
        for (int i = 0; i < _allWeapons.Length; i++)
        {
            //_allWeapons[i]
            int tecla = i + 1;

            switch(tecla)
            {
                case 1:
                    if (_keyboard.digit1Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;
                case 2:
                    if (_keyboard.digit2Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;
                case 3:
                    if (_keyboard.digit3Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;
                case 4:
                    if (_keyboard.digit4Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;
                case 5:
                    if (_keyboard.digit5Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;
                case 6:
                    if (_keyboard.digit6Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;
                case 7:
                    if (_keyboard.digit7Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;

                case 8:
                    if (_keyboard.digit8Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;
                case 9:
                    if (_keyboard.digit9Key.wasPressedThisFrame
                        && _allWeapons[i].GetHasWeapon())
                        ActivarArma(i);
                    break;

            }
        }
    }

    void ActivarArma(int i)
    {
        _armaEquipada.gameObject.SetActive(false);
        _armaEquipada = _allWeapons[i];
        _armaEquipada.gameObject.SetActive(true);
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












using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Image barraVidaImage;
    [SerializeField] TextMeshProUGUI municionText;
    [SerializeField] Image weaponIcon;

    Player _player;

    void Start()
    {
        _player = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    
    void Update()
    {
        UpdateBarraVida();
        UpdateMunicion();
    }
    private void UpdateBarraVida()
    {
        float vidaActual = _player.GetVidaActual();
        float maxVida = _player.GetMaxVida();
        barraVidaImage.fillAmount = vidaActual / maxVida;
    }
    private void UpdateMunicion()
    {
        bool bBalasInfinitas = _player.GetArmaEquipada().GetBalasInfinitas();
        int currentMunicion = _player.GetArmaEquipada().GetCurrentMunicion();
        int currentMunicionInventario = _player.GetArmaEquipada().GetCurrentMunicionInventario();
        
        if(!bBalasInfinitas)
            municionText.text = currentMunicion + " / " + currentMunicionInventario;
        else
            municionText.text = currentMunicion + " / " + "INFINITO";
    }
}

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
        float vidaActual = _player.GetVidaActual();
        float maxVida = _player.GetMaxVida();

        barraVidaImage.fillAmount = vidaActual / maxVida;

    }
}

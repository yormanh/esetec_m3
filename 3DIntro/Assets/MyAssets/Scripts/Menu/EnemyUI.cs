using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyUI : MonoBehaviour
{
    DamageableCharacter _damageableCharacter;
    [SerializeField] Image barraVidaImage;

    void Start()
    {
        _damageableCharacter = GetComponent<DamageableCharacter>();
    }

 
    void Update()
    {
        float vidaActual = _damageableCharacter.GetVidaActual();
        float maxVida = _damageableCharacter.GetMaxVida();

        barraVidaImage.fillAmount = vidaActual / maxVida;

    }
}

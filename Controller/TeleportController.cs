using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour {

    public GameObject player; //Associa o player a este objeto
    private FadeController fade; //Associa o fade a este objeto

    // Usado na Inicialização
    void Start()
    {
        fade = FindObjectOfType<FadeController>(); //Procura na cena um objeto com as caracteristicas do fade
    }

    // Usado para teleportar o player
    public void TeleportPlayer()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z); //o player recebe a posição do ponto de teleporte determinado mas a sua altura se conserva
        fade.isOn = true; //Determina que o fade está ativo
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public GameObject buttonOff; //Estado do botão quando não sofreu interação ainda
    public GameObject buttonOn; //Estado do botão quando sofre interação

    private VRGazeController player; //Associa o player da cena ao botão 

    public GameObject buttonSoundFX; //Som que toca quando se interage com o botão

	// Usado na Inicialização
	void Start () {

        player = FindObjectOfType<VRGazeController>(); //Procura na cena um objeto com as características do player
        buttonSoundFX.GetComponent<AudioSource>().enabled = false; //Determina que o componente que emite som, do objeto ao qual ele está associado, fica desativado


    }
	
	// Usado em cada Frame
	void Update () {

        if (player.gvrStatus) //Caso o player esteja interagindo com o botão
        {
            buttonOff.SetActive(false); //O estado sem interação é desativado
            buttonOn.SetActive(true); //O estado com interação é ativado
            buttonSoundFX.GetComponent<AudioSource>().enabled = true; //O componente que emite som fica ativado
        }
        else //Caso o player não esteja interagindo com o botão
        {
            buttonOff.SetActive(true); //O estado sem interação é ativado
            buttonOn.SetActive(false); //O estado com interação é desativado
            buttonSoundFX.GetComponent<AudioSource>().enabled = false; //O componente que emite som fica desativado
        }
	}
}

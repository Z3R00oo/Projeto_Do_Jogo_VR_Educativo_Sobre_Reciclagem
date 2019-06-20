using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour {

    public float timeToSetOff; //Determina um tempo para desativar o fade
    private float currentTimeToSetOff; //Determina um contador para o tempo de desativar o fade

    public GameObject fadeObject; //Determina o objeto do fade

    public bool isOn; //Determina se ele está ativado ou não
	
	// Usado em cada Frame
	void Update () {

        if (isOn) //Caso o fade esteja ativado
        {
            currentTimeToSetOff += Time.deltaTime; //O contador se inicia
            fadeObject.gameObject.SetActive(true); //O objeto do fade é ativado na cena

            
        }

        if (currentTimeToSetOff >= timeToSetOff) //Caso o contador seja maior ou igual ao tempo para desativar o fade
        {
            fadeObject.gameObject.SetActive(false); //O objeto do fade é desativado
            currentTimeToSetOff = 0; //O contador volta para 0
            isOn = false; //E o fade é desativado
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTime : MonoBehaviour {

    public float timeToChangeScene; //Determina um tempo para trocar de cena
    private float currentTimeToChangeScene = 0; //Determina um contador para o tempo para trocar de cena

    public string sceneName; //Determina um nome para a cena 

    // Usado em cada Frame
    void Update () {

        currentTimeToChangeScene += Time.deltaTime; //Da inicio ao contador 

        if(currentTimeToChangeScene >= timeToChangeScene) //Caso o contador seja maior ou igual ao tempo de troca de cena
        {
            SceneManager.LoadScene(sceneName); //Troca para a cena determinada pelo nome
        }
		
	}
}

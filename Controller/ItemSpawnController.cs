using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnController : MonoBehaviour {

    private int randObject; //Determina um numero que deverá ser apresentado randomicamente

    public string characterTag; //Determina uma tag 

    public GameObject[] objects; //Cria um vetor de objetos

    // Usado quando entrar em um colisor invisivel
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(characterTag)) //Caso o colisor tenha a tag igual à tag determinada 
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z); //Determina a posição do spawn
            randObject = Random.Range(0, objects.Length); //Gera um numero randomico 
            objects[randObject].SetActive(true); //O objeto do vetor na posição [numero randomico] é ativado na cena
            objects[randObject].GetComponent<ItemController>().isObjectActivate = true; //Determina que o objeto escolhido do vetor esta ativo
            objects[randObject].transform.SetParent(transform); //Determina este objeto como o "pai" do objeto escolhido do vetor
            objects[randObject].transform.position = transform.position; //Determina que a posição do objeto escolhido do vetor recebe a posição deste objeto
        }
        else //Caso a tag seja diferente da tag determinada
        {
            return; //O código acima é ignorado e nada acontece
        }
    }
}

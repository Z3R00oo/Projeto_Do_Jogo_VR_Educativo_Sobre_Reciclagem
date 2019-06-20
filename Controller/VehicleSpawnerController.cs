using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawnerController : MonoBehaviour {

    private int randObject; //Determina um numero que será apresentado randomicamente

    public float timeToSpawn; //Determina um tempo para Spawn
    public float currentTimeToSpawn; //Determina um contador para o tempo para Spawn

    public GameObject[] objects; //Cria um vetor de objetos

    public GameObject trigger1; //Determina um objeto qyue servirá como primeiro alvo do percurso
    public GameObject trigger2; //Determina um objeto qyue servirá como segundo alvo do percurso
    public GameObject trigger3; //Determina um objeto qyue servirá como terceiro alvo do percurso
    public GameObject trigger4; //Determina um objeto qyue servirá como quarto alvo do percurso

    // Use this for initialization
    void Start () {

        currentTimeToSpawn = 0; //Determina que o valor inicial do contador é 0
		
	}
	
	// Update is called once per frame
	void Update () {

        currentTimeToSpawn += Time.deltaTime; //Da inicio ao contador

        Vector3 spawnPosition = new Vector3(transform.position.x, objects[randObject].transform.localPosition.y, transform.position.z); //Determina a posição de spawn

        if (currentTimeToSpawn >= timeToSpawn) //Caso o contador seja igual ao tempo de spawn
        {
            currentTimeToSpawn = 0; //O contador volta para 0
            randObject = Random.Range(0, objects.Length); //Gera um numero aleatorio (de 0 ao tamanho do vetor)
            Instantiate(objects[randObject], spawnPosition, objects[randObject].transform.localRotation, transform); // Instancia um objeto do vetor na posição [numero aleatorio] na posição de spawn e sendo "filho" deste objeto
        }
		
	}
}

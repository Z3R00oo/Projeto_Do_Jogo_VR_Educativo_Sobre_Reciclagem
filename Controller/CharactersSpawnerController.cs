using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSpawnerController : MonoBehaviour {

    private int randObject; //Determina um numero que deve surgir randomicamente

    public float timeToSpawn; //Tempo para Spawnar novamente
    public float currentTimeToSpawn; //contador para o tempo de Spawn

    public GameObject[] objects; //Cria um vetor de objetos

    public GameObject trigger1; //Determina um objeto qyue servirá como primeiro alvo do percurso
    public GameObject trigger2; //Determina um objeto qyue servirá como segundo alvo do percurso
    public GameObject trigger3; //Determina um objeto qyue servirá como terceiro alvo do percurso
    public GameObject trigger4; //Determina um objeto qyue servirá como quarto alvo do percurso

    // Usado na Inicialização
    void Start () {

        currentTimeToSpawn = timeToSpawn; //Determina que o contador para o tempo de Spawn recebe inicialmente o tempo de spawn
		
	}
	
	// Usado em cada Frame
	void Update () {

        currentTimeToSpawn += Time.deltaTime; //Dá inicio ao contador para o tempo de spawn

        Vector3 spawnPosition = new Vector3(transform.position.x, objects[randObject].transform.localPosition.y, transform.position.z); //Determina a posição de Spawn

        if (currentTimeToSpawn >= timeToSpawn) //Caso o contador para o tempo de spawn seja maior ou igual ao tempo de spawn
        {
            currentTimeToSpawn = 0; //Volta o contador para o tempo de spawn para 0, para ele poder contar novamente
            randObject = Random.Range(0, objects.Length); //Determina um numero aleatorio
            Instantiate(objects[randObject], spawnPosition, objects[randObject].transform.localRotation, transform); //Instancia na cena um objeto do vetor(em uma posição aleatoria), que deve surgir no ponto de spawn e ser filho do Spawn(este objeto)
        }
		
	}
}

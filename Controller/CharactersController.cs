using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour {

    public float speed; //Determina uma velocidade

    private Rigidbody rb; //Determina um rigidBody(usado para interações com a física)

    private GameObject target; //Determina um alvo
    public GameObject[] triggers; //Cria um vetor de objetos

    private CharactersSpawnerController spawner; //Associa o Spawner (local onde gera objetos na cena) a esse objeto


    // Usado na Inicialização
    void Start () {

        rb = GetComponent<Rigidbody>(); //Faz a variável receber um componente presente neste objeto
        spawner = GetComponentInParent<CharactersSpawnerController>(); //Pega um componente presente no "pai"(nível hierarquico)

        triggers[0] = spawner.trigger1; //Determina que o objeto na posição [0] no vetor recebe o objeto 1 associado ao spawner
        triggers[1] = spawner.trigger2; //Determina que o objeto na posição [1] no vetor recebe o objeto 2 associado ao spawner
        triggers[2] = spawner.trigger3; //Determina que o objeto na posição [2] no vetor recebe o objeto 3 associado ao spawner
        triggers[3] = spawner.trigger4; //Determina que o objeto na posição [3] no vetor recebe o objeto 4 associado ao spawner

        target = triggers[0]; //Determina que o alvo será o objeto na posição [0] no vetor

	}

    // Usado em cada Frame
    void Update () {

        transform.position = new Vector3(transform.position.x, 0, transform.position.z); //Determina a posição incial do objeto na cena

        float fixedSpeed = speed * Time.deltaTime; //Determina a velocidade deste objeto
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, fixedSpeed); //Determina para qual direção este objeto deve se mover

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); //Determina a posição do alvo

        transform.LookAt(targetPosition); //Determina que este objeto deve olhar para o alvo determinado
        
	}
    // Usado quando o persoangem entra em um colisor invisivel
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Track_Trigger_1")) //Caso a tag(categoria) do objeto invisivel for "Track_Trigger_1"
        {
            target = triggers[1]; //O alvo se torna o objeto na posição [1] no vetor

        }
        else if (other.CompareTag("Track_Trigger_2")) //Caso a tag do objeto invisivel for "Track_Trigger_2"
        {
            target = triggers[2]; //O alvo se torna o objeto na posição [2] no vetor
        }
        else if (other.CompareTag("Track_Trigger_3")) //Caso a tag do objeto invisivel for "Track_Trigger_3"
        {
            target = triggers[3]; //O alvo se torna o objeto na posição [3] no vetor
        }
        else if (other.CompareTag("Track_Trigger_4")) //Caso a tag do objeto invisivel for "Track_Trigger_4"
        {
            Destroy(gameObject); //Destroi este objeto
        }


    }
}

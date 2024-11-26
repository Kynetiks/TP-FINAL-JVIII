using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  /*PREMIER SPAWN
 /* public GameObject[] objetsQuiSpawn;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)){

            int randomIndex = Random.Range(0, objetsQuiSpawn.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));

            Instantiate(objetsQuiSpawn[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }

    */

    public float NombreSpawn = 1.0f;
    public float tempsEntreWaves = 3.0f;

    public int NombreEnnemi;

    public GameObject Ennemi;

    bool WaveOver = true;


    void Update(){

        if(WaveOver == true){

            StartCoroutine(WaveSpawner());
        }

    }


    IEnumerator WaveSpawner(){

        WaveOver = false;

        for(int i = 0; i < NombreEnnemi; i++){

            GameObject EnnemiClone = Instantiate(Ennemi);

            yield return new WaitForSeconds(NombreSpawn);
        }

        NombreSpawn -= 0.1f;
        yield return new WaitForSeconds(tempsEntreWaves);

        WaveOver = true;
    }


}

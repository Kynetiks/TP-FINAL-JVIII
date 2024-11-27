using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float NombreSpawn = 1.0f;
    public float tempsEntreWaves = 3.0f;

    public int NombreEnnemi = 10;

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

        NombreEnnemi += 10;

        WaveOver = true;
    }


}

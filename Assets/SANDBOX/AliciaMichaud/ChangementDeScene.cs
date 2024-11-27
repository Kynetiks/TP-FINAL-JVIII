using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementDeScene : MonoBehaviour
{
    public void cs(){
        SceneManager.LoadScene("UIscenemain");
    }
    public void restart(){
        SceneManager.LoadScene("SceneAcceuil");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

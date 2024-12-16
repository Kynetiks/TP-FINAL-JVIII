using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreath : MonoBehaviour
{

    [SerializeField] GameObject vfxBreath;
    private Animator animator;  // R�f�rence � l'Animator de l'ennemi
    [SerializeField] GameObject bouche;

  

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet avec lequel il entre en collision est un ennemi
        if (other.CompareTag("Crystal"))
        {
            
            GameObject clone = Instantiate(vfxBreath);
            clone.transform.position = bouche.transform.position;
            clone.transform.rotation = bouche.transform.rotation;

            Debug.Log("Crystal rep�r�");
            if (animator != null)
            {
                animator.SetBool("NearTarget", true);
            }
            

        }
    }
}

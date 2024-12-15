using UnityEngine;

public class MoveToCrystal : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;         
    private Transform target;

    void Start()
    {
     
        rb = GetComponent<Rigidbody>();
        GameObject targetObject = GameObject.FindGameObjectWithTag("Crystal");

        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            Debug.LogWarning("Aucun objet avec le tag 'Crystal' trouvé !");
        }
    }

    void FixedUpdate()
    {
      
        if (target != null)
        {
          
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed; 
        }
    }
}
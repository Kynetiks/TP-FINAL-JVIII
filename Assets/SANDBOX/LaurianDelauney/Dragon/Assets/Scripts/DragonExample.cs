using UnityEngine;

public class DragonExample : MonoBehaviour
{
    private Animator anim;

    // Hashes for animation states
    int IdleSimple;
    int IdleAgressive;
    int IdleRestless;
    int Walk;
    int BattleStance;
    int Bite;
    int Drakaris;
    int FlyingFWD;
    int FlyingAttack;
    int Hover;
    int Lands;
    int TakeOff;
    int Die;

    // Reference to the Flame Stream (fire effect) prefab
    public GameObject flameStreamPrefab;
    private GameObject currentFlameStream;

    // Position where the flame stream should appear (e.g., the dragon's mouth)
    public Transform firePosition;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Initialize animation state hashes
        IdleSimple = Animator.StringToHash("IdleSimple");
        IdleAgressive = Animator.StringToHash("IdleAgressive");
        IdleRestless = Animator.StringToHash("IdleRestless");
        Walk = Animator.StringToHash("Walk");
        BattleStance = Animator.StringToHash("BattleStance");
        Bite = Animator.StringToHash("Bite");
        Drakaris = Animator.StringToHash("Drakaris");
        FlyingFWD = Animator.StringToHash("FlyingFWD");
        FlyingAttack = Animator.StringToHash("FlyingAttack");
        Hover = Animator.StringToHash("Hover");
        Lands = Animator.StringToHash("Lands");
        TakeOff = Animator.StringToHash("TakeOff");
        Die = Animator.StringToHash("Die");
    }

   void Update()
{
    // Vérifie si la touche Y est pressée pour lancer l'attaque
    if (Input.GetKeyDown(KeyCode.Y))
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleSimple"))
        {
            Debug.Log("Lancer l'animation Drakaris");
            // Désactive l'animation Idle et active Drakaris
            anim.SetBool(IdleSimple, false);
            anim.SetBool(Drakaris, true);

            // Lance l'effet de feu
            SpawnFlameStream();
        }
    }
    // Vérifie si la touche Y est relâchée pour revenir à Idle
    else if (Input.GetKeyUp(KeyCode.Y))
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Drakaris"))
        {
            Debug.Log("Retour à l'animation Idle");
            // Désactive l'animation Drakaris et active Idle
            anim.SetBool(Drakaris, false);
            anim.SetBool(IdleSimple, true);

            // Détruit l'effet de feu
            DestroyFlameStream();
        }
    }
}


    // Method to spawn the flame stream effect
    void SpawnFlameStream()
    {
        if (flameStreamPrefab != null && firePosition != null)

        {
            Debug.Log("Spawning Flame Stream at position: " + firePosition.position);
            // Instantiate the flame stream effect at the fire position
            currentFlameStream = Instantiate(flameStreamPrefab, firePosition.position, firePosition.rotation);
            // Optionally, make the flame stream a child of the dragon to follow its movements
            currentFlameStream.transform.parent = firePosition;

            // You can add a timer to destroy the flame stream after a certain time (e.g., 3 seconds)
            Destroy(currentFlameStream, 3f); // Adjust the time to your needs
        }
    }

    // Method to destroy the flame stream effect
    void DestroyFlameStream()
    {
        if (currentFlameStream != null)
        {
            Destroy(currentFlameStream);
        }
    }
}


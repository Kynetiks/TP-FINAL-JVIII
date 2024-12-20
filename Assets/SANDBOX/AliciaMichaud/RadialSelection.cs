/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class RadialSelection : MonoBehaviour
{
    public OVRInput.Button spawnButton;
    [Range(2, 10)]
    public int numberOfRadialPart;
    public GameObject radialPartPrefab;
    public Transform radialPartCanvas;
    public float angleBetweenPart = 10;
    public Transform handTransform;

    public UnityEvent<int> OnPartSelected;
    private List<GameObject> spawnedParts = new List<GameObject>();
    private int currentSelectedRadialPart = -1;

    public List<GameObject> towerPrefabs; // Liste de tours
    public Transform spawnPoint;         // Point de spawn

    void Start()
    {
        OnPartSelected.AddListener(SpawnTower);
    }

    void Update()
    {
        if (OVRInput.GetDown(spawnButton))
        {
            SpawnRadialPart();
        }
        if (OVRInput.Get(spawnButton))
        {
            GetSelectedRadialPart();
        }
        if (OVRInput.GetUp(spawnButton))
        {
            HideAndTriggerSelected();
        }
    }

    public void HideAndTriggerSelected()
    {
        OnPartSelected.Invoke(currentSelectedRadialPart);
        radialPartCanvas.gameObject.SetActive(false);
    }

    public void GetSelectedRadialPart()
    {
        Vector3 centerToHand = handTransform.position - radialPartCanvas.position;
        Vector3 centerToHandProjected = Vector3.ProjectOnPlane(centerToHand, radialPartCanvas.forward);

        float angle = Vector3.SignedAngle(radialPartCanvas.up, centerToHandProjected, -radialPartCanvas.forward);

        if (angle < 0)
            angle += 360;

        currentSelectedRadialPart = (int)(angle * numberOfRadialPart / 360);

        for (int i = 0; i < spawnedParts.Count; i++)
        {
            if (i == currentSelectedRadialPart)
            {
                spawnedParts[i].GetComponent<Image>().color = Color.yellow;
                spawnedParts[i].transform.localScale = 1.1f * Vector3.one;
            }
            else
            {
                spawnedParts[i].GetComponent<Image>().color = Color.white;
                spawnedParts[i].transform.localScale = Vector3.one;
            }
        }
    }

    public void SpawnRadialPart()
    {
        radialPartCanvas.gameObject.SetActive(true);
        radialPartCanvas.position = handTransform.position;
        radialPartCanvas.rotation = handTransform.rotation;

        foreach (var item in spawnedParts)
        {
            Destroy(item);
        }

        spawnedParts.Clear();
        for (int i = 0; i < numberOfRadialPart; i++)
        {
            float angle = -i * 360f / numberOfRadialPart - angleBetweenPart / 2;
            Vector3 radialpartEulerAngle = new Vector3(0, 0, angle);

            GameObject spawnedRadialPart = Instantiate(radialPartPrefab, radialPartCanvas);
            spawnedRadialPart.transform.position = radialPartCanvas.position;
            spawnedRadialPart.transform.localEulerAngles = new Vector3(0, 0, angle);
            spawnedRadialPart.GetComponent<Image>().fillAmount = (1f / numberOfRadialPart - (angleBetweenPart / 360));

            int index = i;
            Button button = spawnedRadialPart.GetComponent<Button>();
            button.onClick.AddListener(() => { OnPartSelected.Invoke(index); });

            spawnedParts.Add(spawnedRadialPart);
        }
    }

    public void SpawnTower(int selectedPart)
    {
        if (selectedPart >= 0 && selectedPart < towerPrefabs.Count)
        {
            Instantiate(towerPrefabs[selectedPart], spawnPoint.position, spawnPoint.rotation);
            Debug.Log($"Tour {selectedPart} apparue !");
        }
    }
}
*/
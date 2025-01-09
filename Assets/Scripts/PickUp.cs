using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] GameObject animal;
    [SerializeField] GameObject player;
    bool isCarried = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCarried)
        {
            animal.transform.parent = player.transform;
            animal.transform.localPosition = new Vector3(0, 0.3f, 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        AnimalMovement AM = animal.GetComponent<AnimalMovement>();
        if (AM.isAlive == false)
        {
            print("layer tuch");
            isCarried = true;
        }
    }
}

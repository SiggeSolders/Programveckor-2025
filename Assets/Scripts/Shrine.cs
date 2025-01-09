using UnityEngine;

public class Shrine : MonoBehaviour
{
    [SerializeField] GameObject animal;
    GoalsScript goalScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalScript = FindObjectOfType<GoalsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Animal")
        {
            Destroy(animal);
            goalScript.souls++;
        }
    }
}

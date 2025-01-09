using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject player;


    //movement
    Vector3 destinationPoint;
    bool isWalking;
    [SerializeField] float walkingRange;
    Vector3 runDirection;
    float magnitude;
    bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isRunning)
        {
            Run();
        }
        else
        {
            NaturalState();
        }
    }
    
    void NaturalState()
    {
        agent.speed = 2;
        if (!isWalking)
        {
            FindDestination();
        }
        else
        {
            agent.SetDestination(destinationPoint);
        }
        if(Vector3.Distance(transform.position, destinationPoint) < 10)
        {
            isWalking = false;
        }
    }

    void FindDestination()
    {
        float z = Random.Range(-walkingRange, walkingRange);
        float x = Random.Range(-walkingRange, walkingRange);

        destinationPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destinationPoint,Vector3.down, groundLayer))
        {
            isWalking = true;
        }
    }
    void Run()
    {
        agent.speed = 10;
        runDirection = (player.transform.position - transform.position).normalized;
        runDirection = Quaternion.AngleAxis(45, Vector3.up) * runDirection;
        magnitude = runDirection.magnitude; //det blir 1
        agent.SetDestination(transform.position - (runDirection * 5));
    }


    private void OnTriggerEnter(Collider other)
    {
        isRunning = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isRunning = false;
        agent.speed = 2;
    }

}

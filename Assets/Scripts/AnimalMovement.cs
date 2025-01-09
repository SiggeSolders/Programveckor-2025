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
    public float health = 50f;
    bool isAlive = true;
    bool isCarried = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isRunning && isAlive)
        {
            Run();
        }
        if(isAlive == false)
        {
            agent.destination = transform.position;
        }
        if (isCarried)
        {
            transform.position = (player.transform.position += new Vector3(0, 0, 2));
        }
        else
        {
            if (isAlive)
            {
                NaturalState();
            }
        }
    }
    
    // går långsamt till slumpmässiga positioner innom den satta rangen
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

    //Slumpar fram en destination innom range och innom navmeshen
    void FindDestination()
    {
        float z = Random.Range(-walkingRange, walkingRange);
        float x = Random.Range(-walkingRange, walkingRange);

        
        destinationPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        //Kollar om destinationen är innom navmeshens gränser
        if(Physics.Raycast(destinationPoint,Vector3.down, groundLayer))
        {
            isWalking = true;
        }
    }
    //springer ifrån spelaren snabbt i en 35-graders vinkel
    void Run()
    {
        agent.speed = 10;
        //Springer åt motsatt håll från spelaren
        runDirection = (player.transform.position - transform.position).normalized;
        //Gör att den springer i en 35-graders vinkel
        runDirection = Quaternion.AngleAxis(35, Vector3.up) * runDirection;
        //avrundar direction till 1
        magnitude = runDirection.magnitude; 
        agent.SetDestination(transform.position - (runDirection * 5));
    }


    //När spelaren är innom triggern flyr djuret
    private void OnTriggerEnter(Collider other)
    {
        isRunning = true;
    }
    //När spelaren inte längre är nära går den tillbaka till natural state
    private void OnTriggerExit(Collider other)
    {
        isRunning = false;
        agent.speed = 2;
    }

    public void TakeDamage(float amount)
    {
        print("ouch");
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        isAlive = false;
        print("not alive");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAlive == false)
        {
            print("not alive tuch");
            if (collision.gameObject.layer == 6)
            {
                print("layer tuch");
                isCarried = true;
            }
        }
    }
}

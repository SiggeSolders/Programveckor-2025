using UnityEngine;

public class day_night : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    float day_cycle = 2;

    // Update is called once per frame
    void Update()
    {
        //roterar lampans x axel
        rotation.x = day_cycle * Time.deltaTime;
        transform.Rotate(rotation, Space.World);
    }
}

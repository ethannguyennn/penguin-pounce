using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class makePipewooohoooo : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        GameObject newPipe = Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        Enemy enemy = newPipe.GetComponentInChildren<Enemy>(); // Assuming the Enemy script is a child of the pipe
        if (enemy != null)
        {
            enemy.associatedPipe = newPipe.GetComponent<pipeMoveScript>();
        }
    }
}
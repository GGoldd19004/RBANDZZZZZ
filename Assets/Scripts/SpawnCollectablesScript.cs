using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectablesScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject collectable;
    public Vector3[] possibleSpawnLocations;
    public int spawnlocationcount;
    public int amountOfCollectables;

    void Start()
    {
        for (int i = 0; i < amountOfCollectables; i++)
        {
            int value = Random.Range(0, 20);

            if (possibleSpawnLocations[value] != Vector3.zero)
            {
                Instantiate(collectable, possibleSpawnLocations[value], Quaternion.identity);
                possibleSpawnLocations[value] = Vector3.zero;
            }

            else
            {
                i--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

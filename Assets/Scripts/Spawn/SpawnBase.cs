using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBase : MonoBehaviour
{

    public List<Transform> waypoints;

    public GameObject spawnObject;
    public Collider colliderSpawn;
    public Transform localSpawn;
    private GameObject _currentObject;

    bool _firstCollision = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!_firstCollision)
        {
            _currentObject = Instantiate(spawnObject, localSpawn);
            _currentObject.transform.position = localSpawn.transform.position;
            _firstCollision = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

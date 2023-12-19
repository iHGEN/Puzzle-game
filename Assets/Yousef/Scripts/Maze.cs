using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] GameObject[] respawningPoint;
    [SerializeField] GameObject cameraOffSet;
    [SerializeField] GameObject spawner;
    [SerializeField] float maxDistance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeasureTheDistance(respawningPoint, cameraOffSet);
    }

    void MeasureTheDistance(GameObject[] points, GameObject cam) 
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (Vector3.Distance(points[i].transform.position, cam.transform.position) < maxDistance)
            {
                Debug.Log("Enterd"); 
                cam.transform.position = spawner.transform.position;
            }

        }
    }
    
}

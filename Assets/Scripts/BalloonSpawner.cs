using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public int balloonCount=0;
    public GameObject balloonPrefab;

#if UNITY_EDITOR
    private void Start()
    {
        Debug.Log("Press Mouse Button 1 to Instantiate a Balloon");       
    }
#endif

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            var newBalloon = Instantiate(balloonPrefab, transform.position, Quaternion.identity);
            newBalloon.transform.parent = GameObject.Find("BalloonSpawner").transform;
            newBalloon.transform.rotation = Quaternion.Euler(-90, 0, 0);
            balloonCount++;
            int index = newBalloon.GetComponent<Balloon>().matToUse;
            newBalloon.name = ("Balloon - " + balloonCount+" COLOR : " + newBalloon.GetComponent<Balloon>().renderers[index].name); 
        }
    }
  
}

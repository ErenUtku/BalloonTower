using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    public LineRenderer line;

    private Transform platformPos;
    private Transform balloonPos;

    private void Start()
    {

        platformPos = GameObject.Find("Platform").transform;
        balloonPos = GetComponent<Transform>();

        line.positionCount = 2;
    }
    void Update()
    {
        line.SetPosition(0, platformPos.position);
        line.SetPosition(1, balloonPos.position);
    }
}

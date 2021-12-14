using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Material[] renderers;
    public MeshRenderer balloonMat;
    
    private Vector3 scaleChange;

    public int matToUse;



    Color c1 = Color.white;
    Color c2 = Color.grey;

    private void Awake()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = c1;
        lineRenderer.endColor = c2;
        matToUse = Random.Range(0, renderers.Length);

        transform.localScale = new Vector3(20f, 20f, 20f);
        scaleChange = new Vector3(50f, 50f, 50f);
    }

    void Start()
    {
        MeshCollider collider = GetComponent<MeshCollider>();       
        StartCoroutine(ColliderEnable());
        Physics.gravity = new Vector3(0, 9.8f, 0);
        balloonMat = GetComponent<MeshRenderer>();
        GetRandomMaterial();

        /*Debug.Log(renderers.Length);

        for (int i = 0; i < renderers.Length; i++)
        {
            Debug.Log(renderers[i]);
        }*/

    }
    
    void Update()
    {
        if (transform.localScale.x < 40)
        {
            transform.localScale += scaleChange *Time.deltaTime;
        }
    }
    void GetRandomMaterial()
    {
        balloonMat.material = renderers[matToUse];
    }

    IEnumerator ColliderEnable()
    {
        MeshCollider collider = GetComponent<MeshCollider>();
        collider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true;
    }
}

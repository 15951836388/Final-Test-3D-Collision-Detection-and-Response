using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToBoxBehaviour : MonoBehaviour
{
    public MeshFilter meshFilter;
    public Bounds bounds;
    public Vector3 min, max;
    public Vector3 size;
    public bool isColliding;
    public List<CubeBehaviour> contacts;


    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
        bounds = meshFilter.mesh.bounds;
        size = bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;
    }
}

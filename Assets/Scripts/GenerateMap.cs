using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GenerateMap : MonoBehaviour {

    private int width = 256;
    private int length = 256;
    public float scale = 20f;
    public float heightMultiplier = 10f;
    public Material meshMat;
    private Vector3[] vertices;
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private Rigidbody rigidBody;

    private void Awake()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshCollider = gameObject.AddComponent<MeshCollider>();
        rigidBody = gameObject.AddComponent<Rigidbody>();
        CreateMap();
    }

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = meshMat;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateMap()
    {

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Map";
        meshCollider = GetComponent<MeshCollider>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;

        float[,] heights = GenerateHeightMap.GenerateHeights(width, length, scale);

        vertices = new Vector3[(width + 1) * (length + 1)];
        Vector2[] uv = new Vector2[vertices.Length];

        for (int i = 0, y = 0; y <= length; y++)
        {
            for (int x = 0; x <= width; x++, i++)
            {
                vertices[i] = new Vector3(x, heights[x,y] * 0, y);
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;


        int[] triangles = new int[width * length * 6];
        for (int ti = 0, vi = 0, y = 0; y < length; y++, vi++)
        {
            for (int x = 0; x < width; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + width + 1;
                triangles[ti + 5] = vi + width + 2;
            }
        }
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
        meshCollider.convex = false;
    }


    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.cyan;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }

}

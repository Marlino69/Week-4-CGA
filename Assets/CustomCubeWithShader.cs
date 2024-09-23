using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCubeWithShader : MonoBehaviour
{
    [SerializeField]
    public Material cubeMaterial;
    private Texture myTexture;

    // Declaring Spin Speed and Rotation Amount
    public int spinSpeed;
    public Vector3 RotateAmount;
    float width = 1f;
    float height = 1f;
    float thick = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Give initial value for speed and rotation amount
        spinSpeed = 4;
        RotateAmount = new Vector3(0.0f, 50.0f, 0.0f);

        Mesh mesh = new Mesh();
        var vertices = new Vector3[24];
        var uvs = new Vector2[vertices.Length];

        //Load Texture
        myTexture = Resources.Load<Texture>("Textures/Week04-Tutorial");

        //Set Texture to Material
        cubeMaterial.mainTexture = myTexture;

        //First surface towards X-positive
        vertices[0] = new Vector3(width, height, thick);
        vertices[1] = new Vector3(width, -height, thick);
        vertices[2] = new Vector3(width, height, -thick);
        vertices[3] = new Vector3(width, -height, -thick);

        uvs[0] = new Vector2(0.0f, 0.5f);
        uvs[1] = new Vector2(0.25f, 0.5f);
        uvs[2] = new Vector2(0.0f, 0.0f);
        uvs[3] = new Vector2(0.25f, 0.0f);
        
        //Second surface towards Y-positive
        vertices[4] = new Vector3(width, height, thick);
        vertices[5] = new Vector3(-width, height, thick);
        vertices[6] = new Vector3(width, height, -thick);
        vertices[7] = new Vector3(-width, height, -thick);

        uvs[4] = new Vector2(0.0f, 1.0f);
        uvs[5] = new Vector2(0.25f, 1.0f);
        uvs[6] = new Vector2(0.0f, 0.5f);
        uvs[7] = new Vector2(0.25f, 0.5f);

        //Third surface towards Z-positive
        vertices[8] = new Vector3(width, height, thick);
        vertices[9] = new Vector3(-width, height, thick);
        vertices[10] = new Vector3(width, -height, thick);
        vertices[11] = new Vector3(-width, -height, thick);

        uvs[8] = new Vector2(0.25f, 0.5f);
        uvs[9] = new Vector2(0.5f, 0.5f);
        uvs[10] = new Vector2(0.25f, 0.0f);
        uvs[11] = new Vector2(0.5f, 0.0f);

        //Fourth surface towards X-negative
        vertices[12] = new Vector3(-width, height, thick);
        vertices[13] = new Vector3(-width, -height, thick);
        vertices[14] = new Vector3(-width, height, -thick);
        vertices[15] = new Vector3(-width, -height, -thick);

        uvs[12] = new Vector2(0.25f, 1.0f);
        uvs[13] = new Vector2(0.5f, 1.0f);
        uvs[14] = new Vector2(0.25f, 0.5f);
        uvs[15] = new Vector2(0.5f, 0.5f);

        //Fifth surface towards Y-negative
        vertices[16] = new Vector3(width, -height, thick);
        vertices[17] = new Vector3(-width, -height, thick);
        vertices[18] = new Vector3(width, -height, -thick);
        vertices[19] = new Vector3(-width, -height, -thick);

        uvs[16] = new Vector2(0.5f, 1.0f);
        uvs[17] = new Vector2(0.75f, 1.0f);
        uvs[18] = new Vector2(0.5f, 0.5f);
        uvs[19] = new Vector2(0.75f, 0.5f);

        //Sixth surface towards Z-negative
        vertices[20] = new Vector3(width, height, -thick);
        vertices[21] = new Vector3(-width, height, -thick);
        vertices[22] = new Vector3(width, -height, -thick);
        vertices[23] = new Vector3(-width, -height, -thick);

        uvs[20] = new Vector2(0.5f, 0.5f);
        uvs[21] = new Vector2(0.75f, 0.5f);
        uvs[22] = new Vector2(0.5f, 0.0f);
        uvs[23] = new Vector2(0.75f, 0.0f);

        mesh.vertices = vertices;

        //Declaring colors as much as vertices
        var colors = new Color32[vertices.Length];

        //Color for surface towards X-positive
        colors[0] = new Color32(128, 128, 128, 255);
        colors[1] = new Color32(128, 128, 128, 255);
        colors[2] = new Color32(128, 128, 128, 255);
        colors[3] = new Color32(128, 128, 128, 255);

        //Color for surface towards Y-positive
        colors[4] = new Color32(128, 128, 128, 255);
        colors[5] = new Color32(128, 128, 128, 255);
        colors[6] = new Color32(128, 128, 128, 255);
        colors[7] = new Color32(128, 128, 128, 255);

        //Color for surface towards Z-positive
        colors[8] = new Color32(128, 128, 128, 255);
        colors[9] = new Color32(128, 128, 128, 255);
        colors[10] = new Color32(128, 128, 128, 255);
        colors[11] = new Color32(128, 128, 128, 255);

        //Color for surface towards X-negative
        colors[12] = new Color32(128, 128, 128, 255);
        colors[13] = new Color32(128, 128, 128, 255);
        colors[14] = new Color32(128, 128, 128, 255);
        colors[15] = new Color32(128, 128, 128, 255);

        //Color for surface towards Y-negative
        colors[16] = new Color32(128, 128, 128, 255);
        colors[17] = new Color32(128, 128, 128, 255);
        colors[18] = new Color32(128, 128, 128, 255);
        colors[19] = new Color32(128, 128, 128, 255);

        //Color for surface towards Z-negative
        colors[20] = new Color32(128, 128, 128, 255);
        colors[21] = new Color32(128, 128, 128, 255);
        colors[22] = new Color32(128, 128, 128, 255);
        colors[23] = new Color32(128, 128, 128, 255);

        //Assign mesh colors to modified colors variable
        mesh.colors32 = colors;

        //Assign mesh UVs
        mesh.uv = uvs;

        mesh.triangles = new int[] {
            2,0,1,
            2,1,3, //First surface towards X-positive
            6,7,5,
            4,6,5, //Second surface towards Y-positive
            8,9,11,
            8,11,10, //Third surface towards Z-positive
            12,14,13,
            14,15,13, //Fourth surface towards X-negative
            19,18,17,
            18,16,17, //Fifth surface towards Y-negative
            21,20,23,
            20,22,23 //Sixth surface towards Z-negative
        };

        mesh.normals = new Vector3[] {
            //Normals for First Surface (X-positive)
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),

            //Normals for Second Surface (Y-positive)
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),

            //Normals for Third Surface (Z-positive)
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(0.0f, 0.0f, 1.0f),
            new Vector3(0.0f, 0.0f, 1.0f),

            //Normals for Fourth Surface (X-negative)
            new Vector3(-1.0f, 0.0f, 0.0f),
            new Vector3(-1.0f, 0.0f, 0.0f),
            new Vector3(-1.0f, 0.0f, 0.0f),
            new Vector3(-1.0f, 0.0f, 0.0f),

            //Normals for Fifth Surface (Y-negative)
            new Vector3(0.0f, -1.0f, 0.0f),
            new Vector3(0.0f, -1.0f, 0.0f),
            new Vector3(0.0f, -1.0f, 0.0f),
            new Vector3(0.0f, -1.0f, 0.0f),

            //Normals for Sixth Surface (Z-negative)
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, -1.0f),
        };
        
        // mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = cubeMaterial;

        foreach (Vector3 normal in GetComponent<MeshFilter>().mesh.normals) {
            Debug.Log(normal.x + " " + normal.y + " " + normal.z);
        }
    }

    void Update()
    {
        //Spin the cube
        transform.Rotate(RotateAmount * Time.deltaTime / spinSpeed);
    }
}

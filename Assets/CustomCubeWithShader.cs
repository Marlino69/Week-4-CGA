using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCubeWithShader : MonoBehaviour
{
    [SerializeField]
    public Material cubeMaterial;
    private Texture myTexture;

    float width = 1f;
    float height = 1f;
    float thick = 1f;

    // Start is called before the first frame update
    void Start()
    {

        Mesh mesh = new Mesh();
        var vertices = new Vector3[24];
        var uvs = new Vector2[vertices.Length];

        //Load Texture
        myTexture = Resources.Load<Texture>("Textures/Week04-CubeRoom");

        //Set Texture to Material
        cubeMaterial.mainTexture = myTexture;

        //First surface towards X-positive
        vertices[0] = new Vector3(width, height, thick);
        vertices[1] = new Vector3(width, -height, thick);
        vertices[2] = new Vector3(width, height, -thick);
        vertices[3] = new Vector3(width, -height, -thick);

        uvs[0] = new Vector2(0.25f, 0.66f); 
        uvs[1] = new Vector2(0.25f, 0.34f); 
        uvs[2] = new Vector2(0.5f, 0.66f); 
        uvs[3] = new Vector2(0.5f, 0.34f);
        
        //Second surface towards Y-positive
        vertices[4] = new Vector3(width, height, thick);
        vertices[5] = new Vector3(-width, height, thick);
        vertices[6] = new Vector3(width, height, -thick);
        vertices[7] = new Vector3(-width, height, -thick);

        uvs[4] = new Vector2(0.5f, 1.0f);
        uvs[5] = new Vector2(0.75f, 1.0f); 
        uvs[6] = new Vector2(0.5f, 0.67f); 
        uvs[7] = new Vector2(0.75f, 0.67f);

        //Third surface towards Z-positive
        vertices[8] = new Vector3(width, height, thick);
        vertices[9] = new Vector3(-width, height, thick);
        vertices[10] = new Vector3(width, -height, thick);
        vertices[11] = new Vector3(-width, -height, thick);

        uvs[8] = new Vector2(0.25f, 0.66f);
        uvs[9] = new Vector2(0f, 0.66f);
        uvs[10] = new Vector2(0.25f, 0.34f); 
        uvs[11] = new Vector2(0f, 0.34f);

        //Fourth surface towards X-negative
        vertices[12] = new Vector3(-width, height, thick);
        vertices[13] = new Vector3(-width, -height, thick);
        vertices[14] = new Vector3(-width, height, -thick);
        vertices[15] = new Vector3(-width, -height, -thick);

        uvs[12] = new Vector2(1f, 0.66f);
        uvs[13] = new Vector2(1f, 0.34f); 
        uvs[14] = new Vector2(0.75f, 0.66f); 
        uvs[15] = new Vector2(0.75f, 0.34f);

        //Fifth surface towards Y-negative
        vertices[16] = new Vector3(width, -height, thick);
        vertices[17] = new Vector3(-width, -height, thick);
        vertices[18] = new Vector3(width, -height, -thick);
        vertices[19] = new Vector3(-width, -height, -thick);

        uvs[16] = new Vector2(0.5f, 0f);
        uvs[17] = new Vector2(0.75f, 0.0f); 
        uvs[18] = new Vector2(0.5f, 0.33f); 
        uvs[19] = new Vector2(0.75f, 0.33f);

        //Sixth surface towards Z-negative
        vertices[20] = new Vector3(width, height, -thick);
        vertices[21] = new Vector3(-width, height, -thick);
        vertices[22] = new Vector3(width, -height, -thick);
        vertices[23] = new Vector3(-width, -height, -thick);

        uvs[20] = new Vector2(0.5f, 0.67f); 
        uvs[21] = new Vector2(0.75f, 0.67f); 
        uvs[22] = new Vector2(0.5f, 0.33f); 
        uvs[23] = new Vector2(0.75f, 0.33f);

        mesh.vertices = vertices;

        //Assign mesh UVs
        mesh.uv = uvs;

         mesh.triangles = new int[] {
            2,1,0,
            2,3,1, // First Surface towards X Positive 
            6,5,7,
            4,5,6, // Second Surface towards Y Positive 
            8,11,9,
            8,10,11, // Third Surface towards Z Positive 
            12,13,14,
            14,13,15, // Fourth Surface towards X Negative 
            19,17,18,
            18,17,16, // Fifth Surface towards Y Negative 
            21,23,20,
            20,23,22 // Sixth Surface towards Z Negative
    };
        
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = cubeMaterial;
    }

    FilterMode SwitchFilterModes(){
        switch (myTexture.filterMode)
        {
            case FilterMode.Bilinear:
                myTexture.filterMode = FilterMode.Point;
                break;

            case FilterMode.Point:
                myTexture.filterMode = FilterMode.Trilinear;
                break;
            
            case FilterMode.Trilinear:
                myTexture.filterMode = FilterMode.Bilinear;
                break;
        }

        return myTexture.filterMode;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myTexture.filterMode = SwitchFilterModes();
            Debug.Log("Filter Mode : " + myTexture.filterMode);
        }
    }
}

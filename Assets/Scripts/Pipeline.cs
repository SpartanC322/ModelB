using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    Matrix4x4 translation, rotation, scale, viewing, projection;
    // Start is called before the first frame update
    void Start()
    {
        Model cube = new Model(Model.myShape.B);

        CreateUnityGameObject(cube);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject CreateUnityGameObject(Model model)
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();
        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();




        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normals = new List<Vector3>();

        for (int i = 0; i <= model.bIndexList.Count - 3; i = i + 3)
        {
            Vector3 normal_for_face = model.bFaceNormals[i / 3];
            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);
            coords.Add(model.bVertices[model.bIndexList[i]]); dummy_indices.Add(i); text_coords.Add(model.bTextureCoordinates[model.bTextureIndexList[i]]); normals.Add(normal_for_face);
            coords.Add(model.bVertices[model.bIndexList[i + 1]]); dummy_indices.Add(i + 1); text_coords.Add(model.bTextureCoordinates[model.bTextureIndexList[i + 1]]); normals.Add(normal_for_face);
            coords.Add(model.bVertices[model.bIndexList[i + 2]]); dummy_indices.Add(i + 2); text_coords.Add(model.bTextureCoordinates[model.bTextureIndexList[i + 2]]); normals.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        mesh.uv = text_coords.ToArray();
        mesh.normals = normals.ToArray(); ;

        mesh_filter.mesh = mesh;
        return newGO;

    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    Matrix4x4 translation, rotation, scale, viewing, projection;
    // Start is called before the first frame update
    void Start()
    {
        Model modelB = new Model(Model.myShape.B);

        CreateUnityGameObject(modelB);

        List<Vector3> original = modelB.bVertices;

        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.AngleAxis(32, (new Vector3(1, 2, 3)).normalized));
        write_matrix(rotationMatrix, "rotationMatrix");

        List<Vector3> image_after_rotation = find_image_of(original, rotationMatrix);
        write_vertices(image_after_rotation, "rotation");

        Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(2, 3, 4));
        write_matrix(scaleMatrix, "scaleMatrix");

        List<Vector3> image_after_scale = find_image_of(image_after_rotation, scaleMatrix);
        write_vertices(image_after_scale, "scale");

        Matrix4x4 translationMatrix = Matrix4x4.Translate(new Vector3(4, 2, 3));
        write_matrix(translationMatrix, "translationMatrix");

        List<Vector3> image_after_translation = find_image_of(image_after_scale, translationMatrix);
        write_vertices(image_after_translation, "translation");

        Matrix4x4 matrix_of_transformations = rotationMatrix * scale * translationMatrix;

        // Matrix4x4 camera = Matrix4x4.LookAt();
        // Matrix4x4 proj =  Matrix4x4.Perspective()
    }

    private List<Vector3> find_image_of(List<Vector3> vertices, Matrix4x4 matrix_of_transform)
    {
        List<Vector3> new_image = new List<Vector3>();
        foreach (Vector3 v in vertices)
            new_image.Add(matrix_of_transform * v);

        return new_image;

    }

    void write_vertices(List<Vector3> vertices, string txt)
    {
        using (TextWriter tw = new StreamWriter(txt+".txt"))
        {
            foreach (Vector3 s in vertices)
                tw.WriteLine(s);
        }
    }

    void write_matrix(Matrix4x4 matrix, string txt)
    {
        using (TextWriter tw = new StreamWriter(txt + ".txt"))
        {
                tw.WriteLine(matrix);
        }
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
            coords.Add(model.bVertices[model.bIndexList[i]]);
            dummy_indices.Add(i);
            text_coords.Add(model.bTextureCoordinates[model.bTextureIndexList[i]]);
            normals.Add(normal_for_face);
            coords.Add(model.bVertices[model.bIndexList[i + 1]]);
            dummy_indices.Add(i + 1);
            text_coords.Add(model.bTextureCoordinates[model.bTextureIndexList[i + 1]]);
            normals.Add(normal_for_face);
            coords.Add(model.bVertices[model.bIndexList[i + 2]]);
            dummy_indices.Add(i + 2);
            text_coords.Add(model.bTextureCoordinates[model.bTextureIndexList[i + 2]]);
            normals.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        mesh.uv = text_coords.ToArray();
        mesh.normals = normals.ToArray(); ;

        mesh_filter.mesh = mesh;
        return newGO;

    }
}

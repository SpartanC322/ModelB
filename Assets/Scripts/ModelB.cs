using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ModelB
{
    public enum myShape { B }

    List<Vector3> bVertices;
    List<int> bIndexList;
    List<Vector2> bTextureCoordinates;
    List<int> bTextureIndexList;
    List<Vector3> bFaceNormals;

    public ModelB(myShape shape)
    {
        switch (shape)
        {
            case myShape.B:
                initialiseLists();
                AddVertices();

            break;
        }
    }

    private void AddTextureCoordinates()
    {

    }

    private void AddIndicesAndNormals()
    {

    }

    private void AddVertices()
    {
        bVertices.Add(new Vector3(2, 0, 1));
        bVertices.Add(new Vector3(3, 1, 1));
        bVertices.Add(new Vector3(3, 3, 1));
        bVertices.Add(new Vector3(2, 4, 1));
        bVertices.Add(new Vector3(0, 4, 1));
        bVertices.Add(new Vector3(0, -4, 1));
        bVertices.Add(new Vector3(2, -4, 1));
        bVertices.Add(new Vector3(3, -3, 1));
        bVertices.Add(new Vector3(3, -1, 1));
        bVertices.Add(new Vector3(2, 0, -1));
        bVertices.Add(new Vector3(3, 1, -1));
        bVertices.Add(new Vector3(3, 3, -1));
        bVertices.Add(new Vector3(2, 4, -1));
        bVertices.Add(new Vector3(0, 4, -1));
        bVertices.Add(new Vector3(0, -4, -1));
        bVertices.Add(new Vector3(2, -4, -1));
        bVertices.Add(new Vector3(3, -3, -1));
        bVertices.Add(new Vector3(3, -1, -1));
    }

    private void initialiseLists()
    {
        bVertices = new List<Vector3>();
        bIndexList = new List<int>();
        bTextureCoordinates = new List<Vector2>();
        bTextureIndexList = new List<int>();
        bFaceNormals = new List<Vector3>();
    }
}

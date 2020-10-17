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
        bTextureCoordinates.Add(new Vector2(0.25f, 0.5f))
        bTextureCoordinates.Add(new Vector2(0.125f, 0.6f))
        bTextureCoordinates.Add(new Vector2(0.125f, 0.8f))
        bTextureCoordinates.Add(new Vector2(0.25f, 0.9f))
        bTextureCoordinates.Add(new Vector2(0.5f, 0.9f))
        bTextureCoordinates.Add(new Vector2(0.5f, 0.1f))
        bTextureCoordinates.Add(new Vector2(0.25f, 0.1f))
        bTextureCoordinates.Add(new Vector2(0.125f, 0.2f))
        bTextureCoordinates.Add(new Vector2(0.125f, 0.4f))
        bTextureCoordinates.Add(new Vector2(0.875f, 0.5f))
        bTextureCoordinates.Add(new Vector2(1, 0.6f))
        bTextureCoordinates.Add(new Vector2(1, 0.8f))
        bTextureCoordinates.Add(new Vector2(0.875f, 0.9f))
        bTextureCoordinates.Add(new Vector2(0.625f, 0.9f))
        bTextureCoordinates.Add(new Vector2(0.625f, 0.1f))
        bTextureCoordinates.Add(new Vector2(0.875f, 0.1f))
        bTextureCoordinates.Add(new Vector2(1, 0.2f))
        bTextureCoordinates.Add(new Vector2(1, 0.4f))
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

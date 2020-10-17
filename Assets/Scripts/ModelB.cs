﻿using System.Collections;
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
                AddTextureCoordinates();
                AddIndicesAndNormals();

            break;
        }
    }

    private void AddTextureCoordinates()
    {
        bTextureCoordinates.Add(new Vector2(0.25f, 0.5f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.6f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.8f));
        bTextureCoordinates.Add(new Vector2(0.25f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.5f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.5f, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.25f, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.2f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.4f));
        bTextureCoordinates.Add(new Vector2(0.875f, 0.5f));
        bTextureCoordinates.Add(new Vector2(1, 0.6f));
        bTextureCoordinates.Add(new Vector2(1, 0.8f));
        bTextureCoordinates.Add(new Vector2(0.875f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.625f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.625f, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.875f, 0.1f));
        bTextureCoordinates.Add(new Vector2(1, 0.2f));
        bTextureCoordinates.Add(new Vector2(1, 0.4f));
    }

    private void AddIndicesAndNormals()
    {
        //Front Top 1
        bIndexList.Add(0);
        bIndexList.Add(1);
        bIndexList.Add(4);

        //Front Top 2
        bIndexList.Add(1);
        bIndexList.Add(2);
        bIndexList.Add(4);

        //Front Top 3
        bIndexList.Add(2);
        bIndexList.Add(3);
        bIndexList.Add(4);

        //Front Middle
        bIndexList.Add(0);
        bIndexList.Add(4);
        bIndexList.Add(5);

        //Front Bottom 1
        bIndexList.Add(5);
        bIndexList.Add(6);
        bIndexList.Add(7);

        //Front Bottom 2
        bIndexList.Add(5);
        bIndexList.Add(7);
        bIndexList.Add(8);

        //Front Bottom 3
        bIndexList.Add(5);
        bIndexList.Add(8);
        bIndexList.Add(0);

        //Back Top 1
        bIndexList.Add(9);
        bIndexList.Add(10);
        bIndexList.Add(13);

        //Back Top 2
        bTextureIndexList.Add(10);
        bTextureIndexList.Add(11);
        bTextureIndexList.Add(13);

        //Back Top 3
        bTextureIndexList.Add(11);
        bTextureIndexList.Add(12);
        bTextureIndexList.Add(13);

        //Back Middle
        bTextureIndexList.Add(9);
        bTextureIndexList.Add(13);
        bTextureIndexList.Add(14);

        //Back Bottom 1
        bTextureIndexList.Add(14);
        bTextureIndexList.Add(15);
        bTextureIndexList.Add(16);

        //Back Bottom 2
        bTextureIndexList.Add(14);
        bTextureIndexList.Add(16);
        bTextureIndexList.Add(17);

        //Back Bottom 3
        bTextureIndexList.Add(14);
        bTextureIndexList.Add(17);
        bTextureIndexList.Add(9);

        //Left 1
        bTextureIndexList.Add(13);
        bTextureIndexList.Add(4);
        bTextureIndexList.Add(5);

        //Left 2
        bTextureIndexList.Add(13);
        bTextureIndexList.Add(4);
        bTextureIndexList.Add(14);

        //Right 1
        bTextureIndexList.Add(8);
        bTextureIndexList.Add(13);
        bTextureIndexList.Add(16);
        bTextureIndexList.Add(7);

        //Right 2
        bTextureIndexList.Add(7);
        bTextureIndexList.Add(16);
        bTextureIndexList.Add(17);
        bTextureIndexList.Add(8);

        //Right 3
        bTextureIndexList.Add(8);
        bTextureIndexList.Add(17);
        bTextureIndexList.Add(9);
        bTextureIndexList.Add(0);

        //Right 4
        bTextureIndexList.Add(0);
        bTextureIndexList.Add(9);
        bTextureIndexList.Add(10);
        bTextureIndexList.Add(1);

        //Right 5
        bTextureIndexList.Add(1);
        bTextureIndexList.Add(10);
        bTextureIndexList.Add(11);
        bTextureIndexList.Add(2);

        //Right 6
        bTextureIndexList.Add(2);
        bTextureIndexList.Add(11);
        bTextureIndexList.Add(12);
        bTextureIndexList.Add(3);

        //Top 1
        bTextureIndexList.Add(4);
        bTextureIndexList.Add(3);
        bTextureIndexList.Add(12);

        //Top 2
        bTextureIndexList.Add(12);
        bTextureIndexList.Add(13);
        bTextureIndexList.Add(4);

        //Back 1
        bTextureIndexList.Add(5);
        bTextureIndexList.Add(6);
        bTextureIndexList.Add(15);

        //Back 2
        bTextureIndexList.Add(15);
        bTextureIndexList.Add(14);
        bTextureIndexList.Add(5);
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
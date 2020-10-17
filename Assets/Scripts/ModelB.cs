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
                AddTextureCoordinates();
                AddIndicesAndNormals();

            break;
        }
    }

    private void AddTextureCoordinates()
    {
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
        bTextureCoordinates.Add(new Vector2());
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
        bIndexList.Add(10);
        bIndexList.Add(11);
        bIndexList.Add(13);

        //Back Top 3
        bIndexList.Add(11);
        bIndexList.Add(12);
        bIndexList.Add(13);

        //Back Middle
        bIndexList.Add(9);
        bIndexList.Add(13);
        bIndexList.Add(14);

        //Back Bottom 1
        bIndexList.Add(14);
        bIndexList.Add(15);
        bIndexList.Add(16);

        //Back Bottom 2
        bIndexList.Add(14);
        bIndexList.Add(16);
        bIndexList.Add(17);

        //Back Bottom 3
        bIndexList.Add(14);
        bIndexList.Add(17);
        bIndexList.Add(9);

        //Left 1
        bIndexList.Add(13);
        bIndexList.Add(4);
        bIndexList.Add(5);

        //Left 2
        bIndexList.Add(13);
        bIndexList.Add(4);
        bIndexList.Add(14);

        //Right 1
        bIndexList.Add(8);
        bIndexList.Add(13);
        bIndexList.Add(16);
        
        //Right 2
        bIndexList.Add(16);
        bIndexList.Add(7);
        bIndexList.Add(8);

        //Right 3
        bIndexList.Add(7);
        bIndexList.Add(16);
        bIndexList.Add(17);

        //Right 4
        bIndexList.Add(7);
        bIndexList.Add(8);
        bIndexList.Add(17);

        //Right 5
        bIndexList.Add(8);
        bIndexList.Add(17);
        bIndexList.Add(9);

        //Right 6
        bIndexList.Add(9);
        bIndexList.Add(0);
        bIndexList.Add(8);

        //Right 7
        bIndexList.Add(0);
        bIndexList.Add(9);
        bIndexList.Add(10);

        //Right 8
        bIndexList.Add(10);
        bIndexList.Add(1);
        bIndexList.Add(0);

        //Right 9
        bIndexList.Add(1);
        bIndexList.Add(10);
        bIndexList.Add(11);

        //Right 10
        bIndexList.Add(11);
        bIndexList.Add(2);
        bIndexList.Add(1);

        //Right 11
        bIndexList.Add(2);
        bIndexList.Add(11);
        bIndexList.Add(12);

        //Right 12
        bIndexList.Add(12);
        bIndexList.Add(3);
        bIndexList.Add(2);

        //Top 1
        bIndexList.Add(4);
        bIndexList.Add(3);
        bIndexList.Add(12);

        //Top 2
        bIndexList.Add(12);
        bIndexList.Add(13);
        bIndexList.Add(4);

        //Back 1
        bIndexList.Add(5);
        bIndexList.Add(6);
        bIndexList.Add(15);

        //Back 2
        bIndexList.Add(15);
        bIndexList.Add(14);
        bIndexList.Add(5);
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
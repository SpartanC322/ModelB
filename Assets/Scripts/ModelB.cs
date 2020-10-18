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
        bTextureCoordinates.Add(new Vector2(0.25f, 0));
        bTextureCoordinates.Add(new Vector2(0.5f, 0));

        bTextureCoordinates.Add(new Vector2(0, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.25f, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.5f, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.625f, 0.1f));
        bTextureCoordinates.Add(new Vector2(0.875f, 0.1f));

        bTextureCoordinates.Add(new Vector2(0, 0.2f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.2f));
        bTextureCoordinates.Add(new Vector2(1, 0.2f));
        
        bTextureCoordinates.Add(new Vector2(0, 0.4f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.4f));
        bTextureCoordinates.Add(new Vector2(1, 0.4f));
        
        bTextureCoordinates.Add(new Vector2(0, 0.5f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.5f));
        bTextureCoordinates.Add(new Vector2(0.25f, 0.5f));
        bTextureCoordinates.Add(new Vector2(0.875f, 0.5f));
        
        bTextureCoordinates.Add(new Vector2(0, 0.6f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.6f));
        bTextureCoordinates.Add(new Vector2(1, 0.6f));
        
        bTextureCoordinates.Add(new Vector2(0, 0.8f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.8f));
        bTextureCoordinates.Add(new Vector2(0.875f, 0.8f));
        
        bTextureCoordinates.Add(new Vector2(0, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.125f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.25f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.5f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.625f, 0.9f));
        bTextureCoordinates.Add(new Vector2(0.875f, 0.9f));
        
        bTextureCoordinates.Add(new Vector2(0.25f, 1));
        bTextureCoordinates.Add(new Vector2(0.5f, 1));
    }

    private void AddIndicesAndNormals()
    {
        //Front Top 1
        bIndexList.Add(0); bTextureIndexList.Add(16);
        bIndexList.Add(1); bTextureIndexList.Add(19);
        bIndexList.Add(4); bTextureIndexList.Add(27);

        //Front Top 2
        bIndexList.Add(1); bTextureIndexList.Add(19);
        bIndexList.Add(2); bTextureIndexList.Add(22);
        bIndexList.Add(4); bTextureIndexList.Add(27);

        //Front Top 3
        bIndexList.Add(2); bTextureIndexList.Add(22);
        bIndexList.Add(3); bTextureIndexList.Add(26);
        bIndexList.Add(4); bTextureIndexList.Add(27);

        //Front Middle
        bIndexList.Add(0); bTextureIndexList.Add(16);
        bIndexList.Add(4); bTextureIndexList.Add(27);
        bIndexList.Add(5); bTextureIndexList.Add(5);

        //Front Bottom 1
        bIndexList.Add(5); bTextureIndexList.Add(5);
        bIndexList.Add(6); bTextureIndexList.Add(4);
        bIndexList.Add(7); bTextureIndexList.Add(9);

        //Front Bottom 2
        bIndexList.Add(5); bTextureIndexList.Add(5);
        bIndexList.Add(7); bTextureIndexList.Add(9);
        bIndexList.Add(8); bTextureIndexList.Add(12);

        //Front Bottom 3
        bIndexList.Add(5); bTextureIndexList.Add(5);
        bIndexList.Add(8); bTextureIndexList.Add(12);
        bIndexList.Add(0); bTextureIndexList.Add(16);

        //Back Top 1
        bIndexList.Add(9); bTextureIndexList.Add(17);
        bIndexList.Add(10); bTextureIndexList.Add(20);
        bIndexList.Add(13); bTextureIndexList.Add(28);

        //Back Top 2
        bIndexList.Add(10); bTextureIndexList.Add(20);
        bIndexList.Add(11); bTextureIndexList.Add(23);
        bIndexList.Add(13); bTextureIndexList.Add(28);

        //Back Top 3
        bIndexList.Add(11); bTextureIndexList.Add(23);
        bIndexList.Add(12); bTextureIndexList.Add(29);
        bIndexList.Add(13); bTextureIndexList.Add(28);

        //Back Middle
        bIndexList.Add(9); bTextureIndexList.Add(17);
        bIndexList.Add(13); bTextureIndexList.Add(28);
        bIndexList.Add(14); bTextureIndexList.Add(6);

        //Back Bottom 1
        bIndexList.Add(14); bTextureIndexList.Add(6);
        bIndexList.Add(15); bTextureIndexList.Add(7);
        bIndexList.Add(16); bTextureIndexList.Add(17);

        //Back Bottom 2
        bIndexList.Add(14); bTextureIndexList.Add(6);
        bIndexList.Add(16); bTextureIndexList.Add(17);
        bIndexList.Add(17); bTextureIndexList.Add(10);

        //Back Bottom 3
        bIndexList.Add(14); bTextureIndexList.Add(6);
        bIndexList.Add(17); bTextureIndexList.Add(10);
        bIndexList.Add(9); bTextureIndexList.Add(8);

        //Left 1
        bIndexList.Add(13); bTextureIndexList.Add(28);
        bIndexList.Add(4); bTextureIndexList.Add(27);
        bIndexList.Add(5); bTextureIndexList.Add(5);

        //Left 2
        bIndexList.Add(5); bTextureIndexList.Add(28);
        bIndexList.Add(14); bTextureIndexList.Add(6);
        bIndexList.Add(13); bTextureIndexList.Add(28);

        //Right 1
        bIndexList.Add(16); bTextureIndexList.Add(8);
        bIndexList.Add(13); bTextureIndexList.Add(2);
        bIndexList.Add(8); bTextureIndexList.Add(3);
        
        //Right 2
        bIndexList.Add(8); bTextureIndexList.Add(3);
        bIndexList.Add(7); bTextureIndexList.Add(9);
        bIndexList.Add(16); bTextureIndexList.Add(8);

        //Right 3
        bIndexList.Add(17); bTextureIndexList.Add(11);
        bIndexList.Add(16); bTextureIndexList.Add(8);
        bIndexList.Add(7); bTextureIndexList.Add(9);

        //Right 4
        bIndexList.Add(7); bTextureIndexList.Add(9);
        bIndexList.Add(18); bTextureIndexList.Add(12);
        bIndexList.Add(17); bTextureIndexList.Add(11);

        //Right 5
        bIndexList.Add(9); bTextureIndexList.Add(14);
        bIndexList.Add(17); bTextureIndexList.Add(11);
        bIndexList.Add(18); bTextureIndexList.Add(12);

        //Right 6
        bIndexList.Add(18); bTextureIndexList.Add(13);
        bIndexList.Add(0); bTextureIndexList.Add(15);
        bIndexList.Add(9); bTextureIndexList.Add(14);

        //Right 7
        bIndexList.Add(10); bTextureIndexList.Add(18);
        bIndexList.Add(9); bTextureIndexList.Add(14);
        bIndexList.Add(0); bTextureIndexList.Add(15);

        //Right 8
        bIndexList.Add(0); bTextureIndexList.Add(15);
        bIndexList.Add(1); bTextureIndexList.Add(19);
        bIndexList.Add(10); bTextureIndexList.Add(18);

        //Right 9
        bIndexList.Add(11); bTextureIndexList.Add(21);
        bIndexList.Add(10); bTextureIndexList.Add(18);
        bIndexList.Add(1); bTextureIndexList.Add(19);

        //Right 10
        bIndexList.Add(1); bTextureIndexList.Add(19);
        bIndexList.Add(2); bTextureIndexList.Add(22);
        bIndexList.Add(11); bTextureIndexList.Add(21);

        //Right 11
        bIndexList.Add(12); bTextureIndexList.Add(24);
        bIndexList.Add(11); bTextureIndexList.Add(21);
        bIndexList.Add(2); bTextureIndexList.Add(22);

        //Right 12
        bIndexList.Add(2); bTextureIndexList.Add(22);
        bIndexList.Add(3); bTextureIndexList.Add(27);
        bIndexList.Add(12); bTextureIndexList.Add(24);

        //Top 1
        bIndexList.Add(4); bTextureIndexList.Add(27);
        bIndexList.Add(3); bTextureIndexList.Add(26);
        bIndexList.Add(12); bTextureIndexList.Add(30);

        //Top 2
        bIndexList.Add(12); bTextureIndexList.Add(30);
        bIndexList.Add(13); bTextureIndexList.Add(31);
        bIndexList.Add(4); bTextureIndexList.Add(27);

        //Bottom 1
        bIndexList.Add(5); bTextureIndexList.Add(5);
        bIndexList.Add(6); bTextureIndexList.Add(4);
        bIndexList.Add(15); bTextureIndexList.Add(0);

        //Bottom 2
        bIndexList.Add(15); bTextureIndexList.Add(0);
        bIndexList.Add(14); bTextureIndexList.Add(1);
        bIndexList.Add(5); bTextureIndexList.Add(5);
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
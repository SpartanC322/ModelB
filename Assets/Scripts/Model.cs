using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model 
{
    public enum myShape { B }

    public Vector3[] bVertices = new Vector3[20];
    public List<int> bIndexList;
    public List<Vector2> bTextureCoordinates;
    public List<int> bTextureIndexList;
    public List<Vector3> bFaceNormals;

    public Model(myShape shape)
    {
        switch (shape)
        {
            case myShape.B:
                initialize_lists();
                add_vertices();
                add_texture_coordinates();
                add_indices_and_normals();

                break;
        }    
    }

    private void add_texture_coordinates()
    {
        //Wrong B
        //bTextureCoordinates.Add(new Vector2(0.25f, 0));
        //bTextureCoordinates.Add(new Vector2(0.5f, 0));
        //bTextureCoordinates.Add(new Vector2(0, 12.5f));
        //bTextureCoordinates.Add(new Vector2(12.5f, 12.5f));
        //bTextureCoordinates.Add(new Vector2(0.25f, 12.5f));
        //bTextureCoordinates.Add(new Vector2(0.5f, 12.5f));
        //bTextureCoordinates.Add(new Vector2(0.625f, 12.5f));
        //bTextureCoordinates.Add(new Vector2(87.5f, 12.5f));
        //bTextureCoordinates.Add(new Vector2(0, 0.25f));
        //bTextureCoordinates.Add(new Vector2(12.5f, 0.25f));
        //bTextureCoordinates.Add(new Vector2(1, 0.25f));
        //bTextureCoordinates.Add(new Vector2(0, 0.5f));
        //bTextureCoordinates.Add(new Vector2(12.5f, 0.5f));
        //bTextureCoordinates.Add(new Vector2(0.25f, 0.5f));
        //bTextureCoordinates.Add(new Vector2(0.875f, 0.5f));
        //bTextureCoordinates.Add(new Vector2(0, 0.625f));
        //bTextureCoordinates.Add(new Vector2(12.5f, 0.625f));
        //bTextureCoordinates.Add(new Vector2(1, 0.625f));
        //bTextureCoordinates.Add(new Vector2(0, 0.75f));
        //bTextureCoordinates.Add(new Vector2(12.5f, 0.75f));
        //bTextureCoordinates.Add(new Vector2(1, 0.75f));
        //bTextureCoordinates.Add(new Vector2(0, 0.875f));
        //bTextureCoordinates.Add(new Vector2(12.5f, 0.875f));
        //bTextureCoordinates.Add(new Vector2(0.25f, 0.875f));
        //bTextureCoordinates.Add(new Vector2(0.5f, 0.875f));
        //bTextureCoordinates.Add(new Vector2(0.625f, 0.875f));
        //bTextureCoordinates.Add(new Vector2(0.875f, 0.875f));
        //bTextureCoordinates.Add(new Vector2(0.25f, 1));
        //bTextureCoordinates.Add(new Vector2(0.5f, 1));

        //cube
        //bTextureCoordinates.Add(new Vector2(0.25f, 0));
        //bTextureCoordinates.Add(new Vector2(0.5f, 0));
        //bTextureCoordinates.Add(new Vector2(0f, 0.33333f));
        //bTextureCoordinates.Add(new Vector2(0.25f, 0.33333f));
        //bTextureCoordinates.Add(new Vector2(0.5f, 0.33333f));
        //bTextureCoordinates.Add(new Vector2(0.75f, 0.33333f));
        //bTextureCoordinates.Add(new Vector2(1f, 0.33333f));
        //bTextureCoordinates.Add(new Vector2(0f, 0.66667f));
        //bTextureCoordinates.Add(new Vector2(0.25f, 0.66667f));
        //bTextureCoordinates.Add(new Vector2(0.5f, 0.66667f));
        //bTextureCoordinates.Add(new Vector2(0.75f, 0.66667f));
        //bTextureCoordinates.Add(new Vector2(1f, 0.66667f));
        //bTextureCoordinates.Add(new Vector2(0.25f, 1));
        //bTextureCoordinates.Add(new Vector2(0.5f, 1));
    }

    private void add_indices_and_normals()
    {
        //B
        bIndexList.Add(0); bTextureIndexList.Add(24);
        bIndexList.Add(1); bTextureIndexList.Add(25); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(2); bTextureIndexList.Add(22); // Top Right Side 1 1
        bIndexList.Add(0); bTextureIndexList.Add(24);
        bIndexList.Add(2); bTextureIndexList.Add(22); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(3); bTextureIndexList.Add(21); // Top Right Side 1 2

        bIndexList.Add(4); bTextureIndexList.Add(31);
        bIndexList.Add(5); bTextureIndexList.Add(27); bFaceNormals.Add(new Vector3(1, 0, 0));
        bIndexList.Add(1); bTextureIndexList.Add(26); // Top 1
        bIndexList.Add(4); bTextureIndexList.Add(31);
        bIndexList.Add(1); bTextureIndexList.Add(26); bFaceNormals.Add(new Vector3(1, 0, 0));
        bIndexList.Add(0); bTextureIndexList.Add(30); // Top 2

        bIndexList.Add(7); bTextureIndexList.Add(6);
        bIndexList.Add(4); bTextureIndexList.Add(28); bFaceNormals.Add(new Vector3(0, -1, 0));
        bIndexList.Add(5); bTextureIndexList.Add(27); // Left Side  1
        bIndexList.Add(7); bTextureIndexList.Add(6);
        bIndexList.Add(5); bTextureIndexList.Add(27); bFaceNormals.Add(new Vector3(0, -1, 0));
        bIndexList.Add(6); bTextureIndexList.Add(5); // Left Side 2

        bIndexList.Add(9); bTextureIndexList.Add(0);
        bIndexList.Add(7); bTextureIndexList.Add(1); bFaceNormals.Add(new Vector3(-1, 0, 0));
        bIndexList.Add(6); bTextureIndexList.Add(5); // Bottom 1
        bIndexList.Add(9); bTextureIndexList.Add(0);
        bIndexList.Add(6); bTextureIndexList.Add(5); bFaceNormals.Add(new Vector3(-1, 0, 0));
        bIndexList.Add(8); bTextureIndexList.Add(4); // Bottom 2

        bIndexList.Add(10); bTextureIndexList.Add(8);
        bIndexList.Add(11); bTextureIndexList.Add(9); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(8); bTextureIndexList.Add(3); // Bottom Right Side 1 1
        bIndexList.Add(10); bTextureIndexList.Add(8);
        bIndexList.Add(8); bTextureIndexList.Add(3); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(9); bTextureIndexList.Add(2);// Bottom Right Side 1 2

        bIndexList.Add(12); bTextureIndexList.Add(11);
        bIndexList.Add(13); bTextureIndexList.Add(12); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(11); bTextureIndexList.Add(9); // Bottom Right Side 2 1
        bIndexList.Add(12); bTextureIndexList.Add(11);
        bIndexList.Add(11); bTextureIndexList.Add(9); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(10); bTextureIndexList.Add(8); // Bottom Right Side 2 2

        bIndexList.Add(14); bTextureIndexList.Add(14);
        bIndexList.Add(15); bTextureIndexList.Add(15); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(13); bTextureIndexList.Add(12); // Bottom Right Side 3 1
        bIndexList.Add(14); bTextureIndexList.Add(14);
        bIndexList.Add(13); bTextureIndexList.Add(12); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(12); bTextureIndexList.Add(11); // Bottom Right Side 3 2

        bIndexList.Add(16); bTextureIndexList.Add(18);
        bIndexList.Add(17); bTextureIndexList.Add(19); bFaceNormals.Add(new Vector3(0, 1, 1));
        bIndexList.Add(15); bTextureIndexList.Add(15); // Top Right Side 2 1
        bIndexList.Add(16); bTextureIndexList.Add(18);
        bIndexList.Add(15); bTextureIndexList.Add(15); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(12); bTextureIndexList.Add(11); // Top Right Side 2 2

        bIndexList.Add(3); bTextureIndexList.Add(21);
        bIndexList.Add(2); bTextureIndexList.Add(22); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(17); bTextureIndexList.Add(19); // Top Right Side 3 1
        bIndexList.Add(3); bTextureIndexList.Add(21);
        bIndexList.Add(17); bTextureIndexList.Add(19); bFaceNormals.Add(new Vector3(0, 1, 0));
        bIndexList.Add(16); bTextureIndexList.Add(18); // Top Right Side 3 2

        bIndexList.Add(15); bTextureIndexList.Add(16);
        bIndexList.Add(17); bTextureIndexList.Add(19); bFaceNormals.Add(new Vector3(0, 0, -1));
        bIndexList.Add(5); bTextureIndexList.Add(27); // Front top 1
        bIndexList.Add(17); bTextureIndexList.Add(19);
        bIndexList.Add(2); bTextureIndexList.Add(22); bFaceNormals.Add(new Vector3(0, 0, -1));
        bIndexList.Add(5); bTextureIndexList.Add(27); // Front top 2

        bIndexList.Add(2); bTextureIndexList.Add(22);
        bIndexList.Add(1); bTextureIndexList.Add(26); bFaceNormals.Add(new Vector3(0, 0, -1));
        bIndexList.Add(5); bTextureIndexList.Add(27); // Front top 3 
        bIndexList.Add(5); bTextureIndexList.Add(27);
        bIndexList.Add(6); bTextureIndexList.Add(5); bFaceNormals.Add(new Vector3(0, 0, -1));
        bIndexList.Add(15); bTextureIndexList.Add(16); // Front middle

        bIndexList.Add(6); bTextureIndexList.Add(5);
        bIndexList.Add(8); bTextureIndexList.Add(4); bFaceNormals.Add(new Vector3(0, 0, -1));
        bIndexList.Add(11); bTextureIndexList.Add(9); // Front bottom 1
        bIndexList.Add(6); bTextureIndexList.Add(5);
        bIndexList.Add(11); bTextureIndexList.Add(9); bFaceNormals.Add(new Vector3(0, 0, -1));
        bIndexList.Add(13); bTextureIndexList.Add(12); // Front bottom 2

        bIndexList.Add(6); bTextureIndexList.Add(5);
        bIndexList.Add(13); bTextureIndexList.Add(12); bFaceNormals.Add(new Vector3(0, 0, -1));
        bIndexList.Add(15); bTextureIndexList.Add(16); // Front bottom 3

        bIndexList.Add(14); bTextureIndexList.Add(17);
        bIndexList.Add(16); bTextureIndexList.Add(20); bFaceNormals.Add(new Vector3(0, 0, 1));
        bIndexList.Add(4); bTextureIndexList.Add(28); // Back top 1
        bIndexList.Add(16); bTextureIndexList.Add(19);
        bIndexList.Add(3); bTextureIndexList.Add(23); bFaceNormals.Add(new Vector3(0, 0, 1));
        bIndexList.Add(4); bTextureIndexList.Add(28); // Back top 2

        bIndexList.Add(3); bTextureIndexList.Add(23);
        bIndexList.Add(0); bTextureIndexList.Add(29); bFaceNormals.Add(new Vector3(0, 0, 1));
        bIndexList.Add(4); bTextureIndexList.Add(28); // Back top 3 
        bIndexList.Add(4); bTextureIndexList.Add(28);
        bIndexList.Add(7); bTextureIndexList.Add(6); bFaceNormals.Add(new Vector3(0, 0, 1));
        bIndexList.Add(14); bTextureIndexList.Add(17); // Back middle

        bIndexList.Add(7); bTextureIndexList.Add(6);
        bIndexList.Add(9); bTextureIndexList.Add(47); bFaceNormals.Add(new Vector3(0, 0, 1));
        bIndexList.Add(10); bTextureIndexList.Add(10); // Back bottom 1
        bIndexList.Add(7); bTextureIndexList.Add(6);
        bIndexList.Add(10); bTextureIndexList.Add(10); bFaceNormals.Add(new Vector3(0, 0, 1));
        bIndexList.Add(12); bTextureIndexList.Add(13); // Back bottom 2

        bIndexList.Add(7); bTextureIndexList.Add(6);
        bIndexList.Add(12); bTextureIndexList.Add(13); bFaceNormals.Add(new Vector3(0, 0, 1));
        bIndexList.Add(14); bTextureIndexList.Add(17); // Back bottom 3

        //cube
        //bIndexList.Add(0); bTextureIndexList.Add(9);
        //bIndexList.Add(1); bTextureIndexList.Add(8); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(2); bTextureIndexList.Add(3); // front 1
        //bIndexList.Add(0); bTextureIndexList.Add(9);
        //bIndexList.Add(2); bTextureIndexList.Add(3); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(3); bTextureIndexList.Add(4); // front 2

        //bIndexList.Add(4); bTextureIndexList.Add(10);
        //bIndexList.Add(7); bTextureIndexList.Add(5); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(6); bTextureIndexList.Add(6); // back  1
        //bIndexList.Add(4); bTextureIndexList.Add(10);
        //bIndexList.Add(6); bTextureIndexList.Add(6); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(5); bTextureIndexList.Add(11); // back 2

        //bIndexList.Add(1); bTextureIndexList.Add(8);
        //bIndexList.Add(5); bTextureIndexList.Add(7); bFaceNormals.Add(new Vector3(-1, 0, 0));
        //bIndexList.Add(6); bTextureIndexList.Add(2); // Left 1
        //bIndexList.Add(1); bTextureIndexList.Add(8);
        //bIndexList.Add(6); bTextureIndexList.Add(6); bFaceNormals.Add(new Vector3(-1, 0, 0));
        //bIndexList.Add(2); bTextureIndexList.Add(2); // Left 2

        //bIndexList.Add(0); bTextureIndexList.Add(9);
        //bIndexList.Add(3); bTextureIndexList.Add(4); bFaceNormals.Add(new Vector3(1, 0, 0));
        //bIndexList.Add(7); bTextureIndexList.Add(5); // right 1
        //bIndexList.Add(0); bTextureIndexList.Add(9);
        //bIndexList.Add(7); bTextureIndexList.Add(5); bFaceNormals.Add(new Vector3(1, 0, 0));
        //bIndexList.Add(4); bTextureIndexList.Add(10);// right 2

        //bIndexList.Add(0); bTextureIndexList.Add(9);
        //bIndexList.Add(4); bTextureIndexList.Add(13); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(5); bTextureIndexList.Add(12); // top 1
        //bIndexList.Add(0); bTextureIndexList.Add(9);
        //bIndexList.Add(5); bTextureIndexList.Add(12); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(1); bTextureIndexList.Add(8); // top 2

        //bIndexList.Add(2); bTextureIndexList.Add(3);
        //bIndexList.Add(6); bTextureIndexList.Add(0); bFaceNormals.Add(new Vector3(0, -1, 0));
        //bIndexList.Add(7); bTextureIndexList.Add(1); // bottom 1
        //bIndexList.Add(2); bTextureIndexList.Add(3);
        //bIndexList.Add(7); bTextureIndexList.Add(1); bFaceNormals.Add(new Vector3(0, -1, 0));
        //bIndexList.Add(3); bTextureIndexList.Add(4); // bottom 2
    }

    private void add_vertices()
    {
        //B
        //Front
        bVertices[0] = new Vector3(1, 0, 1);
        bVertices[1] = new Vector3(2, 1, 1);
        bVertices[2] = new Vector3(2, 3, 1);
        bVertices[3] = new Vector3(1, 4, 1);
        bVertices[4] = new Vector3(-1, 4, 1);
        bVertices[5] = new Vector3(-1, -4, 1);
        bVertices[6] = new Vector3(1, -4, 1);
        bVertices[7] = new Vector3(2, -3, 1);
        bVertices[8] = new Vector3(2, -1, 1);

        //Back
        bVertices[9] = new Vector3(1, 0, -1);
        bVertices[10] = new Vector3(2, 1, -1);
        bVertices[11] = new Vector3(2, 3, -1);
        bVertices[12] = new Vector3(1, 4, -1);
        bVertices[13] = new Vector3(-1, 4, -1);
        bVertices[14] = new Vector3(-1, -4, -1);
        bVertices[15] = new Vector3(1, -4, -1);
        bVertices[16] = new Vector3(2, -3, -1);
        bVertices[17] = new Vector3(2, -1, -1);

        //Wrong B
        ////Front
        //bVertices[0] = new Vector3(0, 0, 1);
        //bVertices[1] = new Vector3(1, 1, 1);
        //bVertices[2] = new Vector3(1, 2, 1);
        //bVertices[3] = new Vector3(0, 3, 1);
        //bVertices[4] = new Vector3(-1, 3, 1);
        //bVertices[5] = new Vector3(-1, -3, 1);
        //bVertices[6] = new Vector3(0, -3, 1);
        //bVertices[7] = new Vector3(1, -2, 1);
        //bVertices[8] = new Vector3(1, -1, 1);
        ////Back
        //bVertices[9] = new Vector3(0, 0, -1);
        //bVertices[10] = new Vector3(1, 1, -1);
        //bVertices[11] = new Vector3(1, 2, -1);
        //bVertices[12] = new Vector3(0, 3, -1);
        //bVertices[13] = new Vector3(-1, 3, -1);
        //bVertices[14] = new Vector3(-1, -3, -1);
        //bVertices[15] = new Vector3(0, -3, -1);
        //bVertices[16] = new Vector3(1, -2, -1);
        //bVertices[17] = new Vector3(1, -1, -1);

        //Cube
        //bVertices[0] = new Vector3(2, 4, 1);
        //bVertices[1] = new Vector3(-2, 4, 1);
        //bVertices[2] = new Vector3(-2, -4, 1);
        //bVertices[3] = new Vector3(1, -1, 1);
        //bVertices[4] = new Vector3(1, 1, -1);
        //bVertices[5] = new Vector3(-1, 1, -1);
        //bVertices[6] = new Vector3(-1, -1, -1);
        //bVertices[7] = new Vector3(1, -1, -1);
    }

    private void initialize_lists()
    {
        bVertices = new Vector3[18];
        bIndexList = new List<int>();
        bTextureCoordinates = new List<Vector2>();
        bTextureIndexList = new List<int>();
        bFaceNormals = new List<Vector3>();
    }
}

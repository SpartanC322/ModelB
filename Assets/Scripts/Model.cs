using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model 
{
    public enum myShape { B, cube }

    public Vector3[] bVertices = new Vector3[20];
    public int[] bIndexList = new int[96];
    public Vector2[] bTextureCoordinates;
    public int[] bTextureIndexList;
    public Vector3[] bFaceNormals;

    public Model(myShape shape)
    {
        switch (shape)
        {
            case myShape.B:
                initialise();
                addCubeVertices();
                addBTextureCoordinates();
                addBIndicesAndNormals();

                break;

            case myShape.cube:
                initialise();
                addCubeVertices();
                addCubeTextureCoordinates();
                addCubeIndicesAndNormals();

                break;
        }    
    }

    private void addBTextureCoordinates()
    {
        bTextureCoordinates[0] = new Vector2(0.25f, 0);
        bTextureCoordinates[1] = new Vector2(0.5f, 0);
        bTextureCoordinates[2] = new Vector2(0, 0.1f);
        bTextureCoordinates[3] = new Vector2(0.125f, 0.1f);
        bTextureCoordinates[4] = new Vector2(0.25f, 0.1f);
        bTextureCoordinates[5] = new Vector2(0.5f, 0.1f);
        bTextureCoordinates[6] = new Vector2(0.625f, 0.1f);
        bTextureCoordinates[7] = new Vector2(0.875f, 0.1f);
        bTextureCoordinates[8] = new Vector2(0, 0.2f);
        bTextureCoordinates[9] = new Vector2(0.125f, 0.2f);
        bTextureCoordinates[10] = new Vector2(1, 0.2f);
        bTextureCoordinates[11] = new Vector2(0, 0.4f);
        bTextureCoordinates[12] = new Vector2(0.125f, 0.4f);
        bTextureCoordinates[13] = new Vector2(1, 0.4f);
        bTextureCoordinates[14] = new Vector2(0, 0.5f);
        bTextureCoordinates[15] = new Vector2(0.125f, 0.5f);
        bTextureCoordinates[16] = new Vector2(0.25f, 0.5f);
        bTextureCoordinates[17] = new Vector2(0.875f, 0.5f);
        bTextureCoordinates[18] = new Vector2(0, 0.6f);
        bTextureCoordinates[19] = new Vector2(0.125f, 0.6f);
        bTextureCoordinates[20] = new Vector2(1, 0.6f);
        bTextureCoordinates[21] = new Vector2(0, 0.8f);
        bTextureCoordinates[22] = new Vector2(0.125f, 0.8f);
        bTextureCoordinates[23] = new Vector2(1, 0.8f);
        bTextureCoordinates[24] = new Vector2(0, 0.9f);
        bTextureCoordinates[25] = new Vector2(0.125f, 0.9f);
        bTextureCoordinates[26] = new Vector2(0.5f, 0.9f);
        bTextureCoordinates[27] = new Vector2(0.625f, 0.9f);
        bTextureCoordinates[28] = new Vector2(0.875f, 0.9f);
        bTextureCoordinates[29] = new Vector2(0.25f, 1);
        bTextureCoordinates[30] = new Vector2(0.5f, 1);

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
    }

    private void addCubeTextureCoordinates()
    {
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

    private void addBIndicesAndNormals()
    {
        //new b
        //Front
        bIndexList[0] = 0;
        bIndexList[1] = 1;  bFaceNormals[0] = new Vector3(0,0,-1);
        bIndexList[3] = 4;

        bIndexList[4] = 1;
        bIndexList[5] = 2; bFaceNormals[1] = new Vector3(0,0,-1);
        bIndexList[6] = 4;

        bIndexList[7] = 2;
        bIndexList[8] = 3; bFaceNormals[2] = new Vector3(0,0,-1);
        bIndexList[9] = 4;

        bIndexList[10] = 0;
        bIndexList[11] = 4; bFaceNormals[3] = new Vector3(0,0,-1);
        bIndexList[12] = 5;

        bIndexList[13] = 5;
        bIndexList[14] = 6; bFaceNormals[4] = new Vector3(0, 0, -1);
        bIndexList[15] = 7;

        bIndexList[16] = 5;
        bIndexList[17] = 7; bFaceNormals[5] = new Vector3(0, 0, -1);
        bIndexList[18] = 8;

        bIndexList[19] = 5;
        bIndexList[20] = 8; bFaceNormals[6] = new Vector3(0, 0, -1);
        bIndexList[21] = 0;


        //Back
        bIndexList[22] = 9;
        bIndexList[23] = 10; bFaceNormals[7] = new Vector3(0, 0, 1);
        bIndexList[24] = 13;

        bIndexList[25] = 10;
        bIndexList[26] = 11; bFaceNormals[8] = new Vector3(0, 0, 1);
        bIndexList[27] = 13;

        bIndexList[28] = 11;
        bIndexList[29] = 12; bFaceNormals[9] = new Vector3(0, 0, 1);
        bIndexList[30] = 13;

        bIndexList[31] = 9;
        bIndexList[32] = 13; bFaceNormals[10] = new Vector3(0, 0, 1);
        bIndexList[33] = 14;

        bIndexList[34] = 14;
        bIndexList[35] = 15; bFaceNormals[11] = new Vector3(0, 0, 1);
        bIndexList[36] = 16;

        bIndexList[36] = 14;
        bIndexList[37] = 16; bFaceNormals[12] = new Vector3(0, 0, 1);
        bIndexList[38] = 17;

        bIndexList[39] = 14;
        bIndexList[40] = 17; bFaceNormals[13] = new Vector3(0, 0, 1);
        bIndexList[41] = 9;

        //Top
        bIndexList[42] = 3;
        bIndexList[43] = 12; bFaceNormals[14] = new Vector3(0, 1, 0);
        bIndexList[44] = 13;

        bIndexList[45] = 13;
        bIndexList[46] = 4; bFaceNormals[15] = new Vector3(0, 1, 0);
        bIndexList[47] = 3;

        //Bottom
        bIndexList[48] = 5;
        bIndexList[49] = 14; bFaceNormals[16] = new Vector3(0, -1, 0);
        bIndexList[50] = 15;

        bIndexList[51] = 15;
        bIndexList[52] = 6; bFaceNormals[17] = new Vector3(0, -1, 0);
        bIndexList[53] = 5;

        //Left
        bIndexList[54] = 4;
        bIndexList[55] = 13; bFaceNormals[18] = new Vector3(-1, 0, 0);
        bIndexList[56] = 14;

        bIndexList[57] = 14;
        bIndexList[58] = 5; bFaceNormals[19] = new Vector3(-1, 0, 0);
        bIndexList[59] = 4;

        //Right centre top
        bIndexList[60] = 0;
        bIndexList[61] = 9; bFaceNormals[20] = new Vector3(1, -1, 0);
        bIndexList[62] = 10;

        bIndexList[63] = 10;
        bIndexList[64] = 1; bFaceNormals[21] = new Vector3(1, -1, 0);
        bIndexList[65] = 0;

        //Right middle top
        bIndexList[66] = 1;
        bIndexList[67] = 10; bFaceNormals[22] = new Vector3(1, 0, 0);
        bIndexList[68] = 11;

        bIndexList[69] = 11;
        bIndexList[70] = 2; bFaceNormals[23] = new Vector3(1, 0, 0);
        bIndexList[71] = 1;

        //Right upper top
        bIndexList[72] = 2;
        bIndexList[73] = 11; bFaceNormals[24] = new Vector3(-1, 1, 0);
        bIndexList[74] = 12;

        bIndexList[75] = 12;
        bIndexList[76] = 3; bFaceNormals[25] = new Vector3(-1, 1, 0);
        bIndexList[77] = 2;

        //Right centre bottom
        bIndexList[78] = 8;
        bIndexList[79] = 17; bFaceNormals[26] = new Vector3(1, 1, 0);
        bIndexList[80] = 9;

        bIndexList[81] = 9;
        bIndexList[82] = 0; bFaceNormals[27] = new Vector3(1, 1, 0);
        bIndexList[83] = 8;

        //Right middle bottom
        bIndexList[84] = 7;
        bIndexList[85] = 16; bFaceNormals[28] = new Vector3(1, 0, 0);
        bIndexList[86] = 17;

        bIndexList[87] = 17;
        bIndexList[88] = 8; bFaceNormals[29] = new Vector3(1, 0, 0);
        bIndexList[89] = 7;

        //Right lower bottom
        bIndexList[90] = 6;
        bIndexList[91] = 15; bFaceNormals[30] = new Vector3(1, -1, 0);
        bIndexList[92] = 16;

        bIndexList[93] = 16;
        bIndexList[94] = 7; bFaceNormals[31] = new Vector3(1, -1, 0);
        bIndexList[95] = 6;


        ////wrong B
        //bIndexList.Add(0); bTextureIndexList.Add(24);
        //bIndexList.Add(1); bTextureIndexList.Add(25); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(2); bTextureIndexList.Add(22); // Top Right Side 1 1
        //bIndexList.Add(0); bTextureIndexList.Add(24);
        //bIndexList.Add(2); bTextureIndexList.Add(22); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(3); bTextureIndexList.Add(21); // Top Right Side 1 2

        //bIndexList.Add(4); bTextureIndexList.Add(31);
        //bIndexList.Add(5); bTextureIndexList.Add(27); bFaceNormals.Add(new Vector3(1, 0, 0));
        //bIndexList.Add(1); bTextureIndexList.Add(26); // Top 1
        //bIndexList.Add(4); bTextureIndexList.Add(31);
        //bIndexList.Add(1); bTextureIndexList.Add(26); bFaceNormals.Add(new Vector3(1, 0, 0));
        //bIndexList.Add(0); bTextureIndexList.Add(30); // Top 2

        //bIndexList.Add(7); bTextureIndexList.Add(6);
        //bIndexList.Add(4); bTextureIndexList.Add(28); bFaceNormals.Add(new Vector3(0, -1, 0));
        //bIndexList.Add(5); bTextureIndexList.Add(27); // Left Side  1
        //bIndexList.Add(7); bTextureIndexList.Add(6);
        //bIndexList.Add(5); bTextureIndexList.Add(27); bFaceNormals.Add(new Vector3(0, -1, 0));
        //bIndexList.Add(6); bTextureIndexList.Add(5); // Left Side 2

        //bIndexList.Add(9); bTextureIndexList.Add(0);
        //bIndexList.Add(7); bTextureIndexList.Add(1); bFaceNormals.Add(new Vector3(-1, 0, 0));
        //bIndexList.Add(6); bTextureIndexList.Add(5); // Bottom 1
        //bIndexList.Add(9); bTextureIndexList.Add(0);
        //bIndexList.Add(6); bTextureIndexList.Add(5); bFaceNormals.Add(new Vector3(-1, 0, 0));
        //bIndexList.Add(8); bTextureIndexList.Add(4); // Bottom 2

        //bIndexList.Add(10); bTextureIndexList.Add(8);
        //bIndexList.Add(11); bTextureIndexList.Add(9); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(8); bTextureIndexList.Add(3); // Bottom Right Side 1 1
        //bIndexList.Add(10); bTextureIndexList.Add(8);
        //bIndexList.Add(8); bTextureIndexList.Add(3); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(9); bTextureIndexList.Add(2);// Bottom Right Side 1 2

        //bIndexList.Add(12); bTextureIndexList.Add(11);
        //bIndexList.Add(13); bTextureIndexList.Add(12); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(11); bTextureIndexList.Add(9); // Bottom Right Side 2 1
        //bIndexList.Add(12); bTextureIndexList.Add(11);
        //bIndexList.Add(11); bTextureIndexList.Add(9); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(10); bTextureIndexList.Add(8); // Bottom Right Side 2 2

        //bIndexList.Add(14); bTextureIndexList.Add(14);
        //bIndexList.Add(15); bTextureIndexList.Add(15); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(13); bTextureIndexList.Add(12); // Bottom Right Side 3 1
        //bIndexList.Add(14); bTextureIndexList.Add(14);
        //bIndexList.Add(13); bTextureIndexList.Add(12); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(12); bTextureIndexList.Add(11); // Bottom Right Side 3 2

        //bIndexList.Add(16); bTextureIndexList.Add(18);
        //bIndexList.Add(17); bTextureIndexList.Add(19); bFaceNormals.Add(new Vector3(0, 1, 1));
        //bIndexList.Add(15); bTextureIndexList.Add(15); // Top Right Side 2 1
        //bIndexList.Add(16); bTextureIndexList.Add(18);
        //bIndexList.Add(15); bTextureIndexList.Add(15); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(12); bTextureIndexList.Add(11); // Top Right Side 2 2

        //bIndexList.Add(3); bTextureIndexList.Add(21);
        //bIndexList.Add(2); bTextureIndexList.Add(22); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(17); bTextureIndexList.Add(19); // Top Right Side 3 1
        //bIndexList.Add(3); bTextureIndexList.Add(21);
        //bIndexList.Add(17); bTextureIndexList.Add(19); bFaceNormals.Add(new Vector3(0, 1, 0));
        //bIndexList.Add(16); bTextureIndexList.Add(18); // Top Right Side 3 2

        //bIndexList.Add(15); bTextureIndexList.Add(16);
        //bIndexList.Add(17); bTextureIndexList.Add(19); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(5); bTextureIndexList.Add(27); // Front top 1
        //bIndexList.Add(17); bTextureIndexList.Add(19);
        //bIndexList.Add(2); bTextureIndexList.Add(22); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(5); bTextureIndexList.Add(27); // Front top 2

        //bIndexList.Add(2); bTextureIndexList.Add(22);
        //bIndexList.Add(1); bTextureIndexList.Add(26); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(5); bTextureIndexList.Add(27); // Front top 3 
        //bIndexList.Add(5); bTextureIndexList.Add(27);
        //bIndexList.Add(6); bTextureIndexList.Add(5); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(15); bTextureIndexList.Add(16); // Front middle

        //bIndexList.Add(6); bTextureIndexList.Add(5);
        //bIndexList.Add(8); bTextureIndexList.Add(4); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(11); bTextureIndexList.Add(9); // Front bottom 1
        //bIndexList.Add(6); bTextureIndexList.Add(5);
        //bIndexList.Add(11); bTextureIndexList.Add(9); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(13); bTextureIndexList.Add(12); // Front bottom 2

        //bIndexList.Add(6); bTextureIndexList.Add(5);
        //bIndexList.Add(13); bTextureIndexList.Add(12); bFaceNormals.Add(new Vector3(0, 0, -1));
        //bIndexList.Add(15); bTextureIndexList.Add(16); // Front bottom 3

        //bIndexList.Add(14); bTextureIndexList.Add(17);
        //bIndexList.Add(16); bTextureIndexList.Add(20); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(4); bTextureIndexList.Add(28); // Back top 1
        //bIndexList.Add(16); bTextureIndexList.Add(19);
        //bIndexList.Add(3); bTextureIndexList.Add(23); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(4); bTextureIndexList.Add(28); // Back top 2

        //bIndexList.Add(3); bTextureIndexList.Add(23);
        //bIndexList.Add(0); bTextureIndexList.Add(29); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(4); bTextureIndexList.Add(28); // Back top 3 
        //bIndexList.Add(4); bTextureIndexList.Add(28);
        //bIndexList.Add(7); bTextureIndexList.Add(6); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(14); bTextureIndexList.Add(17); // Back middle

        //bIndexList.Add(7); bTextureIndexList.Add(6);
        //bIndexList.Add(9); bTextureIndexList.Add(47); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(10); bTextureIndexList.Add(10); // Back bottom 1
        //bIndexList.Add(7); bTextureIndexList.Add(6);
        //bIndexList.Add(10); bTextureIndexList.Add(10); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(12); bTextureIndexList.Add(13); // Back bottom 2

        //bIndexList.Add(7); bTextureIndexList.Add(6);
        //bIndexList.Add(12); bTextureIndexList.Add(13); bFaceNormals.Add(new Vector3(0, 0, 1));
        //bIndexList.Add(14); bTextureIndexList.Add(17); // Back bottom 3
    }

    private void addCubeIndicesAndNormals()
    {
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

    private void addBVertices()
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

        
    }

    private void addCubeVertices()
    {
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

    private void initialise()
    {
        bVertices = new Vector3[20];
        bIndexList = new int[96];
        bTextureCoordinates = new Vector2[31];
        bTextureIndexList = new int[96];
        bFaceNormals = new Vector3[32];
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    Matrix4x4 translation, rotation, scale, viewing, projection;
    private Vector3[] shapeVertices = new Vector3[18], imageAfterTranslate, imageAfterRotation, original;
    private Texture2D screen;
    private float angle;
    private Color defaultColour;
    public Light myLight;
    private static int screenWidth = Screen.width;
    private static int screenHeight = Screen.height;
    private Renderer myScreen;
    private Model myB = new Model(Model.myShape.B);

    // Start is called before the first frame update
    void Start()
    {
        GameObject lightGO = new GameObject("The Light");
        myLight = lightGO.AddComponent<Light>();
        myScreen = FindObjectOfType<Renderer>();
        screen = new Texture2D(screenWidth, screenHeight);
        defaultColour = new Color(screen.GetPixel(1, 1).r, screen.GetPixel(1, 1).g, screen.GetPixel(1, 1).b, screen.GetPixel(1, 1).a);
        myScreen.material.mainTexture = screen;

        //CreateUnityGameObject(myB);

        int i = 0;

        foreach (var item in myB.bVertices)
        {
            i++;
            Debug.Log(i+" | "+item.ToString());
        }

        shapeVertices = myB.bVertices;

        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.AngleAxis(32, (new Vector3(1, 2, 3)).normalized));

        WriteMatrixToFile(rotationMatrix, "rotationMatrix");

        Vector3[] imageAfterRotation = new Vector3[100];

        //foreach (var item in shapeVertices)
        //{
        //    Debug.Log(item.ToString());
        //}

        //Debug.Log(findImageOf(shapeVertices, rotationMatrix).ToString());

        imageAfterRotation = findImageOf(shapeVertices, rotationMatrix);

        //foreach (var item in imageAfterRotation)
        //{
        //    Debug.Log(item.ToString());
        //}

        WriteVerticesToFile(imageAfterRotation, "rotatedImage");

        Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(2, 3, 4));

        WriteMatrixToFile(scaleMatrix, "scaleMatrix");

        Vector3[] imageAfterScale = findImageOf(imageAfterRotation, scaleMatrix);

        Matrix4x4 translationMatrix = Matrix4x4.Translate(new Vector3(4, 2, 3));

        WriteMatrixToFile(translationMatrix, "translationMatrix");

        Vector3[] imageAfterTranslation = findImageOf(imageAfterScale, translationMatrix);

        Matrix4x4 matrixOfTransformations = rotationMatrix * scale * translationMatrix;

        //foreach (var item in shapeVertices)
        //{
        //    Debug.Log(item.ToString());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        screen = new Texture2D(screenWidth, screenHeight);
        myScreen.material.mainTexture = screen;
        angle += 5;

        Matrix4x4 perspMatrix = Matrix4x4.Perspective(90, 1, 1, 100);
        Matrix4x4 viewMatrix = ViewingMatrix(new Vector3(1, 0, 10), new Vector3(0, 0, 20), new Vector3(0, 1, 0));
        Matrix4x4 worldMatrix = RotationMatrix(new Vector3(0.5f, 0.5f, 0), angle);
        Matrix4x4 allMatrix = perspMatrix * viewMatrix * worldMatrix;

        CreateShape(DivideZ(MatrixTransform(shapeVertices, allMatrix)));
        screen.Apply();
    }

    private Vector3[] findImageOf(Vector3[] vertices, Matrix4x4 matrixOfTransform)
    {
        Vector3[] newImage = new Vector3[18];
        int i = 0;
        foreach (Vector3 v in vertices)
        {
            newImage[i] = matrixOfTransform * v;
        }

        return newImage;
    }


    void WriteVerticesToFile(Vector3[] vertices, string txt)
    {
        using (TextWriter tw = new StreamWriter(txt + ".txt"))
        {
            foreach (Vector3 s in vertices)
                tw.WriteLine(s);
        }
    }

    void WriteMatrixToFile(Matrix4x4 matrix, string txt)
    {
        using (TextWriter tw = new StreamWriter(txt + ".txt"))
        {
            tw.WriteLine(matrix);
        }
    }

    public GameObject CreateUnityGameObject(Model model)
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();
        MeshFilter meshFilter = newGO.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummyIndices = new List<int>();
        List<Vector2> textCoords = new List<Vector2>();
        List<Vector3> normals = new List<Vector3>();

        for (int i = 0; i <= myB.bIndexList.Length - 3; i = i + 3)
        {
            Vector3 normal_for_face = myB.bFaceNormals[i / 3];
            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);
            coords.Add(myB.bVertices[myB.bIndexList[i]]); dummyIndices.Add(i); textCoords.Add(myB.bTextureCoordinates[myB.bTextureIndexList[i]]); normals.Add(normal_for_face);
            coords.Add(myB.bVertices[myB.bIndexList[i + 1]]); dummyIndices.Add(i + 1); textCoords.Add(myB.bTextureCoordinates[myB.bTextureIndexList[i + 1]]); normals.Add(normal_for_face);
            coords.Add(myB.bVertices[myB.bIndexList[i + 2]]); dummyIndices.Add(i + 2); textCoords.Add(myB.bTextureCoordinates[myB.bTextureIndexList[i + 2]]); normals.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummyIndices.ToArray();
        mesh.uv = textCoords.ToArray();
        mesh.normals = normals.ToArray(); ;

        meshFilter.mesh = mesh;
        return newGO;

    }

    private Matrix4x4 RotationMatrix(Vector3 axis, float angle)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, axis.normalized);

        return Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one);
    }

    private Matrix4x4 ScalingMatrix(Vector3 scale)
    {
        return Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
    }

    private Matrix4x4 ViewingMatrix(Vector3 camera, Vector3 target, Vector3 up)
    {
        return Matrix4x4.TRS(-camera, Quaternion.LookRotation(target - camera, up.normalized), Vector3.one);
    }

    private void CreateShape(Vector3[] shape)
    {
        //Front
        CreateFace(shape[myB.bIndexList[0]], shape[myB.bIndexList[1]], shape[myB.bIndexList[2]]);

        CreateFace(shape[myB.bIndexList[3]], shape[myB.bIndexList[4]], shape[myB.bIndexList[5]]);

        CreateFace(shape[myB.bIndexList[6]], shape[myB.bIndexList[7]], shape[myB.bIndexList[8]]);

        CreateFace(shape[myB.bIndexList[9]], shape[myB.bIndexList[10]], shape[myB.bIndexList[11]]);

        CreateFace(shape[myB.bIndexList[12]], shape[myB.bIndexList[13]], shape[myB.bIndexList[14]]);

        CreateFace(shape[myB.bIndexList[15]], shape[myB.bIndexList[16]], shape[myB.bIndexList[17]]);

        CreateFace(shape[myB.bIndexList[18]], shape[myB.bIndexList[19]], shape[myB.bIndexList[20]]);


        //Back
        CreateFace(shape[myB.bIndexList[21]], shape[myB.bIndexList[22]], shape[myB.bIndexList[23]]);

        CreateFace(shape[myB.bIndexList[24]], shape[myB.bIndexList[25]], shape[myB.bIndexList[26]]);

        CreateFace(shape[myB.bIndexList[27]], shape[myB.bIndexList[28]], shape[myB.bIndexList[29]]);

        CreateFace(shape[myB.bIndexList[30]], shape[myB.bIndexList[31]], shape[myB.bIndexList[32]]);

        CreateFace(shape[myB.bIndexList[33]], shape[myB.bIndexList[34]], shape[myB.bIndexList[35]]);

        CreateFace(shape[myB.bIndexList[36]], shape[myB.bIndexList[37]], shape[myB.bIndexList[28]]);

        CreateFace(shape[myB.bIndexList[39]], shape[myB.bIndexList[40]], shape[myB.bIndexList[41]]);

        //Top
        CreateFace(shape[myB.bIndexList[42]], shape[myB.bIndexList[43]], shape[myB.bIndexList[44]]);

        CreateFace(shape[myB.bIndexList[45]], shape[myB.bIndexList[46]], shape[myB.bIndexList[47]]);

        //Bottom
        CreateFace(shape[myB.bIndexList[48]], shape[myB.bIndexList[49]], shape[myB.bIndexList[50]]);

        CreateFace(shape[myB.bIndexList[51]], shape[myB.bIndexList[52]], shape[myB.bIndexList[53]]);

        //Left
        CreateFace(shape[myB.bIndexList[54]], shape[myB.bIndexList[55]], shape[myB.bIndexList[56]]);

        CreateFace(shape[myB.bIndexList[57]], shape[myB.bIndexList[58]], shape[myB.bIndexList[59]]);

        //Right centre top
        CreateFace(shape[myB.bIndexList[60]], shape[myB.bIndexList[61]], shape[myB.bIndexList[62]]);

        CreateFace(shape[myB.bIndexList[63]], shape[myB.bIndexList[64]], shape[myB.bIndexList[65]]);

        //Right middle top
        CreateFace(shape[myB.bIndexList[66]], shape[myB.bIndexList[67]], shape[myB.bIndexList[68]]);

        CreateFace(shape[myB.bIndexList[69]], shape[myB.bIndexList[70]], shape[myB.bIndexList[71]]);

        //Right upper top
        CreateFace(shape[myB.bIndexList[72]], shape[myB.bIndexList[73]], shape[myB.bIndexList[74]]);

        CreateFace(shape[myB.bIndexList[75]], shape[myB.bIndexList[76]], shape[myB.bIndexList[77]]);

        //Right centre bottom
        CreateFace(shape[myB.bIndexList[78]], shape[myB.bIndexList[79]], shape[myB.bIndexList[80]]);

        CreateFace(shape[myB.bIndexList[81]], shape[myB.bIndexList[82]], shape[myB.bIndexList[83]]);

        //Right middle bottom
        CreateFace(shape[myB.bIndexList[84]], shape[myB.bIndexList[85]], shape[myB.bIndexList[86]]);

        CreateFace(shape[myB.bIndexList[87]], shape[myB.bIndexList[88]], shape[myB.bIndexList[89]]);

        //Right lower bottom
        CreateFace(shape[myB.bIndexList[90]], shape[myB.bIndexList[91]], shape[myB.bIndexList[92]]);

        CreateFace(shape[myB.bIndexList[93]], shape[myB.bIndexList[94]], shape[myB.bIndexList[95]]);

        ////Front
        //CreateFace(shape[0], shape[1], shape[4]);

        //CreateFace(shape[1], shape[2], shape[4]);

        //CreateFace(shape[2], shape[3], shape[4]);

        //CreateFace(shape[0], shape[4], shape[5]);

        //CreateFace(shape[5], shape[6], shape[7]);

        //CreateFace(shape[5], shape[7], shape[8]);

        //CreateFace(shape[5], shape[8], shape[0]);


        ////Back
        //CreateFace(shape[9], shape[10], shape[13]);

        //CreateFace(shape[10], shape[11], shape[13]);

        //CreateFace(shape[11], shape[12], shape[13]);

        //CreateFace(shape[9], shape[13], shape[14]);

        //CreateFace(shape[14], shape[15], shape[16]);

        //CreateFace(shape[14], shape[16], shape[17]);

        //CreateFace(shape[14], shape[17], shape[9]);

        ////Top
        //CreateFace(shape[3], shape[12], shape[13]);

        //CreateFace(shape[13], shape[4], shape[3]);

        ////Bottom
        //CreateFace(shape[5], shape[14], shape[15]);

        //CreateFace(shape[15], shape[6], shape[5]);

        ////Left
        //CreateFace(shape[4], shape[13], shape[14]);

        //CreateFace(shape[14], shape[5], shape[4]);

        ////Right centre top
        //CreateFace(shape[0], shape[9], shape[10]);

        //CreateFace(shape[10], shape[1], shape[0]);

        ////Right middle top
        //CreateFace(shape[1], shape[10], shape[11]);

        //CreateFace(shape[11], shape[2], shape[1]);

        ////Right upper top
        //CreateFace(shape[2], shape[11], shape[12]);

        //CreateFace(shape[12], shape[3], shape[2]);

        ////Right centre bottom
        //CreateFace(shape[8], shape[17], shape[9]);

        //CreateFace(shape[9], shape[0], shape[8]);

        ////Right middle bottom
        //CreateFace(shape[7], shape[16], shape[17]);

        //CreateFace(shape[17], shape[8], shape[7]);

        ////Right lower bottom
        //CreateFace(shape[6], shape[15], shape[16]);

        //CreateFace(shape[16], shape[7], shape[6]);
    }

    public Vector3 getVectorNormal(Vector2 a, Vector2 b, Vector2 c)
    {
        return Vector3.Normalize(Vector3.Cross(b - a, c - a));
    }

    public Vector3 getLightDirection(Vector3 center)
    {
        return Vector3.Normalize((center - myLight.transform.position));
    }

    public void CreateFace(Vector2 i, Vector2 j, Vector2 k)
    {
        float dotProduct = (j.x - i.x) * (k.y - j.y) - (j.y - i.y) * (k.x - j.x);

        if (dotProduct > 0)
        {
            Vector2 center = GetCenter(i, j, k);
            center = ConvertXY(center);

            CreateLine(i, j, screen);
            CreateLine(j, k, screen);
            CreateLine(k, i, screen);

            FillStack((int)center.x, (int)center.y, Color.green, defaultColour);
        }
    }

    public void FloodFill(int x, int y, Color newColour, Color oldColour, Texture2D screen)
    {

        if ((x < 0) || (x >= screenWidth))
        {
            return;
        }

        if ((y < 0) || (y >= screenHeight))
        {
            return;
        }

        if (screen.GetPixel(x, y) != oldColour)
        {
            return;
        }

        else
        {
            screen.SetPixel(x, y, newColour);
            FloodFill(x + 1, y, newColour, oldColour, screen);
            FloodFill(x, y + 1, newColour, oldColour, screen);
            FloodFill(x - 1, y, newColour, oldColour, screen);
            FloodFill(x, y - 1, newColour, oldColour, screen);
        }
    }

    private void FillStack(int x, int y, Color newColour, Color oldColour)
    {
        Stack<Vector2> pixelStack = new Stack<Vector2>();
        pixelStack.Push(new Vector2(x, y));
   
        while (pixelStack.Count > 0)
        {
            Vector2 pixel = pixelStack.Pop();
            if (CheckBounds(pixel))
            {
                if (screen.GetPixel((int)pixel.x, (int)pixel.y) == oldColour)
                {
                    screen.SetPixel((int)pixel.x, (int)pixel.y, newColour);
                    pixelStack.Push(new Vector2(pixel.x + 1, pixel.y));
                    pixelStack.Push(new Vector2(pixel.x - 1, pixel.y));
                    pixelStack.Push(new Vector2(pixel.x, pixel.y + 1));
                    pixelStack.Push(new Vector2(pixel.x, pixel.y - 1));
                }
            }
        }
    }

    private Vector2 GetCenter(Vector2 point1, Vector2 point2, Vector2 point3)
    {
        return new Vector2((point1.x + point2.x + point3.x) / 3, (point1.y + point2.y + point3.y) / 3);
    }

    public bool CheckBounds(Vector2 pixel)
    {
        if ((pixel.x < 0) || (pixel.x >= screenWidth - 1))
        {
            return false;
        }

        if ((pixel.y < 0) || (pixel.y >= screenHeight - 1))
        {
            return false;
        }

        return true;
    }

    private Vector3[] MatrixTransform(Vector3[] meshVertices, Matrix4x4 transformMatrix)
    {
        Vector3[] output = new Vector3[meshVertices.Length];
        for (int i = 0; i < meshVertices.Length; i++)
        {
            output[i] = transformMatrix * new Vector4(meshVertices[i].x, meshVertices[i].y, meshVertices[i].z, 1);
        }

        return output;
    }

    private Vector3[] DivideZ(Vector3[] shape)
    {
        List<Vector3> output = new List<Vector3>();
        foreach (Vector3 v in shape)
        {
            output.Add(new Vector3(-v.x / v.z, -v.y / v.z, -1.0f));
        }

        return output.ToArray();
    }

    private void CreateLine(Vector2 v1, Vector2 v2, Texture2D screen)
    {
        Vector2 start = v1, end = v2;

        if (LineClip(ref start, ref end))
        {
            Plot(screen, BreshenhamLine(ConvertXY(start), ConvertXY(end)));
        }
    }

    private void Plot(Texture2D screen, List<Vector2Int> list)
    {
        foreach (Vector2Int point in list)
            screen.SetPixel(point.x, point.y, Color.blue);
    }

    public static Vector2Int ConvertXY(Vector3 v)
    {
        return new Vector2Int((int)((v.x + 1.0f) * (screenWidth - 1) / 2.0f), (int)((1.0f - v.y) * (screenHeight - 1) / 2.0f));
    }

    public static bool LineClip(ref Vector2 v, ref Vector2 u)
    {
        Outcode vOutcode = new Outcode(v);
        Outcode uOutcode = new Outcode(u);
        Outcode inView = new Outcode();

        if ((vOutcode + uOutcode) == inView)
        {
            return true;
        }

        if ((vOutcode * uOutcode) != inView)
        {
            return false;
        }

        if (vOutcode == inView)
        {
            return LineClip(ref u, ref v);
        }

        if (vOutcode.up)
        {
            v = InterceptOf(u, v, 0);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inView) return LineClip(ref u, ref v);
        }

        if (vOutcode.down)
        {
            v = InterceptOf(u, v, 1);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inView) return LineClip(ref u, ref v);
        }

        if (vOutcode.left)
        {
            v = InterceptOf(u, v, 2);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inView) return LineClip(ref u, ref v);
        }

        if (vOutcode.right)
        {
            v = InterceptOf(u, v, 3);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inView) return LineClip(ref u, ref v);
        }

        return false;
    }

    private static Vector2 InterceptOf(Vector2 u, Vector2 v, int edge)
    {
        float m = (v.y - u.y) / (v.x - u.x);

        if (edge == 0)
        {
            return new Vector2(u.x + (1 / m) * (1 - u.y), 1);
        }

        if (edge == 1)
        {
            return new Vector2(u.x + (1 / m) * (-1 - u.y), -1);
        }

        if (edge == 2)
        {
            return new Vector2(-1, u.y + m * (-1 - u.x));
        }

        return new Vector2(1, u.y + m * (1 - u.x));
    }

    public static List<Vector2Int> BreshenhamLine(Vector2Int start, Vector2Int finish)
    {
        List<Vector2Int> breshenhamList = new List<Vector2Int>();

        int dX = finish.x - start.x;
        int dY = finish.y - start.y;
        int twoDY = dY * 2;
        int twoDydX = 2 * (dY - dX);
        int p = twoDY - dX;

        if (dX < 0)
        {
            return BreshenhamLine(finish, start);
        }

        if (dY < 0)
        {
            return NegativeY(BreshenhamLine(MakeNegative(start), MakeNegative(finish)));
        }

        if (dY > dX)
        {
            return SwapXY(BreshenhamLine(SwapXWithY(start), SwapXWithY(finish)));
        }

        int y = start.y;

        for (int x = start.x; x <= finish.x; x++)
        {
            breshenhamList.Add(new Vector2Int(x, y));

            if (p > 0)
            {
                y++;
                p += twoDydX;
            }

            else
            {
                p += twoDY;
            }
        }
        return breshenhamList;
    }

    public static List<Vector2Int> NegativeY(List<Vector2Int> yValues)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int v in yValues)
        {
            outputList.Add(MakeNegative(v));
        }

        return outputList;
    }

    public static Vector2Int MakeNegative(Vector2Int point)
    {
        return new Vector2Int(point.x, point.y * -1);
    }

    public static List<Vector2Int> SwapXY(List<Vector2Int> list)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int v in list)
        {
            outputList.Add(SwapXWithY(v));
        }

        return outputList;
    }

    public static Vector2Int SwapXWithY(Vector2Int value)
    {
        return new Vector2Int(value.y, value.x);
    }
}
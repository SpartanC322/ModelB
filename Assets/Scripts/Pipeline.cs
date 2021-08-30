using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    Matrix4x4 translationMatrix, rotationMatrix, scaleMatrix, viewingMatrix, projectionMatrix, matrixOfAllTransformations, matrixOfAll;
    private Vector3[] shapeVertices = new Vector3[18];
    private Texture2D screen;
    private Color defaultColour;
    private Light myLight;
    private Renderer myScreen;
    private Model myB = new Model(Model.myShape.B);
    private static int screenWidth = Screen.width;
    private static int screenHeight = Screen.height;
    private float angle;

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

        shapeVertices = myB.GetVertices();

        testMatrixAndVertices();
    }

    // Update is called once per frame
    void Update()
    {
        screen = new Texture2D(screenWidth, screenHeight);
        myScreen.material.mainTexture = screen;
        angle += 5;

        Matrix4x4 perspMatrix = Matrix4x4.Perspective(90, 1, 1, 100);
        Matrix4x4 viewMatrix = ViewingMatrix(new Vector3(1, 0, 10), new Vector3(0, 0, 20), new Vector3(0, 1, 0));
        Matrix4x4 rotationMatrix = RotationMatrix(new Vector3(0.5f, 0.5f, 0), angle);
        Matrix4x4 allMatrix = perspMatrix * viewMatrix * rotationMatrix;

        CreateShape(DivideZ(MatrixTransform(shapeVertices, allMatrix)));
        screen.Apply();
    }

    //Modifys the given vertice list using given matrix
    private List<Vector3> findImageOf(List<Vector3> vertices, Matrix4x4 transformMatrix)
    {
        List<Vector3> newImage = new List<Vector3>();

        foreach (Vector3 v in vertices)
        {
            newImage.Add(transformMatrix * v);
        }

        return newImage;
    }

    //Writes a Vertice list to a text file
    void WriteVerticesToFile(List<Vector3> vertices, string txt)
    {
        using (TextWriter tw = new StreamWriter(txt + ".txt"))
        {
            foreach (Vector3 s in vertices)
                tw.WriteLine(s);
        }
    }

    //Writes a matrix to a text file
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

        for (int i = 0; i <= myB.GetIndex().Length - 3; i = i + 3)
        {
            Vector3 normalForFace = myB.GetFaceNormals()[i / 3];
            normalForFace = new Vector3(normalForFace.x, normalForFace.y, -normalForFace.z);
            coords.Add(myB.GetVertices()[myB.GetIndex()[i]]); dummyIndices.Add(i); textCoords.Add(myB.GetTextureCoordinates()[myB.GetTextureIndex()[i]]); normals.Add(normalForFace);
            coords.Add(myB.GetVertices()[myB.GetIndex()[i + 1]]); dummyIndices.Add(i + 1); textCoords.Add(myB.GetTextureCoordinates()[myB.GetTextureIndex()[i + 1]]); normals.Add(normalForFace);
            coords.Add(myB.GetVertices()[myB.GetIndex()[i + 2]]); dummyIndices.Add(i + 2); textCoords.Add(myB.GetTextureCoordinates()[myB.GetTextureIndex()[i + 2]]); normals.Add(normalForFace);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummyIndices.ToArray();
        mesh.uv = textCoords.ToArray();
        mesh.normals = normals.ToArray(); ;

        meshFilter.mesh = mesh;
        return newGO;

    }

    //Generate files for Assignment 1 excel sheet
    private void testMatrixAndVertices()
    {
        Vector3 cam = new Vector3(1, 0, 10);
        Vector3 tar = new Vector3(0, 0, 20);

        List<Vector3> shapeList = new List<Vector3>(shapeVertices);

        WriteVerticesToFile(shapeList, "justVertices");

        rotationMatrix = Matrix4x4.Rotate(Quaternion.AngleAxis(32, (new Vector3(1, 2, 3)).normalized));

        WriteMatrixToFile(rotationMatrix, "rotationMatrix");

        List<Vector3> imageAfterRotation = findImageOf(shapeList, rotationMatrix);

        WriteVerticesToFile(imageAfterRotation, "rotatedVertices");

        scaleMatrix = Matrix4x4.Scale(new Vector3(2, 3, 4));

        WriteMatrixToFile(scaleMatrix, "scaleMatrix");

        List<Vector3> imageAfterScale = findImageOf(imageAfterRotation, scaleMatrix);

        WriteVerticesToFile(imageAfterScale, "scaleVertices");

        translationMatrix = Matrix4x4.Translate(new Vector3(4, 2, 3));

        WriteMatrixToFile(translationMatrix, "translationMatrix");

        List<Vector3> imageAfterTranslation = findImageOf(imageAfterScale, translationMatrix);

        WriteVerticesToFile(imageAfterTranslation, "translatedVertices");

        matrixOfAllTransformations = rotationMatrix * scaleMatrix * translationMatrix;

        WriteMatrixToFile(matrixOfAllTransformations, "allTransformsMatrix");

        List<Vector3> afterAllTransforms = findImageOf(shapeList, matrixOfAllTransformations);

        WriteVerticesToFile(afterAllTransforms, "allTransformsVertices");

        viewingMatrix = ViewingMatrix(new Vector3(1, 0, 10), new Vector3(0, 0, 20), new Vector3(0, 1, 0));

        WriteMatrixToFile(viewingMatrix, "viewingMatrix");

        List<Vector3> imageAfterViewing = findImageOf(imageAfterTranslation, viewingMatrix);

        WriteVerticesToFile(imageAfterViewing, "viewingVertices");

        projectionMatrix = Matrix4x4.Perspective(90, 1, 1, 100);

        WriteMatrixToFile(projectionMatrix, "projectionMatrix");

        List<Vector3> imageAfterProjection = findImageOf(imageAfterViewing, projectionMatrix);

        WriteVerticesToFile(imageAfterProjection, "projectionVertices");

        matrixOfAll = rotationMatrix * scaleMatrix * translationMatrix * viewingMatrix * projectionMatrix;

        WriteMatrixToFile(matrixOfAll, "matrixOfAll");

        List<Vector3> imageAfterAll = findImageOf(shapeList, matrixOfAll);

        WriteVerticesToFile(imageAfterAll, "verticesAfterAll");
    }

    //Matrix methods to manipulate position of shape
    //Matrix for rotation
    private Matrix4x4 RotationMatrix(Vector3 axis, float angle)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, axis.normalized);

        return Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one);
    }

    //Matrix for Scaling
    private Matrix4x4 ScalingMatrix(Vector3 scale)
    {
        return Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
    }

    //Matrix for View
    private Matrix4x4 ViewingMatrix(Vector3 camera, Vector3 target, Vector3 up)
    {
        return Matrix4x4.TRS(-camera, Quaternion.LookRotation(target - camera, up.normalized), Vector3.one);
    }

    //Matrix for transformation
    private Vector3[] MatrixTransform(Vector3[] meshVertices, Matrix4x4 transformMatrix)
    {
        Vector3[] output = new Vector3[meshVertices.Length];
        for (int i = 0; i < meshVertices.Length; i++)
        {
            output[i] = transformMatrix * new Vector4(meshVertices[i].x, meshVertices[i].y, meshVertices[i].z, 1);
        }

        return output;
    }

    //Creates all faces of the B
    private void CreateShape(Vector3[] shape)
    {
        //Front
        CreateFace(shape[myB.GetIndexAt(0)], shape[myB.GetIndexAt(1)], shape[myB.GetIndexAt(2)]);

        CreateFace(shape[myB.GetIndexAt(3)], shape[myB.GetIndexAt(4)], shape[myB.GetIndexAt(5)]);

        CreateFace(shape[myB.GetIndexAt(6)], shape[myB.GetIndexAt(7)], shape[myB.GetIndexAt(8)]);

        CreateFace(shape[myB.GetIndexAt(9)], shape[myB.GetIndexAt(10)], shape[myB.GetIndexAt(11)]);

        CreateFace(shape[myB.GetIndexAt(12)], shape[myB.GetIndexAt(13)], shape[myB.GetIndexAt(14)]);

        CreateFace(shape[myB.GetIndexAt(15)], shape[myB.GetIndexAt(16)], shape[myB.GetIndexAt(17)]);

        CreateFace(shape[myB.GetIndexAt(18)], shape[myB.GetIndexAt(19)], shape[myB.GetIndexAt(20)]);


        //Back
        CreateFace(shape[myB.GetIndexAt(21)], shape[myB.GetIndexAt(22)], shape[myB.GetIndexAt(23)]);

        CreateFace(shape[myB.GetIndexAt(24)], shape[myB.GetIndexAt(25)], shape[myB.GetIndexAt(26)]);

        CreateFace(shape[myB.GetIndexAt(27)], shape[myB.GetIndexAt(28)], shape[myB.GetIndexAt(29)]);

        CreateFace(shape[myB.GetIndexAt(30)], shape[myB.GetIndexAt(31)], shape[myB.GetIndexAt(32)]);

        CreateFace(shape[myB.GetIndexAt(33)], shape[myB.GetIndexAt(34)], shape[myB.GetIndexAt(35)]);

        CreateFace(shape[myB.GetIndexAt(36)], shape[myB.GetIndexAt(37)], shape[myB.GetIndexAt(28)]);

        CreateFace(shape[myB.GetIndexAt(39)], shape[myB.GetIndexAt(40)], shape[myB.GetIndexAt(41)]);

        //Top
        CreateFace(shape[myB.GetIndexAt(42)], shape[myB.GetIndexAt(43)], shape[myB.GetIndexAt(44)]);

        CreateFace(shape[myB.GetIndexAt(45)], shape[myB.GetIndexAt(46)], shape[myB.GetIndexAt(47)]);

        //Bottom
        CreateFace(shape[myB.GetIndexAt(48)], shape[myB.GetIndexAt(49)], shape[myB.GetIndexAt(50)]);

        CreateFace(shape[myB.GetIndexAt(51)], shape[myB.GetIndexAt(52)], shape[myB.GetIndexAt(53)]);

        //Left
        CreateFace(shape[myB.GetIndexAt(54)], shape[myB.GetIndexAt(55)], shape[myB.GetIndexAt(56)]);

        CreateFace(shape[myB.GetIndexAt(57)], shape[myB.GetIndexAt(58)], shape[myB.GetIndexAt(59)]);

        //Right centre top
        CreateFace(shape[myB.GetIndexAt(60)], shape[myB.GetIndexAt(61)], shape[myB.GetIndexAt(62)]);

        CreateFace(shape[myB.GetIndexAt(63)], shape[myB.GetIndexAt(64)], shape[myB.GetIndexAt(65)]);

        //Right middle top
        CreateFace(shape[myB.GetIndexAt(66)], shape[myB.GetIndexAt(67)], shape[myB.GetIndexAt(68)]);

        CreateFace(shape[myB.GetIndexAt(69)], shape[myB.GetIndexAt(70)], shape[myB.GetIndexAt(71)]);

        //Right upper top
        CreateFace(shape[myB.GetIndexAt(72)], shape[myB.GetIndexAt(73)], shape[myB.GetIndexAt(74)]);

        CreateFace(shape[myB.GetIndexAt(75)], shape[myB.GetIndexAt(76)], shape[myB.GetIndexAt(77)]);

        //Right centre bottom
        CreateFace(shape[myB.GetIndexAt(78)], shape[myB.GetIndexAt(79)], shape[myB.GetIndexAt(80)]);

        CreateFace(shape[myB.GetIndexAt(81)], shape[myB.GetIndexAt(82)], shape[myB.GetIndexAt(83)]);

        //Right middle bottom
        CreateFace(shape[myB.GetIndexAt(84)], shape[myB.GetIndexAt(85)], shape[myB.GetIndexAt(86)]);

        CreateFace(shape[myB.GetIndexAt(87)], shape[myB.GetIndexAt(88)], shape[myB.GetIndexAt(89)]);

        //Right lower bottom
        CreateFace(shape[myB.GetIndexAt(90)], shape[myB.GetIndexAt(91)], shape[myB.GetIndexAt(92)]);

        CreateFace(shape[myB.GetIndexAt(93)], shape[myB.GetIndexAt(94)], shape[myB.GetIndexAt(95)]);
    }

    //Get the normal of the vaector
    public Vector3 GetVectorNormal(Vector2 x, Vector2 y, Vector2 z)
    {
        return Vector3.Normalize(Vector3.Cross(y - x, z - x));
    }

    //Get the direction of the light
    public Vector3 GetLightDirection(Vector3 center)
    {
        return Vector3.Normalize((center - myLight.transform.position));
    }

    //Issue with back face thinking it is front
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

    //Fills the faces of the shape with colour given
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

    //Finds the center of given points
    private Vector2 GetCenter(Vector2 point1, Vector2 point2, Vector2 point3)
    {
        return new Vector2((point1.x + point2.x + point3.x) / 3, (point1.y + point2.y + point3.y) / 3);
    }

    //Checks bounds of screen
    public bool CheckBounds(Vector2 z)
    {
        if ((z.x < 0) || (z.x >= screenWidth - 1))
        {
            return false;
        }

        if ((z.y < 0) || (z.y >= screenHeight - 1))
        {
            return false;
        }

        return true;
    }

    //Divide by z
    private Vector3[] DivideZ(Vector3[] shape)
    {
        List<Vector3> output = new List<Vector3>();
        foreach (Vector3 v in shape)
        {
            output.Add(new Vector3(-v.x / v.z, -v.y / v.z, -1.0f));
        }

        return output.ToArray();
    }

    //Create a line using the screen and 2 given vectors
    private void CreateLine(Vector2 v1, Vector2 v2, Texture2D screen)
    {
        Vector2 start = v1, end = v2;

        if (LineClip(ref start, ref end))
        {
            Plot(screen, BreshenhamLine(ConvertXY(start), ConvertXY(end)));
        }
    }

    //Plot points
    private void Plot(Texture2D screen, List<Vector2Int> list)
    {
        foreach (Vector2Int point in list)
            screen.SetPixel(point.x, point.y, Color.blue);
    }

    //Converts x and y vectors
    public static Vector2Int ConvertXY(Vector3 z)
    {
        return new Vector2Int((int)((z.x + 1.0f) * (screenWidth - 1) / 2.0f), (int)((1.0f - z.y) * (screenHeight - 1) / 2.0f));
    }

    //Line clipping
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

    //Breshenham's line algorithm
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

    //Makes y values negative
    public static List<Vector2Int> NegativeY(List<Vector2Int> yValues)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int v in yValues)
        {
            outputList.Add(MakeNegative(v));
        }

        return outputList;
    }

    //Makes a value negatuve
    public static Vector2Int MakeNegative(Vector2Int point)
    {
        return new Vector2Int(point.x, point.y * -1);
    }

    //Swaps x and y values
    public static List<Vector2Int> SwapXY(List<Vector2Int> list)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int v in list)
        {
            outputList.Add(SwapXWithY(v));
        }

        return outputList;
    }

    //Swap x with y
    public static Vector2Int SwapXWithY(Vector2Int value)
    {
        return new Vector2Int(value.y, value.x);
    }
}
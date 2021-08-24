using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    private Vector3[] shapeVertices = new Vector3[18];
    private Vector3[] imageAfterRotation;
    private Vector3[] imageAfterTranslate;
    private Vector3[] originalPoints;
    private Texture2D screen;
    private float angle;
    private Color defaultColour;
    public Light myLight;
    private static int screenWidth = Screen.width;
    private static int screenHeight = Screen.height;
    private Renderer ourScreen;
    private Model myB = new Model(Model.myShape.B);

    // Start is called before the first frame update
    void Start()
    {
        GameObject lightGO = new GameObject("The Light");
        myLight = lightGO.AddComponent<Light>();
        ourScreen = FindObjectOfType<Renderer>();
        screen = new Texture2D(screenWidth, screenHeight);
        defaultColour = new Color(screen.GetPixel(1, 1).r, screen.GetPixel(1, 1).g, screen.GetPixel(1, 1).b, screen.GetPixel(1, 1).a);
        ourScreen.material.mainTexture = screen;

        shapeVertices = myB.bVertices;

        foreach (var item in shapeVertices)
        {
            Debug.Log(item.ToString());
        }

        //Vector3[] imageAfterViewingMatrix = applyViewingMatrix(cube);

        //Vector3[] cubeAfterProjectionMatrix = applyProjectionMatrix(imageAfterViewingMatrix);

        //cubeAfterProjectionMatrix = applyTranslateMAtrix(cubeAfterProjectionMatrix);

        //imageAfterRotation = applyRotationMatrix(cubeAfterProjectionMatrix);

        //cubeAfterProjectionMatrix = divide_by_z(cubeAfterProjectionMatrix);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(screen);
        screen = new Texture2D(screenWidth, screenHeight);
        ourScreen.material.mainTexture = screen;
        angle += 2;
        Matrix4x4 persp = Matrix4x4.Perspective(45, 1.6f, 1, 1000);
        Matrix4x4 View = viewingMatrix(new Vector3(0, 0, 10), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix4x4 world = rotationMatrix(new Vector3(1, 1, 0), angle) /* * translateMatrix(new Vector3(2, 1, 3))*/;
        Matrix4x4 overAll = persp * View * world;

        //originalPoints = shapeVertices;

        createShape(divide_by_z(MatrixTransform(shapeVertices, overAll)));
        screen.Apply();
    }

    private Matrix4x4 translateMatrix(Vector3 v)
    {
        return Matrix4x4.TRS(v, Quaternion.identity, Vector3.one);
    }
    private Matrix4x4 rotationMatrix(Vector3 axis, float angle)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, axis.normalized);

        return Matrix4x4.TRS(new Vector3(0, 0, 0), rotation, Vector3.one);
    }

    private Matrix4x4 viewingMatrix(Vector3 positionOfCamera, Vector3 target, Vector3 up)
    {
        return Matrix4x4.TRS(-positionOfCamera, Quaternion.LookRotation(target - positionOfCamera, up.normalized), Vector3.one);
    }

    private Vector3[] applyRotationMatrix(Vector3[] shape)
    {
        Vector3 startingAxis = new Vector3(40, 40, 40);
        startingAxis.Normalize();
        Quaternion rotation = Quaternion.AngleAxis(2, startingAxis);
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(new Vector3(40, 20, 30), rotation, Vector3.one);

        //printMatrix(rotationMatrix);

        Vector3[] imageAfterRotation = MatrixTransform(shape, rotationMatrix);

        return imageAfterRotation;
    }

    private void createShape(Vector3[] shape)
    {
        //Front
        createFace(shape[0], shape[1], shape[4]);

        createFace(shape[1], shape[2], shape[4]);

        createFace(shape[2], shape[3], shape[4]);

        createFace(shape[0], shape[4], shape[5]);

        createFace(shape[5], shape[6], shape[7]);

        createFace(shape[5], shape[7], shape[8]);

        createFace(shape[5], shape[8], shape[0]);


        //Back
        createFace(shape[9], shape[10], shape[13]);

        createFace(shape[10], shape[11], shape[13]);

        createFace(shape[11], shape[12], shape[13]);

        createFace(shape[9], shape[13], shape[14]);

        createFace(shape[14], shape[15], shape[16]);

        createFace(shape[14], shape[16], shape[17]);

        createFace(shape[14], shape[17], shape[9]);

        //Top
        createFace(shape[3], shape[12], shape[13]);

        createFace(shape[13], shape[4], shape[3]);

        //Bottom
        createFace(shape[5], shape[14], shape[15]);

        createFace(shape[15], shape[6], shape[5]);

        //Left
        createFace(shape[4], shape[13], shape[14]);

        createFace(shape[14], shape[5], shape[4]);

        //Right centre top
        createFace(shape[0], shape[9], shape[10]);

        createFace(shape[10], shape[1], shape[0]);

        //Right middle top
        createFace(shape[1], shape[10], shape[11]);

        createFace(shape[11], shape[2], shape[1]);

        //Right upper top
        createFace(shape[2], shape[11], shape[12]);

        createFace(shape[12], shape[3], shape[2]);

        //Right centre bottom
        createFace(shape[8], shape[17], shape[9]);

        createFace(shape[9], shape[0], shape[8]);

        //Right middle bottom
        createFace(shape[7], shape[16], shape[17]);

        createFace(shape[17], shape[8], shape[7]);

        //Right lower bottom
        createFace(shape[6], shape[15], shape[16]);

        createFace(shape[16], shape[7], shape[6]);
    }

    public Vector3 getVectorNormal(Vector2 a, Vector2 b, Vector2 c)
    {
        return Vector3.Normalize(Vector3.Cross(b - a, c - a));
    }

    public Vector3 getLightDirection(Vector3 center)
    {
        return Vector3.Normalize((center - myLight.transform.position));
    }

    public void createFace(Vector2 i, Vector2 j, Vector2 k)
    {
        float z = (j.x - i.x) * (k.y - j.y) - (j.y - i.y) * (k.x - j.x);

        if (z >= 0)
        {
            drawLine(i, j, screen);
            drawLine(j, k, screen);
            drawLine(k, i, screen);

            Vector2 center = getCenter(i, j, k);
            center = convertXY(center);
            Vector3 normal = getVectorNormal(i, j, k);
            Vector3 lightDirection = getLightDirection(center);
            float dotProduct = Vector3.Dot(lightDirection, normal);
            //Color reflection = new Color(dotProduct * Color.yellow.r * light.intensity, dotProduct * Color.yellow.g * light.intensity, dotProduct * Color.yellow.b * light.intensity, 1);
            floodFillStack((int)center.x, (int)center.y, Color.yellow, defaultColour);
        }
    }

    public void floodFill(int x, int y, Color newColour, Color oldColour, Texture2D screen)
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
            floodFill(x + 1, y, newColour, oldColour, screen);
            floodFill(x, y + 1, newColour, oldColour, screen);
            floodFill(x - 1, y, newColour, oldColour, screen);
            floodFill(x, y - 1, newColour, oldColour, screen);
        }
    }

    private void floodFillStack(int x, int y, Color newColour, Color oldColour)
    {
        Stack<Vector2> pixels = new Stack<Vector2>();
        pixels.Push(new Vector2(x, y));
   
        while (pixels.Count > 0)
        {
            Vector2 p = pixels.Pop();
            if (checkBounds(p))
            {
                if (screen.GetPixel((int)p.x, (int)p.y) == oldColour)
                {
                    screen.SetPixel((int)p.x, (int)p.y, newColour);
                    pixels.Push(new Vector2(p.x + 1, p.y));
                    pixels.Push(new Vector2(p.x - 1, p.y));
                    pixels.Push(new Vector2(p.x, p.y + 1));
                    pixels.Push(new Vector2(p.x, p.y - 1));
                }
            }
        }
    }

    private Vector2 getCenter(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        return new Vector2((p1.x + p2.x + p3.x) / 3, (p1.y + p2.y + p3.y) / 3);
    }

    public bool checkBounds(Vector2 pixel)
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

    private Vector3[] applyProjectionMatrix(Vector3[] imageAfterViewingMatrix)
    {
        Matrix4x4 projectionMatrix = Matrix4x4.Perspective(45, 1.6f, 1, 1000);

        Vector3[] imageAfterProjection = MatrixTransform(imageAfterViewingMatrix, projectionMatrix);

        return imageAfterProjection;
    }

    private Vector3[] applyViewingMatrix(Vector3[] shape)
    {
        Matrix4x4 viewingMatrix = Matrix4x4.TRS(new Vector3(0, 0, 10), Quaternion.LookRotation(new Vector3(0, 0, 0) - new Vector3(0, 0, 10), new Vector3(0, 1, 0).normalized), Vector3.one);

        Vector3[] imageAfterViewingMatrix = MatrixTransform(shape, viewingMatrix);

        return imageAfterViewingMatrix;
    }

    public Vector3[] applyTranslateMAtrix(Vector3[] shape)
    {
        Matrix4x4 transformMatrix = Matrix4x4.TRS(new Vector3(4, 3, 3), Quaternion.identity, Vector3.one);

        Vector3[] imageAfterTranslate = MatrixTransform(shape, transformMatrix);

        return imageAfterTranslate;
    }

    private Vector3[] divide_by_z(Vector3[] shape)
    {
        List<Vector3> output = new List<Vector3>();
        foreach (Vector3 v in shape)
        {
            output.Add(new Vector3(-v.x / v.z, -v.y / v.z, -1.0f));
        }

        return output.ToArray();
    }

    private void drawLine(Vector2 v1, Vector2 v2, Texture2D screen)
    {
        Vector2 start = v1, end = v2;

        if (lineClip(ref start, ref end))
        {
            plot(screen, breshenhamLine(convertXY(start), convertXY(end)));
        }

    }

    private void plot(Texture2D screen, List<Vector2Int> list)
    {
        foreach (Vector2Int point in list)
            screen.SetPixel(point.x, point.y, Color.blue);

    }

    public static Vector2Int convertXY(Vector3 v)
    {
        return new Vector2Int((int)((v.x + 1.0f) * (screenWidth - 1) / 2.0f), (int)((1.0f - v.y) * (screenHeight - 1) / 2.0f));
    }

    public static bool lineClip(ref Vector2 v, ref Vector2 u)
    {

        Outcode v_outcode = new Outcode(v);
        Outcode u_outcode = new Outcode(u);
        Outcode inViewport = new Outcode();
        if ((v_outcode + u_outcode) == inViewport)
            return true;
        if ((v_outcode * u_outcode) != inViewport)
            return false;

        if (v_outcode == inViewport)
            return lineClip(ref u, ref v);

        // v must be outside viewport
        if (v_outcode.up)
        {
            v = intercept(u, v, 0);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inViewport) return lineClip(ref u, ref v);
        }

        if (v_outcode.down)
        {
            v = intercept(u, v, 1);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inViewport) return lineClip(ref u, ref v);
        }

        if (v_outcode.left)
        {
            v = intercept(u, v, 2);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inViewport) return lineClip(ref u, ref v);
        }

        if (v_outcode.right)
        {
            v = intercept(u, v, 3);
            Outcode v2_outcode = new Outcode(v);
            if (v2_outcode == inViewport) return lineClip(ref u, ref v);
        }

        return false;
    }

    private static Vector2 intercept(Vector2 u, Vector2 v, int edge)
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

    public static List<Vector2Int> breshenhamLine(Vector2Int start, Vector2Int finish)
    {
        List<Vector2Int> breshenhamList = new List<Vector2Int>();

        int dX = finish.x - start.x;
        int dY = finish.y - start.y;
        int twoDY = dY * 2;
        int twoDydX = 2 * (dY - dX);
        int p = twoDY - dX;

        if (dX < 0)
        {
            return breshenhamLine(finish, start);
        }

        if (dY < 0)
        {
            return negativeY(breshenhamLine(negativeY(start), negativeY(finish)));
        }

        if (dY > dX)
        {
            return swapXY(breshenhamLine(swapXY(start), swapXY(finish)));
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

    public static List<Vector2Int> negativeY(List<Vector2Int> yValues)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int v in yValues)
        {
            outputList.Add(negativeY(v));
        }

        return outputList;
    }

    public static Vector2Int negativeY(Vector2Int point)
    {
        return new Vector2Int(point.x, point.y * -1);
    }

    public static List<Vector2Int> swapXY(List<Vector2Int> list)
    {

        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int v in list)
        {
            outputList.Add(swapXY(v));
        }

        return outputList;
    }

    public static Vector2Int swapXY(Vector2Int value)
    {
        return new Vector2Int(value.y, value.x);
    }

    private Vector3[] MatrixTransform(
        Vector3[] meshVertices,
        Matrix4x4 transformMatrix)
    {
        Vector3[] output = new Vector3[meshVertices.Length];
        for (int i = 0; i < meshVertices.Length; i++)
        {
            output[i] = transformMatrix * new Vector4(meshVertices[i].x, meshVertices[i].y, meshVertices[i].z, 1);
        }

        return output;
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    //change rows & columns to an int stored elsewhere
    public int rows = 10;
    public int columns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftBottomLocation = new Vector3(0, 0, 0); //this is the start location, also store this elsewhere for different instances

    public GameObject[,] gridArray;
    public int startX = 0;
    public int startY = 0;
    public int endX = 2; //why2?? said it doesnt matter in video
    public int endY = 2; //why2?? said it doesnt matter in video


    public int r = 0;
    public int c = 0;
    void Awake()
    {
        gridArray = new GameObject[columns, rows];
        if (gridPrefab)
            GenerateGrid();
        else print("missing gridPrefab, please assign.");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GenerateGrid()
    {
        for (int r = 0; r < columns; r++)
        {
            for (int c = 0; c < rows; c++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(leftBottomLocation.x + scale * r, leftBottomLocation.y, leftBottomLocation.z + scale * c), Quaternion.identity); // will move the object by the scale amount
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStat>().x = r;
                obj.GetComponent<GridStat>().y = c;
                gridArray[r, c] = obj;

            }
        }
    }
    void InitialSetUp()
    {
        foreach (GameObject obj in gridArray)
        {
            obj.GetComponent<GridStat>().visited = -1;
        }
        gridArray[startX, startY].GetComponent<GridStat>().visited = 0;
    }
    bool TestDirection(int x, int y, int step, int direction)
    {
        //int direction tells which case to use, 1 is up, 2 is right, 3 is down, 4 is left
        switch (direction)
        {
            case 1:
                if (y + 1 < rows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;

            case 2:
                if (x + 1 < columns && gridArray[x+1, y] && gridArray[x+1,y].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;

            case 3:
                if (y - 1 >-1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
            case 4:
                if (x-1 >-1 && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
        }
        return false;
    }
    void SetVisited (int x, int y, int step)
    {
        if(gridArray[x,y])
           gridArray[x,y].GetComponent<GridStat>().visited = step;
    }
}

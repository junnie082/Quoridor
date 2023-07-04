using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;

    const int ROW = 9;
    const int COL = 9;
    private Cell[,] cells = new Cell[COL, ROW];

    private Vector2Int P1Coordinate = new Vector2Int();
    private Vector2Int P2Coordinate = new Vector2Int();
    private List<Vector2Int> possiblePawnList = new List<Vector2Int>();

    private void Awake()
    {
//        UIEvenetManager.AddListener("", );
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeBoard());
    }
    IEnumerator InitializeBoard()
    {
        createBoard();

        yield return null;

        setEdge();

        Cell cell = GetCell(1, 1);
        cell.SetPawn(true, Color.red);
    }

    private void SetPawn(EPlayer ePlayer) {
        return;
    //make only possible route pressable
    private void makePossAble(List<Vector2Int> possibleList) 
    {
        //DeSelect clicked one
        for(int i = 0; i < possiblePawnList.Count; i++)
        {
            Vector2Int coord = possiblePawnList[i];
            Cell targetCell = GetCell(coord.x, coord.y);
            targetCell.SetClickablePawn(false);
        }
        //Select ones
        for(int i = 0; i < possibleList.Count; i++)
        {
            Vector2Int coord = possibleList[i];
            Cell targetCell = GetCell(coord.x, coord.y);
            targetCell.SetClickablePawn(true);
        }
        possiblePawnList = possibleList;
    }
    }
    public Cell GetCell(int col, int row)
    {
        if (row >= 0 && row < ROW && col >= 0 && col < COL)
        {
            return cells[col, row];
        }
        else
        {
            Debug.LogError("Invalid cell coordinates!");
            return null;
        }
    }

    private void createBoard()
    {
        for (int row = 0; row < ROW; row++)
        {
            for (int col = 0; col < COL; col++)
            {
                GameObject cellGO = Instantiate(cellPrefab, transform);
                Cell cell = cellGO.GetComponent<Cell>();
                cell.SetEdge(col == COL - 1, row == ROW - 1);
                cell.SetCoordinate(col, row);
                cells[col, row] = cell;

                cellGO.name = "Cell_( " + col + ", " + row +" )";
            }
        }
    }
    private void setEdge()
    {
        for (int row = 0; row < ROW; row++)
        {
            cells[COL - 1, row].SetRightPlank(false, Color.red);
        }
        for (int col = 0; col < COL; col++)
        {
            cells[col, ROW-1].SetBottomPlank(false, Color.red);
        }
    }


}
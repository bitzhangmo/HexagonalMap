﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;

    public HexCell cellPrefab;
    public Text cellLabelPrefab;
    public Color defaultColor = Color.white;
    public Color touchedColor = Color.magenta;
    Canvas gridCanvas;
    HexMesh hexMesh;
    HexCell[] cells;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();
        cells = new HexCell[height * width];

        for(int z = 0 , i = 0; z < height ; z++)
        {
            for(int x = 0; x < width; x++)
            {
                CreateCell(x,z,i++);
            }
        }
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        hexMesh.Triangulate(cells);
    }
    void CreateCell(int x,int z,int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.innerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell> (cellPrefab);
        cell.transform.SetParent(transform,false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffserCorrdinates(x,z);
        cell.color = defaultColor;
        
        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform,false);
        label.rectTransform.anchoredPosition = new Vector2(position.x,position.z);
        label.text = cell.coordinates.ToStringOnSeoarateLines();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMeshPro;
    private GridObject _gridObject;

    public void SetGridObject(GridObject gridObject)
    {
        this._gridObject = gridObject;
    }

    private void Update()
    {
        _textMeshPro.text = _gridObject.ToString();
    }
}
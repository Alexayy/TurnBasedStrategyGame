using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // [SerializeField] private Transform _gridDebugObjectPrefab;
    //
    // private GridSystem _gridSystem;

    // [SerializeField] private Unit _unit;

    // Start is called before the first frame update
    void Start()
    {
        // _gridSystem = new GridSystem(10, 10, 2f);
        // _gridSystem.CreateDebugObjects(_gridDebugObjectPrefab);
        //
        // Debug.Log(new GridPosition(5, 7));
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     GridSystemVisual.Instance.HideAllGridPosition();
        //     GridSystemVisual.Instance.ShowGridPositionList(_unit.GetMoveAction().GetValidActionGridPositionList());
        //     
        //     
        // }
        
        // Debug.Log(_unit.transform.position);
        // Debug.Log(_gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }
}
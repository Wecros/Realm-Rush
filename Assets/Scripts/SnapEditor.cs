using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
public class SnapEditor : MonoBehaviour
{
    const int gridSize = 10;
    // Update is called once per frame
    void Update()
    {
        PositionSnap();
    }

    void PositionSnap() {
        Vector2Int gridPos = new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
        transform.position = new Vector3(gridPos.x * gridSize, 0f, gridPos.y * gridSize);
    }
}

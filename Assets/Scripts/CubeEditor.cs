using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	Vector3 gridPos;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {
	const int gridSize = 10;
	TextMesh textMesh;

	void Update()
    {
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(gridPos.x, 0f, gridPos.z);

        UpdateLabel(gridPos);
    }

    private void UpdateLabel(Vector3 gridPos)
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x / gridSize + "," + gridPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = "Waypoint: " + labelText;
        //gameObject.name = labelText;
    }
}

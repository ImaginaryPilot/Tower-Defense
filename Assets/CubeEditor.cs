using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range(1f,20f)]float gridsize = 10f;

    TextMesh textmesh;

    void Update()
    {
        Vector3 SnapPos;
        SnapPos.x = Mathf.RoundToInt(transform.position.x / gridsize) * gridsize;
        SnapPos.z = Mathf.RoundToInt(transform.position.z / gridsize) * gridsize;

        transform.position = new Vector3(SnapPos.x, 0f, SnapPos.z);

        textmesh = GetComponentInChildren<TextMesh>();
        string Labeltext = SnapPos.x / gridsize + "," + SnapPos.z / gridsize;
        textmesh.text = Labeltext;
        gameObject.name = Labeltext;
    }
}

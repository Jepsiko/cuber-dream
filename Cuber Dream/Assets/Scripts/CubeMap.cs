using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState cubeState;

    public Transform front;
    public Transform back;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;


    public void Set() {
        cubeState = FindObjectOfType<CubeState>();

        UpdateMap(cubeState.front, front);
        UpdateMap(cubeState.back, back);
        UpdateMap(cubeState.up, up);
        UpdateMap(cubeState.down, down);
        UpdateMap(cubeState.left, left);
        UpdateMap(cubeState.right, right);
    }

    void UpdateMap(List<GameObject> face, Transform side) {
        int i = 0;
        foreach (Transform map in side) {
            if (face[i].name[0] == 'F')
                map.GetComponent<Image>().color = new Color(0, 0.23f, 0.64f, 1);
            if (face[i].name[0] == 'B')
                map.GetComponent<Image>().color = Color.green;
            if (face[i].name[0] == 'U')
                map.GetComponent<Image>().color = Color.white;
            if (face[i].name[0] == 'D')
                map.GetComponent<Image>().color = Color.yellow;
            if (face[i].name[0] == 'L')
                map.GetComponent<Image>().color = Color.red;
            if (face[i].name[0] == 'R')
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);

            i++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneDialog : MonoBehaviour
{
    public Dictionary<int, string> dialogDict = new Dictionary<int, string>();

    private void Start()
    {
        dialogDict.Add(101, "BuildIndex 1, Dialog No.01 \n");
        dialogDict.Add(102, "BuildIndex 1, Dialog No.02 \n");
        dialogDict.Add(103, "BuildIndex 1, Dialog No.03 \n");
        dialogDict.Add(104, "BuildIndex 1, Dialog No.04 \n");
        dialogDict.Add(105, "BuildIndex 1, Dialog No.05 \n");

        dialogDict.Add(301, "BuildIndex 3, Dialog No.01 \n");
        dialogDict.Add(302, "BuildIndex 3, Dialog No.02 \n");
        dialogDict.Add(303, "BuildIndex 3, Dialog No.03 \n");
        dialogDict.Add(304, "BuildIndex 3, Dialog No.04 \n");
        dialogDict.Add(305, "BuildIndex 3, Dialog No.05 \n");

        dialogDict.Add(501, "BuildIndex 5, Dialog No.01 \n");
        dialogDict.Add(502, "BuildIndex 5, Dialog No.02 \n");
        dialogDict.Add(503, "BuildIndex 5, Dialog No.03 \n");
        dialogDict.Add(504, "BuildIndex 5, Dialog No.04 \n");
        dialogDict.Add(505, "BuildIndex 5, Dialog No.05 \n");

        dialogDict.Add(701, "BuildIndex 7, Dialog No.01 \n");
        dialogDict.Add(702, "BuildIndex 7, Dialog No.02 \n");
        dialogDict.Add(703, "BuildIndex 7, Dialog No.03 \n");
        dialogDict.Add(704, "BuildIndex 7, Dialog No.04 \n");
        dialogDict.Add(705, "BuildIndex 7, Dialog No.05 \n");
    }
}

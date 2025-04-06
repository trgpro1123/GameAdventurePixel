using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexMap : MonoBehaviour
{
    [SerializeField] private int index;

    public int GetIndexMap(){
        return index;
    }
}

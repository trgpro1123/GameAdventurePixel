using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    private int indexMap;
    public void ToggleAciveMap(){
        foreach(Transform inventorySlot in this.transform){
            if(inventorySlot.gameObject.GetComponent<IndexMap>()?.GetIndexMap()==indexMap){
                inventorySlot.gameObject.SetActive(true);
            }
        }
    }
    public void AciveMapFalse(){
        if(this.transform.childCount==0) return;
        foreach(Transform inventorySlot in this.transform){
            inventorySlot.gameObject.SetActive(false);
        }
    }
    public void GetIndexScene(int index){
        indexMap=index;
    }
    public void ReloadMap(){
        Destroy(gameObject);
    }
}

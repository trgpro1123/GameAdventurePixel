using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] Material whiteMaterial;
    [SerializeField] float timeDuration;

    private Material rawMaterial;
    private SpriteRenderer spr;

    private void Awake() {
        spr=GetComponent<SpriteRenderer>();
        rawMaterial=spr.material;
    }
    public float GetTimeDuratinFlash(){
        return timeDuration;
    }

    public IEnumerator FlashRoutine(){
        spr.material=whiteMaterial;
        yield return new WaitForSeconds(timeDuration);
        spr.material=rawMaterial;
    }

    
}

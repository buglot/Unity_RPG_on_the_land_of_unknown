using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image card;

    public void Set(UpGradesData upGrades){
        card.sprite = upGrades.card;
    }
    public void Clear(){
        card.sprite = null;
    }
}

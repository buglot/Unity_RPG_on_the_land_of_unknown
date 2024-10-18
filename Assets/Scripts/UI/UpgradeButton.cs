using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject card;
    public void Set(UpGradesData upGrades){
        card = upGrades.card;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image card;
    [SerializeField] TextMeshProUGUI about;
    [SerializeField] TextMeshProUGUI title;
    public void Set(UpGradesData upGrades)
    {
        card.sprite = upGrades.card;
        title.text = upGrades.Name;
        setAbout(upGrades);
    }
    private void setAbout(UpGradesData upgrades)
    {
        string text = "";
        switch (upgrades.UpgradesType)
        {

            case UpGradesType.WeaponUpGrade:
                WeaponStats w = upgrades.weaponUpgradeState;
                if (w.damage != 0)
                {
                    text += "Damage +" + w.damage.ToString() + "\n";
                }
                if (w.knockback != 0)
                {
                    text += "Knockback +" + w.knockback.ToString() + "\n";
                }
                if (w.timeToAttack != 0)
                {
                    if (w.timeToAttack > 0)
                    {
                        text += "Speed Attack +" + w.timeToAttack.ToString() + "\n";
                    }
                    else
                    {
                        text += "Delay To Attack " + w.timeToAttack.ToString() + "\n";
                    }

                }
                break;
            case UpGradesType.WeaponUnlock:
                text += "New Weapon";
                break;
            case UpGradesType.PlayAbilityUpGrade:
                PlayerStateUpgrade p = upgrades.PlayerStateUpgrade;
                if (p.armor != 0)
                {
                    text += "armor +" + p.armor.ToString() + "\n";
                }
                if (p.health != 0)
                {
                    text += "health +" + p.health.ToString() + "\n";
                }
                if (p.maxblood != 0)
                {
                    text += "Max Blood +" + p.maxblood.ToString() + "\n";
                }
                if (p.MoveSpeed != 0)
                {
                    text += "Move Speed +" + p.MoveSpeed.ToString() + "\n";
                }
                break;
            case UpGradesType.WeaponChange:
                text += "Evolution\n";
                break;
        }
        about.text = text;
    }
    public void Clear()
    {
        card.sprite = null;
    }
}

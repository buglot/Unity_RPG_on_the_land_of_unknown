using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]

public class PlayerStateUpgrade{
    public PlayerStateUpgrade(float maxblood,float health,float armor){
        this.maxblood = maxblood;
        this.health = health;
        this.armor = armor;
    }
    public float maxblood;
    public float health;
    public float armor;
}
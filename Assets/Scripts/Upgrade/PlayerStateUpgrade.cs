using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]

public class PlayerStateUpgrade{
    public PlayerStateUpgrade(float maxblood,float health,float armor,float MoveSpeed){
        this.maxblood = maxblood;
        this.health = health;
        this.armor = armor;
        this.MoveSpeed = MoveSpeed;
    }
    public float maxblood;
    public float health;
    public float armor;
    public float MoveSpeed;
}
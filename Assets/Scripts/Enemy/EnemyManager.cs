using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField] Enemy enemy;
    [SerializeField] EnemyWalk walk;
    [SerializeField] ItemDrop itemDrop;
    [SerializeField] ItemDropState itemDropState;
    [SerializeField] EnemyState state;
    [SerializeField] KnockbackEnemies knockbackEnemies;
    public void SetState(EnemyState state){
        enemy.state = new EnemyState(state);
        this.state = enemy.state;
        SetSpeed(state.speed);
    }
    
    public void SetSpeed(float a){
        walk.setSpeed(a);
    }
    public void SetItemDrop(ItemDropState state){
        itemDrop.item = new ItemDropState(state);
        itemDropState = itemDrop.item;
    }

    public void UpdateStateForProgress(float progress)
    {
        state.ApplyProgress(progress);
        itemDropState.ApplyProgress(progress);
        knockbackEnemies.ApplyProgress(progress);
    }
}
using UnityEngine;
public interface IScalableEnemy
{
    void ScaleStats(int playerLevel);
    float GetHealth();
    int GetDamage();
}

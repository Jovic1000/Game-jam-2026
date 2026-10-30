using UnityEngine;

[CreateAssetMenu(fileName = "NPCStats", menuName = "Scriptable Objects/NPCStats")]
public class NPCStats : ScriptableObject
{
    public float maxHealth = 1f;

    public float detectionRadius = 10f;

    public float runDistance = 20f;
    public float moveSpeed = 2f;


    public float soulsOnDeath = 1f;
}

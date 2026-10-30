using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private NPCStats _stats;
    [SerializeField] private GameObject _npcPrefab;

/*    public void SpawnNPCStats()
    {
        SpawnNPCStats(_stats);
    }

    public void SpawnNPCStats(NPCStats stats)
    {
        GameObject npc = Instantiate(_npcPrefab);
        // Init npc with stats
    }*/

    public void SpawnNPC(GameObject prefab)
    {
        GameObject npc = Instantiate(prefab);
    }

}

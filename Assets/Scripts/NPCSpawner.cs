using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private NPCStats _stats;
    [SerializeField] private GameObject _npcPrefab;

    public bool _spawnAtStart = true;

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
        npc.transform.position = transform.position;
    }

    private void Start()
    {
        if (_spawnAtStart) SpawnNPC(_npcPrefab);
    }
}

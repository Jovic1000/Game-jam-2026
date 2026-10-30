using UnityEngine;

public partial class ToiletController : MonoBehaviour
{
    [SerializeField] private int _souls;

    public void AddSoul()
    {
        _souls++;
    }
}

using UnityEngine;

public class HexCell : MonoBehaviour
{
    [SerializeField] private HexCoordinates coordinates = new HexCoordinates(0, 0);
    [SerializeField] private int t = 100;
    [SerializeField] private Vector3 t2 = Vector3.down;
}
using TMPro;
using UnityEngine;


public class HexGrid : MonoBehaviour
{
    [SerializeField] private int width = 6;
    [SerializeField] private int height = 6;

    [SerializeField] private HexCell cellPrefab;
    [SerializeField] private TMP_Text cellLabelPrefab;

    HexCell[] cells;
    Canvas gridCanvas;
    HexMesh hexMesh;

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();
        cells = new HexCell[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    private void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * HexMetrics.innerRadius * 2f;
        position.y = 0f;
        position.z = z * HexMetrics.outerRadius * 1.5f;

        HexCell cell = cells[i] = Instantiate(cellPrefab);
        cell.name = $"{x}-{z}";
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        // cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

        TMP_Text label = Instantiate(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        // label.text = cell.coordinates.ToStringOnSeparateLines();
    }
}

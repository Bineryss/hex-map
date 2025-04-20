using UnityEngine;
using UnityEngine.UIElements;
public class HexMapEditor : MonoBehaviour
{
    public Color[] colors;
    public HexGrid hexGrid;
    private Color activeColor;
    private IPanel panel;

    void Awake()
    {
        SelectColor(0);
        panel = GetComponent<UIDocument>().rootVisualElement.panel;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !IsPointerOverUI(Input.mousePosition))
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            hexGrid.ColorCell(hit.point, activeColor);
        }
    }
    private bool IsPointerOverUI(Vector2 mousePosition)
    {
        Vector2 screenPos = mousePosition;
        screenPos.y = Screen.height - screenPos.y; // Flip Y coordinate

        Vector2 panelPos = RuntimePanelUtils.ScreenToPanel(panel, screenPos);
        VisualElement pickedElement = panel.Pick(panelPos);

        // Only block if the element has PickingMode.Position
        return pickedElement != null && pickedElement.pickingMode == PickingMode.Position;
    }
    public void SelectColor(int index)
    {
        activeColor = colors[index];
    }
}
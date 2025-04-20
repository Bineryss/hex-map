using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EditorUI : MonoBehaviour
{
    public UnityEvent<int> onColorChange;

    private VisualElement root;
    void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("white").clicked += () => handleColorSelect(0);
        root.Q<Button>("red").clicked += () => handleColorSelect(1);
        root.Q<Button>("green").clicked += () => handleColorSelect(2);
        root.Q<Button>("blue").clicked += () => handleColorSelect(3);
    }

    private void handleColorSelect(int selection)
    {
        onColorChange?.Invoke(selection);
    }
}

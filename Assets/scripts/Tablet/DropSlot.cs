using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public string requiredTag = "PillPink";

    // Просто проверяем, есть ли уже дети у слота
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped == null) return;

        // Проверяем тег таблетки
        if (dropped.tag != requiredTag) return;

        // Проверяем, есть ли уже таблетка в этом слоте
        if (transform.childCount > 0)
        {
            return;
        }

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        if (draggableItem != null)
        {
            draggableItem.parentAfterDrag = transform;
        }
    }
}
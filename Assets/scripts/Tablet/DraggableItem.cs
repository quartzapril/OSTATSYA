using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private Image image;
    private Transform originalParent;
    private Vector3 originalPosition;

    private void Start()
    {
        image = GetComponent<Image>();
        originalParent = transform.parent;
        originalPosition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Запоминаем текущего родителя
        parentAfterDrag = transform.parent;

        // Поднимаем объект на верхний уровень Canvas
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        // Отключаем raycast, чтобы видеть слоты под объектом
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Двигаем объект за курсором
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Включаем raycast обратно
        image.raycastTarget = true;

        // Устанавливаем нового родителя (если слот изменился)
        transform.SetParent(parentAfterDrag);

        // Если родитель не изменился - возвращаем на место
        if (parentAfterDrag == originalParent)
        {
            transform.localPosition = originalPosition;
        }
        else
        {
            // Центрируем в новом слоте
            transform.localPosition = Vector3.zero;
        }
    }
}
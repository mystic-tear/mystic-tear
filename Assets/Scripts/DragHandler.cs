using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged; //itemBeingDragged

    Vector3 startPosition;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;

        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

//public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
//{
//    public static GameObject itemBeingDrag;
//    Vector3 startPosition;
//    Transform startParent;
//    bool start = true;

//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        itemBeingDrag = gameObject;
//        startPosition = transform.position;
//        startParent = transform.parent;
//        GetComponent<CanvasGroup>().blocksRaycasts = false;
//        GetComponent<LayoutElement>().ignoreLayout = true;
//        itemBeingDrag.transform.SetParent(transform.parent.parent.parent);
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        transform.position = Input.mousePosition;
//    }

//    public void OnEndDrag(PointerEventData eventData)
//    {
//        itemBeingDrag = null;
//        if (transform.parent == startParent || transform.parent == startParent.parent.parent)
//        {
//            transform.position = startPosition;
//            transform.SetParent(startParent);
//        }
//        GetComponent<CanvasGroup>().blocksRaycasts = true;
//        GetComponent<LayoutElement>().ignoreLayout = false;
//    }
//}


//public class DragHandler : MonoBehaviour
//{

//    private bool isDragging;

//    public void OnMouseDown()
//    {
//        isDragging = true;
//    }

//    public void OnMouseUp()
//    {
//        isDragging = false;
//    }

//    void Update()
//    {
//        if (isDragging)
//        {
//            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
//            transform.Translate(mousePosition);
//        }
//    }
//}
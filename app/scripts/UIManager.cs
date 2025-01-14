using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster _raycaster;
    private PointerEventData pData;
    private EventSystem eventSystem;

    public Transform selectionPoint; // the centre of the contents section 
    public static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

            }
            return instance;
        }

    }
    // Start is called before the first frame update
    // throws a ray , to find out wether or not a button is on the selection point or not
    void Start()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pData = new PointerEventData(eventSystem);
        pData.position = selectionPoint.position;
    }

    // Update is called once per frame
 
    // finds out if the button is selected or not
    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        _raycaster.Raycast(pData,results);
        foreach (RaycastResult result in results )
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}

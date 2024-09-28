using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public GameObject CrossHair;
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new();
    public bool isOpened;
    public float reachDistance = 3f;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        UIPanel.SetActive(true);

    }
    private void Start()
    {
        for (int i=0; i<InventoryPanel.childCount; i++)
        {
            if(InventoryPanel.GetChild(i).GetComponent<InventorySlot>() !=null)
            {
                slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIPanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            if (isOpened == true)
            {
                UIPanel.SetActive(true);
                CrossHair.SetActive(false);
            }
            else
            {
                UIPanel.SetActive(false);
                CrossHair.SetActive(true);
            }
        }

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
            Debug.DrawRay(ray.origin, ray.direction* reachDistance, Color.green);
            
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.red);
        }

    }
    private void AddItem(ItemScriptableObjects _item, int _amount)
    {
        foreach(InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                slot.itemAmountText.text = slot.amount.ToString();
                return;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == false)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }
}

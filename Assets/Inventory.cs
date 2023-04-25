using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> items = new List<Item>();
    public static bool inventoryIsOpen = false;
    public GameObject inventory;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    #region Singleton
    public static Inventory instance;

    void Awake() {
      if (instance != null) {
        Debug.LogWarning("More than one intance of Inventory found!");
        return;
      }
      instance = this;
    }
    #endregion

    void Update() {
      if (Input.GetKeyDown(KeyCode.I)) {
          if (inventoryIsOpen) {
              CloseInventory();
          } else {
              OpenInventory();
          }
      }
    }

    public bool Add (Item item) {
      if (!item.isDefaultItem) {
        if (items.Count >= space) {
          Debug.Log("Not enough space en el inventario.");
          return false;
        }
        items.Add(item);
        if (onItemChangedCallback != null) {
          onItemChangedCallback.Invoke();
        }
      }
      return true;
    }

    public void Remove (Item item) {
      items.Remove(item);
      if (onItemChangedCallback != null) {
        onItemChangedCallback.Invoke();
      }
    }

    public void OpenInventory() {
        inventory.SetActive(true);
        inventoryIsOpen = true;
    }

    public void CloseInventory() {
        inventory.SetActive(false);
        inventoryIsOpen = false;
    }

    void UpdateUI() {
        Debug.Log("PICKITEANDO ITEMS");
    }
}

using UnityEngine;

public class InventoryIU : MonoBehaviour {

  Inventory inventory;

  InventorySlot[] slots;

  public Transform itemsContainer;
  public GameObject inventoryIU;

  void Start() {
    inventory = Inventory.instance;
    inventory.onItemChangedCallback += UpdateUI;

    slots = itemsContainer.GetComponentsInChildren<InventorySlot>();
  }

  void Update () {
    if (Input.GetButtonDown("Inventory")) {
      inventoryIU.SetActive(!inventoryIU.activeSelf);
    }
  }

  void UpdateUI () {
    for (int i = 0; i < slots.Length; i++) {
      if (i < inventory.items.Count) {
        slots[i].AddItem(inventory.items[i]);
      } else {
        slots[i].ClearSlot();
      }
    }
  }
}

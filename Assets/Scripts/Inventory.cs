using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    // TODO: esta logica pasar a GAME MANAGER 
    // ahora esta en en canvas, este solo tiene q manejar la UI
    public List<Item> items = new List<Item>();

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
}

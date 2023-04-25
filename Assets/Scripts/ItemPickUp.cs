using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {
    public Item item;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
          PickUp();
        }
    }

    public void PickUp() {
        Debug.Log(item.name);
        bool wasPickUp = Inventory.instance.Add(item);

        if (wasPickUp ) {
            Destroy(gameObject);
        }
    }
}

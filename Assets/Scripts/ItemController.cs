using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

  int cnt = 0;
  string itemName = "cookie";

  void Start() {
  }

  void Update() {
  }

  public void GetItem(string itemName) {
    cnt++;
    GameObject.Find("GameManager").GetComponent<CanvasController>().OnItemPanel();
  }

  public void UseItem() {
    cnt--;
  }

}

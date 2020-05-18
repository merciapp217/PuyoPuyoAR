using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

  [SerializeField] GameObject GetItemPanel;

  void Start() {
    GetItemPanel.SetActive(false);
  }

  void Update() {
  }


  // TODO：汎用的なメソッドに作り直そう
  public void OnItemPanel() {
    GetItemPanel.SetActive(true);
  }

  public void RemoveItemPanel() {
    GetItemPanel.SetActive(false);
  }

}

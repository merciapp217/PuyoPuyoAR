using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour {
  
  public GameObject cookie;
  public GameObject smoke;

  GameObject itemController;
  Renderer smokeRnd;
  Color alpha = new Color(0, 0, 0, 0.05f);

  void Start() {
    itemController = GameObject.Find("GameManager");
    smokeRnd = smoke.GetComponent<Renderer>();
  }

  void Update() {
    cookie.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
    smoke.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
    smokeRnd.material.color -= alpha;

    StartCoroutine(DelayMethod(0.4f, () => {
      itemController.GetComponent<ItemController>().GetItem("cookie");
      Destroy(this.gameObject);
    }));

  }

  // 遅延処理
  private IEnumerator DelayMethod(float waitTime, Action action) {
    yield return new WaitForSeconds(waitTime);
    action();
  }
}

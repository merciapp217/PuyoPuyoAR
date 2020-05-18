using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuyoPuyoController : MonoBehaviour {
  
  public Material[] _material;
  public Texture cry_Texture, angry_Texture, smile_Texture;
  

  int cnt = 0;
  //float waitTime = 0;
  //string face = "smile";
  Camera ARcamera;
  Renderer m_Renderer;

  void Start() {
    transform.rotation = new Quaternion(0, 90, 0, 0);
    m_Renderer = transform.Find("Sphere").GetComponent<Renderer>();
    ARcamera = GameObject.FindGameObjectWithTag("ARCamera").GetComponent<Camera>();
  }

  void Update() {
    // あたいを見てっ！！
    this.transform.LookAt(ARcamera.transform);

    // TODO:連打時に実行されるよう修正する
    if (Input.GetMouseButtonDown(0)) {

      Vector3 pos = Input.mousePosition;
      Ray ray = ARcamera.ScreenPointToRay(pos);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, 100f)) {
        if (hit.collider.gameObject == this.gameObject) {
          cnt++;
        }
      }
    }

    // おこたん大爆発！！
    if (cnt > 5) {
      ChageFace("angry");
      StartCoroutine(DelayMethod(10.0f, () => {
        ChageFace("smile");
        cnt = 0;
      }));
    }

  }

  // angry:おこたん（赤）
  // smile:笑顔（青）
  // hangry:げっそり（緑）
  void ChageFace(string face) {
    if (face == "angry") {
      m_Renderer.material.SetTexture("_MainTex", angry_Texture);
      //this.GetComponent<Renderer>().sharedMaterial = _material[1];
    }
    if (face == "smile") {
      m_Renderer.material.SetTexture("_MainTex", smile_Texture);
      //this.GetComponent<Renderer>().sharedMaterial = _material[0];
    }
  }

  // 遅延処理
  private IEnumerator DelayMethod(float waitTime, Action action) {
    yield return new WaitForSeconds(waitTime);
    action();
  }
}

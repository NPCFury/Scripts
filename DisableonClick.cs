using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisableonClick : MonoBehaviour {

	 public Button button;
         public GameObject objectToDeactivate;
         
         void Start() {
            button.onClick.AddListener(delegate { DeactiveObject(objectToDeactivate); });
         }
         
         public void DeactiveObject(GameObject go) {
               go.SetActive(false);
         }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandler : MonoBehaviour, IDropHandler {

	private GameObject positionToTransform;

	void Update()
	{
		if (gameObject.name == "Slot1") {
			if (transform.GetChild (0).name == "02") {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot1 = true;
			} else {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot1 = false;
			}
		}

		if (gameObject.name == "Slot2") {
			if (transform.GetChild (0).name == "03") {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot2 = true;
			} else {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot2 = false;
			}

		}

		if (gameObject.name == "Slot3") {
			if (transform.GetChild (0).name == "01") {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot3 = true;
			} else {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot3 = false;
			}

		}

		if (gameObject.name == "Slot4") {
			if (transform.GetChild (0).name == "04") {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot4 = true;
			} else {
				GameObject.Find ("GameController").GetComponent<PZ1_GC> ().slot4 = false;
			}

		}
	}

	public GameObject symbol 
	{
		get {
			if(transform.childCount>0){
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if (symbol) {
			positionToTransform = this.transform.GetChild (0).gameObject;
			this.transform.GetChild (0).SetParent (UIElementsDragger.itemBeingDragged.transform.parent);
			UIElementsDragger.itemBeingDragged.transform.SetParent (this.transform);
			positionToTransform.transform.localPosition = new Vector2 (0, 0);
		}
	}
	#endregion
}

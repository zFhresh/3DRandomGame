using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HouseScript : MonoBehaviour
{
    TextMeshPro text;
    [SerializeField]string TMPtext;
    void Start()
    {
        text = this.gameObject.transform.GetChild(9).GetComponent<TextMeshPro>();
        text.text = TMPtext;
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            text.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            text.gameObject.SetActive(false);
        }
    }
}

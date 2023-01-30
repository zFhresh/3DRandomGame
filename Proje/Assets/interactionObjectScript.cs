using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class interactionObjectScript : MonoBehaviour
{
    [SerializeField] GameObject BottomText;
    [SerializeField] Camera FarmCam;
    [SerializeField] GameObject MainCam;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            BottomText.SetActive(true);
            BottomText.GetComponent<TextMeshProUGUI>().text = "Farm ile etkileşime girmek için 'F' tuşuna bas";
            isOver = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            BottomText.SetActive(false);
            isOver = false;
        }
    }
    void Start()
    {
        MainCam = Camera.main.gameObject;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    PlayerScript Player;
    bool isOpen = false;
    bool isOver = false;
    void Update()
    {
            if(!isOpen && Input.GetKeyDown(KeyCode.F) && isOver) {
                MainCam.SetActive(false);
                FarmCam.gameObject.SetActive(true);
                isOpen = true;
                Player.enabled = false;
                BottomText.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.F)) {
                MainCam.SetActive(true);
                FarmCam.gameObject.SetActive(false);
                isOpen = false;
                Player.enabled = true;
                BottomText.SetActive(true);
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool moving;
    private float startPosX;
    private float startPosY;
    private Vector2 resetPosition;
    string binTag;
    bool colliding;
    Vector2 collisionPos;
    int count;

    public GameObject player;
    bool clicked;
    public float speed;

    void Awake(){
        
    }
    void Start(){
        resetPosition = this.transform.position;
        binTag = "Bin";
        speed = GameObject.Find("GameStateManager").GetComponent<GameStateManager>().speed;
        Debug.Log(speed);
    }

    void Update(){
        if(clicked == false) {
            Vector3 distance = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y, 0);
            Vector3 direction = (distance*-1).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        if(moving){
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }

    }

    private void OnMouseDown(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("clicked");
            clicked = true;
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            
            moving = true;
        }
    }

    private void OnMouseUp(){
        moving = false;
        clicked = false;

        if(colliding == true){
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(binTag == collision.tag) {
            colliding = true;
        }
        if(collision.tag == "Player") {
            GameObject.Find("GameStateManager").GetComponent<GameStateManager>().HealthDown();
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(binTag == collision.tag) {
            colliding = false;
        }
    }
}
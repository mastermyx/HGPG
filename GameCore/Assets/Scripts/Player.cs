using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Transform[] PlayerPoints;


    private CharacterController controller;


    private float verticalVolicity;
    private float sideVolicity;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;
    private float deltaPower = 1.0f;

    private bool isPressed = false;

    static int powerBonus = 10;
    static float sideBonus = 3.0f;

    private bool isLeft = true; 

	private void Start()
	{
        controller = GetComponent<CharacterController>();
         
	}


	private void Update()
	{
        


        if (Input.GetMouseButtonDown(0))
        {

            verticalVolicity -= gravity * Time.deltaTime;
            if (isPressed == false){
                deltaPower = 1;
                isPressed = true;
            }

            Debug.Log("DOWN, delta:" + deltaPower);
             
        } else if (Input.GetMouseButtonUp(0)) {
            
            isLeft = !isLeft;
            verticalVolicity = jumpForce + deltaPower;
            Debug.Log("UP, delta:" + deltaPower);

            sideVolicity = isLeft ? sideBonus : -sideBonus; 
            isPressed = false;

        } else {
            verticalVolicity -= gravity * Time.deltaTime;
        }


        if (isPressed) {
            deltaPower += (powerBonus * Time.deltaTime);
        }






        Vector3 moveVector = new Vector3(sideVolicity, verticalVolicity, 0);


        moveVector.x = Input.GetAxis("Horizontal") * 5.0f + sideVolicity;

    

        moveVector.y = verticalVolicity;
        moveVector.z = Input.GetAxis("Vertical") * 5.0f;
        controller.Move(moveVector * Time.deltaTime);
	}
}



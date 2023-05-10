using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float rotationSpeed = 0.1f;
    public Vector3 newRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovementController playerMovementController = other.GetComponent<PlayerMovementController>();

            if (playerMovementController != null)
            {
                if(gameObject.tag == "Rotate Right" && PlayerMovementController.instance.currentDirection == "z") {
                    PlayerMovementController.instance.transform.Rotate(0,90,0);
                    PlayerMovementController.instance.currentDirection = "x";
                    playerMovementController.RotateCamera("right");


                }
                else if(gameObject.tag == "Rotate Right" &&  PlayerMovementController.instance.currentDirection == "x") {
                    PlayerMovementController.instance.transform.Rotate(0,90,0);
                    PlayerMovementController.instance.currentDirection = "z";
                    playerMovementController.RotateCamera("right");


                }
                else if(gameObject.tag == "Rotate Left" &&  PlayerMovementController.instance.currentDirection == "z") {
                    PlayerMovementController.instance.transform.Rotate(0,-90,0);
                    PlayerMovementController.instance.currentDirection = "x";
                    playerMovementController.RotateCamera("left");


                }
                else if(gameObject.tag == "Rotate Left" &&  PlayerMovementController.instance.currentDirection == "x") {
                    PlayerMovementController.instance.transform.Rotate(0,-90,0);
                    PlayerMovementController.instance.currentDirection = "z";
                    playerMovementController.RotateCamera("left");
                }
                else if(gameObject.tag == "Finish") {
                    PlayerMovementController.instance.FinishTheGame();
                }
            }
        }
    }
}

using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{    public void TurnCameraToMouse(float amount){
        transform.Rotate(CustomControls.GetRotationVector() * amount * Time.deltaTime);
    }
}

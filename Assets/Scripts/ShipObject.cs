using UnityEngine;

    // A class for linking camera to ship appearance
public class ShipObject : MonoBehaviour
{
    [SerializeField] CameraBehaviour shipCamera;
    [SerializeField] ShipBehaviour physicalShip;
    [SerializeField] private float shipMovementSpeed = 10;
    [SerializeField] private float shipTurningSpeed = 10;
    [SerializeField] private float cameraTurningSpeed = 10;

    private void Move(float amount){
        transform.Translate(physicalShip.GetShipCourse() * Time.deltaTime * shipMovementSpeed * amount);
    }

    void Update(){
        shipCamera.TurnCameraToMouse(cameraTurningSpeed);
        physicalShip.TurnTo(shipCamera.transform.rotation, shipTurningSpeed);
        Move(CustomControls.GetThrustValue() + 0.2f);
    }
}

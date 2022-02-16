using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public void TurnTo(Quaternion destination, float turningSpeed){
        transform.rotation = Quaternion.RotateTowards(transform.rotation, destination, turningSpeed * Time.deltaTime);
    }

    public Vector3 GetShipCourse(){
        return transform.rotation * Vector3.forward;
    }
}

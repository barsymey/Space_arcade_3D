using UnityEngine;

public class Joystick : MonoBehaviour
{
    public GameObject joystickHandle;
    private float joystickDistance = 200;

    //For Editor and PC builds
    /*
    public Vector2 JoystickYield()
    {
        Vector2 joystickPosition = Input.mousePosition - transform.position;
        if (Input.GetMouseButton(0))
        {
            float distance = origin.rect.width/2;
            if (joystickPosition.magnitude < distance)
            {
                joystickHandle.transform.position = Input.mousePosition;
                return joystickPosition/distance;
            }else if(joystickPosition.magnitude < distance*2){
                joystickHandle.transform.position = origin.anchoredPosition + joystickPosition.normalized*distance;
                return joystickPosition.normalized;
            }
        }
        joystickHandle.transform.position = gameObject.transform.position;
        return Vector2.zero;
    }*/

    public Vector2 JoystickYield(){
        if(Input.touchCount > 0){
            for(int i = 0; i<Input.touchCount; i++ ){
                Touch touch = Input.GetTouch(i);
                Vector2 joystickValue = GetJoystickValueByInputTouch(touch);
                if(joystickValue.magnitude < joystickDistance){
                    joystickHandle.transform.position = new Vector3(touch.position.x, touch.position.y, transform.position.z);
                    return joystickValue/joystickDistance;
                }else if(joystickValue.magnitude < joystickDistance*2){
                    joystickHandle.transform.position = new Vector3(joystickValue.normalized.x, joystickValue.normalized.y, 0f)*joystickDistance + transform.position;
                    return joystickValue.normalized;
                }
            }
        }
        joystickHandle.transform.position = transform.position;
        return Vector2.zero;
    }

    public Vector2 GetJoystickValueByInputTouch(Touch touch){
        Vector2 originPosition = new Vector2(transform.position.x, transform.position.y);
        return touch.position - originPosition;
    }
}

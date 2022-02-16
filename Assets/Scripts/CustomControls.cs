using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomControls : MonoBehaviour
{
    private static float xControlAxis;
    private static float yControlAxis;
    private static float zControlAxis;
    private static float thrustControlAxis;
    [SerializeField] private Joystick yawPitchJoystick;
    [SerializeField] private Joystick rollThrustJoystick;

    private void Control(){
        Vector2 yawPitchAmount = yawPitchJoystick.JoystickYield();
        xControlAxis = yawPitchAmount.x;
        yControlAxis = -yawPitchAmount.y;
        Vector2 rollThrustAmount = rollThrustJoystick.JoystickYield();
        zControlAxis = -rollThrustAmount.x;
        thrustControlAxis = rollThrustAmount.y;
    }



    public static Vector3 GetRotationVector(){
        return new Vector3(yControlAxis, xControlAxis, zControlAxis);
    }

    public static float GetThrustValue(){
        return thrustControlAxis;
    }

    void Update()
    {
        Control();
    }
}

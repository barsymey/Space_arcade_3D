using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    static HashSet<CustomPhysics> physicalObjects = new HashSet<CustomPhysics>();
    [SerializeField]private bool drawGizmo;
    [SerializeField]private float collisionRadius = 10;
    [SerializeField]private float drag = 10;
    private float speed;
    float Speed{
        get{
            return speed;
        }
        set{
            speed = value;
            if(speed < 0)speed = 0;
        }
    }
    private Vector3 direction;

    void Start(){
        physicalObjects.Add(this);
    }

    void OnDestroy(){
        physicalObjects.Remove(this);
    }

    void Update(){
        MoveWithAcceleration();
        InteractOtherPhysicalObjects();
    }

    private void InteractOtherPhysicalObjects(){
        foreach(CustomPhysics obj in physicalObjects){
            if(CheckCollision(obj.transform.position) && obj != this){
                Vector3 collisionVector = transform.position - obj.transform.position;
                BounceOff(collisionVector.normalized);
            } 
        }
    }

    private bool CheckCollision(Vector3 other){
        if(Vector3.Distance(transform.position, other) < collisionRadius) return true;
        else return false;
    }

    private void MoveWithAcceleration(){
        transform.Translate(direction * speed * Time.deltaTime);
        Speed -= drag * Time.deltaTime;
    }

    public void BounceOff(Vector3 bounceDirection){
        direction = bounceDirection;
        speed = 20;
    }

        void OnDrawGizmosSelected()
    {
        if(drawGizmo){
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, collisionRadius);
        }
    }


}

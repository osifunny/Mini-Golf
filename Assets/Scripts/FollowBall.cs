using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] float speed = 1;

    void Update(){
        if(this.transform.position != ball.Position){
            this.transform.position = Vector3.Lerp(
                this.transform.position, 
                ball.Position, 
                Time.deltaTime*speed);
            if(!ball.IsMoving && Vector3.Distance(transform.position, ball.Position) < 0.1f)
            transform.position = ball.Position;
        }
    }
}

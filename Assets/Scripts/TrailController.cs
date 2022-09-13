using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    TrailRenderer myTrail;
    EdgeCollider2D myCollider;

    void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();
        myCollider = this.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        for (int position = 0; position< trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }
    //void OnCollisionEnter(Collider collision)
  //  {
  //      //if(collision.gameObject.tag =="Enemy")
       // Destroy(gameObject);
   // }
}

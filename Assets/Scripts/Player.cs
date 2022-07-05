using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed=10f;

    private Vector2 rawInput;

    private Vector2 delta;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    [SerializeField] private float leftPadding;
    [SerializeField] private float rightPadding;
    [SerializeField] private float topPadding;
    [SerializeField] private float bottomPadding;

    Shooter shooter;

    private void Awake() 
    {
     shooter=GetComponent<Shooter>();   
    }
    
    
    private void Start() 
    {
        InitiliazeBounds();
    }
    void Update()
    {
        Move();
    }

    void InitiliazeBounds()
    {
        Camera mainCamera= Camera.main;
        minBounds=mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds=mainCamera.ViewportToWorldPoint(new Vector2(1,1));

    }

    private void Move()
    {
        delta = rawInput * movementSpeed * Time.deltaTime;
        
        Vector2 newPos=new Vector2();
        newPos.x=Mathf.Clamp(transform.position.x+delta.x,minBounds.x+leftPadding,maxBounds.x-rightPadding);
        newPos.y=Mathf.Clamp(transform.position.y+delta.y,minBounds.y+bottomPadding,maxBounds.y-topPadding);
        transform.position=newPos;

    }

    void OnMove(InputValue value)
    {
        rawInput= value.Get<Vector2>();
        
        
    }

    void OnFire(InputValue value)
    {
       if(shooter!=null)
       {
        shooter.isShooting=value.isPressed;
       }
        
    }




    




    
    
   
  







}

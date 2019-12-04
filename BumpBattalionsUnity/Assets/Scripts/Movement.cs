using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigbod;
    [SerializeField]
    private float baseSpeed = 5.0f;
    [SerializeField]
    private float HorizontalAxis = 0.0f;
    [SerializeField]
    private float verticalAxis = 0.0f;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //SetMovementAxisValues(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//temporary to test moving around the unit
        rigbod.velocity = new Vector2(0.0f, 0.0f);
        if (canMove)
        {
            if (PlayerCommander.instance.play || CompareTag("Cursor"))
            {
                rigbod.velocity = new Vector2(baseSpeed * HorizontalAxis, baseSpeed * verticalAxis);
            }
        }
    }

    //To be used by the player object
    public void SetMovementAxisValues(float horizontal, float vertical)
    {
        float moveVectorMagnitude = Mathf.Sqrt(horizontal*horizontal + vertical*vertical);

        HorizontalAxis = moveVectorMagnitude > 0 ? horizontal / moveVectorMagnitude : 0;
        verticalAxis = moveVectorMagnitude > 0 ? vertical / moveVectorMagnitude : 0;
    }

    public void setCanMove(bool newVal)
    {
        canMove = newVal;
    }
}

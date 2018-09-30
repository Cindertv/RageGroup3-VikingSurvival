using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 worldSpaceFacingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 direction = worldSpaceFacingDirection - transform.position;

        //Get the facing angle between the player and the mouse position
        float angle = -Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        

        transform.rotation = Quaternion.Euler(-90, 90 + angle, 0);
        float xMovement = x * movementSpeed * Time.deltaTime;
        float yMovement = y * movementSpeed * Time.deltaTime;

        //transform.Translate(new Vector3(xMovement, 0, yMovement), Space.World);
        transform.Translate(Vector3.down * y * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * movementSpeed * Time.deltaTime);
    }
}

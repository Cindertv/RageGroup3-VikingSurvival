using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.5f;
    public float speedMultiplier = 1;
    public float playerHeatlh { get; private set; }
    public Image uiPlayerHealth;
    Animator anim;
    
    // Use this for initialization
    void Start()
    {
        playerHeatlh = 100f;
        anim = GetComponentInChildren<Animator>();
        uiPlayerHealth.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedMultiplier = 5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedMultiplier = 1f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 worldSpaceFacingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 direction = worldSpaceFacingDirection - transform.position;

        
        float angle = -Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        

        transform.rotation = Quaternion.Euler(0, 90 + angle, 0);

        
        anim.SetFloat("Speed", y * movementSpeed * speedMultiplier);
        transform.Translate(Vector3.forward * y * movementSpeed * speedMultiplier * Time.deltaTime);
        transform.Translate(Vector3.right * x * movementSpeed * speedMultiplier * Time.deltaTime);

        if (playerHeatlh <= 0)
        {           
            print("PlayerDead");
        }

       

        
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = 5;
        }
        else
        {
            movementSpeed = 1;
        }
         
    }
    public void TakeDamage (float ammount)
    {

        playerHeatlh -= ammount;

        if (playerHeatlh <0)
        {
            print("Player is dead");
        }
        updateUI();

    }
    private void updateUI()
    {

        uiPlayerHealth.fillAmount = playerHeatlh / 100f;

    }
    public void AddHealth(float ammount)
    {

        playerHeatlh += ammount;
        updateUI();
    }

}

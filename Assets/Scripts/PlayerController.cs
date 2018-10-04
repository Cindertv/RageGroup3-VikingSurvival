using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.5f;
    public float speedMultiplier = 1;
    public float playerHeatlh { get; private set; }
    public Image uiPlayerHealth;
    Animator anim;

    private bool isAlive = true;


    void Start()
    {
        playerHeatlh = 100f;
        anim = GetComponentInChildren<Animator>();
        uiPlayerHealth.fillAmount = 1;
    }


    void Update()
    {
        if (isAlive)
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
            transform.Translate(new Vector3(x * movementSpeed * speedMultiplier * Time.deltaTime, 0, y * movementSpeed * speedMultiplier * Time.deltaTime), Space.World);
            //transform.Translate(Vector3.forward * y * movementSpeed * speedMultiplier * Time.deltaTime);
            //transform.Translate(Vector3.right * x * movementSpeed * speedMultiplier * Time.deltaTime);
        }





        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = 5;
        }
        else
        {
            movementSpeed = 1;
        }

    }
    public void TakeDamage(float ammount)
    {
        playerHeatlh -= ammount;

        if (playerHeatlh < 0 && isAlive)
        {
            isAlive = false;
            print("Player is dead");
            anim.SetTrigger("Death");
            return;
        }
        UpdateUI();

    }
    private void UpdateUI()
    {
        uiPlayerHealth.fillAmount = playerHeatlh / 100f;

    }
    public void AddHealth(float ammount)
    {
        if (isAlive)
        {
            playerHeatlh += ammount;
            UpdateUI();
        }
    }

}

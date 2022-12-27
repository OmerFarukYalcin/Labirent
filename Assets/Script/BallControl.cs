using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    [SerializeField] GameManager gManager;
    
    private Rigidbody rb;
    
    public GameObject finish;
    
    [SerializeField] Button levelButton;
    [SerializeField] Text timerText;
    public Text healtText;
    [SerializeField] Text caseText;

    public float velocity = 6f;
    
    public static float timeCounter = 60;
    public static int healt = 5;

    bool gameComplete;
    bool gameRunning = true;


    Vector3 movementVector;
    void Start()
    {
        UpdateTexts(healtText.gameObject.name);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            print("healt:"+healt);
            print("time:"+timeCounter);
        }
        GetComponent<BallCollision>().SendGameBool(out gameComplete, out gameRunning);
        if (gameRunning && !gameComplete)
        {
            timeCounter -= Time.deltaTime;
            UpdateTexts(timerText.gameObject.name);
        }
        else if (!gameComplete)
        {
            UpdateTexts(caseText.gameObject.name);
            levelButton.gameObject.SetActive(true);
            gManager.sendDefaultValue(out healt, out timeCounter);
        }

        if (timeCounter <0)
            gameRunning =false;
        
        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();

    }
    private void FixedUpdate()
    {
        if (gameRunning && !gameComplete) 
        {
            MovementInput();
            rb.AddForce(CalculateMovementVector(movementVector.z,movementVector.x,velocity));
        }
        else
        {
            StopVelocitiesOfBall();
        }
    }

    void MovementInput()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
    }

    void StopVelocitiesOfBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    Vector3 CalculateMovementVector (float _horizontal, float _vertical, float _moveSpeed)
    {
        float x = _horizontal * velocity;
        float z = _vertical * -velocity;

        return new Vector3(x, 0f, z);
    }

    public void UpdateTexts(string _name)
    {
        switch (_name)
        {
            case "timer":
                timerText.text = (int)timeCounter + "";
                break;
            case "healt":
                healtText.text = healt + "";
                break;
            case "case":
                caseText.text = "Oyun Tamamlanamadý.";
                break;
        }
    }

    
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    public float verticalLookLimit = 60f;
    public Transform cameraTransform;
    private Rigidbody playerRigidbody;
    private float rotationY = 0f;
    private bool isMoving = false;
    public Vector3 transformPlayer;
    public CameraManager cm;
    Rigidbody rb;
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
       rb = GetComponent<Rigidbody>();
    }
    /*
    private void Update()
    {
        if(!cm.sentado){
            // Rotação do personagem com o mouse
        float rotationX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0f, rotationX, 0f);

        // Rotação vertical da câmera com o mouse
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -verticalLookLimit, verticalLookLimit); // Limita a rotação vertical
        cameraTransform.localRotation = Quaternion.Euler(rotationY, transform.localEulerAngles.y, 0f);

        isMoving = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
         Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
    
        }else{
             Cursor.lockState = CursorLockMode.None; // Trava o cursor no centro da tela
        }
        
       
    }

    private void FixedUpdate()
{
     if(!cm.sentado){
    float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (!isMoving)
        {
            // Nenhuma entrada de movimento, interrompe a movimentação
            return;
        }

        Vector3 movement = (cameraTransform.forward * moveVertical + cameraTransform.right * moveHorizontal).normalized;
        movement.y = 0f; // Garante que o personagem não se mova verticalmente

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
       // rb.AddForce(movement * 10f);
        // Posicionamento da câmera
        transformPlayer = transform.position;
        cameraTransform.position =transform.position;
     }
    
}
*/
    private void OnColisionEnter(Collider other)
    {
        if (other.gameObject.tag == "a4") {
        Physics.IgnoreCollision(other.GetComponent<Collider>(),  this.gameObject.GetComponent<Collider>());
        }
    }

}
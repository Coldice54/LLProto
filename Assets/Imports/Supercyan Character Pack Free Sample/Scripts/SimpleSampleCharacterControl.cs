using System.Collections.Generic;
using UnityEngine;

public class SimpleSampleCharacterControl : MonoBehaviour
{
    private enum ControlMode
    {
        /// <summary>
        /// Up moves the character forward, left and right turn the character gradually and down moves the character backwards
        /// </summary>
        Tank,
        /// <summary>
        /// Character freely moves in the chosen direction from the perspective of the camera
        /// </summary>
        Direct
    }

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] public float m_jumpForce = 4;
    [SerializeField] public float m_jumpDownForce = 4;
    [SerializeField] private float m_moveForce = 10;
    [SerializeField] private bool m_moveWithForce = true;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Direct;

    [SerializeField] private AudioSource playerDyingSound;
    [SerializeField] private AudioClip[] jumpClips;
    [SerializeField] private AudioClip[] runClips;
    [SerializeField] private AudioClip[] landClips;
    [SerializeField] private AudioClip[] walkClips;
    private AudioSource audioSource;
    private AudioClip clip;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_jumpInput = false;

    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
        Cursor.visible = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void Update()
    {
        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            m_jumpInput = true;
        }
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        switch (m_controlMode)
        {
            case ControlMode.Direct:
                DirectUpdate();
                break;

            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }

        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;

        if (transform.position.y < -23.5f)
        {
            gameObject.SetActive(false);
            //when we find the particle effectsc:
            //particalSystem.gameObject.transform.position = transform.position;
            //particalSystem.gameObject.SetActive(true);
            playerDyingSound.Play();
            FindObjectOfType<GameManager>().Respawn();
        }
    }

    private void TankUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool walk = Input.GetKey(KeyCode.LeftShift);

        if (v < 0)
        {
            if (walk) { v *= m_backwardsWalkScale; }
            else { v *= m_backwardRunScale; }
        }
        else if (walk)
        {
            v *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        m_animator.SetFloat("MoveSpeed", m_currentV);

        JumpingAndLanding();
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= m_walkScale;
            h *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            if (m_moveWithForce == false)
            {
                transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            }
            else
            {
                Vector3 velocityChange = m_currentDirection * m_moveSpeed - m_rigidBody.velocity;

                velocityChange.y = 0;

                m_rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
            }
            //m_rigidBody.velocity = m_currentDirection * m_moveSpeed * Time.deltaTime;
            //if (!Input.anyKey){
            // m_rigidBody.velocity = Vector3.zero;}

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_isGrounded && m_rigidBody.velocity.y < 0)
        {
            m_rigidBody.AddForce(Vector3.down * m_jumpDownForce * 2);
        }
        else if (!m_isGrounded && m_rigidBody.velocity.y > 0)
        {
            m_rigidBody.AddForce(Vector3.down * m_jumpDownForce);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }
    private void StepRun()
    {
        clip = GetRandomRunClip();
        audioSource.PlayOneShot(clip);
    }
    private void StepWalk()
    {
        clip = GetRandomWalkClip();
        audioSource.PlayOneShot(clip);
    }
    private void Jump()
    {
        clip = GetRandomJumpClip();
        audioSource.PlayOneShot(clip);
    }
    private void Land()
    {
        clip = GetRandomLandClip();
        audioSource.PlayOneShot(clip);
    }
    private AudioClip GetRandomRunClip()
    {
        return runClips[UnityEngine.Random.Range(0, runClips.Length)];
    }
    private AudioClip GetRandomWalkClip()
    {
        return walkClips[UnityEngine.Random.Range(0, walkClips.Length)];
    }
    private AudioClip GetRandomJumpClip()
    {
        return jumpClips[UnityEngine.Random.Range(0, jumpClips.Length)];
    }
    private AudioClip GetRandomLandClip()
    {
        return landClips[UnityEngine.Random.Range(0, landClips.Length)];
    }
}

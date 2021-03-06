using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeChange2 : MonoBehaviour
{
    public enum Size
    {
        Small,
        Regular,
        Large
    }

    public Size playerSize = Size.Regular;
    [SerializeField] SimpleSampleCharacterControl charController;
    Vector3 initialScale;

    public float initialJumpForce;
    public float initialDownForce;
    public bool touchingSizePlatform;

    // Start is called before the first frame update
    public void Start()
    {
        initialScale = transform.localScale;
        initialJumpForce = charController.m_jumpForce;
        initialDownForce = charController.m_jumpDownForce;
        touchingSizePlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && touchingSizePlatform)
        {
            grow();
            updateSize();
        }
        if (Input.GetKeyDown("e") && touchingSizePlatform)
        {
            shrink();
            updateSize();
        }
    }

    void grow()
    {
        playerSize = playerSize switch
        {
            Size.Small => Size.Regular,
            Size.Regular => Size.Large,
            Size.Large => Size.Large,
            _ => Size.Regular,
        };
    }

    void shrink()
    {
        playerSize = playerSize switch
        {
            Size.Small => Size.Small,
            Size.Regular => Size.Small,
            Size.Large => Size.Regular,
            _ => Size.Regular,
        };
    }

    public void updateSize()
    {
        switch (playerSize)
        {
            case Size.Small:
                {
                    transform.localScale = initialScale / 2f;
                    charController.m_jumpForce = initialJumpForce - 10;
                    charController.m_jumpDownForce = initialDownForce - 12;
                    break;
                }
            case Size.Regular:
                {
                    transform.localScale = initialScale;
                    charController.m_jumpForce = initialJumpForce;
                    charController.m_jumpDownForce = initialDownForce;
                    break;
                }
            case Size.Large:
                {
                    transform.localScale = initialScale * 2f;
                    charController.m_jumpForce = initialJumpForce + 15;
                    charController.m_jumpDownForce = initialDownForce + 15;
                    break;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SizePlatform"))
        {
            touchingSizePlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SizePlatform"))
        {
            touchingSizePlatform = false;
        }
    }

    public void resetSize()
    {
        playerSize = Size.Regular;
        updateSize();
    }
}

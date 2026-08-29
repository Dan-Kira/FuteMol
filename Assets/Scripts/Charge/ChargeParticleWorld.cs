using System.Collections.Generic;
using UnityEngine;

public class ChargeParticleWorld : MonoBehaviour
{
    public static readonly List<ChargeParticleWorld> AllCharges = new List<ChargeParticleWorld>();

    [SerializeField] private float charge;
    public float Charge => charge;

    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable() => AllCharges.Add(this);
    private void OnDisable() => AllCharges.Remove(this);

    private void Update()
    {
        if (ChallengeManager.Instance.CurrentState != ChallengeManager.ChallengeStates.Formulando)
        {
            isDragging = false;
            return;
        }

        HandleInput();
    }

    private void HandleInput()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit.collider != null && hit.transform == transform)
            {
                isDragging = true;
                offset = transform.position - mouseWorldPos;
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            transform.position = mouseWorldPos + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            VerifyInputPlace();
        }
    }

    private void VerifyInputPlace()
    {
        Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
        
        bool isInsideArea = false;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("ChargeArea"))
            {
                isInsideArea = true;
                break;
            }
        }

        if (!isInsideArea)
        {
            ChargeBoxUI.Instance.ReturnChargeToBox(this.charge > 0);
            Destroy(gameObject);
        }
    }
}
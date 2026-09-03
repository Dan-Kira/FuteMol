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

    private Collider2D myCollider;
    private static bool isAnyDragging = false;

    private void Awake()
    {
        mainCamera = Camera.main;
        myCollider = GetComponent<Collider2D>();
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

        if (Input.GetMouseButtonDown(0) && !isAnyDragging)
        {
            Collider2D[] hits = Physics2D.OverlapPointAll(mouseWorldPos);
            foreach (var hit in hits)
            {
                if (hit == myCollider)
                {
                    isDragging = true;
                    isAnyDragging = true;
                    offset = transform.position - mouseWorldPos;
                    break;
                }
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            transform.position = mouseWorldPos + offset;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            isAnyDragging = false;
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
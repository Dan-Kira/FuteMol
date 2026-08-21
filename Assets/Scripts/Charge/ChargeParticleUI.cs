using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class ChargeParticleUI :
    MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    [SerializeField] private float charge;

    private GameObject worldPrefab;

    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Transform originalParent;
    private Vector3 originalPosition;

    public float Charge => charge;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialize(GameObject worldPrefab)
    {
        this.worldPrefab = worldPrefab;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.position;

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;

        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if (ChallengeManager.Instance.CurrentChallenge !=
            ChallengeManager.ChallengeStates.Formulando)
        {
            ReturnToBox();
            return;
        }

        Camera camera = Camera.main;

        if (camera == null)
        {
            ReturnToBox();
            return;
        }

        Vector3 worldPosition = camera.ScreenToWorldPoint(eventData.position);

        worldPosition.z = 0f;

        Collider2D hit = Physics2D.OverlapPoint(worldPosition);

        if (hit == null ||
            !hit.CompareTag("ChargeArea"))
        {
            ReturnToBox();
            return;
        }

        InstantiateWorldCharge(worldPosition);
    }

    private void InstantiateWorldCharge(Vector3 position)
    {
        if (worldPrefab == null)
        {

            ReturnToBox();
            return;
        }

        Instantiate(worldPrefab, position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void ReturnToBox()
    {
        transform.SetParent(originalParent);
        transform.position = originalPosition;
    }
}
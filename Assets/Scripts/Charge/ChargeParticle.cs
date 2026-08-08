using UnityEngine;
using UnityEngine.EventSystems;

public class ChargeParticle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform chargeBox;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public float charge;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        chargeBox = transform.parent;
        canvasGroup.blocksRaycasts = false;

        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        canvasGroup.alpha = 1f;

        GameObject dropArea = eventData.pointerEnter?.GetComponentInParent<GameObject>();
        if(dropArea == null)
        {
            ReturnToBox();

            return;
        }

        if (dropArea == chargeBox)
        {
            ReturnToBox();

            return;
        }

        SwapArea(dropArea);
    }

    public void ReturnToBox()
    {

    }

    public void SwapArea(GameObject targetArea)
    {
        gameObject.transform.position = targetArea.transform.position;
    }
}
//==============Read Me===========\\
/* É necessário fazer com que o sistema das partículas aqui avise o ChargeBoxUI que a quantia de partículas na "caixa"
 * diminuiu, para isso acredito que o ideal seria transformar o ChargeBoxUI em um Singleton, ou criar um singleton que 
 * irá gerenciar essas informações por conta própria, só repassando para o ChargeBoxUI e para o ChargeParticle
 */

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; // Importe o namespace do Text Mesh Pro

public class ButtonHoverEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [Header("Configura��es de Hover")]
    [SerializeField] private float hoverScale = 1.1f; // Escala do bot�o (10% maior)
    [SerializeField] private float hoverFontSize = 22f; // Tamanho da fonte
    [SerializeField] private Color hoverTextColor = Color.yellow; // Cor do texto
    [SerializeField] private float lerpSpeed = 8f; // Velocidade da anima��o

    private Vector3 originalScale;
    private TMP_Text buttonText; // Use TMP_Text para Text Mesh Pro
    private float originalFontSize;
    private Color originalTextColor;
    private bool isHovering;

    void Start() {
        originalScale = transform.localScale;
        buttonText = GetComponentInChildren<TMP_Text>(); // Busque o componente TMP_Text
        if (buttonText != null) {
            originalFontSize = buttonText.fontSize;
            originalTextColor = buttonText.color;
        }
        else {
            Debug.LogError("TextMeshPro Text component not found on children of " + gameObject.name);
            enabled = false; // Desativa o script se o componente TMP_Text n�o for encontrado
        }
    }

    void Update() {
        // Interpola��o suave para todos os efeitos
        float delta = lerpSpeed * Time.deltaTime;

        // Escala do bot�o
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            isHovering ? originalScale * hoverScale : originalScale,
            delta
        );

        // Tamanho e cor do texto (verifique se buttonText n�o � nulo)
        if (buttonText != null) {
            buttonText.fontSize = Mathf.Lerp(
                buttonText.fontSize,
                isHovering ? hoverFontSize : originalFontSize,
                delta
            );

            buttonText.color = Color.Lerp(
                buttonText.color,
                isHovering ? hoverTextColor : originalTextColor,
                delta
            );
        }
    }

    public void OnPointerEnter(PointerEventData eventData) => isHovering = true;
    public void OnPointerExit(PointerEventData eventData) => isHovering = false;
}
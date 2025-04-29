using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Configura��o B�sica")]
    public string customMessage;
    public Color newColor = Color.red;

    [Header("Configura��o de Anima��o")]
    public Animator objectAnimator; // Animator da bancada/m�quina
    public string objectAnimationTrigger = "Cut"; // Nome do trigger da bancada

    private MeshRenderer meshRenderer;
    private Color originalColor;
    private Animator playerAnimator; // Refer�ncia ao Animator do jogador

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            originalColor = meshRenderer.material.color;
        }
    }

    public string GetInteractionMessage()
    {
        return string.IsNullOrEmpty(customMessage) ? "Interagir com " + gameObject.name : customMessage;
    }

    public void SetPlayerAnimator(Animator animator)
    {
        playerAnimator = animator;
    }

    public void Interact()
    {
        // Mudan�a de cor (feedback visual)
        if (meshRenderer != null)
        {
            meshRenderer.material.color = (meshRenderer.material.color == originalColor) ? newColor : originalColor;
        }

        // Dispara anima��es
        if (objectAnimator != null)
        {
            objectAnimator.SetTrigger(objectAnimationTrigger);
        }

        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Cutting"); // Trigger da anima��o do player
        }

        Debug.Log($"Interagiu com {gameObject.name}");
    }
}
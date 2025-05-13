using UnityEngine;

public class OfficeWorker : MonoBehaviour
{
    public SpriteRenderer OfficeWorkerSpriteRenderer;
    private void KeepOnScreen()
    {
        OfficeWorkerSpriteRenderer.transform.position =
            SpriteTools.ConstrainSpriteToScreen(OfficeWorkerSpriteRenderer);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        // if move right
        if (direction.x > 0)
        {
            OfficeWorkerSpriteRenderer.flipX = false;
        }
        // if nove left
        else if (direction.x < 0)
        {
            OfficeWorkerSpriteRenderer.flipX = true;
        }
    }
}

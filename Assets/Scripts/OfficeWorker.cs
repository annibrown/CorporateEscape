using UnityEngine;

public class OfficeWorker : MonoBehaviour
{
    public SpriteRenderer officeWorkerSpriteRenderer;
    
    public void MoveManually(Vector2 direction)
    {
        Move(direction);
    }

    private void KeepOnScreen()
    {
        officeWorkerSpriteRenderer.transform.position =
            SpriteTools.ConstrainSpriteToScreen(officeWorkerSpriteRenderer);
    }

    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);

        float xAmount = GameParameters.OfficeWorkerMoveSpeed * direction.x * Time.deltaTime;
        float yAmount = GameParameters.OfficeWorkerMoveSpeed * direction.y * Time.deltaTime;

        Vector2 moveAmount = new Vector2(xAmount, yAmount);

        officeWorkerSpriteRenderer.transform.Translate(moveAmount);
        
        KeepOnScreen();
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            officeWorkerSpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            officeWorkerSpriteRenderer.flipX = true;
        }
    }
}
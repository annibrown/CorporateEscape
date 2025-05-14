using UnityEngine;

public class OfficeWorker : MonoBehaviour
{
    public SpriteRenderer OfficeWorkerSpriteRenderer;
    
    public void MoveManually(Vector2 direction)
    {
        //Move(direction);
        Move(direction);
    }
    
    private void KeepOnScreen()
    {
        OfficeWorkerSpriteRenderer.transform.position =
            SpriteTools.ConstrainSpriteToScreen(OfficeWorkerSpriteRenderer);
    }
    
    public void Move(Vector2 direction)
    {
        
        FaceCorrectDirection(direction);
        
        float xAmount = GameParameters.OfficeWorkerMoveSpeed * direction.x * Time.deltaTime;
        float yAmount = GameParameters.OfficeWorkerMoveSpeed * direction.y * Time.deltaTime;
        
        Vector2 moveAmount = new Vector2(xAmount, yAmount);
        
        OfficeWorkerSpriteRenderer.transform.Translate(moveAmount);

        KeepOnScreen();
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

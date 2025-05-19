using UnityEngine;

public class EmptyCoffeeCupPaddle : MonoBehaviour
{
    
    public UI UI;
    public void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("CoffeeDrop"))
        { 
            AddPointToScore();
            Destroy(other.gameObject);
        }
        
    }
    
    private void AddPointToScore()
    {
        ScoreKeeper.Add(1);
        UI.ShowScore();
        
    }
}

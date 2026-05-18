using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer1;
    //public static int count = 0;
    // Start is called before the first frame update
   void OnMouseDown()
    {
        //if (count==0){
           Debug.Log("detected arrow click");
           sceneManager.LoadNextLevel();
        //}
        //count++;
    }
}

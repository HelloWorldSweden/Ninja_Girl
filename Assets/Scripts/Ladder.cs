using UnityEngine;

public class Ladder : MonoBehaviour, IUseable
{
    private Player _pl;
    private PlayerSprite _plSprite;

    private void Start()
    {
        _pl = FindObjectOfType<Player>();
        _plSprite = FindObjectOfType<PlayerSprite>();
    }

    // ############################ Här Skriver ni Use method ####################### //
    public void Use()
    {
        


    }

    // ################################# ########################################## //

    // ######################## Här Skriver ni OnTriggerExit2D method ############# //
   


   
    // ###################################### ################################### //




    private void UseLadder(bool onLadder, int gravity, int layerWeight, int animSpeed)
    {
        //############# Här sätter ni OnLadder property lika med onLadder parameter. ##################
        

        //################################### ########################################### //
        _pl.myRigidBody.gravityScale = gravity;
        _plSprite.MyAnimator.SetLayerWeight(2, layerWeight);
        _plSprite.MyAnimator.speed = animSpeed;
    }


}

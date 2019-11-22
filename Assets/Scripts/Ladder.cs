using UnityEngine;

public class Ladder : MonoBehaviour, IUseable
{
    private Player _pl;
    private PlayerSprite _plSprite;
    private LadderMovement lMovement;

    private void Start()
    {
        _pl = FindObjectOfType<Player>();
        _plSprite = FindObjectOfType<PlayerSprite>();
        lMovement = FindObjectOfType<LadderMovement>();
    }

    // ############################ Här Skriver vi Use method ####################### //
    void Use()
    {



    }
    // ################################# ########################################## //

    private void OnTriggerExit2D(Collider2D collision)
    {
        // """""""""""""""""""""""""" HÄR SKRIVER VI EN IF SATS """""""""""""""""""""""""" //



        // ###################################### ################################### //
    }





    private void UseLadder(bool onLadder, int gravity, int layerWeight, int animSpeed)
    {
        //############# Här sätter ni OnLadder property lika med onLadder parameter. ##################



        //################################### ########################################### //
        _pl.myRigidBody.gravityScale = gravity;
        _plSprite.MyAnimator.SetLayerWeight(2, layerWeight);
        _plSprite.MyAnimator.speed = animSpeed;
    }

    void IUseable.Use()
    {
        throw new System.NotImplementedException();
    }
}

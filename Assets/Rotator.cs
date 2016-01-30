using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
    public enum Direction { left, right, none }  
    public Direction testRotateDirection = Direction.none;
    public float transitionTime = 1.0f;

	// Update is called once per frame
	public void Update () 
    {
        if (testRotateDirection != Direction.none)
        {
            transitioner.transitionDirectionTo(StateTransitioner.Direction.forward);
            testRotateDirection = Direction.none;
        }

        if (transitioner.CurrentDirection != StateTransitioner.Direction.stopped)
        {

        }
	}

    public void OnTriggerRotateLeft()
    {
        transitioner.transitionDirectionTo(StateTransitioner.Direction.forward);
    }

    public void OnTriggerRotateRight()
    {
        transitioner.transitionDirectionTo(StateTransitioner.Direction.backward);
    }

    private StateTransitioner.Direction mapDirections(Direction direction)
    {
        switch (direction)
        {
            case Direction.left:
                return StateTransitioner.Direction.forward;
            case Direction.right:
                return StateTransitioner.Direction.backward;
            default:
                return StateTransitioner.Direction.stopped;
        }
    }

    private Direction mapStateDirections(StateTransitioner.Direction direction)
    {
        switch (direction)
        {
            case StateTransitioner.Direction.forward:
                return Direction.left;
            case StateTransitioner.Direction.backward:
                return Direction.right;
            default:
                return Direction.none;
        }
    }

    private StateTransitioner transitioner = new StateTransitioner();
}

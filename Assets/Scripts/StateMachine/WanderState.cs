using System;

public class WanderState:BaseState
{
    private Ghost _ghost;
    public WanderState(Ghost ghost):base(ghost.gameObject)
    {
        _ghost = ghost;
    }

    public override Type Tick()
    {
        throw new NotImplementedException();
    }
}

public class PlayerStateFactory
{
    PlayerStateMachine _context;

    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBaseState Flying() 
    {
        return new PlayerFlyingState(_context, this);
    }

    public PlayerBaseState Landed() 
    {
        return new PlayerLandedState(_context, this);
    }

    public PlayerBaseState Hover() 
    {
        return new PlayerHoverState(_context, this);
    }
}

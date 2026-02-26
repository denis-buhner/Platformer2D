public class DeathState : BaseState
{
    public override void Tick()
    {
        gameObject.SetActive(false);
    }
}

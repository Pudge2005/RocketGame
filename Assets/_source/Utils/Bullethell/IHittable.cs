namespace Game
{
    public interface IHittable
    {
        System.Type TargetType { get; }


        void HitObjectTarget(object target);
    }
}

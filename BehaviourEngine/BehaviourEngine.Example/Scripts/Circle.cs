using OpenTK;

namespace BehaviourEngine.Example
{
    public class Circle : GameObject
    {
        public Circle(Vector2 position, float radius)
        {
            this.AddBehaviour(new CircleCollider2D(radius));
            this.AddBehaviour(new CircleCollider2DRenderer());

            this.AddBehaviour(new DraggableObject());
            this.AddBehaviour(new CircleScaler());

            this.AddBehaviour(new Sensor());

            GameObject.Spawn(this, position);
        }
    }
}

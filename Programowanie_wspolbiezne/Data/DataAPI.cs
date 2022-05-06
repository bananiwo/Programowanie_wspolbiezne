using System.Numerics;

namespace Data
{
    public abstract class DataAPI : DataBase

    {
        public abstract void move();
        public abstract void step(float interval);
        public abstract Vector2 getPosition();
        public abstract void setPosition(Vector2 newPos);
        public static DataAPI CreateObject(Vector2 startPos, Vector2 startSpeed, Vector2 owner)
        {
            return new Ball(startPos, startSpeed, owner);
        }
    }
}

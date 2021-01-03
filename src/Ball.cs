using System.Diagnostics;
using UninformedSearch.Task.Logic;

namespace UninformedSearch.Task
{
    [DebuggerDisplay("{DebugText,nq}")]
    public sealed class Ball
    {
        public Ball(int id, Color color)
        {
            Id = id;
            Color = color;
        }

        /// <summary>
        /// Returns ordinal number of a ball on board
        /// </summary>
        public int Id
        {
            get;
        }

        /// <summary>
        /// Returns color of a ball
        /// </summary>
        public Color Color
        {
            get;
        }

        /// <summary>
        /// Returns full name of a ball (color + identifier)
        /// </summary>
        public string Name
        {
            get => $"{Color:G}-{Id}";
        }

        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var other = (Ball) obj;

            return Id == other.Id && Color == other.Color;
        }

        public override int GetHashCode()
        {
            return HashUtil.GetHashCode(Id, Color);
        }

        /// <summary>
        /// Creates a clone object
        /// </summary>
        public Ball Clone()
        {
            return new Ball(Id, Color);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebugText
        {
            get
            {
                return $"{Color:G} #{Id}";
            }
        }
    }
}
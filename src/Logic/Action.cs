using System.Diagnostics;
using System.Text;

namespace UninformedSearch.Task.Logic
{
    [DebuggerDisplay("{DebugText,nq}")]
    public sealed class Action
    {
        /// <summary>
        /// A ball to move from source position to target position on board
        /// </summary>
        public Ball BallToRelocate { get; set; }

        /// <summary>
        /// Position of a ball on board before it's moved 
        /// </summary>
        public int SourcePosition { get; set; }

        /// <summary>
        /// Position of a ball on board after it's moved 
        /// </summary>
        public int TargetPosition { get; set; }

        /// <summary>
        /// Direction of where to relocate a ball within the board
        /// </summary>
        public MoveDirection Direction { get; set; }

        public string CommandText
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append($"Take a [{BallToRelocate.Name}] ball ")
                    .Append($"at slot {SourcePosition + 1} ")
                    .Append($"and put it {DirectionText(Direction)} ")
                    .Append($"into slot {TargetPosition + 1}");

                return sb.ToString();
            }
        }

        public override int GetHashCode()
        {
            return HashUtility.GetHashCode(BallToRelocate, SourcePosition, TargetPosition, Direction);
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

            var other = (Action) obj;

            return Equals(BallToRelocate, other.BallToRelocate) &&
                   SourcePosition == other.SourcePosition &&
                   TargetPosition == other.TargetPosition &&
                   Direction == other.Direction;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebugText
        {
            get
            {
                return CommandText;
            }
        }

        private static string DirectionText(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.ToLeft:
                    return "to the left";
                case MoveDirection.ToLeftWithJump:
                    return "to the left with a jump";
                case MoveDirection.ToRight:
                    return "to the right";
                case MoveDirection.ToRightWithJump:
                    return "to the right with a jump";

                default:
                    return string.Empty;
            }
        } 
    }
}
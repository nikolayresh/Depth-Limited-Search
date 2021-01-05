using System.Diagnostics;
using System.Text;

namespace UninformedSearch.Task.Logic
{
    [DebuggerDisplay("{DebugText,nq}")]
    public sealed class Action
    {
        /// <summary>
        /// A ball to move from source position to target position within the board
        /// </summary>
        public Ball BallToMove { get; set; }

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

        /// <summary>
        /// Returns textual description of this action
        /// </summary>
        public string CommandText
        {
            get
            {
                var sb = new StringBuilder();

                sb.Append($"Take a [{BallToMove.Name}] ball ")
                    .Append($"at slot {SourcePosition + 1} ")
                    .Append($"and put it {DirectionText(Direction)} ")
                    .Append($"into slot {TargetPosition + 1}");

                return sb.ToString();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var otherAction = (Action) obj;

            return Equals(BallToMove, otherAction.BallToMove) &&
                   SourcePosition == otherAction.SourcePosition &&
                   TargetPosition == otherAction.TargetPosition &&
                   Direction == otherAction.Direction;
        }

        public override int GetHashCode()
        {
            return HashUtility.GetHashCode(BallToMove, SourcePosition, TargetPosition, Direction);
        }

        private static string DirectionText(MoveDirection direction)
        {
            return direction switch
            {
                MoveDirection.ToLeft => "to the left",
                MoveDirection.ToLeftWithJump => "to the left with a jump",
                MoveDirection.ToRight => "to the right",
                MoveDirection.ToRightWithJump => "to the right with a jump",
                _ => string.Empty,
            };
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebugText
        {
            get
            {
                return CommandText;
            }
        }
    }
}
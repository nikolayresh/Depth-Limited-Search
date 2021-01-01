using System.Diagnostics;
using System.Text;

namespace UninformedSearch.Task
{
    [DebuggerDisplay("{DebugText,nq}")]
    public sealed class Slot
    {
        private Ball _ball;

        public Ball GetBall()
        {
            return _ball;
        }

        public void SetBall(Ball ball)
        {
            _ball = ball;
        }

        public bool IsEmpty()
        {
            return (_ball is null);
        }

        public void SetEmpty()
        {
            _ball = null;
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

            var other = obj as Slot;
            return Equals(_ball, other.GetBall());
        }

        public Slot Clone()
        {
            var slot = new Slot();

            if (_ball != null)
            {
                slot.SetBall(_ball.Clone());
            }

            return slot;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebugText
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("Ball: [");
                sb.Append(_ball != null ? _ball.ToString() : "empty");
                sb.Append("]");

                return sb.ToString();
            }
        }
    }
}
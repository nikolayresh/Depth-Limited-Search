using System;
using System.Diagnostics;
using System.Text;

namespace UninformedSearch.Task
{
    [DebuggerDisplay("{DebugText,nq}")]
    public sealed class Slot
    {
        private Ball _ball;

        /// <summary>
        /// Returns a ball located in this slot
        /// </summary>
        public Ball GetBall()
        {
            return _ball;
        }

        /// <summary>
        /// Takes out a ball from this slot and returns it
        /// </summary>
        public Ball PopBall()
        {
            var ret = _ball;

            if (ret != null)
            {
                _ball = null;
                return ret;
            }

            throw new InvalidOperationException(
                "Slot is empty. Cannot pop a ball");
        }

        /// <summary>
        /// Puts a ball into this slot
        /// </summary>
        public void SetBall(Ball ball)
        {
            _ball = ball;
        }

        /// <summary>
        /// Returns a boolean value whether this slot is empty
        /// </summary>
        public bool IsEmpty()
        {
            return _ball == null;
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

            var otherSlot = (Slot) obj;

            return Equals(GetBall(), otherSlot.GetBall());
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
                sb.Append(_ball != null ? _ball.ToString() : "<empty>");
                sb.Append("]");

                return sb.ToString();
            }
        }
    }
}
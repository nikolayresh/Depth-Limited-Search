namespace UninformedSearch.Task.Logic
{
    /// <summary>
    /// Type of movement
    /// </summary>
    public enum MoveDirection
    {
        /// <summary>
        /// Move a ball to the left
        /// </summary>
        ToLeft,

        /// <summary>
        /// Move a ball to the right
        /// </summary>
        ToRight,

        /// <summary>
        /// Move a ball to the left with a jump over neighbor ball
        /// </summary>
        ToLeftWithJump,

        /// <summary>
        /// Move a ball to the right with a jump over neighbor ball
        /// </summary>
        ToRightWithJump
    }
}
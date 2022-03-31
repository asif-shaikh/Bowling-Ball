namespace BowlingBall.Interfaces
{
    /// <summary>
    /// Indicates the game containing frames.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// The pins knocked by rolling the ball
        /// </summary>
        /// <param name="pins"></param>
        void Roll(int pins);

        /// <summary>
        /// Calculates the score for the game.
        /// </summary>
        /// <returns></returns>
        int GetScore();
    }
}

using BowlingBall.Types;
using System.Collections.Generic;

namespace BowlingBall.Interfaces
{
    /// <summary>
    /// Indiacate each frame
    /// </summary>
    public interface IFrame
    {
        /// <summary>
        /// Indicates whether the frame has more allowed rolls.
        /// </summary>
        bool IsRollAllowed { get; }

        /// <summary>
        /// Indicates the frame scoring type, based on player's rolls
        /// </summary>
        FrameScoreType FrameScoreType { get; }

        /// <summary>
        /// Gets the pins knocked in the frame
        /// </summary>
        List<int> GetPins();

        /// <summary>
        /// Stores the pins knocked by the roll
        /// </summary>
        /// <param name="pins">Number of pins knocked.</param>
        void KnockDownPins(int pins);
    }
}

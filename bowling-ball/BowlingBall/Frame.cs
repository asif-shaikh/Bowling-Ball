using BowlingBall.Interfaces;
using BowlingBall.Types;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    internal class Frame : IFrame
    {
        #region Fields and properties
        /// <summary>
        /// Knocked pins data.
        /// </summary>
        private readonly List<int> _knockedPins = new List<int>();

        /// <summary>
        /// The last frame can have extra roll; calculation differs based on last roll.
        /// </summary>
        private readonly bool _isLastFrame;

        private int _rollCount, Score;

        /// <summary>
        /// Indicates whether the frame has more allowed rolls.
        /// </summary>
        public bool IsRollAllowed => _rollCount == 0 ||
            (_rollCount == 1 && _knockedPins.First() < 10) ||
            (_rollCount == 2 && _isLastFrame);

        /// <summary>
        /// Indicates the frame scoring type, based on player's rolls
        /// </summary>
        public FrameScoreType FrameScoreType
        {
            get
            {
                if(_knockedPins.Take(2).Sum() == 10)
                {
                    if(_rollCount == 1)
                        return FrameScoreType.Strike;
                    else
                        return FrameScoreType.Spare;
                }

                return FrameScoreType.None;
            }
        }
        #endregion

        #region ctor
        /// <summary>
        /// Creates an instance for the new frame; also defines whether the frame is last or not.
        /// </summary>
        /// <param name="isLastFrame">
        /// Indicates whether the frame is last frame in the game
        /// </param>
        public Frame(bool isLastFrame = false)
        {
            _rollCount = 0;
            _isLastFrame = isLastFrame;
        }
        #endregion

        #region Interface Methods

        /// <summary>
        /// Stores the pins knocked by the roll
        /// </summary>
        /// <param name="pins">Number of pins knocked.</param>
        public void KnockDownPins(int pins)
        {
            if (pins > (10 - _knockedPins.Sum()) && !_isLastFrame)
                pins = 10 - _knockedPins.Sum();

            if (IsRollAllowed && _knockedPins.Count == _rollCount)
                _knockedPins.Add(pins);

            _rollCount += 1;
        }

        /// <summary>
        /// Gets the pins knocked in the frame
        /// </summary>
        public List<int> GetPins() { return _knockedPins; }
        #endregion

        #region Other methods
        /// <summary>
        /// Adds score after calculation for each frame
        /// Not exposed outside the game; and can be handled internally
        /// </summary>
        /// <param name="_score"></param>
        public void AddScore(int _score) { Score += _score; }

        /// <summary>
        /// Gives the score of current frame.
        /// Can be leveraged further if required.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetScore() { return Score; }
        #endregion
    }
}

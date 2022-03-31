using BowlingBall.Interfaces;
using BowlingBall.Types;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    /// <summary>
    /// The game
    /// </summary>
    public class Game : IGame
    {
        #region Fields and Properties
        private const int MaxFramesAllowed = 10;
        
        /// <summary>
        /// The frames
        /// </summary>
        private readonly List<IFrame> _frames;

        /// <summary>
        /// Indicates whether the game is over or not.
        /// </summary>
        private bool _isGameOver => MaxFramesAllowed == _frames.Count && !_frames.Last().IsRollAllowed;
        #endregion

        #region ctor
        public Game()
        {
            _frames = new List<IFrame>();
        }
        #endregion

        #region Interface Methods
        /// <summary>
        /// The pins knocked by rolling the ball
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            IFrame frame = GetFrame();

            // since the frame can be null in cases where rolls are over limit
            if (frame != null)
                frame.KnockDownPins(pins);
        }

        /// <summary>
        /// Calculates the score for the game.
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            if (_frames.Count < 10)
                return 0;

            return CalculateFrameScores();
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Abstraction for the frame to be managed.
        /// Can be leveraged later and move to another class.
        /// </summary>
        /// <returns></returns>
        private IFrame GetFrame()
        {
            if (_isGameOver)
                return null;
            else if (_frames.Any() && _frames.Last().IsRollAllowed)
                return _frames.Last();

            IFrame frame = new Frame(_frames.Count == MaxFramesAllowed - 1);
            _frames.Add(frame);

            return frame;
        }

        /// <summary>
        /// Iterates over the frames and calculates the score 
        /// for each frame and the overall game.
        /// </summary>
        /// <returns></returns>
        private int CalculateFrameScores()
        {
            int score = 0;

            for (int counter = 0; counter < _frames.Count; counter++)
            {
                var frame = _frames[counter];

                score = counter < MaxFramesAllowed - 1
                    ? score + frame.GetPins().Take(2).Sum()
                    : score + frame.GetPins().Sum();

                if (counter < MaxFramesAllowed - 1)
                {
                    if (frame.FrameScoreType == FrameScoreType.Spare)
                    {
                        score += _frames[counter + 1].GetPins().FirstOrDefault();
                    }
                    else if (frame.FrameScoreType == FrameScoreType.Strike)
                    {
                        var nextFrame = _frames[counter + 1];
                        score += nextFrame.GetPins().Take(2).Sum();

                        if (nextFrame.FrameScoreType == FrameScoreType.Strike)
                            score += _frames[counter + 2].GetPins().First();
                    }
                }

                ((Frame)frame).AddScore(score);
            }

            return score;
        }

        #endregion
    }
}

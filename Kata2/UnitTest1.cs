namespace Kata2
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, "Love")]
        [InlineData(1, "Fifteen")]
        [InlineData(2, "Thirty")]
        [InlineData(3, "Forty")]
        public void ConversionTest(int inputScore, string prettyScore)
        {

            var score = new Score();

            var actualScore = score.AsString(inputScore);

            Assert.Equal(prettyScore, actualScore);

        }

        [Theory]
        [InlineData(0, 2, "Love:Thirty")]
        [InlineData(0, 3, "Love:Forty")]
        [InlineData(1, 0, "Fifteen:Love")]
        [InlineData(2, 0, "Thirty:Love")]
        [InlineData(3, 0, "Forty:Love")]
        [InlineData(3, 3, "Deuce")]
        [InlineData(4,3, "Advantage P1")]
        [InlineData(3,4, "Advantage P2")]
        [InlineData(4,4, "Deuce")]
        [InlineData(10,10, "Deuce")]
        [InlineData(4,0, "P1 Wins")]
        [InlineData(0,4, "P2 Wins")]
        [InlineData(6,4, "P1 Wins")]
        [InlineData(3,1, "Forty:Fifteen")]
        [InlineData(1, 1, "Fifteen:Fifteen")]
        [InlineData(7, 6, "Advantage P1")]

        public void SetTest(int p1Score, int p2Score, string expectedScore)
        {

            var scoreboard = new Scoreboard();

            var actualScore = scoreboard.ScoreboardWriter(p1Score, p2Score);

            Assert.Equal(expectedScore, actualScore);

            //Dales Awesome refactor
            //Assert.Equal("Love:Fifteen", new Scoreboard().ScoreboardWriter("Love", "Fifteen"));

        }

        public class Scoreboard
        {
            public string ScoreboardWriter(int p1points, int p2points)
            {
                if (p1points >= 4 && p1points - p2points >= 2)
                    return "P1 Wins";

                if (p2points >= 4 && p2points - p1points >= 2)
                    return "P2 Wins";

                if (p1points >= 3 && p2points >= 3)
                {
                    if (p1points > p2points)
                        return "Advantage P1";
                    else if (p1points < p2points)
                        return "Advantage P2";

                    return "Deuce";
                }

                var p1PointsAsString = new Score().AsString(p1points);
                var p2PointsAsString = new Score().AsString(p2points);

                return p1PointsAsString + ":" + p2PointsAsString;
            }

        }
        public class Score
        {
            public string AsString(int points)
            {
                switch (points)
                {
                    case 0: return "Love";
                    case 1: return "Fifteen";
                    case 2: return "Thirty";
                    case 3: return "Forty";
                }
                return "L";
            }
        }
    }       
    
    
    
}

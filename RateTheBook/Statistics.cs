namespace RateTheBook
{
    public class Statistics
    {
        public double HighestRating;
        public double LowestRating;
        public int Count;
        public double RatingSum;
        //public double ReadingTimeSum;

        public Statistics()
        {
            HighestRating= double.MinValue;
            LowestRating= double.MaxValue;
            RatingSum = 0;
            //ReadingTimeSum = 0;
            Count = 0;
        }

        public double AverageRating
        {
            get
            {
                return RatingSum / Count;
            }
        }
        //public double AverageReadingTime
        //{
        //    get
        //    {
        //        return ReadingTimeSum / Count;
        //    }
        //}

        public void AddNewStatistics(double rate)
        {
            Count += 1;
            LowestRating = Math.Min(rate, LowestRating);
            HighestRating = Math.Max(rate, HighestRating);
            RatingSum += rate;
            //ReadingTimeSum += time;
        }

    }
}

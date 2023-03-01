namespace RateTheBook
{
    public class Statistics
    {
        public double HighestRating;
        public double LowestRating;
        public int Count;
        public double RatingSum;
        public bool WasAdded;

        public Statistics()
        {
            HighestRating= double.MinValue;
            LowestRating= double.MaxValue;
            RatingSum = 0;
            Count = 0;
            WasAdded= false;
        }

        public double AverageRating
        {
            get
            {
                return RatingSum / Count;
            }
        }

        public void AddNewStatistics(double rating)
        {
            Count += 1;
            LowestRating = Math.Min(rating, LowestRating);
            HighestRating = Math.Max(rating, HighestRating);
            RatingSum += rating;
            WasAdded= true;
        }

    }
}

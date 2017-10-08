using System;
namespace SchoolIn.API.EF
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string PostType { get; set; }
		public string Link { get; set; }
        public string Description { get; set; }
		
        public int NumberOfRate1 { get; set; }
        public int NumberOfRate2 { get; set; }
        public int NumberOfRate3 { get; set; }
        public int NumberOfRate4 { get; set; }
        public int NumberOfRate5 { get; set; }

		public int TotalOfRates
		{
			get
			{
				return NumberOfRate1 + NumberOfRate2 + NumberOfRate3 + NumberOfRate4 + NumberOfRate5;
			}
		}

        public int Rate
        {
            get 
            { 
                return TotalOfRates / 5; 
            }
        }

    }
}

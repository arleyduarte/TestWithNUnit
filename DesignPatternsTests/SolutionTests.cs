using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace DesignPatterns.Program.Tests
{
    [TestFixture()]
    public class SolutionTests
    {


        [Test()]
        public void GetBest()
        {
            var pnd = "4 94 8";
            var scores = "8 6 4 6";
            var result = Solution.GetBestCandidate(pnd, scores);

            Assert.AreEqual(1, result);

        }




        [Test()]
        public void FileCandidateTest()
        {
            int counter = 0;
            string line;
            var pnd = "";
            var scores = "";

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\zyghtadmin\Desktop\source-code-starter\TestNinja\DesignPatternsTests\Resource\t1.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);

                if (counter == 0)
                {
                    pnd = line;
                }

                if (counter == 1)
                {
                    scores = line;
                }
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  

            Assert.AreEqual(2, counter);


            Assert.AreEqual("30887 686881794 84", pnd);
            Assert.IsNotEmpty(scores);

            var result = Solution.GetBestCandidate(pnd, scores);

            Assert.AreEqual(5355, result);

        }



        [Test()]
        public void SelectCandidateTest()
        {
            int[] scores = {8, 6, 4, 6};
            var patience = 94;
            var losePatience = 8;

           var result =  Solution.SelectCandidate(scores, patience, losePatience);

           Assert.AreEqual(1, result);

        }


        [Test()]
        public void GetRatingsCandidateTest()
        {
            int[] scores = { 8, 6, 4, 6 };

            int[] ratings = { 752, 516, 312, 420 };


            var patience = 94;
            var losePatience = 8;

            var result = Solution.CalculateRatings(scores, patience, losePatience);

            Assert.AreEqual(ratings, result);

        }
    }


    public static class Solution
    {


        private static int nConstraint = (int) Math.Pow(10, 5);
        private static int pConstraint = (int)Math.Pow(10, 9);

        public static int GetBestCandidate(string pnd, string scores)
        {
            var values = pnd.Split(' ');
            int n = Convert.ToInt32(values[0]);
            int patience = Convert.ToInt32(values[1]);
            int lostPatience = Convert.ToInt32(values[2]);

            var tempScores = scores.Split(' ');

            int[] scoresV = new int[n];

            for (int i = 0; i < tempScores.Length; i++)
            {

                scoresV[i] = Convert.ToInt32(tempScores[i]);
            }


            if (scoresV.Length > nConstraint)
            {
                throw new  ArgumentOutOfRangeException("");
            }


            if (1 > lostPatience || lostPatience  > 100)
            {
                throw new ArgumentOutOfRangeException("lostPatience");
            }

            if (patience > nConstraint)
            {
                throw new ArgumentOutOfRangeException("patience");
            }

            return SelectCandidate(scoresV, patience, lostPatience);

        }


        public static int SelectCandidate(int[] scores,  int patience,  int losePatience)
        {

            int[] ratings = CalculateRatings(scores, patience, losePatience);

            var maxRating = 0;
            for (int i = 0; i < ratings.Length; i++)
            {

                if (maxRating < ratings[i])
                    maxRating = ratings[i];

            }


            for (int i = 0; i < ratings.Length; i++)
            {
                if (ratings[i] == maxRating)
                    return i+1;
            }


            return  0;
        }



        public static int[] CalculateRatings(int[] scores, int patience, int losePatience)
        {

            int[] ratings = new int[scores.Length];

            var currentPatience = patience;

            for (int i = 0; i < scores.Length; i++)
            {
                var score = scores[i];
                var rating = score * currentPatience;

                ratings[i] = rating;


                if (currentPatience > 0)
                {
                    currentPatience = currentPatience - losePatience;
                }




                if (i == 5928)
                {
                    
                    Console.WriteLine(rating);
                }

                if (i == 5355)
                {

                    Console.WriteLine(rating);
                }


            }



            return ratings;
        }
    }




}
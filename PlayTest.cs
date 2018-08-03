using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace CamanaBayPuzzle

{
    [TestClass]
    public class PlayTest
    {
        Home Home { get; set; }
        Utilities Utilities { get; set; }
        public PlayTest()
        {
            Home = new Home();
            Utilities = new Utilities();
        }

        [TestMethod]
        public void PlayGame()
        {



            Home.GoToPage();

            string test = Home.cell0.Text;
            Home.cell1.SendKeys(test);
            //Initialise the values for the puzzle
            List<string> grid = new List<string>();
            {
                grid.Add("");
                grid.Add("");
                grid.Add("");
                grid.Add("");
                grid.Add("");
                grid.Add("");
                grid.Add("7");
                grid.Add("");
                grid.Add("");
            }

            List<int> ColTotal = new List<int>();
            {
                ColTotal.Add(10);
                ColTotal.Add(9);
                ColTotal.Add(8);
            }


            List<int> RowTotal = new List<int>();
            {
                RowTotal.Add(13);
                RowTotal.Add(7);
                RowTotal.Add(3);
            }


            List<string> RsubTotal = new List<string>();
            {
                RsubTotal.Add("");
                RsubTotal.Add("");
                RsubTotal.Add("");
            }

            List<string> CsubTotal = new List<string>();
            {
                CsubTotal.Add("");
                CsubTotal.Add("");
                CsubTotal.Add("");
            }


            //Define groups of squares 'subsets' that must contain numbers 1 to 9

            List<int> sqr1 = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });


            //Fill in the blanks with initial values ("123456789")
            InitialiseSquares(grid);
            PrintTheGrid(grid, RsubTotal, CsubTotal);

            CalculateSubtotals(ColTotal,RowTotal, grid, CsubTotal, RsubTotal);
            PrintTheGrid(grid, RsubTotal, CsubTotal);

            FilterGrid(grid, sqr1);
            PrintTheGrid(grid, RsubTotal, CsubTotal);

           

           

           





        }//end main


        // Methods:---------------------

        private void PrintTheGrid(List<string> grid, List<string> RsubTotal, List<string> CsubTotal )
        {
            Home.driver.Navigate().Refresh();
            Home.cell0.SendKeys(grid[0]);
            Home.cell1.SendKeys(grid[1]);
            Home.cell2.SendKeys(grid[2]);

            Home.cell3.SendKeys(grid[3]);
            Home.cell4.SendKeys(grid[4]);
            Home.cell5.SendKeys(grid[5]);

            //cell 6 is already known
            Home.cell7.SendKeys(grid[7]);
            Home.cell8.SendKeys(grid[8]);

            Home.r0st.SendKeys(RsubTotal[0]);
            Home.r1st.SendKeys(RsubTotal[1]);
            Home.r2st.SendKeys(RsubTotal[2]);

            Home.c0st.SendKeys(CsubTotal[0]);
            Home.c1st.SendKeys(CsubTotal[1]);
            Home.c2st.SendKeys(CsubTotal[2]);


        }

        private void InitialiseSquares(List<string> grid)
        {
            for (int c = 0; c < 9; c++)
            {
                //Find all the blanks and fill them with strings
                if (grid[c] == "")
                {
                    grid[c] = "123456789";
                }

            }
        }


        private void FilterGrid(List<string> grid, List<int> sqr1)

        {
            foreach (int n in sqr1)
            {
                if (grid[n].Length > 1)
                {
                    foreach (int m in sqr1)
                    {
                        if (grid[m].Length == 1)
                        {
                            string knownnumber = grid[m];
                            string unknownnumber = grid[n];
                            int startpos = unknownnumber.IndexOf(knownnumber);

                            if (unknownnumber.Length > 1 && startpos > -1)
                            {
                                string newunknownnumber = unknownnumber.Remove(startpos, 1); //remove the known number from the '1234'
                                grid[n] = newunknownnumber;
                            }

                        }
                    }
                }

            }

        }


        private void CalculateSubtotals(List<int> ColTotal, List<int> RowTotal, List<string> grid, List<string> CsubTotal, List<string> RsubTotal)
        {
            //Column0
            for (int i = 0; i < 3; i++)
            {
                int r = 0;

                switch (ColTotal[i])
                {
                    case -6:
                        { grid[i + 6] = "1,2"; CsubTotal[i] = "-7,-8"; }
                        break;
                    case -5:
                        { grid[i + 6] = "1,2,3"; CsubTotal[i] = ",-6,-7,-8"; }
                        break;
                    case -4:
                        { grid[i + 6] = "1,2,3,4"; CsubTotal[i] = "-5,-6,-7,-8"; }
                        break;
                    case -3:
                        { grid[i + 6] = "1,2,3,4,5"; CsubTotal[i] = "-4,-5,-6,-7,-8"; }
                        break;
                    case -2:
                        { grid[i + 6] = "1,2,3,4,5,6"; CsubTotal[i] = "-3,-4,-5,-6,-7,-8"; }
                        break;
                    case -1:
                        { grid[i + 6] = "1,2,3,4,5,6,7"; CsubTotal[i] = "-2,-3,-4,-5,-6,-7,-8"; }
                        break;
                    case 0:
                        { grid[i + 6] = "1,2,3,4,5,6,7,8"; CsubTotal[i] = "-1,-2,-3,-4,-5,-6,-7,-8"; }
                        break;
                    case 1:
                        { grid[i + 6] = "2,3,4,5,6,7,8,9"; CsubTotal[i] = "-1,-2,-3,-4,-5,-6,-7,-8"; }
                        break;
                    case 2:
                        { grid[i + 6] = "1,3,4,5,6,7,8,9"; CsubTotal[i] = "1,-1,-2,-3,-4,-5,-6,-7"; }
                        break;
                    case 3:
                        { grid[i + 6] = "1,2,4,5,6,7,8,9"; CsubTotal[i] = "2,1,-1,-2,-3,-4,-5,-6"; }
                        break;
                    case 4:
                        { grid[i + 6] = "1,2,3,5,6,7,8,9"; CsubTotal[i] = "3,2,1,-1,-2,-3,-4,-5"; }
                        break;
                    case 5:
                        { grid[i + 6] = "1,2,3,4,6,7,8,9"; CsubTotal[i] = "4,3,2,1,-1,-2,-3,-4"; }
                        break;
                    case 6:
                        { grid[i + 6] = "1,2,3,4,5,7,8,9"; CsubTotal[i] = "5,4,3,2,1,-1,-2,-3"; }
                        break;
                    case 7:
                        { grid[i + 6] = "1,2,3,4,5,6,8,9"; CsubTotal[i] = "6,5,4,3,2,1,-1,-2"; }
                        break;
                    case 8:
                        { grid[i + 6] = "1,2,3,4,5,6,7,9"; CsubTotal[i] = "7,6,5,4,3,2,1,-1"; }
                        break;
                    case 9:
                        { grid[i + 6] = "1,2,3,4,5,6,7,8"; CsubTotal[i] = "8,7,6,5,4,3,2,1"; }
                        break;
                    case 10:
                        { grid[i + 6] = "2,3,4,5,6,7,8,9"; CsubTotal[i] = "8,7,6,5,4,3,2,1"; }
                        break;
                    case 11:
                        { grid[i + 6] = "3,4,5,6,7,8,9"; CsubTotal[i] = "8,7,6,5,4,3,2"; }
                        break;
                    case 12:
                        { grid[i + 6] = "4,5,6,7,8,9"; CsubTotal[i] = "8,7,6,5,4,3"; }
                        break;
                    case 13:
                        { grid[i + 6] = "5,6,7,8,9"; CsubTotal[i] = "8,7,6,5,4"; }
                        break;
                    case 14:
                        { grid[i + 6] = "6,7,8,9"; CsubTotal[i] = "8,7,6,5"; }
                        break;
                    case 15:
                        { grid[i + 6] = "7,8,9"; CsubTotal[i] = "8,7,6"; }
                        break;
                    case 16:
                        { grid[i + 6] = "8,9"; CsubTotal[i] = "8,7"; }
                        break;

                }//end switch

                switch (i)//required to set value of r to appropriate row 
                {
                    case 0: { r = 2; } break;
                    case 1: { r = 5; } break;
                    case 2: { r = 8; } break;
                }


                switch (RowTotal[i])
                {
                    case -6:
                        { grid[r] = "1,2"; RsubTotal[i] = "-7,-8"; }
                        break;
                    case -5:
                        { grid[r] = "1,2,3"; RsubTotal[i] = ",-6,-7,-8"; }
                        break;
                    case -4:
                        { grid[r] = "1,2,3,4"; RsubTotal[i] = "-5,-6,-7,-8"; }
                        break;
                    case -3:
                        { grid[r] = "1,2,3,4,5"; RsubTotal[i] = "-4,-5,-6,-7,-8"; }
                        break;
                    case -2:
                        { grid[r] = "1,2,3,4,5,6"; RsubTotal[i] = "-3,-4,-5,-6,-7,-8"; }
                        break;
                    case -1:
                        { grid[r] = "1,2,3,4,5,6,7"; RsubTotal[i] = "-2,-3,-4,-5,-6,-7,-8"; }
                        break;
                    case 0:
                        { grid[r] = "1,2,3,4,5,6,7,8"; RsubTotal[i] = "-1,-2,-3,-4,-5,-6,-7,-8"; }
                        break;
                    case 1:
                        { grid[r] = "2,3,4,5,6,7,8,9"; RsubTotal[i] = "-1,-2,-3,-4,-5,-6,-7,-8"; }
                        break;
                    case 2:
                        { grid[r] = "1,3,4,5,6,7,8,9"; RsubTotal[i] = "1,-1,-2,-3,-4,-5,-6,-7"; }
                        break;
                    case 3:
                        { grid[r] = "1,2,4,5,6,7,8,9"; RsubTotal[i] = "2,1,-1,-2,-3,-4,-5,-6"; }
                        break;
                    case 4:
                        { grid[r] = "1,2,3,5,6,7,8,9"; RsubTotal[i] = "3,2,1,-1,-2,-3,-4,-5"; }
                        break;
                    case 5:
                        { grid[r] = "1,2,3,4,6,7,8,9"; RsubTotal[i] = "4,3,2,1,-1,-2,-3,-4"; }
                        break;
                    case 6:
                        { grid[r] = "1,2,3,4,5,7,8,9"; RsubTotal[i] = "5,4,3,2,1,-1,-2,-3"; }
                        break;
                    case 7:
                        { grid[r] = "1,2,3,4,5,6,8,9"; RsubTotal[i] = "6,5,4,3,2,1,-1,-2"; }
                        break;
                    case 8:
                        { grid[r] = "1,2,3,4,5,6,7,9"; RsubTotal[i] = "7,6,5,4,3,2,1,-1"; }
                        break;
                    case 9:
                        { grid[r] = "1,2,3,4,5,6,7,8"; RsubTotal[i] = "8,7,6,5,4,3,2,1"; }
                        break;
                    case 10:
                        { grid[r] = "2,3,4,5,6,7,8,9"; RsubTotal[i] = "8,7,6,5,4,3,2,1"; }
                        break;
                    case 11:
                        { grid[r] = "3,4,5,6,7,8,9"; RsubTotal[i] = "8,7,6,5,4,3,2"; }
                        break;
                    case 12:
                        { grid[r] = "4,5,6,7,8,9"; RsubTotal[i] = "8,7,6,5,4,3"; }
                        break;
                    case 13:
                        { grid[r] = "5,6,7,8,9"; RsubTotal[i] = "8,7,6,5,4"; }
                        break;
                    case 14:
                        { grid[r] = "6,7,8,9"; RsubTotal[i] = "8,7,6,5"; }
                        break;
                    case 15:
                        { grid[r] = "7,8,9"; RsubTotal[i] = "8,7,6"; }
                        break;
                    case 16:
                        { grid[r] = "8,9"; RsubTotal[i] = "8,7"; }
                        break;

                }//end switch










            }// For loop...Next i


        }


    }


}



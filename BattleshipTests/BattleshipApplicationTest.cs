using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipApplication.GameboardInitilizer;
using BattleshipTests.HelperMethods;
using System;

namespace BattleshipTests
{
    [TestClass]
    public class BattleshipApplicationTest
    {
        HelperMethodsForTests hm = new HelperMethodsForTests();
        int placeCoordinatesX = 3;
        int placeCoordinatesY = 5;

        [TestMethod]
        public void TestGameboard()
        {
            Assert.AreEqual(new Gameboard(10).BoardSize, 10);
        }

        [TestMethod]
        public void TestCreateShips()
        {
            for (int i = 0; i < hm.Ships.Length; i++)
            {
                Assert.AreEqual(hm.Ships[i].ShipLength, hm.ShipLengths[i]);
            }

            hm.TestContext.WriteLine("Successfully created ships.");
        }


        [TestMethod]
        public void TestPlaceShipsWithin()
        {
            try
            {
                hm.P1.PlaceShip(1, 1, 5, true);
                hm.P1.PlaceShip(1, 1, 5, false);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                hm.TestContext.WriteLine("Failed to place ship within the borders.");
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestPlaceShipsOutside()
        {
            try
            {
                hm.P1.PlaceShip(placeCoordinatesX, placeCoordinatesY, 6, true);
            } catch (ArgumentOutOfRangeException ex)
            {
                hm.TestContext.WriteLine("Failed to throw the correct exeption.");
                Assert.Fail(ex.Message);
            }
            
        }

        
    }
}

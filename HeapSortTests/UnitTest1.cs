namespace HeapSortTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var arr = new int[] { -3, 134, 3, 2, 867, 4, 67456, -4567, 0 };
            var expected = new int[] { -4567, -3, 0, 2, 3, 4, 134, 867, 67456};

            //Act
            var result = HeapSort.HeapSort.Sort(arr);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
using OneElevenAPI.Repository;

namespace OneElevenAPITest
{
    public class MainTest
    {
        [Theory]
        [InlineData("are", "aer")]
        [InlineData("helloworld", "dehllloorw")]
        [InlineData("alice", "aceil")]
        [InlineData("Aeroplane", "Aaeelnopr")]
        [InlineData("Bananas", "aaaBnns")]
        [InlineData("ABab", "AaBb")]
        [InlineData("example", "aeelmpx")]
        [InlineData("pre-condition", "cdeiinnooprt")]
        [InlineData("z-a-b-u", "abuz")]
        public void Merge_TwoCharArraysFromString_ReturnSortedArray(string TestCase, string TestResult)
        {
            var mockMain = new Main();

            var testArr = TestCase.ToCharArray();
            var result = mockMain.sortString(testArr);

            Assert.Equal(TestResult.ToCharArray(), result);
        }
    }
}

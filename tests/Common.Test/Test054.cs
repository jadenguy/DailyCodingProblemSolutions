// Sudoku is a puzzle where you're given a partially-filled 9 by 9 grid with digits. The objective is to fill the grid with the constraint that every row, column, and box (3 by 3 subgrid) must contain all of the digits from 1 to 9.
// Implement an efficient sudoku solver.


using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test054
    {
        private const string fullSquare = "123456789";
        private const string partialSquare = "123456780";
        private const string invalidSquare = "111111111";
        private const string emptySquare = "000000000";
        private const string indexSquare = "012345678";
        private const string emptyBoard = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        private const string initialBoard = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
        private const string completeBoard = "483921657967345821251876493548132976729564138136798245372689514814253769695417382";
        private const string invalidBoard = "111111111111111111111111111111111111111111111111111111111111111111111111111111111";
        private const string indexHBoard = "012345678012345678012345678012345678012345678012345678012345678012345678012345678";
        private const string Grid01 = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
        private const string Grid02 = "200080300060070084030500209000105408000000000402706000301007040720040060004010003";
        private const string Grid03 = "000000907000420180000705026100904000050000040000507009920108000034059000507000000";
        private const string Grid04 = "030050040008010500460000012070502080000603000040109030250000098001020600080060020";
        private const string Grid05 = "020810740700003100090002805009040087400208003160030200302700060005600008076051090";
        private const string Grid06 = "100920000524010000000000070050008102000000000402700090060000000000030945000071006";
        private const string Grid07 = "043080250600000000000001094900004070000608000010200003820500000000000005034090710";
        private const string Grid08 = "480006902002008001900370060840010200003704100001060049020085007700900600609200018";
        private const string Grid09 = "000900002050123400030000160908000000070000090000000205091000050007439020400007000";
        private const string Grid10 = "001900003900700160030005007050000009004302600200000070600100030042007006500006800";
        private const string Grid11 = "000125400008400000420800000030000095060902010510000060000003049000007200001298000";
        private const string Grid12 = "062340750100005600570000040000094800400000006005830000030000091006400007059083260";
        private const string Grid13 = "300000000005009000200504000020000700160000058704310600000890100000067080000005437";
        private const string Grid14 = "630000000000500008005674000000020000003401020000000345000007004080300902947100080";
        private const string Grid15 = "000020040008035000000070602031046970200000000000501203049000730000000010800004000";
        private const string Grid16 = "361025900080960010400000057008000471000603000259000800740000005020018060005470329";
        private const string Grid17 = "050807020600010090702540006070020301504000908103080070900076205060090003080103040";
        private const string Grid18 = "080005000000003457000070809060400903007010500408007020901020000842300000000100080";
        private const string Grid19 = "003502900000040000106000305900251008070408030800763001308000104000020000005104800";
        private const string Grid20 = "000000000009805100051907420290401065000000000140508093026709580005103600000000000";
        private const string Grid21 = "020030090000907000900208005004806500607000208003102900800605007000309000030020050";
        private const string Grid22 = "005000006070009020000500107804150000000803000000092805907006000030400010200000600";
        private const string Grid23 = "040000050001943600009000300600050002103000506800020007005000200002436700030000040";
        private const string Grid24 = "004000000000030002390700080400009001209801307600200008010008053900040000000000800";
        private const string Grid25 = "360020089000361000000000000803000602400603007607000108000000000000418000970030014";
        private const string Grid26 = "500400060009000800640020000000001008208000501700500000000090084003000600060003002";
        private const string Grid27 = "007256400400000005010030060000508000008060200000107000030070090200000004006312700";
        private const string Grid28 = "000000000079050180800000007007306800450708096003502700700000005016030420000000000";
        private const string Grid29 = "030000080009000500007509200700105008020090030900402001004207100002000800070000090";
        private const string Grid30 = "200170603050000100000006079000040700000801000009050000310400000005000060906037002";
        private const string Grid31 = "000000080800701040040020030374000900000030000005000321010060050050802006080000000";
        private const string Grid32 = "000000085000210009960080100500800016000000000890006007009070052300054000480000000";
        private const string Grid33 = "608070502050608070002000300500090006040302050800050003005000200010704090409060701";
        private const string Grid34 = "050010040107000602000905000208030501040070020901080406000401000304000709020060010";
        private const string Grid35 = "053000790009753400100000002090080010000907000080030070500000003007641200061000940";
        private const string Grid36 = "006080300049070250000405000600317004007000800100826009000702000075040190003090600";
        private const string Grid37 = "005080700700204005320000084060105040008000500070803010450000091600508007003010600";
        private const string Grid38 = "000900800128006400070800060800430007500000009600079008090004010003600284001007000";
        private const string Grid39 = "000080000270000054095000810009806400020403060006905100017000620460000038000090000";
        private const string Grid40 = "000602000400050001085010620038206710000000000019407350026040530900020007000809000";
        private const string Grid41 = "000900002050123400030000160908000000070000090000000205091000050007439020400007000";
        private const string Grid42 = "380000000000400785009020300060090000800302009000040070001070500495006000000000092";
        private const string Grid43 = "000158000002060800030000040027030510000000000046080790050000080004070100000325000";
        private const string Grid44 = "010500200900001000002008030500030007008000500600080004040100700000700006003004050";
        private const string Grid45 = "080000040000469000400000007005904600070608030008502100900000005000781000060000010";
        private const string Grid46 = "904200007010000000000706500000800090020904060040002000001607000000000030300005702";
        private const string Grid47 = "000700800006000031040002000024070000010030080000060290000800070860000500002006000";
        private const string Grid48 = "001007090590080001030000080000005800050060020004100000080000030100020079020700400";
        private const string Grid49 = "000003017015009008060000000100007000009000200000500004000000020500600340340200000";
        private const string Grid50 = "300200000000107000706030500070009080900020004010800050009040301000702000000008006";
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(fullSquare, true)]
        [TestCase(partialSquare, true)]
        [TestCase(emptySquare, true)]
        [TestCase(invalidSquare, false)]
        public void Problem054IsSquareValid(string square, bool valid)
        {
            //-- Arrange
            var expected = valid;

            //-- Act
            bool actual = Solution054.ValidateSquare(square);

            // //-- Assert
            Assert.AreEqual(expected, actual, "square state validity wrong");
        }
        [Test]
        [TestCase(initialBoard, true)]
        [TestCase(completeBoard, true)]
        [TestCase(invalidBoard, false)]
        public void Problem054IsBoardValid(string board, bool valid)
        {
            //-- Arrange
            var expected = valid;

            //-- Act
            bool actual = Solution054.ValidateBoard(board);

            // //-- Assert
            Assert.AreEqual(expected, actual, "board state validity wrong");
        }
        [Test]
        [TestCase(initialBoard, false)]
        [TestCase(completeBoard, true)]
        [TestCase(invalidBoard, false)]
        public void Problem054IsBoardSolved(string board, bool valid)
        {
            //-- Arrange
            var expected = valid;

            //-- Act
            bool actual = Solution054.IsBoardSolved(board);

            // //-- Assert
            Assert.AreEqual(expected, actual, "board solve state wrong");
        }
        [Test]
        [TestCase(emptySquare, emptyBoard)]
        [TestCase(invalidSquare, invalidBoard)]
        public void Problem054BoardToDimensionsSimple(string square, string board)
        {
            //-- Arrange
            var expectedSquare = square;
            var expectedSquareCount = 27;

            //-- Act
            var actual = Solution054.BoardToSquares(board).ToArray();

            // //-- Assert
            Assert.AreEqual(expectedSquareCount, actual.Length, "wrong number of samples returned");
            if (expectedSquareCount == actual.Length)
            {
                for (int i = 0; i < expectedSquareCount; i++)
                {
                    Assert.AreEqual(expectedSquare, actual[i], "wrong squares");
                }
            }
        }
        [Test]
        public void WhoAreMyNeighborsThree()
        {
            //-- Arrange
            int wanted = 3;
            int[] expected = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 12, 13, 14, 21, 22, 23, 30, 39, 48, 57, 66, 75 };

            //-- Act
            var actual = Solution054.FindNeighbors(wanted).SelectMany(k => k).OrderBy(k => k).Distinct();

            //-- Assert
            Assert.AreEqual(expected, actual, "wrong neighbors");
        }
        [Test]
        public void Problem054BoardToDimensionsComplex()
        {
            //-- Arrange
            var expectedSquareCount = 27;
            var expectedHorizontal = indexSquare;
            string board = indexHBoard;

            //-- Act
            var actual = Solution054.BoardToSquares(board);

            // //-- Assert
            Assert.AreEqual(expectedSquareCount, actual.Length, "wrong number of samples returned");
            if (expectedSquareCount == actual.Length)
            {
                for (int i = 0; i < 9; i++)
                {
                    Assert.AreEqual(expectedHorizontal, actual[i], "row wrong");
                    var expectedVertical = new string(i.ToString()[0], 9);
                    Assert.AreEqual(expectedVertical, actual[i + 9], "column wrong");
                    var x = i % 3;
                    var z = 333 * x;
                    var expectedSquareSquare = (12 + z).ToString("000");
                    expectedSquareSquare += expectedSquareSquare + expectedSquareSquare;
                    Assert.AreEqual(expectedSquareSquare, actual[i + 18], "box wrong");
                }
            }
        }
        [Test]
        [TestCase(Grid01, true)]
        [TestCase(Grid02, true)]
        [TestCase(Grid03, true)]
        [TestCase(Grid04, true)]
        [TestCase(Grid05, true)]
        [TestCase(Grid06, true)]
        [TestCase(Grid07, true)]
        [TestCase(Grid08, true)]
        [TestCase(Grid09, true)]
        [TestCase(Grid10, true)]
        [TestCase(Grid11, true)]
        [TestCase(Grid12, true)]
        [TestCase(Grid13, true)]
        [TestCase(Grid14, true)]
        [TestCase(Grid15, true)]
        [TestCase(Grid16, true)]
        [TestCase(Grid17, true)]
        [TestCase(Grid18, true)]
        [TestCase(Grid19, true)]
        [TestCase(Grid20, true)]
        [TestCase(Grid21, true)]
        [TestCase(Grid22, true)]
        [TestCase(Grid23, true)]
        [TestCase(Grid24, true)]
        [TestCase(Grid25, true)]
        [TestCase(Grid26, true)]
        [TestCase(Grid27, true)]
        [TestCase(Grid28, true)]
        [TestCase(Grid29, true)]
        [TestCase(Grid30, true)]
        [TestCase(Grid31, true)]
        [TestCase(Grid32, true)]
        [TestCase(Grid33, true)]
        [TestCase(Grid34, true)]
        [TestCase(Grid35, true)]
        [TestCase(Grid36, true)]
        [TestCase(Grid37, true)]
        [TestCase(Grid38, true)]
        [TestCase(Grid39, true)]
        [TestCase(Grid40, true)]
        [TestCase(Grid41, true)]
        [TestCase(Grid42, true)]
        [TestCase(Grid43, true)]
        [TestCase(Grid44, true)]
        [TestCase(Grid45, true)]
        [TestCase(Grid46, true)]
        [TestCase(Grid47, true)]
        [TestCase(Grid48, true)]
        [TestCase(Grid49, true)]
        [TestCase(Grid50, true)]
        public void Problem054Solve(string board, bool result)
        {
            //-- Arrange
            bool expected = result;

            //-- Act
            var solutions = Solution054.Solve(board);
            string solution = solutions.First();
            var actual = Solution054.IsBoardSolved(solution);

            //-- Assert
            Assert.AreEqual(expected, actual, "something went wrong");
        }
    }
}
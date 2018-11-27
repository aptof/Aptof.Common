using Aptof.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aptof.Common.Test.UtilityTest
{
    public class RupeesTest
    {
        private IRupees GetSut(decimal initialValue)
        {
            return new Rupees(initialValue);
        }

        [Theory]
        [InlineData(0, "Zero")]
        [InlineData(1, "One")]
        [InlineData(2, "Two")]
        [InlineData(3, "Three")]
        [InlineData(4, "Four")]
        [InlineData(5, "Five")]
        [InlineData(6, "Six")]
        [InlineData(7, "Seven")]
        [InlineData(8, "Eight")]
        [InlineData(9, "Nine")]
        [InlineData(10, "Ten")]
        [InlineData(11, "Eleven")]
        [InlineData(12, "Twelve")]
        [InlineData(13, "Thirteen")]
        [InlineData(14, "Fourteen")]
        [InlineData(15, "Fifteen")]
        [InlineData(16, "Sixteen")]
        [InlineData(17, "Seventeen")]
        [InlineData(18, "Eighteen")]
        [InlineData(19, "Nineteen")]
        [InlineData(20, "Twenty")]
        [InlineData(30, "Thirty")]
        [InlineData(40, "Fourty")]
        [InlineData(50, "Fifty")]
        [InlineData(60, "Sixty")]
        [InlineData(70, "Seventy")]
        [InlineData(80, "Eighty")]
        [InlineData(90, "Ninety")]
        [InlineData(91, "Ninety One")]
        [InlineData(85, "Eighty Five")]
        [InlineData(100, "One Hundred")]
        [InlineData(110, "One Hundred Ten")]
        [InlineData(201, "Two Hundred One")]
        [InlineData(350, "Three Hundred Fifty")]
        [InlineData(413, "Four Hundred Thirteen")]
        [InlineData(996, "Nine Hundred Ninety Six")]
        [InlineData(1000, "One Thousand")]
        [InlineData(2001, "Two Thousand One")]
        [InlineData(5010, "Five Thousand Ten")]
        [InlineData(6019, "Six Thousand Nineteen")]
        [InlineData(8500, "Eight Thousand Five Hundred")]
        [InlineData(8510, "Eight Thousand Five Hundred Ten")]
        [InlineData(8518, "Eight Thousand Five Hundred Eighteen")]
        [InlineData(9999, "Nine Thousand Nine Hundred Ninety Nine")]
        [InlineData(10000, "Ten Thousand")]
        [InlineData(12001, "Twelve Thousand One")]
        [InlineData(25010, "Twenty Five Thousand Ten")]
        [InlineData(36019, "Thirty Six Thousand Nineteen")]
        [InlineData(58500, "Fifty Eight Thousand Five Hundred")]
        [InlineData(68510, "Sixty Eight Thousand Five Hundred Ten")]
        [InlineData(78518, "Seventy Eight Thousand Five Hundred Eighteen")]
        [InlineData(99999, "Ninety Nine Thousand Nine Hundred Ninety Nine")]
        [InlineData(112001, "One Lakh Twelve Thousand One")]
        [InlineData(325010, "Three Lakh Twenty Five Thousand Ten")]
        [InlineData(1112001, "Eleven Lakh Twelve Thousand One")]
        [InlineData(5325010, "Fifty Three Lakh Twenty Five Thousand Ten")]
        [InlineData(11112001, "One Crore Eleven Lakh Twelve Thousand One")]
        [InlineData(85325010, "Eight Crore Fifty Three Lakh Twenty Five Thousand Ten")]
        [InlineData(111112001, "Eleven Crore Eleven Lakh Twelve Thousand One")]
        [InlineData(585325010, "Fifty Eight Crore Fifty Three Lakh Twenty Five Thousand Ten")]
        [InlineData(1111112001, "One Hundred Eleven Crore Eleven Lakh Twelve Thousand One")]
        [InlineData(6585325010, "Six Hundred Fifty Eight Crore Fifty Three Lakh Twenty Five Thousand Ten")]
        [InlineData(26585325010, "Two Thousand Six Hundred Fifty Eight Crore Fifty Three Lakh Twenty Five Thousand Ten")]
        [InlineData(12.01, "Twelve and One Paisa")]
        [InlineData(12.10, "Twelve and Ten Paisa")]
        [InlineData(27.00, "Twenty Seven")]
        public void InWord_r_correct_value(decimal value, string expected)
        {
            var sut = GetSut(value);
            expected = "Rupees " + expected + " Only";
            Assert.Equal(expected, sut.InWord());
        }
    }
}

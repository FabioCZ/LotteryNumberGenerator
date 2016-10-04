using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumberGenerator
{
  public class LotteryTicketConstraint
  {
    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }
    public int NumberCount { get; private set; }

    public LotteryTicketConstraint(int minVal, int maxVal, int numCount)
    {
      MinValue = minVal;
      MaxValue = maxVal;
      NumberCount = numCount;
      if(minVal >= maxVal) throw new ArgumentException("The minimum value should be smaller than the maximum value");
      if(numCount > maxVal - minVal) throw new ArgumentException("The count of lottery number should be smaller than the difference between min and max value");
    }
  }
}

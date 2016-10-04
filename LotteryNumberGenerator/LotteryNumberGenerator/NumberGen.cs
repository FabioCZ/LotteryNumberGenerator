using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumberGenerator
{
  class NumberGen
  {
    private Random random;
    public LotteryTicketConstraint TicketConstraint { get; private set; }
    public List<int> SelectedNumbers { get; private set; }

    public NumberGen(LotteryTicketConstraint constraint)
    {
      TicketConstraint = constraint;
      random = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
    }

    public List<int> Generate()
    {
      SelectedNumbers = new List<int>();
      foreach (var i in Enumerable.Range(0, TicketConstraint.NumberCount))
      {
        var next = GetNextNum();
        while (SelectedNumbers.Contains(next))
        {
          next = GetNextNum();
        }
        SelectedNumbers.Add(next);
      }
      return SelectedNumbers;
    }

    private int GetNextNum() => random.Next(TicketConstraint.MinValue, TicketConstraint.MaxValue);
  }
}

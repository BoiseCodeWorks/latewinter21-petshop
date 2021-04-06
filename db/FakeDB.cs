using System.Collections.Generic;
using latewin21_petshop.Models;

namespace latewin21_petshop.db
{
  public class FakeDB
  {

    //NOTE make sure you instantiate your list before you try to access it.
    public static List<Cat> Cats { get; set; } = new List<Cat>();
  }
}
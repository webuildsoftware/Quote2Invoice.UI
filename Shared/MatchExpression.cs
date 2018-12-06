using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quote2Invoice.UI.Shared
{
  public class MatchExpression
  {
    public List<Regex> Regexes { get; set; }

    public Action<Match, object> Action { get; set; }
  }
}

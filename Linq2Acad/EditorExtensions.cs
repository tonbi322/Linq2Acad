﻿using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2Acad
{
  public static class EditorExtensions
  {
    public static void WriteLine(this Editor editor, string formatString, params object[] args)
    {
      editor.WriteMessage(string.Format("\n" + formatString, args));
    }

    public static PromptResult GetString(this Editor editor, string message, Func<string, bool> validate)
    {
      PromptResult result = null;

      while(true)
      {
        result = editor.GetString(message);

        if (result.Status != PromptStatus.OK ||
            result.Status == PromptStatus.OK && validate(result.StringResult))
        {
          break;
        }
      }

      return result;
    }
  }
}
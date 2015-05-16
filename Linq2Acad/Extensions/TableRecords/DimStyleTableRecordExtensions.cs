﻿using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2Acad
{
  public static class DimStyleTableRecordExtensions
  {
    public static bool IsValidName(this IEnumerable<DimStyleTableRecord> source, string name, bool allowVerticalBar)
    {
      return TableHelpers.IsValidName(name, allowVerticalBar);
    }

    public static DimStyleTableRecord GetItem(this IEnumerable<DimStyleTableRecord> source, string name)
    {
      return TableHelpers.GetItem<DimStyleTableRecord, DimStyleTable>(source, dst => dst[name]);
    }

    public static bool Contains(this IEnumerable<DimStyleTableRecord> source, string name)
    {
      return TableHelpers.Contains<DimStyleTableRecord, DimStyleTable>(source, dst => dst.Has(name));
    }

    public static bool Contains(this IEnumerable<DimStyleTableRecord> source, ObjectId id)
    {
      return TableHelpers.Contains<DimStyleTableRecord, DimStyleTable>(source, dst => dst.Has(id));
    }

    public static ObjectId Add(this IEnumerable<DimStyleTableRecord> source, DimStyleTableRecord item)
    {
      return TableHelpers.Add<DimStyleTableRecord, DimStyleTable>(source, item);
    }

    public static IEnumerable<ObjectId> Add(this IEnumerable<DimStyleTableRecord> source, IEnumerable<DimStyleTableRecord> items)
    {
      return TableHelpers.AddRange<DimStyleTableRecord, DimStyleTable>(source, items);
    }
  }
}
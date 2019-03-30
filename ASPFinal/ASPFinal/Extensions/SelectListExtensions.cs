using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPFinal.Models;
using System.Web.Mvc;

namespace ASPFinal.Extensions
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> ToDropdown<T>(this IEnumerable<T> innerList) where T : class
        {
            #region Yield return
            foreach (var item in innerList)
            {
                yield return new SelectListItem
                {
                    Value = typeof(T).GetProperty("Id").GetValue(item).ToString(),
                    Text = typeof(T).GetProperty("Name").GetValue(item).ToString()
                };
            }
            #endregion
        }

    }
}
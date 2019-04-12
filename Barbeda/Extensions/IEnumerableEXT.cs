using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barbeda.Extensions
{
    public static class IEnumerableEXT
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> InputList, string Values,string Texts) where  T : class
        {
            //List<SelectListItem> result = null;


            //foreach (var item in InputList)
            //{
            //    SelectListItem selectListItem = new SelectListItem
            //    {
            //        Value = typeof(T).GetProperty(Values)?.GetValue(item).ToString(), //item.GetType().GetProperty(Values).GetValue(item).ToString(),
            //        Text = typeof(T).GetProperty(Texts)? .GetValue(item).ToString()//item.GetType().GetProperty(Texts).GetValue(item).ToString()
            //    };
            //    result.Add(selectListItem);
            //}
            //return result;

            //YIELD RETURN DAHA QISA YAZ 
            foreach (var item in InputList)
            {
                yield return new SelectListItem
                {
                    Value = typeof(T).GetProperty(Values)?.GetValue(item).ToString(), //item.GetType().GetProperty(Values).GetValue(item).ToString(),
                    Text = typeof(T).GetProperty(Texts)?.GetValue(item).ToString()//item.GetType().GetProperty(Texts).GetValue(item).ToString()
                };

            }

        }
    }
}
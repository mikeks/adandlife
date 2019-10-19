using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;


namespace AdAndLifeWebsite.Classes
{
	public static class Extensions
	{

		public static string GetEnumDescription(Enum value) 
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute),
				false);

			if (attributes != null &&
				attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}

		public static string GetDescription<TEnum>(this TEnum EnumValue) where TEnum : struct
		{
			return GetEnumDescription((Enum)(object)EnumValue);
		}

		public static string[] GetEnumDescriptions<T>() where T : struct
		{
			Array values = Enum.GetValues(typeof(T));
			string[] s = new string[values.Length];
			int i = 0;
			foreach (var v in values)
			{
				s[i++] = GetEnumDescription((Enum)v);
			}
			return s;
		}


	}
}
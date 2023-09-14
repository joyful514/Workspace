namespace ProHelper
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Xml;

    public class Sql
    {
        public static string EscapeJavaScript(string str)
        {
            str = str.Replace(@"\", @"\\");
            str = str.Replace("'", @"\'");
            str = str.Replace("\"", "\\\"");
            str = str.Replace("\t", @"\t");
            str = str.Replace("\r", @"\r");
            str = str.Replace("\n", @"\n");
            return str;
        }

        public static string EscapeSQL(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }

        public static string EscapeSQLLike(string str)
        {
            str = str.Replace(@"\", @"\\");
            str = str.Replace("%", @"\%");
            str = str.Replace("_", @"\_");
            return str;
        }

        public static string FormatParamVal(object val)
        {
            string str;
            if ((val == null) || (val == DBNull.Value))
            {
                str = "NULL";
            }
            else
            {
                Type type = val.GetType();
                if (type == typeof(string))
                {
                    str = $"N'{val.ToString().Replace("'", "''")}'";
                }
                else if ((type == typeof(DateTime)) || (type == typeof(Guid)))
                {
                    str = $"'{val}'";
                }
                else if (!(type == typeof(TimeSpan)))
                {
                    str = !(type == typeof(bool)) ? (!type.IsEnum ? (!type.IsValueType ? $"'{val.ToString().Replace("'", "''")}'" : val.ToString()) : Convert.ToInt32(val).ToString()) : (((bool) val) ? "1" : "0");
                }
                else
                {
                    DateTime time = new DateTime(0x79d, 10, 1);
                    str = $"(CAST('{time + ((TimeSpan) val)}' AS datetime) - CAST('{time}' AS datetime))";
                }
            }
            return str;
        }

        public static string HexEncode(byte[] aby)
        {
            string str = "0123456789abcdef";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < aby.Length; i++)
            {
                builder.Append(str[(aby[i] & 240) >> 4]);
                builder.Append(str[aby[i] & 15]);
            }
            return builder.ToString();
        }

        public static bool IsEmptyGuid(Guid g) => 
            g == Guid.Empty;

        public static bool IsEmptyGuid(object obj)
        {
            bool flag;
            if ((obj == null) || (obj == DBNull.Value))
            {
                flag = true;
            }
            else
            {
                string s = obj.ToString();
                flag = (s == string.Empty) || (XmlConvert.ToGuid(s) == Guid.Empty);
            }
            return flag;
        }

        public static bool IsEmptyString(object obj) => 
            ((obj == null) || (obj == DBNull.Value)) || (obj.ToString() == string.Empty);

        public static bool IsEmptyString(string str) => 
            (str == null) || (str == string.Empty);

        public static byte[] ToBinary(object obj) => 
            ((obj != null) && (obj != DBNull.Value)) ? ((byte[]) obj) : new byte[0];

        public static bool ToBoolean(bool b) => 
            b;

        public static bool ToBoolean(int n) => 
            n != 0;

        public static bool ToBoolean(object obj)
        {
            bool flag;
            if ((obj == null) || (obj == DBNull.Value))
            {
                flag = false;
            }
            else if (obj.GetType() == Type.GetType("System.Int32"))
            {
                flag = Convert.ToInt32(obj) != 0;
            }
            else if (obj.GetType() == Type.GetType("System.Byte"))
            {
                flag = Convert.ToByte(obj) != 0;
            }
            else if (obj.GetType() == Type.GetType("System.SByte"))
            {
                flag = Convert.ToSByte(obj) != 0;
            }
            else if (obj.GetType() == Type.GetType("System.Int16"))
            {
                flag = Convert.ToInt16(obj) != 0;
            }
            else if (obj.GetType() == Type.GetType("System.Decimal"))
            {
                flag = Convert.ToDecimal(obj) != 0M;
            }
            else if (!(obj.GetType() == Type.GetType("System.String")))
            {
                flag = !(obj.GetType() != Type.GetType("System.Boolean")) ? bool.Parse(obj.ToString()) : false;
            }
            else
            {
                string str = obj.ToString().ToLower();
                flag = ((str == "true") || (str == "on")) || (str == "1");
            }
            return flag;
        }

        public static byte[] ToByteArray(Array arrBYTES)
        {
            byte[] destination = null;
            int length = (arrBYTES == null) ? 0 : arrBYTES.Length;
            destination = new byte[length];
            if (length > 0)
            {
                GCHandle handle = GCHandle.Alloc(arrBYTES, GCHandleType.Pinned);
                Marshal.Copy(handle.AddrOfPinnedObject(), destination, 0, length);
                handle.Free();
            }
            return destination;
        }

        public static string ToDateString(DateTime dt) => 
            !(dt == DateTime.MinValue) ? dt.ToShortDateString() : string.Empty;

        public static DateTime ToDateTime(DateTime dt) => 
            dt;

        public static object ToDBBinary(object obj) => 
            ((obj != null) && (obj != DBNull.Value)) ? obj : DBNull.Value;

        public static object ToDBBinary(byte[] aby) => 
            (aby != null) ? ((aby.Length != 0) ? ((object) aby) : ((object) DBNull.Value)) : ((object) DBNull.Value);

        public static object ToDBBoolean(bool b) => 
            b ? 1 : 0;

        public static object ToDBBoolean(object obj)
        {
            object obj2;
            if ((obj == null) || (obj == DBNull.Value))
            {
                obj2 = DBNull.Value;
            }
            else if (!(obj.GetType() != Type.GetType("System.Boolean")))
            {
                obj2 = Convert.ToBoolean(obj) ? 1 : 0;
            }
            else
            {
                string str = obj.ToString().ToLower();
                obj2 = ((str == "true") || ((str == "on") || (str == "1"))) ? 1 : 0;
            }
            return obj2;
        }

        public static object ToDBDateTime(DateTime dt) => 
            !(dt == DateTime.MinValue) ? ((object) dt) : ((object) DBNull.Value);

        public static object ToDBDecimal(decimal d) => 
            d;

        public static object ToDBFloat(float f) => 
            f;

        public static object ToDBGuid(Guid g) => 
            !(g == Guid.Empty) ? ((object) g) : ((object) DBNull.Value);

        public static object ToDBGuid(object obj)
        {
            object obj2;
            if ((obj == null) || (obj == DBNull.Value))
            {
                obj2 = DBNull.Value;
            }
            else if (obj.GetType() == Type.GetType("System.Guid"))
            {
                obj2 = obj;
            }
            else
            {
                string s = obj.ToString();
                if (s == string.Empty)
                {
                    obj2 = DBNull.Value;
                }
                else
                {
                    Guid guid = XmlConvert.ToGuid(s);
                    obj2 = !(guid == Guid.Empty) ? ((object) guid) : ((object) DBNull.Value);
                }
            }
            return obj2;
        }

        public static object ToDBInteger(int n) => 
            n;

        public static object ToDBString(object obj)
        {
            object obj2;
            if ((obj == null) || (obj == DBNull.Value))
            {
                obj2 = DBNull.Value;
            }
            else
            {
                string str = obj.ToString();
                obj2 = (str != string.Empty) ? ((object) str) : ((object) DBNull.Value);
            }
            return obj2;
        }

        public static object ToDBString(string str) => 
            !ReferenceEquals(str, null) ? ((str != string.Empty) ? ((object) str) : ((object) DBNull.Value)) : ((object) DBNull.Value);

        public static decimal ToDecimal(decimal d) => 
            d;

        public static decimal ToDecimal(double d) => 
            Convert.ToDecimal(d);

        public static decimal ToDecimal(object obj)
        {
            decimal num;
            if ((obj == null) || (obj == DBNull.Value))
            {
                num = 0M;
            }
            else if (obj.GetType() == Type.GetType("System.Decimal"))
            {
                num = Convert.ToDecimal(obj);
            }
            else
            {
                string s = obj.ToString();
                num = (s != string.Empty) ? decimal.Parse(s, NumberStyles.Any) : 0M;
            }
            return num;
        }

        public static decimal ToDecimal(float f) => 
            Convert.ToDecimal(f);

        public static double ToDouble(double d) => 
            d;

        public static float ToFloat(float f) => 
            f;

        public static Guid ToGuid(Guid g) => 
            g;

        public static Guid ToGuid(object obj)
        {
            Guid empty;
            if ((obj == null) || (obj == DBNull.Value))
            {
                empty = Guid.Empty;
            }
            else if (obj.GetType() == Type.GetType("System.Guid"))
            {
                empty = (Guid) obj;
            }
            else
            {
                string s = obj.ToString();
                empty = (s != string.Empty) ? XmlConvert.ToGuid(s) : Guid.Empty;
            }
            return empty;
        }

        public static int ToInteger(int n) => 
            n;

        public static int ToInteger(object obj)
        {
            int num;
            if ((obj == null) || (obj == DBNull.Value))
            {
                num = 0;
            }
            else if (obj.GetType() == Type.GetType("System.Int32"))
            {
                num = Convert.ToInt32(obj);
            }
            else if (obj.GetType() == Type.GetType("System.Boolean"))
            {
                num = Convert.ToBoolean(obj) ? 1 : 0;
            }
            else if (obj.GetType() == Type.GetType("System.Single"))
            {
                num = Convert.ToInt32(Math.Floor((double) ((float) obj)));
            }
            else
            {
                string s = obj.ToString();
                num = (s != string.Empty) ? int.Parse(s, NumberStyles.Any) : 0;
            }
            return num;
        }

        public static long ToLong(long n) => 
            n;

        public static long ToLong(object obj)
        {
            long num;
            if ((obj == null) || (obj == DBNull.Value))
            {
                num = 0L;
            }
            else if (obj.GetType() == Type.GetType("System.Int64"))
            {
                num = Convert.ToInt64(obj);
            }
            else
            {
                string s = obj.ToString();
                num = (s != string.Empty) ? long.Parse(s, NumberStyles.Any) : 0L;
            }
            return num;
        }

        public static short ToShort(short n) => 
            n;

        public static short ToShort(int n) => 
            (short) n;

        public static short ToShort(object obj)
        {
            short num;
            if ((obj == null) || (obj == DBNull.Value))
            {
                num = 0;
            }
            else if ((obj.GetType() == Type.GetType("System.Int32")) || (obj.GetType() == Type.GetType("System.Int16")))
            {
                num = Convert.ToInt16(obj);
            }
            else
            {
                string s = obj.ToString();
                num = (s != string.Empty) ? short.Parse(s, NumberStyles.Any) : (short)0;
            }
            return num;
        }

        public static string ToString(DateTime dt) => 
            !(dt == DateTime.MinValue) ? dt.ToString() : string.Empty;

        public static string ToString(object obj) => 
            ((obj != null) && (obj != DBNull.Value)) ? obj.ToString() : string.Empty;

        public static string ToString(string str) => 
            !ReferenceEquals(str, null) ? str : string.Empty;

        public static string ToTimeString(DateTime dt) => 
            !(dt == DateTime.MinValue) ? dt.ToShortTimeString() : string.Empty;
    }
}


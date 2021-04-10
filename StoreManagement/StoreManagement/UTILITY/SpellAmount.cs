using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.UTILITY
{
    static class SpellAmount
    {
        public static string comma(decimal amount)
        {
            string str2 = "";
            string str3 = "";
            str2 = amount.ToString();
            int index = amount.ToString().IndexOf(".", 0);
            str3 = amount.ToString().Substring(index + 1);
            if (str2 == str3)
            {
                str3 = "";
            }
            else
            {
                str2 = amount.ToString().Substring(0, amount.ToString().IndexOf(".", 0)).Replace(",", "").ToString();
            }
            switch (str2.Length)
            {
                case 4:
                    if (!(str3 == ""))
                    {
                        return (str2.Substring(0, 1) + "," + str2.Substring(1, 3) + "." + str3);
                    }
                    return (str2.Substring(0, 1) + "," + str2.Substring(1, 3));

                case 5:
                    if (!(str3 == ""))
                    {
                        return (str2.Substring(0, 2) + "," + str2.Substring(2, 3) + "." + str3);
                    }
                    return (str2.Substring(0, 2) + "," + str2.Substring(2, 3));

                case 6:
                    if (!(str3 == ""))
                    {
                        return (str2.Substring(0, 1) + "," + str2.Substring(1, 2) + "," + str2.Substring(3, 3) + "." + str3);
                    }
                    return (str2.Substring(0, 1) + "," + str2.Substring(1, 2) + "," + str2.Substring(3, 3));

                case 7:
                    if (!(str3 == ""))
                    {
                        return (str2.Substring(0, 2) + "," + str2.Substring(2, 2) + "," + str2.Substring(4, 3) + "." + str3);
                    }
                    return (str2.Substring(0, 2) + "," + str2.Substring(2, 2) + "," + str2.Substring(4, 3));

                case 8:
                    if (!(str3 == ""))
                    {
                        return (str2.Substring(0, 1) + "," + str2.Substring(1, 2) + "," + str2.Substring(3, 2) + "," + str2.Substring(5, 3) + "." + str3);
                    }
                    return (str2.Substring(0, 1) + "," + str2.Substring(1, 2) + "," + str2.Substring(3, 2) + "," + str2.Substring(5, 3));

                case 9:
                    if (!(str3 == ""))
                    {
                        return (str2.Substring(0, 2) + "," + str2.Substring(2, 2) + "," + str2.Substring(4, 2) + "," + str2.Substring(6, 3) + "." + str3);
                    }
                    return (str2.Substring(0, 2) + "," + str2.Substring(2, 2) + "," + str2.Substring(4, 2) + "," + str2.Substring(6, 3));
            }
            if (str3 == "")
            {
                return str2;
            }
            return (str2 + "." + str3);
        }

        public static string F_Crore(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            if (amt_paisa == "")
            {
                num = Convert.ToInt32(amt.Substring(0, 1));
                if (num > 1)
                {
                    str = Tens(num.ToString()) + " Crores";
                }
                else
                {
                    str = Tens(num.ToString()) + " Crore";
                }
                if (amt.Substring(1, 7) != "0000000")
                {
                    if (amt.Substring(1, 2) != "00")
                    {
                        if (amt.Substring(1, 1) != "0")
                        {
                            num2 = Convert.ToInt32(amt.Substring(1, 2));
                            if (amt.Substring(3, 5) == "00000")
                            {
                                str2 = " and " + Word_Spell_Tens(num2.ToString()) + " Lakhs";
                            }
                            else
                            {
                                str2 = " " + Word_Spell_Tens(num2.ToString()) + " Lakhs";
                            }
                        }
                        else
                        {
                            num2 = Convert.ToInt32(amt.Substring(2, 1));
                            if (amt.Substring(3, 5) == "00000")
                            {
                                str2 = " and " + Tens(num2.ToString());
                            }
                            else
                            {
                                str2 = " " + Tens(num2.ToString());
                            }
                            if (num2 > 1)
                            {
                                str2 = str2 + " Lakhs";
                            }
                            else
                            {
                                str2 = str2 + " Lakh";
                            }
                        }
                    }
                    if (amt.Substring(3, 2) != "00")
                    {
                        if (amt.Substring(3, 1) != "0")
                        {
                            num3 = Convert.ToInt32(amt.Substring(3, 2));
                            if (amt.Substring(5, 3) == "000")
                            {
                                str3 = " and " + Word_Spell_Tens(num3.ToString()) + " Thousands";
                            }
                            else
                            {
                                str3 = " " + Word_Spell_Tens(num3.ToString()) + " Thousands";
                            }
                        }
                        else
                        {
                            num3 = Convert.ToInt32(amt.Substring(4, 1));
                            if (amt.Substring(5, 3) == "000")
                            {
                                str3 = " and " + Tens(num3.ToString());
                            }
                            else
                            {
                                str3 = " " + Tens(num3.ToString());
                            }
                            if (num3 > 1)
                            {
                                str3 = str3 + " Thousands";
                            }
                            else
                            {
                                str3 = str3 + " Thousand";
                            }
                        }
                    }
                    if (amt.Substring(5, 3) != "000")
                    {
                        if (amt.Substring(5, 1) != "0")
                        {
                            num4 = Convert.ToInt32(amt.Substring(5, 1));
                            if (num4 > 1)
                            {
                                if (amt.Substring(6, 2) == "00")
                                {
                                    str4 = " and" + Tens(num4.ToString()) + " Hundreds";
                                }
                                else
                                {
                                    str4 = " " + Tens(num4.ToString()) + " Hundreds";
                                }
                            }
                            else if (amt.Substring(6, 2) == "00")
                            {
                                str4 = " and" + Tens(num4.ToString()) + " Hundred";
                            }
                            else
                            {
                                str4 = " " + Tens(num4.ToString()) + " Hundred";
                            }
                        }
                        if (amt.Substring(6, 2) != "00")
                        {
                            num5 = Convert.ToInt32(amt.Substring(6, 2));
                            if (Convert.ToInt32(amt.Substring(6, 1)) != 0)
                            {
                                str5 = " and " + Word_Spell_Tens(num5.ToString());
                            }
                            else
                            {
                                str5 = " and " + Tens(num5.ToString());
                            }
                        }
                    }
                }
            }
            else if (amt_paisa != "")
            {
                num = Convert.ToInt32(amt.Substring(0, 1));
                if (num > 1)
                {
                    str = Tens(num.ToString()) + " Crores";
                }
                else
                {
                    str = Tens(num.ToString()) + " Crore";
                }
                if (amt.Substring(1, 7) != "0000000")
                {
                    if (amt.Substring(1, 2) != "00")
                    {
                        if (amt.Substring(1, 1) != "0")
                        {
                            num2 = Convert.ToInt32(amt.Substring(1, 2));
                            str2 = " " + Word_Spell_Tens(num2.ToString()) + " Lakhs";
                        }
                        else
                        {
                            num2 = Convert.ToInt32(amt.Substring(2, 1));
                            if (num2 > 1)
                            {
                                str2 = " " + Tens(num2.ToString()) + " Lakhs";
                            }
                            else
                            {
                                str2 = " " + Tens(num2.ToString()) + " Lakh";
                            }
                        }
                    }
                    if (amt.Substring(3, 2) != "00")
                    {
                        if (amt.Substring(3, 1) != "0")
                        {
                            num3 = Convert.ToInt32(amt.Substring(3, 2));
                            str3 = " " + Word_Spell_Tens(num3.ToString()) + " Thousands";
                        }
                        else
                        {
                            num3 = Convert.ToInt32(amt.Substring(4, 1));
                            if (num3 > 1)
                            {
                                str3 = " " + Tens(num3.ToString()) + " Thousands";
                            }
                            else
                            {
                                str3 = " " + Tens(num3.ToString()) + " Thousand";
                            }
                        }
                    }
                    if (amt.Substring(5, 3) != "000")
                    {
                        if (amt.Substring(5, 1) != "0")
                        {
                            num4 = Convert.ToInt32(amt.Substring(5, 1));
                            if (num4 > 1)
                            {
                                str4 = " " + Tens(num4.ToString()) + " Hundreds";
                            }
                            else
                            {
                                str4 = " " + Tens(num4.ToString()) + " Hundred";
                            }
                        }
                        if (amt.Substring(6, 2) != "00")
                        {
                            num5 = Convert.ToInt32(amt.Substring(6, 2));
                            if (amt.Substring(6, 1) != "0")
                            {
                                str5 = " " + Word_Spell_Tens(num5.ToString());
                            }
                            else
                            {
                                str5 = " " + Tens(num5.ToString());
                            }
                        }
                    }
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str6 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str6 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + str3 + str4 + str5 + str6 + " Only");
            return (str + str2 + str3 + str4 + str5 + str6 + " Taka Only");
        }

        public static string F_Crores(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            if (amt_paisa == "")
            {
                str = Word_Spell_Tens(Convert.ToInt32(amt.Substring(0, 2)).ToString()) + " Crores";
                if (amt.Substring(2, 7) != "0000000")
                {
                    if (amt.Substring(2, 2) != "00")
                    {
                        if (amt.Substring(2, 1) != "0")
                        {
                            num2 = Convert.ToInt32(amt.Substring(2, 2));
                            if (amt.Substring(4, 5) == "00000")
                            {
                                str2 = " and " + Word_Spell_Tens(num2.ToString()) + " Lakhs";
                            }
                            else
                            {
                                str2 = " " + Word_Spell_Tens(num2.ToString()) + " Lakhs";
                            }
                        }
                        else
                        {
                            num2 = Convert.ToInt32(amt.Substring(3, 1));
                            if (amt.Substring(4, 5) == "00000")
                            {
                                str2 = " and " + Tens(num2.ToString());
                            }
                            else
                            {
                                str2 = " " + Tens(num2.ToString());
                            }
                            if (num2 > 1)
                            {
                                str2 = str2 + " Lakhs";
                            }
                            else
                            {
                                str2 = str2 + " Lakh";
                            }
                        }
                    }
                    if (amt.Substring(4, 2) != "00")
                    {
                        if (amt.Substring(4, 1) != "0")
                        {
                            num3 = Convert.ToInt32(amt.Substring(4, 2));
                            if (amt.Substring(6, 3) == "000")
                            {
                                str3 = " and " + Word_Spell_Tens(num3.ToString()) + " Thousands";
                            }
                            else
                            {
                                str3 = " " + Word_Spell_Tens(num3.ToString()) + " Thousands";
                            }
                        }
                        else
                        {
                            num3 = Convert.ToInt32(amt.Substring(5, 1));
                            if (amt.Substring(4, 5) == "000")
                            {
                                str3 = " and " + Tens(num3.ToString());
                            }
                            else
                            {
                                str3 = " " + Tens(num3.ToString());
                            }
                            if (num3 > 1)
                            {
                                str3 = str3 + " Thousands";
                            }
                            else
                            {
                                str3 = str3 + " Thousand";
                            }
                        }
                    }
                    if (amt.Substring(6, 3) != "000")
                    {
                        if (amt.Substring(6, 1) != "0")
                        {
                            num4 = Convert.ToInt32(amt.Substring(6, 1));
                            if (num4 > 1)
                            {
                                if (amt.Substring(7, 2) == "00")
                                {
                                    str4 = " and" + Tens(num4.ToString()) + " Hundreds";
                                }
                                else
                                {
                                    str4 = " " + Tens(num4.ToString()) + " Hundreds";
                                }
                            }
                            else if (amt.Substring(7, 2) == "00")
                            {
                                str4 = " and" + Tens(num4.ToString()) + " Hundred";
                            }
                            else
                            {
                                str4 = " " + Tens(num4.ToString()) + " Hundred";
                            }
                        }
                        if (amt.Substring(7, 2) != "00")
                        {
                            num5 = Convert.ToInt32(amt.Substring(7, 2));
                            if (Convert.ToInt32(amt.Substring(7, 1)) != 0)
                            {
                                str5 = " and " + Word_Spell_Tens(num5.ToString());
                            }
                            else
                            {
                                str5 = " and " + Tens(num5.ToString());
                            }
                        }
                    }
                }
            }
            else if (amt_paisa != "")
            {
                str = Word_Spell_Tens(Convert.ToInt32(amt.Substring(0, 2)).ToString()) + " Crores";
                if (amt.Substring(2, 7) != "0000000")
                {
                    if (amt.Substring(2, 2) != "00")
                    {
                        if (amt.Substring(2, 1) != "0")
                        {
                            num2 = Convert.ToInt32(amt.Substring(2, 2));
                            str2 = " " + Word_Spell_Tens(num2.ToString()) + " Lakhs";
                        }
                        else
                        {
                            num2 = Convert.ToInt32(amt.Substring(3, 1));
                            if (num2 > 1)
                            {
                                str2 = " " + Tens(num2.ToString()) + " Lakhs";
                            }
                            else
                            {
                                str2 = " " + Tens(num2.ToString()) + " Lakh";
                            }
                        }
                    }
                    if (amt.Substring(4, 2) != "00")
                    {
                        if (amt.Substring(4, 1) != "0")
                        {
                            num3 = Convert.ToInt32(amt.Substring(4, 2));
                            str3 = " " + Word_Spell_Tens(num3.ToString()) + " Thousands";
                        }
                        else
                        {
                            num3 = Convert.ToInt32(amt.Substring(5, 1));
                            if (num3 > 1)
                            {
                                str3 = " " + Tens(num3.ToString()) + " Thousands";
                            }
                            else
                            {
                                str3 = " " + Tens(num3.ToString()) + " Thousand";
                            }
                        }
                    }
                    if (amt.Substring(6, 3) != "000")
                    {
                        if (amt.Substring(6, 1) != "0")
                        {
                            num4 = Convert.ToInt32(amt.Substring(6, 1));
                            if (num4 > 1)
                            {
                                str4 = " " + Tens(num4.ToString()) + " Hundreds";
                            }
                            else
                            {
                                str4 = " " + Tens(num4.ToString()) + " Hundred";
                            }
                        }
                        if (amt.Substring(7, 2) != "00")
                        {
                            num5 = Convert.ToInt32(amt.Substring(7, 2));
                            if (amt.Substring(7, 1) != "0")
                            {
                                str5 = " " + Word_Spell_Tens(num5.ToString());
                            }
                            else
                            {
                                str5 = " " + Tens(num5.ToString());
                            }
                        }
                    }
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str6 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str6 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + str3 + str4 + str5 + str6 + " Only");
            return (str + str2 + str3 + str4 + str5 + str6 + " Taka Only");
        }

        public static string F_Hundred(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            int num = 0;
            int num2 = 0;
            if (amt_paisa == "")
            {
                if (amt.Substring(0, 3) != "000")
                {
                    if (amt.Substring(0, 1) != "0")
                    {
                        num = Convert.ToInt32(amt.Substring(0, 1));
                        if (num > 1)
                        {
                            str = Tens(num.ToString()) + " Hundreds";
                        }
                        else
                        {
                            str = Tens(num.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(1, 2) != "00")
                    {
                        num2 = Convert.ToInt32(amt.Substring(1, 2));
                        if (Convert.ToInt32(amt.Substring(1, 1)) != 0)
                        {
                            str2 = " and " + Word_Spell_Tens(num2.ToString());
                        }
                        else
                        {
                            str2 = " and " + Tens(num2.ToString());
                        }
                    }
                }
            }
            else if (amt_paisa != "")
            {
                if (amt.Substring(0, 3) != "000")
                {
                    if (amt.Substring(0, 1) != "0")
                    {
                        num = Convert.ToInt32(amt.Substring(0, 1));
                        if (num > 1)
                        {
                            str = Tens(num.ToString()) + " Hundreds";
                        }
                        else
                        {
                            str = Tens(num.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(1, 2) != "00")
                    {
                        num2 = Convert.ToInt32(amt.Substring(1, 2));
                        if (amt.Substring(1, 1) != "0")
                        {
                            str2 = " " + Word_Spell_Tens(num2.ToString());
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString());
                        }
                    }
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str3 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str3 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + str3 + " Only");
            return (str + str2 + str3 + " Taka Only");
        }

        public static string F_Lakh(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            if (amt_paisa == "")
            {
                if (amt.Substring(0, 1) != "0")
                {
                    num = Convert.ToInt32(amt.Substring(0, 1));
                    if (num > 1)
                    {
                        str = Tens(num.ToString()) + " Lakhs";
                    }
                    else
                    {
                        str = Tens(num.ToString()) + " Lakh";
                    }
                }
                if (amt.Substring(1, 2) != "00")
                {
                    if (amt.Substring(1, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(1, 2));
                        if (amt.Substring(3, 3) == "000")
                        {
                            str2 = " and " + Word_Spell_Tens(num2.ToString()) + " Thousands";
                        }
                        else
                        {
                            str2 = " " + Word_Spell_Tens(num2.ToString()) + " Thousands";
                        }
                    }
                    else
                    {
                        num2 = Convert.ToInt32(amt.Substring(2, 1));
                        if (amt.Substring(3, 3) == "000")
                        {
                            str2 = " and " + Tens(num2.ToString());
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString());
                        }
                        if (num2 > 1)
                        {
                            str2 = str2 + " Thousands";
                        }
                        else
                        {
                            str2 = str2 + " Thousand";
                        }
                    }
                }
                if (amt.Substring(3, 3) != "000")
                {
                    if (amt.Substring(3, 1) != "0")
                    {
                        num3 = Convert.ToInt32(amt.Substring(3, 1));
                        if (num3 > 1)
                        {
                            if (amt.Substring(4, 2) == "00")
                            {
                                str3 = " and" + Tens(num3.ToString()) + " Hundreds";
                            }
                            else
                            {
                                str3 = " " + Tens(num3.ToString()) + " Hundreds";
                            }
                        }
                        else if (amt.Substring(4, 2) == "00")
                        {
                            str3 = " and" + Tens(num3.ToString()) + " Hundred";
                        }
                        else
                        {
                            str3 = " " + Tens(num3.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(4, 2) != "00")
                    {
                        num4 = Convert.ToInt32(amt.Substring(4, 2));
                        if (Convert.ToInt32(amt.Substring(4, 1)) != 0)
                        {
                            str4 = " and " + Word_Spell_Tens(num4.ToString());
                        }
                        else
                        {
                            str4 = " and " + Tens(num4.ToString());
                        }
                    }
                }
            }
            else if (amt_paisa != "")
            {
                if (amt.Substring(0, 1) != "0")
                {
                    num = Convert.ToInt32(amt.Substring(0, 1));
                    if (num > 1)
                    {
                        str = Tens(num.ToString()) + " Lakhs";
                    }
                    else
                    {
                        str = Tens(num.ToString()) + " Lakh";
                    }
                }
                if (amt.Substring(1, 2) != "00")
                {
                    if (amt.Substring(1, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(1, 2));
                        str2 = " " + Word_Spell_Tens(num2.ToString()) + " Thousands";
                    }
                    else
                    {
                        num2 = Convert.ToInt32(amt.Substring(2, 1));
                        if (num2 > 1)
                        {
                            str2 = " " + Tens(num2.ToString()) + " Thousands";
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString()) + " Thousand";
                        }
                    }
                }
                if (amt.Substring(3, 3) != "000")
                {
                    if (amt.Substring(3, 1) != "0")
                    {
                        num3 = Convert.ToInt32(amt.Substring(3, 1));
                        if (num3 > 1)
                        {
                            str3 = " " + Tens(num3.ToString()) + " Hundreds";
                        }
                        else
                        {
                            str3 = " " + Tens(num3.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(4, 2) != "00")
                    {
                        num4 = Convert.ToInt32(amt.Substring(4, 2));
                        if (amt.Substring(4, 1) != "0")
                        {
                            str4 = " " + Word_Spell_Tens(num4.ToString());
                        }
                        else
                        {
                            str4 = " " + Tens(num4.ToString());
                        }
                    }
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str5 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str5 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + str3 + str4 + str5 + " Only");
            return (str + str2 + str3 + str4 + str5 + " Taka Only");
        }

        public static string F_Lakhs(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            if (amt_paisa == "")
            {
                if ((amt.Substring(0, 2) != "00") && (amt.Substring(0, 1) != "0"))
                {
                    str = Word_Spell_Tens(Convert.ToInt32(amt.Substring(0, 2)).ToString()) + " Lakhs";
                }
                if (amt.Substring(2, 2) != "00")
                {
                    if (amt.Substring(2, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(2, 2));
                        if (amt.Substring(4, 3) == "000")
                        {
                            str2 = " and " + Word_Spell_Tens(num2.ToString()) + " Thousands";
                        }
                        else
                        {
                            str2 = " " + Word_Spell_Tens(num2.ToString()) + " Thousands";
                        }
                    }
                    else
                    {
                        num2 = Convert.ToInt32(amt.Substring(3, 1));
                        if (amt.Substring(4, 3) == "000")
                        {
                            str2 = " and " + Tens(num2.ToString());
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString());
                        }
                        if (num2 > 1)
                        {
                            str2 = str2 + " Thousands";
                        }
                        else
                        {
                            str2 = str2 + " Thousand";
                        }
                    }
                }
                if (amt.Substring(4, 3) != "000")
                {
                    if (amt.Substring(4, 1) != "0")
                    {
                        num3 = Convert.ToInt32(amt.Substring(4, 1));
                        if (num3 > 1)
                        {
                            if (amt.Substring(5, 2) == "00")
                            {
                                str3 = " and" + Tens(num3.ToString()) + " Hundreds";
                            }
                            else
                            {
                                str3 = " " + Tens(num3.ToString()) + " Hundreds";
                            }
                        }
                        else if (amt.Substring(5, 2) == "00")
                        {
                            str3 = " and" + Tens(num3.ToString()) + " Hundred";
                        }
                        else
                        {
                            str3 = " " + Tens(num3.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(5, 2) != "00")
                    {
                        num4 = Convert.ToInt32(amt.Substring(5, 2));
                        if (Convert.ToInt32(amt.Substring(5, 1)) != 0)
                        {
                            str4 = " and " + Word_Spell_Tens(num4.ToString());
                        }
                        else
                        {
                            str4 = " and " + Tens(num4.ToString());
                        }
                    }
                }
            }
            else if (amt_paisa != "")
            {
                if ((amt.Substring(0, 2) != "00") && (amt.Substring(0, 1) != "0"))
                {
                    num = Convert.ToInt32(amt.Substring(0, 2));
                    str = " " + Word_Spell_Tens(num.ToString()) + " Lakhs";
                }
                if (amt.Substring(2, 2) != "00")
                {
                    if (amt.Substring(2, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(2, 2));
                        str2 = " " + Word_Spell_Tens(num2.ToString()) + " Thousands";
                    }
                    else
                    {
                        num2 = Convert.ToInt32(amt.Substring(3, 1));
                        if (num2 > 1)
                        {
                            str2 = " " + Tens(num2.ToString()) + " Thousands";
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString()) + " Thousand";
                        }
                    }
                }
                if (amt.Substring(4, 3) != "000")
                {
                    if (amt.Substring(4, 1) != "0")
                    {
                        num3 = Convert.ToInt32(amt.Substring(4, 1));
                        if (num3 > 1)
                        {
                            str3 = " " + Tens(num3.ToString()) + " Hundreds";
                        }
                        else
                        {
                            str3 = " " + Tens(num3.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(5, 2) != "00")
                    {
                        num4 = Convert.ToInt32(amt.Substring(5, 2));
                        if (amt.Substring(5, 1) != "0")
                        {
                            str4 = " " + Word_Spell_Tens(num4.ToString());
                        }
                        else
                        {
                            str4 = " " + Tens(num4.ToString());
                        }
                    }
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str5 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str5 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + str3 + str4 + str5 + " Only");
            return (str + str2 + str3 + str4 + str5 + " Taka Only");
        }

        public static string F_Number(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            int num = 0;
            if (amt_paisa == "")
            {
                if (amt.Substring(0, 2) != "00")
                {
                    num = Convert.ToInt32(amt.Substring(0, 2));
                    if (Convert.ToInt32(amt.Substring(0, 1)) != 0)
                    {
                        str = Word_Spell_Tens(num.ToString());
                    }
                    else
                    {
                        str = Tens(num.ToString());
                    }
                }
                else
                {
                    str = " Zero ";
                }
            }
            else if (amt_paisa != "")
            {
                if (amt.Substring(0, 2) != "00")
                {
                    num = Convert.ToInt32(amt.Substring(0, 2));
                    if (amt.Substring(0, 1) != "0")
                    {
                        str = Word_Spell_Tens(num.ToString());
                    }
                    else
                    {
                        str = Tens(num.ToString());
                    }
                }
                else
                {
                    str = " Zero ";
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str2 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str2 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + " Only");
            return (str + str2 + " Taka Only");
        }

        public static string F_Thousand(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (amt_paisa == "")
            {
                if (amt.Substring(0, 1) != "0")
                {
                    num = Convert.ToInt32(amt.Substring(0, 1));
                    if (num > 1)
                    {
                        str = Tens(num.ToString()) + " Thousands";
                    }
                    else
                    {
                        str = Tens(num.ToString()) + " Thousand";
                    }
                }
                if (amt.Substring(1, 3) != "000")
                {
                    if (amt.Substring(1, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(1, 1));
                        if (num2 > 1)
                        {
                            if (amt.Substring(2, 2) == "00")
                            {
                                str2 = " and" + Tens(num2.ToString()) + " Hundreds";
                            }
                            else
                            {
                                str2 = " " + Tens(num2.ToString()) + " Hundreds";
                            }
                        }
                        else if (amt.Substring(2, 2) == "00")
                        {
                            str2 = " and" + Tens(num2.ToString()) + " Hundred";
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(2, 2) != "00")
                    {
                        num3 = Convert.ToInt32(amt.Substring(2, 2));
                        if (Convert.ToInt32(amt.Substring(2, 1)) != 0)
                        {
                            str3 = " and " + Word_Spell_Tens(num3.ToString());
                        }
                        else
                        {
                            str3 = " and " + Tens(num3.ToString());
                        }
                    }
                }
            }
            else if (amt_paisa != "")
            {
                if (amt.Substring(0, 1) != "0")
                {
                    num = Convert.ToInt32(amt.Substring(0, 1));
                    if (num > 1)
                    {
                        str = Tens(num.ToString()) + " Thousands";
                    }
                    else
                    {
                        str = Tens(num.ToString()) + " Thousand";
                    }
                }
                if (amt.Substring(1, 3) != "000")
                {
                    if (amt.Substring(1, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(1, 1));
                        if (num2 > 1)
                        {
                            str2 = " " + Tens(num2.ToString()) + " Hundreds";
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(2, 2) != "00")
                    {
                        num3 = Convert.ToInt32(amt.Substring(2, 2));
                        if (amt.Substring(2, 1) != "0")
                        {
                            str3 = " " + Word_Spell_Tens(num3.ToString());
                        }
                        else
                        {
                            str3 = " " + Tens(num3.ToString());
                        }
                    }
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str4 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str4 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + str3 + str4 + " Only");
            return (str + str2 + str3 + str4 + " Taka  Only");
        }

        public static string F_Thousands(string amt, string amt_paisa)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (amt_paisa == "")
            {
                if (amt.Substring(0, 1) != "0")
                {
                    str = Word_Spell_Tens(Convert.ToInt32(amt.Substring(0, 2)).ToString()) + " Thousands";
                }
                if (amt.Substring(2, 3) != "000")
                {
                    if (amt.Substring(2, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(2, 1));
                        if (num2 > 1)
                        {
                            if (amt.Substring(3, 2) == "00")
                            {
                                str2 = " and" + Tens(num2.ToString()) + " Hundreds";
                            }
                            else
                            {
                                str2 = " " + Tens(num2.ToString()) + " Hundreds";
                            }
                        }
                        else if (amt.Substring(3, 2) == "00")
                        {
                            str2 = " and" + Tens(num2.ToString()) + " Hundred";
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(3, 2) != "00")
                    {
                        num3 = Convert.ToInt32(amt.Substring(3, 2));
                        if (Convert.ToInt32(amt.Substring(3, 1)) != 0)
                        {
                            str3 = " and " + Word_Spell_Tens(num3.ToString());
                        }
                        else
                        {
                            str3 = " and " + Tens(num3.ToString());
                        }
                    }
                }
            }
            else if (amt_paisa != "")
            {
                if (amt.Substring(0, 1) != "0")
                {
                    num = Convert.ToInt32(amt.Substring(0, 2));
                    if (num > 1)
                    {
                        str = Word_Spell_Tens(num.ToString()) + " Thousands";
                    }
                    else
                    {
                        str = Word_Spell_Tens(num.ToString()) + " Thousand";
                    }
                }
                if (amt.Substring(2, 3) != "000")
                {
                    if (amt.Substring(2, 1) != "0")
                    {
                        num2 = Convert.ToInt32(amt.Substring(2, 1));
                        if (num2 > 1)
                        {
                            str2 = " " + Tens(num2.ToString()) + " Hundreds";
                        }
                        else
                        {
                            str2 = " " + Tens(num2.ToString()) + " Hundred";
                        }
                    }
                    if (amt.Substring(3, 2) != "00")
                    {
                        num3 = Convert.ToInt32(amt.Substring(3, 2));
                        if (amt.Substring(3, 1) != "0")
                        {
                            str3 = " " + Word_Spell_Tens(num3.ToString());
                        }
                        else
                        {
                            str3 = " " + Tens(num3.ToString());
                        }
                    }
                }
                if (amt_paisa.Substring(0, 2) != "00")
                {
                    if (amt_paisa.Substring(0, 1) != "0")
                    {
                        str4 = " and " + Word_Spell_Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                    else
                    {
                        str4 = " " + Tens(amt_paisa.Substring(0, 2)) + " Paisa";
                    }
                }
            }
            //return ("Taka " + str + str2 + str3 + str4 + " Only");
            return (str + str2 + str3 + str4 + " Taka Only");
        }

        public static string InWrods(decimal amount)
        {
            string amt = "";
            string str2 = "";
            amt = amount.ToString();
            int index = amount.ToString().IndexOf(".", 0);
            str2 = amount.ToString().Substring(index + 1);
            if (amt == str2)
            {
                str2 = "";
            }
            else
            {
                amt = amount.ToString().Substring(0, amount.ToString().IndexOf(".", 0)).Replace(",", "").ToString();
            }
            switch (amt.Length)
            {
                case 1:
                    return F_Number("0" + amt, str2);

                case 2:
                    return F_Number(amt, str2);

                case 3:
                    return F_Hundred(amt, str2);

                case 4:
                    return F_Thousand(amt, str2);

                case 5:
                    return F_Thousands(amt, str2);

                case 6:
                    return F_Lakh(amt, str2);

                case 7:
                    return F_Lakhs(amt, str2);

                case 8:
                    return F_Crore(amt, str2);

                case 9:
                    return F_Crores(amt, str2);
            }
            return "";
        }

        public static string Tens(string s_amt)
        {
            switch (s_amt)
            {
                case "0":
                    return "";

                case "1":
                    return "One";

                case "2":
                    return "Two";

                case "3":
                    return "Three";

                case "4":
                    return "Four";

                case "5":
                    return "Five";

                case "6":
                    return "Six";

                case "7":
                    return "Seven";

                case "8":
                    return "Eight";

                case "9":
                    return "Nine";

                case "10":
                    return "Ten";

                case "11":
                    return "Eleven";

                case "12":
                    return "Twelve";

                case "13":
                    return "Thirteen";

                case "14":
                    return "Forteen";

                case "15":
                    return "Fifteen";

                case "16":
                    return "Sixteen";

                case "17":
                    return "Seventeen";

                case "18":
                    return "Eighteen";

                case "19":
                    return "Nineteen";

                case "20":
                    return "Twenty";

                case "30":
                    return "Thirty";

                case "40":
                    return "Forty";

                case "50":
                    return "Fifty";

                case "60":
                    return "Sixty";

                case "70":
                    return "Seventy";

                case "80":
                    return "Eighty";

                case "90":
                    return "Ninety";
            }
            return "Nothing";
        }

        public static string Word_Spell_Tens(string amt)
        {
            string str = null;
            string str2 = null;
            int num = 0;
            num = Convert.ToInt32(amt.Substring(0, 2));
            if (num > 20)
            {
                str = amt.Substring(0, 1) + "0";
                str2 = amt.Substring(1, 1);
                return (Tens(str) + " " + Tens(str2));
            }
            return Tens(num.ToString());
        }
    }
}

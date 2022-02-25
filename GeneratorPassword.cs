using System;
using System.Collections.Generic;

namespace L1
{
    class GeneratorPassword
    {
        private int lengthPassword = 6;
        private char[]? arrSymbols;
        internal int countPasswords = 5;
        public int LengthPassword
        {
            get
            {
                return lengthPassword;
            }         
        }
        public GeneratorPassword()
        {

        }
        public GeneratorPassword(char[] arrSymbols, int lengthPassword = 6)
        {

            if (lengthPassword < 0 || lengthPassword > 20)
            {
                throw new ArgumentException("Длинна пароля не может быть меньше 0 или больше 20");
            }

            if (arrSymbols == null || arrSymbols.Length == 0)
            {
                throw new ArgumentException("Список не может быть пустым");
            }

            this.lengthPassword = lengthPassword;
            this.arrSymbols = arrSymbols;

        }

        public string[] GetPasswords()
        {
            if (arrSymbols is not null)
            {
                Random rnd = new Random();
                string[] newStr = new string[countPasswords];

                for (int j = 0; j < countPasswords; j++)
                {
                    for (int i = 0; i < this.lengthPassword; i++)
                    {
                        var numberIndex = rnd.Next(0, arrSymbols.Length - 1);
                        newStr[j] += ((char)arrSymbols[numberIndex]).ToString();
                    }
                }
                return newStr;
            }
            return new string[0];
        }

    }
}

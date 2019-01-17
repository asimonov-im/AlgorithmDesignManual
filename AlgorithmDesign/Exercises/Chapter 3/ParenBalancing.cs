namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;

    public static class ParenBalancing
    {
        public static (bool isBalanced, int errorIndex) CheckBalance(string parenStr)
        {
            int openParenCount = 0;
            int firstOpenParenIndex = -1;
            for (int i = 0; i < parenStr.Length; ++i)
            {
                char c = parenStr[i];
                if (c == '(')
                {
                    if (openParenCount == 0)
                    {
                        firstOpenParenIndex = i;
                    }

                    ++openParenCount;
                }
                else if (c == ')')
                {
                    if (openParenCount > 0)
                    {
                        --openParenCount;
                    }
                    else
                    {
                        return (false, i);
                    }
                }
                else
                {
                    throw new ArgumentException("The string must only contain the '(' and ')' characters.");
                }
            }

            if (openParenCount == 0)
            {
                return (true, -1);
            }
            else
            {
                return (false, firstOpenParenIndex);
            }
            
        }
    }
}

<Query Kind="Program" />

void Main()
{
	RomanToInt("I").Dump(); // 1
	RomanToInt("III").Dump(); // 3
	RomanToInt("IV").Dump(); // 4
	RomanToInt("LXXXIX").Dump(); // 89
	
	RomanToInt("XCIX").Dump(); // 99
	RomanToInt("MCMXXXIV").Dump(); // 1934
}

// You can define other methods, fields, classes and namespaces here



int RomanToInt(string s) 
{
    Func<char, int> valueFunc = c => 
	{
		if (c == 'I') return 1;
		if (c == 'V') return 5;
		if (c == 'X') return 10;
		if (c == 'L') return 50;
		if (c == 'C') return 100;
		if (c == 'D') return 500;
		if (c == 'M') return 1000;
		return 0;
	};
	
	int result = 0;
	int length = s.Length;
	for (int i = 0; i < length; i++)
	{
		int v1 = valueFunc(s[i]);
		if (i + 1 < length)
		{
			int v2 = valueFunc(s[i+1]);
			if (v1 >= v2)
			{	
				result += v1;
			}
			else
			{
				result = result + v2 - v1;
				i++;
			}
		}
		else
		{
			result += v1;
		}
	}
	
	return result;
}